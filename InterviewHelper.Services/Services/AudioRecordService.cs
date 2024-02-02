using NAudio.CoreAudioApi;
using NAudio.Wave;

using System.Runtime.InteropServices;

namespace InterviewHelper.Services.Services
{
    public class AudioRecordService : IAudioRecordService
    {
        private WasapiLoopbackCapture capture;
        private WaveFileWriter writer;
        private readonly IOpenAIQuestionService _openAIQuestionService;
        private bool isRecording;

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        public AudioRecordService(IOpenAIQuestionService openAIQuestionService)
        {
            _openAIQuestionService = openAIQuestionService;

        }

        public async Task StartRecordingSpeakerAsync(string path)
        {
            // Start recording only if it is not already recording
            if (!isRecording)
            {
                // Get the default loopback device
                var device = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

                // Create a capture object
                capture = new WasapiLoopbackCapture(device);

                // Set the format to 16 bit PCM
                capture.WaveFormat = new WaveFormat(44100, 16, 2);

                // Create a writer to save the captured data
                writer = new WaveFileWriter(path, capture.WaveFormat);

                // Register the event handler
                capture.DataAvailable += Capture_DataAvailable;
                // Start capturing
                capture.StartRecording();

                // Change the recording state
                isRecording = true;
                capture.RecordingStopped += Capture_RecordingStopped;
            }
        }

        public async Task<string> StopRecordingSpeakerAsync(string path)
        {  // Stop recording only if it is already recording
            if (isRecording)
            {
                // Stop capturing
                capture.StopRecording();

                // Dispose the capture object
                capture.Dispose();
                capture = null;

                // Dispose the writer object
                writer.Dispose();
                writer = null;

                // Change the recording state
                isRecording = false;
                var answer = await _openAIQuestionService.GetTextFromVoice(path);
                return answer ?? "No Data";
            }
            return "No data";
        }

        public void StartRecordMicrofhoneAsync()
        {
            record("open new Type waveaudio Alias recsound", "", 0, 0);
            record("record recsound", "", 0, 0);
        }

        public async Task<string> StopRecordMicrofhoneAsync(string path)
        {
            record($"save recsound {path}", "", 0, 0);
            record("close recsound", "", 0, 0);
            var responce = await _openAIQuestionService.GetTextFromVoice(path);
            return responce ?? "No data";
        }

        private void Capture_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Write the captured data to the file
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void Capture_RecordingStopped(object sender, StoppedEventArgs e)
        {
            // Do nothing
        }


    }
}

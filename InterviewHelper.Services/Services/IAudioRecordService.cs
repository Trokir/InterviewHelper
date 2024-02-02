
namespace InterviewHelper.Services.Services
{
    public interface IAudioRecordService
    {
        Task StartRecordingSpeakerAsync(string path);
        Task<string> StopRecordingSpeakerAsync(string path);
        void StartRecordMicrofhoneAsync();
        Task<string> StopRecordMicrofhoneAsync(string path);
    }
}
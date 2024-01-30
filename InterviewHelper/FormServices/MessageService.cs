
namespace InterviewHelper.FormServices
{
    public class MessageService : IMessageService
    {
        public DialogResult ShowCustomMessage(string message, string caption, MessageBoxButtons boxButtons, MessageBoxIcon boxIcon)
        {
            return MessageBox.Show(message, caption, boxButtons, boxIcon);
        }
        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(text: message, caption: caption);
        }
        public void ShowError(string message, string caption)
        {
            MessageBox.Show(text: message, caption: caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInfo(string message, string caption)
        {
            MessageBox.Show(text: message, caption: caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWarning(string message, string caption)
        {
            MessageBox.Show(text: message, caption: caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public IEnumerable<bool> ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}

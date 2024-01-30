namespace InterviewHelper.FormServices
{
    public interface IMessageService
    {
        void ShowMessage(string message, string caption);
        void ShowInfo(string message, string caption);
        void ShowWarning(string message, string caption);
        void ShowError(string message, string caption);
        DialogResult ShowCustomMessage(string message, string caption, MessageBoxButtons boxButtons, MessageBoxIcon boxIcon);
    }
}

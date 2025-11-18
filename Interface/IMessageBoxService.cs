namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface IMessageBoxService
    {
        void ShowInfo(string message, string title);
        void ShowError(string message, string title);
        bool ShowYesNo(string message, string title);
        bool? ShowYesNoCancel(string message, string title);
    }
}

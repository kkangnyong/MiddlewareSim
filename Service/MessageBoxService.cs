using SimReeferMiddlewareSystemWPF.Interface;
using System.Windows;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInfo(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public bool ShowYesNo(string message, string title)
        {
            return MessageBoxResult.Yes == MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public bool? ShowYesNoCancel(string message, string title)
        {
            return MessageBoxResult.Yes == MessageBox.Show(message, title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }
    }
}

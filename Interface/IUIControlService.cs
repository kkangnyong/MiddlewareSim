using System.Windows.Controls;

namespace SimReeferMiddlewareSystemWPF.Interface
{
    public interface IUIControlService
    {
        UserControl GetLoadingControl();
        UserControl GetCompleteControl();
    }
}

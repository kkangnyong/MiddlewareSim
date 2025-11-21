using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.UIControl;
using System.Windows.Controls;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public class UIControlService : IUIControlService
    {
        public UserControl GetLoadingControl() 
        {
            return new LoadingControl();
        }
        public UserControl GetCompleteControl()
        {
            return new CompleteControl();
        }
    }
}

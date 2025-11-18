using SimReeferMiddlewareSystemWPF.Inteface;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class DeviceInfoViewModel : ViewModelBase
    {
        private readonly IMessageBoxService _messageService;
        private readonly IModelData _modelDataService;
        private readonly IDeviceInfo _modelInfo;

        public DeviceInfoViewModel() { }

        public DeviceInfoViewModel(IMessageBoxService messageService, IModelData modelDataService, IDeviceInfo modelInfo) 
        {
            _messageService = messageService;
            _modelDataService = modelDataService;
            _modelInfo = modelInfo;

            messageService.ShowInfo(_modelInfo.DeviceNumber.ToString(), "test");
        }
    }
}

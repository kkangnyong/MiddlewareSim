using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class ProtocolViewModel : ViewModelBase
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IModelData _modelDataService;
        private readonly DeviceInfoStore _deviceInfoStore;
        private DeviceInfoModel CurrentDeviceInfoModel => _deviceInfoStore._currentDeviceInfo;
        public ICommand ToDeviceInfoCommand { get; set; }

        public INotifyPropertyChanged? CurrentDeviceInfoViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModel)); }
        }

        public INotifyPropertyChanged? CurrentDeviceBodyViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModel)); }
        }

        private void ToDeviceInfo(object _)
        {
            _modelDataService.SetDeviceInfoValues(new List<byte[]>
            {
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Code.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.DeviceNumber.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Major.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Minor.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Revision.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.DbgIdCode.ToString().Trim(), 4),
            });
        }

        public ProtocolViewModel() { }

        public ProtocolViewModel(IMessageBoxService messageBoxService, IModelData modelData, DeviceInfoStore deviceInfoStore)
        {
            _deviceInfoStore = deviceInfoStore;
            _messageBoxService = messageBoxService;
            _modelDataService = modelData;
            ToDeviceInfoCommand = new RelayCommand<object>(ToDeviceInfo);
        }
    }
}

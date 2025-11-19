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
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.PwrCSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.RccCSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.FlashSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.FlashOBR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.LwdgSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CurStandbyCount.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.LastGeofenceIndex.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.UsimIMSI.ToString().Trim(), 20, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Rssi.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.MCCMNC.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Lac.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CellID.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.WireType.ToString().Trim(), 20, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.ActiveBand.ToString().Trim(), 30, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CellOperator.ToString().Trim(), 30, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Ccpr.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CommPeriod.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.GpsTimeout.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.GpsStableTime.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.WireConnTimeout.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.RetryCount.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.RcCount.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.TotalStandbyCount.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.AccelShockUpper.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.SetTempLower.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.SetTempUpper.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.HumidLower.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.HumidUpper.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.StateChangedAlarm.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CutOffVoltage.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Voltage.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.IsCharging ? "1" : "0", 1),
            });
        }

        public ProtocolViewModel() { }

        public ProtocolViewModel(IMessageBoxService messageBoxService, IModelData modelData, DeviceInfoStore deviceInfoStore)
        {
            _deviceInfoStore = deviceInfoStore;
            _messageBoxService = messageBoxService;
            _modelDataService = modelData;
            ToDeviceInfoCommand = new RelayCommand<object>(ToDeviceInfo);
            _modelDataService._dataValuesList = new List<byte[]>();
        }
    }
}

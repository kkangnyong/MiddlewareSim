using SimReeferMiddlewareSystemWPF.Model;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class SetupInfoStore
    {
        public SetupInfoModel? _currentSetupInfo;
        //public DeviceInfoViewModel? CurrentDeviceInfo 
        //{ 
        //    get => _currentDeviceInfo;
        //    set 
        //    {
        //        _currentDeviceInfo = value;
        //        CurrentDeviceInfoChanged?.Invoke(_currentDeviceInfo!);
        //        _currentDeviceInfo = null;
        //    }
        //}

        //public Action<DeviceInfoViewModel>? CurrentDeviceInfoChanged { get; set; }
    }
}

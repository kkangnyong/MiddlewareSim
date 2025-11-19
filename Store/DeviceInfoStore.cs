using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.ViewModel;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class DeviceInfoStore
    {
        public DeviceInfoModel? _currentDeviceInfo;
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

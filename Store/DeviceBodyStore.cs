using SimReeferMiddlewareSystemWPF.Model;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class DeviceBodyStore
    {
        public DeviceBodyModel? _currentDeviceBody;
        public Action<DeviceBodyModel>? CurrentDeviceBodyChanged { get; set; }
    }
}

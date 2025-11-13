using SimReeferMiddlewareSystemWPF.Store;
using System.Windows.Controls;

namespace SimReeferMiddlewareSystemWPF.Inteface
{
    public interface IParentUserCtrl
    {
        IDeviceInfo DeviceInfo { get; }
        ISetupInfo SetupInfo { get; }
        IDeviceBody DeviceBody { get; }
        ISensorBody SensorBody { get; }
        IReeferBody ReeferBody { get; }
        Button StartDataCtrl { get; }
        Button StartCommandCtrl { get; }

        void SetEnable(bool isEnable);
        void SetEnableStartDataControl(bool isEnable);
        void SetEnableStartCommandControl(bool isEnable);
        void SetEnableAllControl(bool isEnable);
        void SetEnableDeviceInfoControl(bool isEnable);
        void SetEnableSetupInfoControl(bool isEnable);
        void SetEnableSensorBodyControl(bool isEnable);
        void SetEnableDeviceBodyControl(bool isEnable);
        void SetEnableReeferBodyControl(bool isEnable);

    }
}

using System.ComponentModel;

namespace SimReeferMiddlewareSystemWPF.Service
{
    public enum CodeType
    {
        [Description("None")]
        None = 0,
        [Description("Common")]
        CommonData = 1,
        [Description("Last")]
        LastData = 17
    }

    public enum DataType
    {
        [Description("Device")]
        Device = 0,
        [Description("Reefer")]
        Reefer = 1,
        [Description("Sensor")]
        Sensor = 2
    }
}

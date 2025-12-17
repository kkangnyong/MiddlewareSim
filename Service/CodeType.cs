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

    public enum GPSEnableType
    {
        [Description("None")]
        None = 0,
        [Description("A")]
        A = 1,
        [Description("V")]
        V = 2
    }

    public enum NSType
    {
        [Description("None")]
        None = 0,
        [Description("N")]
        North = 1,
        [Description("S")]
        South = 2
    }

    public enum EWType
    {
        [Description("None")]
        None = 0,
        [Description("E")]
        East = 1,
        [Description("W")]
        West = 2
    }
}

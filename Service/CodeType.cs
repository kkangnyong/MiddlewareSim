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
}

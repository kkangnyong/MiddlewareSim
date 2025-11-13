namespace SimReeferMiddlewareSystemWPF.Model
{
    public class DeviceBodyModel : ModelBase
    {
        public int Code { get; set; }
        public int Index { get; set; }
        public int DeviceNumber { get; set; }
        public ushort Year { get; set; }
        public ushort Month { get; set; }
        public ushort Day { get; set; }
        public ushort Hour { get; set; }
        public ushort Min { get; set; }
        public ushort Second { get; set; }
        public bool GPSEnable { get; set; }
        public int LatDegree { get; set; }
        public int LatDegreePoint1 { get; set; }
        public int LatDegreePoint2 { get; set; }
        public int LatDegreePoint3 { get; set; }
        public char NS { get; set; }
        public int LongDegree { get; set; }
        public int LongDegreePoint1 { get; set; }
        public int LongDegreePoint2 { get; set; }
        public int LongDegreePoint3 { get; set; }
        public char EW { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public bool IsCharging { get; set; }
        public float Battery { get; set; }
        public float Temp { get; set; }
        public int AcclX { get; set; }
        public int AcclY { get; set; }
        public int AcclZ { get; set; }
        public string Alarm { get; set; }
        public int GeofenceInOutIndex { get; set; }
        public char GeofenceInOutState { get; set; }
        public short CommCode { get; set; }
        public short Rsrp { get; set; }
        public short Rscp { get; set; }
        public short Rssi { get; set; }
        public short MobileErrorCode { get; set; }
    }
}

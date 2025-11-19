namespace SimReeferMiddlewareSystemWPF.Model
{
    public class DeviceBodyModel
    {
        public char Code { get; set; }
        public ushort Index { get; set; } = 1;
        public int DeviceNumber { get; set; } = 6002032;
        public byte Year { get; set; } = 25;
        public byte Month { get; set; } = 1;
        public byte Day { get; set; } = 2;
        public byte Hour { get; set; } = 0;
        public byte Min { get; set; } = 48;
        public byte Second { get; set; } = 49;
        public char GPSEnable { get; set; } = 'A';
        public byte LatDegree { get; set; } = 35;
        public byte LatDegreePoint1 { get; set; } = 10;
        public byte LatDegreePoint2 { get; set; } = 30;
        public byte LatDegreePoint3 { get; set; } = 97;
        public char NS { get; set; } = 'N';
        public byte LongDegree { get; set; } = 129;
        public byte LongDegreePoint1 { get; set; } = 8;
        public byte LongDegreePoint2 { get; set; } = 0;
        public byte LongDegreePoint3 { get; set; } = 82;
        public char EW { get; set; } = 'E';
        public string Speed { get; set; } = "32.96";
        public string MaxSpeed { get; set; } = "34.26";
        public bool IsCharging { get; set; } = true;
        public string Battery { get; set; } = "4.19";
        public string Temp { get; set; } = "37.0";
        public string AcclX { get; set; } = "35.0";
        public string AcclY { get; set; } = "35.0";
        public string AcclZ { get; set; } = "35.0";
        public int Alarm { get; set; } = 0;
        public short GeofenceInOutIndex { get; set; } = -1;
        public byte GeofenceInOutState { get; set; } = 0;
        public char CommCode { get; set; } = '2';
        public short Rsrp { get; set; } = -55;
        public short Rscp { get; set; } = 0;
        public short Rssi { get; set; } = 0;
        public ushort MobileErrorCode { get; set; } = 1001;
    }
}

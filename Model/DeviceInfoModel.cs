namespace SimReeferMiddlewareSystemWPF.Model
{
    public class DeviceInfoModel
    {
        public char Code { get; set; } = default!;
        public int DeviceNumber { get; set; } = default!;
        public byte Major { get; set; } = default!;
        public byte Minor { get; set; } = default!;
        public byte Revision { get; set; } = default!;
        public int DbgIdCode { get; set; } = default!;
        public int PwrCSR { get; set; } = default!;
        public int RccCSR { get; set; } = default!;
        public int FlashSR { get; set; } = default!;
        public int FlashOBR { get; set; } = default!;
        public int LwdgSR { get; set; } = default!;
        public short CurStandbyCount { get; set; } = default!;
        public int LastGeofenceIndex { get; set; } = default!;
        public string UsimIMSI { get; set; } = default!;
        public short Rssi { get; set; } = default!;
        public string Iccid { get; set; } = default!;
        public int MCCMNC { get; set; } = default!;
        public short Lac { get; set; } = default!;
        public int CellID { get; set; } = default!;
        public string WireType { get; set; } = default!;
        public string ActiveBand { get; set; } = default!;
        public string CellOperator { get; set; } = default!;
        public byte Ccpr { get; set; } = default!;
        public ushort CommPeriod { get; set; } = default!;
        public byte GpsTimeout { get; set; } = default!;
        public byte GpsStableTime { get; set; } = default!;
        public byte WireConnTimeout { get; set; } = default!;
        public byte RetryCount { get; set; } = default!;
        public byte RcCount { get; set; } = default!;
        public ushort TotalStandbyCount { get; set; } = default!;
        public byte AccelShockUpper { get; set; } = default!;
        public ushort SetTempLower { get; set; } = default!;
        public ushort SetTempUpper { get; set; } = default!;
        public ushort HumidLower { get; set; } = default!;
        public ushort HumidUpper { get; set; } = default!;
        public ushort StateChangedAlarm { get; set; } = default!;
        public string CutOffVoltage { get; set; } = default!;
        public string Voltage { get; set; } = default!;
        public bool IsCharging { get; set; } = default!;
    }
}

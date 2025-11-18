namespace SimReeferMiddlewareSystemWPF.Inteface
{
    public interface IDeviceInfo
    {
        public char Code { get; set; }
        public int DeviceNumber { get; set; }
        public byte Major { get; set; }
        public byte Minor { get; set; }
        public byte Revision { get; set; }
        public int DbgIdCode { get; set; }
        public int PwrCSR { get; set; }
        public int RccCSR { get; set; }
        public int FlashSR { get; set; }
        public int FlashOBR { get; set; }
        public int LwdgSR { get; set; }
        public short CurStandbyCount { get; set; }
        public int LastGeofenceIndex { get; set; }
        public string UsimIMSI { get; set; }
        public short Rssi { get; set; }
        public string Iccid { get; set; }
        public int MCCMNC { get; set; }
        public short Lac { get; set; }
        public int CellID { get; set; }
        public string WireType { get; set; }
        public string ActiveBand { get; set; }
        public string CellOperator { get; set; }
        public byte Ccpr { get; set; }
        public ushort CommPeriod { get; set; }
        public byte GpsTimeout { get; set; }
        public byte GpsStableTime { get; set; }
        public byte WireConnTimeout { get; set; }
        public byte RetryCount { get; set; }
        public byte RcCount { get; set; }
        public ushort TotalStandbyCount { get; set; }
        public byte AccelShockUpper { get; set; }
        public ushort SetTempLower { get; set; }
        public ushort SetTempUpper { get; set; }
        public ushort HumidLower { get; set; }
        public ushort HumidUpper { get; set; }
        public ushort StateChangedAlarm { get; set; }
        public string CutOffVoltage { get; set; }
        public string Voltage { get; set; }
        public bool IsCharging { get; set; }
    }
}

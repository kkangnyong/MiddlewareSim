namespace SimReeferMiddlewareSystemWPF.Model
{
    public class DeviceBodyModel
    {
        private int _code = 0;
        private ushort _index = 1;
        private int _deviceNumber = 6002032;
        private byte _year = 25;
        private byte _month = 11;
        private byte _day = 19;
        private byte _hour = 8;
        private byte _min = 48;
        private byte _second = 49;
        private char _gpsEnable = 'A';
        private byte _latDegree = 35;
        private byte _latDegreePoint1 = 10;
        private byte _latDegreePoint2 = 30;
        private byte _latDegreePoint3 = 97;
        private char _ns = 'N';
        private byte _longDegree = 129;
        private byte _longDegreePoint1 = 8;
        private byte _longDegreePoint2 = 0;
        private byte _longDegreePoint3 = 82;
        private char _ew = 'E';
        private string _speed = "32.96";
        private string _maxSpeed = "34.26";
        private bool _isCharging = true;
        private string _battery = "4.19";
        private string _temp = "37.0";
        private string _acclX = "35.0";
        private string _acclY = "35.0";
        private string _acclZ = "35.0";
        private int _alarm = 0;
        private short _geofenceInOutIndex = -1;
        private byte _geofenceInOutState = 0;
        private char _commCode = '2';
        private short _rsrp = -55;
        private short _rscp = 0;
        private short _rssi = 0;
        private ushort _mobileErrorCode = 1001;

        public int Code
        {
            get { return _code; }
            set
            {
                if (_code != null)
                {
                    _code = value;
                }
            }
        }
        public ushort Index
        {
            get { return _index; }
            set
            {
                if (_index != null)
                {
                    _index = value;
                }
            }
        }
        public int DeviceNumber
        {
            get { return _deviceNumber; }
            set
            {
                if (_deviceNumber != null)
                {
                    _deviceNumber = value;
                }
            }
        }
        public byte Year
        {
            get { return _year; }
            set
            {
                if (_year != null)
                {
                    _year = value;
                }
            }
        }
        public byte Month
        {
            get { return _month; }
            set
            {
                if (_month != null)
                {
                    _month = value;
                }
            }
        }
        public byte Day
        {
            get { return _day; }
            set
            {
                if (_day != null)
                {
                    _day = value;
                }
            }
        }
        public byte Hour
        {
            get { return _hour; }
            set
            {
                if (_hour != null)
                {
                    _hour = value;
                }
            }
        }
        public byte Min
        {
            get { return _min; }
            set
            {
                if (_min != null)
                {
                    _min = value;
                }
            }
        }
        public byte Second
        {
            get { return _second; }
            set
            {
                if (_second != null)
                {
                    _second = value;
                }
            }
        }
        public char GPSEnable
        {
            get { return _gpsEnable; }
            set
            {
                if (_gpsEnable != null)
                {
                    _gpsEnable = value;
                }
            }
        }
        public byte LatDegree
        {
            get { return _latDegree; }
            set
            {
                if (_latDegree != null)
                {
                    _latDegree = value;
                }
            }
        }
        public byte LatDegreePoint1
        {
            get { return _latDegreePoint1; }
            set
            {
                if (_latDegreePoint1 != null)
                {
                    _latDegreePoint1 = value;
                }
            }
        }
        public byte LatDegreePoint2
        {
            get { return _latDegreePoint2; }
            set
            {
                if (_latDegreePoint2 != null)
                {
                    _latDegreePoint2 = value;
                }
            }
        }
        public byte LatDegreePoint3
        {
            get { return _latDegreePoint3; }
            set
            {
                if (_latDegreePoint3 != null)
                {
                    _latDegreePoint3 = value;
                }
            }
        }
        public char NS
        {
            get { return _ns; }
            set
            {
                if (_ns != null)
                {
                    _ns = value;
                }
            }
        }
        public byte LongDegree
        {
            get { return _longDegree; }
            set
            {
                if (_longDegree != null)
                {
                    _longDegree = value;
                }
            }
        }
        public byte LongDegreePoint1
        {
            get { return _longDegreePoint1; }
            set
            {
                if (_longDegreePoint1 != null)
                {
                    _longDegreePoint1 = value;
                }
            }
        }
        public byte LongDegreePoint2
        {
            get { return _longDegreePoint2; }
            set
            {
                if (_longDegreePoint2 != null)
                {
                    _longDegreePoint2 = value;
                }
            }
        }
        public byte LongDegreePoint3
        {
            get { return _longDegreePoint3; }
            set
            {
                if (_longDegreePoint3 != null)
                {
                    _longDegreePoint3 = value;
                }
            }
        }
        public char EW
        {
            get { return _ew; }
            set
            {
                if (_ew != null)
                {
                    _ew = value;
                }
            }
        }
        public string Speed
        {
            get { return _speed; }
            set
            {
                if (_speed != null)
                {
                    _speed = value;
                }
            }
        }
        public string MaxSpeed
        {
            get { return _maxSpeed; }
            set
            {
                if (_maxSpeed != null)
                {
                    _maxSpeed = value;
                }
            }
        }
        public bool IsCharging
        {
            get { return _isCharging; }
            set
            {
                if (_isCharging != null)
                {
                    _isCharging = value;
                }
            }
        }
        public string Battery
        {
            get { return _battery; }
            set
            {
                if (_battery != null)
                {
                    _battery = value;
                }
            }
        }
        public string Temp
        {
            get { return _temp; }
            set
            {
                if (_temp != null)
                {
                    _temp = value;
                }
            }
        }
        public string AcclX
        {
            get { return _acclX; }
            set
            {
                if (_acclX != null)
                {
                    _acclX = value;
                }
            }
        }
        public string AcclY
        {
            get { return _acclY; }
            set
            {
                if (_acclY != null)
                {
                    _acclY = value;
                }
            }
        }
        public string AcclZ
        {
            get { return _acclZ; }
            set
            {
                if (_acclZ != null)
                {
                    _acclZ = value;
                }
            }
        }
        public int Alarm
        {
            get { return _alarm; }
            set
            {
                if (_alarm != null)
                {
                    _alarm = value;
                }
            }
        }
        public short GeofenceInOutIndex
        {
            get { return _geofenceInOutIndex; }
            set
            {
                if (_geofenceInOutIndex != null)
                {
                    _geofenceInOutIndex = value;
                }
            }
        }
        public byte GeofenceInOutState
        {
            get { return _geofenceInOutState; }
            set
            {
                if (_geofenceInOutState != null)
                {
                    _geofenceInOutState = value;
                }
            }
        }
        public char CommCode
        {
            get { return _commCode; }
            set
            {
                if (_commCode != null)
                {
                    _commCode = value;
                }
            }
        }
        public short Rsrp
        {
            get { return _rsrp; }
            set
            {
                if (_rsrp != null)
                {
                    _rsrp = value;
                }
            }
        }
        public short Rscp 
        {
            get { return _rscp; }
            set
            {
                if (_rscp != null)
                {
                    _rscp = value;
                }
            }
        }
        public short Rssi
        {
            get { return _rssi; }
            set
            {
                if (_rssi != null)
                {
                    _rssi = value;
                }
            }
        }
        public ushort MobileErrorCode
        {
            get { return _mobileErrorCode; }
            set
            {
                if (_mobileErrorCode != null)
                {
                    _mobileErrorCode = value;
                }
            }
        }
    }
}

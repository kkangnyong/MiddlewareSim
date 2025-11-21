using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8
{
    public class ReeferBodyViewModelVer8 : ViewModelBase
    {
        private static ReeferBodyViewModelVer8 _instance;
        public ReeferBodyViewModelVer8 Instance { get { if (_instance == null) _instance = new ReeferBodyViewModelVer8(); return _instance; } }

        private ReeferBodyStore _reeferBodyStore;

        private ReeferBodyModel _reeferBodyModel;
        public ReeferBodyModel ReeferBodyModel { get { if (_reeferBodyModel == null) _reeferBodyModel = Instance._reeferBodyStore._currentReeferBody = new ReeferBodyModel(); return _reeferBodyModel; } }

        public ReeferBodyViewModelVer8() { }

        public ReeferBodyViewModelVer8(ReeferBodyStore reeferBodyStore)
        {
            _instance = this;
            Instance._reeferBodyStore = reeferBodyStore;
        }

        public string ContainerSN
        {
            get { return ReeferBodyModel.ContainerSN; }
            set
            {
                if (ReeferBodyModel.ContainerSN != null)
                {
                    ReeferBodyModel.ContainerSN = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sp
        {
            get { return ReeferBodyModel.Sp; }
            set
            {
                if (ReeferBodyModel.Sp != null)
                {
                    ReeferBodyModel.Sp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Ss
        {
            get { return ReeferBodyModel.Ss; }
            set
            {
                if (ReeferBodyModel.Ss != null)
                {
                    ReeferBodyModel.Ss = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Dss
        {
            get { return ReeferBodyModel.Dss; }
            set
            {
                if (ReeferBodyModel.Dss != null)
                {
                    ReeferBodyModel.Dss = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Rs
        {
            get { return ReeferBodyModel.Rs; }
            set
            {
                if (ReeferBodyModel.Rs != null)
                {
                    ReeferBodyModel.Rs = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Eos
        {
            get { return ReeferBodyModel.Eos; }
            set
            {
                if (ReeferBodyModel.Eos != null)
                {
                    ReeferBodyModel.Eos = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Ambs
        {
            get { return ReeferBodyModel.Ambs; }
            set
            {
                if (ReeferBodyModel.Ambs != null)
                {
                    ReeferBodyModel.Ambs = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Dchs
        {
            get { return ReeferBodyModel.Dchs; }
            set
            {
                if (ReeferBodyModel.Dchs != null)
                {
                    ReeferBodyModel.Dchs = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Sgs
        {
            get { return ReeferBodyModel.Sgs; }
            set
            {
                if (ReeferBodyModel.Sgs != null)
                {
                    ReeferBodyModel.Sgs = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Tintern
        {
            get { return ReeferBodyModel.Tintern; }
            set
            {
                if (ReeferBodyModel.Tintern != null)
                {
                    ReeferBodyModel.Tintern = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Tfc
        {
            get { return ReeferBodyModel.Tfc; }
            set
            {
                if (ReeferBodyModel.Tfc != null)
                {
                    ReeferBodyModel.Tfc = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte AirExchange
        {
            get { return ReeferBodyModel.AirExchange; }
            set
            {
                if (ReeferBodyModel.AirExchange != null)
                {
                    ReeferBodyModel.AirExchange = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte TotalCurrent
        {
            get { return ReeferBodyModel.TotalCurrent; }
            set
            {
                if (ReeferBodyModel.TotalCurrent != null)
                {
                    ReeferBodyModel.TotalCurrent = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Usda1
        {
            get { return ReeferBodyModel.Usda1; }
            set
            {
                if (ReeferBodyModel.Usda1 != null)
                {
                    ReeferBodyModel.Usda1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Usda2
        {
            get { return ReeferBodyModel.Usda2; }
            set
            {
                if (ReeferBodyModel.Usda2 != null)
                {
                    ReeferBodyModel.Usda2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Usda3
        {
            get { return ReeferBodyModel.Usda3; }
            set
            {
                if (ReeferBodyModel.Usda3 != null)
                {
                    ReeferBodyModel.Usda3 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Cts
        {
            get { return ReeferBodyModel.Cts; }
            set
            {
                if (ReeferBodyModel.Cts != null)
                {
                    ReeferBodyModel.Cts = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Humid
        {
            get { return ReeferBodyModel.Humid; }
            set
            {
                if (ReeferBodyModel.Humid != null)
                {
                    ReeferBodyModel.Humid = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte HumiditySet
        {
            get { return ReeferBodyModel.HumiditySet; }
            set
            {
                if (ReeferBodyModel.HumiditySet != null)
                {
                    ReeferBodyModel.HumiditySet = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte O2
        {
            get { return ReeferBodyModel.O2; }
            set
            {
                if (ReeferBodyModel.O2 != null)
                {
                    ReeferBodyModel.O2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte O2Set
        {
            get { return ReeferBodyModel.O2Set; }
            set
            {
                if (ReeferBodyModel.O2Set != null)
                {
                    ReeferBodyModel.O2Set = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Co2
        {
            get { return ReeferBodyModel.Co2; }
            set
            {
                if (ReeferBodyModel.Co2 != null)
                {
                    ReeferBodyModel.Co2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte Co2Set
        {
            get { return ReeferBodyModel.Co2Set; }
            set
            {
                if (ReeferBodyModel.Co2Set != null)
                {
                    ReeferBodyModel.Co2Set = value;
                    OnPropertyChanged();
                }
            }
        }
        public byte ModeType
        {
            get { return ReeferBodyModel.ModeType; }
            set
            {
                if (ReeferBodyModel.ModeType != null)
                {
                    ReeferBodyModel.ModeType = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Hrp
        {
            get { return ReeferBodyModel.Hrp; }
            set
            {
                if (ReeferBodyModel.Hrp != null)
                {
                    ReeferBodyModel.Hrp = value;
                    OnPropertyChanged();
                }
            }
        }
        public short Lrp
        {
            get { return ReeferBodyModel.Lrp; }
            set
            {
                if (ReeferBodyModel.Lrp != null)
                {
                    ReeferBodyModel.Lrp = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Phase3Voltage
        {
            get { return ReeferBodyModel.Phase3Voltage; }
            set
            {
                if (ReeferBodyModel.Phase3Voltage != null)
                {
                    ReeferBodyModel.Phase3Voltage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Phase3Current
        {
            get { return ReeferBodyModel.Phase3Current; }
            set
            {
                if (ReeferBodyModel.Phase3Current != null)
                {
                    ReeferBodyModel.Phase3Current = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Pt
        {
            get { return ReeferBodyModel.Pt; }
            set
            {
                if (ReeferBodyModel.Pt != null)
                {
                    ReeferBodyModel.Pt = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Ifc
        {
            get { return ReeferBodyModel.Ifc; }
            set
            {
                if (ReeferBodyModel.Ifc != null)
                {
                    ReeferBodyModel.Ifc = value;
                    OnPropertyChanged();
                }
            }
        }
        public string DefrostInter
        {
            get { return ReeferBodyModel.DefrostInter; }
            set
            {
                if (ReeferBodyModel.DefrostInter != null)
                {
                    ReeferBodyModel.DefrostInter = value;
                    OnPropertyChanged();
                }
            }
        }
        public string IsoStatus
        {
            get { return ReeferBodyModel.IsoStatus; }
            set
            {
                if (ReeferBodyModel.IsoStatus != null)
                {
                    ReeferBodyModel.IsoStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Status
        {
            get { return ReeferBodyModel.Status; }
            set
            {
                if (ReeferBodyModel.Status != null)
                {
                    ReeferBodyModel.Status = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Alarms
        {
            get { return ReeferBodyModel.Alarms; }
            set
            {
                if (ReeferBodyModel.Alarms != null)
                {
                    ReeferBodyModel.Alarms = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PrivateAlarms
        {
            get { return ReeferBodyModel.PrivateAlarms; }
            set
            {
                if (ReeferBodyModel.PrivateAlarms != null)
                {
                    ReeferBodyModel.PrivateAlarms = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Controller
        {
            get { return ReeferBodyModel.Controller; }
            set
            {
                if (ReeferBodyModel.Controller != null)
                {
                    ReeferBodyModel.Controller = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HwVer
        {
            get { return ReeferBodyModel.HwVer; }
            set
            {
                if (ReeferBodyModel.HwVer != null)
                {
                    ReeferBodyModel.HwVer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string SwVer
        {
            get { return ReeferBodyModel.SwVer; }
            set
            {
                if (ReeferBodyModel.SwVer != null)
                {
                    ReeferBodyModel.SwVer = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EtcCode
        {
            get { return ReeferBodyModel.EtcCode; }
            set
            {
                if (ReeferBodyModel.EtcCode != null)
                {
                    ReeferBodyModel.EtcCode = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

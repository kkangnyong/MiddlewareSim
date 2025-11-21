using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver8
{
    public class ProtocolViewModelVer8 : ViewModelBase
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IModelDataService _modelDataService;
        private readonly DeviceInfoStore _deviceInfoStore;
        private readonly SetupInfoStore _setupInfoStore;
        private readonly DeviceBodyStore _deviceBodyStore;
        private readonly ReeferBodyStore _reeferBodyStore;
        private DeviceInfoModel CurrentDeviceInfoModel => _deviceInfoStore._currentDeviceInfo;
        private SetupInfoModel CurrentSetupInfoModel => _setupInfoStore._currentSetupInfo;
        private DeviceBodyModel CurrentDeviceBodyModel => _deviceBodyStore._currentDeviceBody;
        private ReeferBodyModel CurrentReeferBodyModel => _reeferBodyStore._currentReeferBody;
        public ICommand ToDeviceInfoCommand { get; set; }
        public ICommand ToSetupInfoCommand { get; set; }
        public ICommand ToDeviceBodyCommand { get; set; }
        public ICommand ToReeferBodyCommand { get; set; }
        public ICommand ToStartDataCommand { get; set; }
        public ICommand ToStartCommandCommand { get; set; }

        public INotifyPropertyChanged? CurrentDeviceInfoViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(DeviceInfoViewModelVer8)); }
        }

        public INotifyPropertyChanged? CurrentSetupInfoViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(SetupInfoViewModelVer8)); }
        }

        public INotifyPropertyChanged? CurrentDeviceBodyViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(DeviceBodyViewModelVer8)); }
        }

        public INotifyPropertyChanged? CurrentReeferBodyViewModel
        {
            get { return (ViewModelBase)App.Current.Services.GetService(typeof(ReeferBodyViewModelVer8)); }
        }
        private bool _isDeviceInfoEnabled { get; set; } = false;
        private bool _isSetupInfoEnabled { get; set; } = false;
        private bool _isStartDataEnabled { get; set; } = false;
        private bool _isDeviceDataEnabled { get; set; } = false;
        private bool _isReeferDataEnabled { get; set; } = false;
        private bool _isStartCommandEnabled { get; set; } = false;

        private static ProtocolViewModelVer8 _instance;
        public ProtocolViewModelVer8 Instance { get { if (_instance == null) _instance = new ProtocolViewModelVer8(); return _instance; } }

        public ProtocolViewModelVer8() { }

        public ProtocolViewModelVer8(IMessageBoxService messageBoxService, IModelDataService modelData,
            DeviceInfoStore deviceInfoStore,
            SetupInfoStore setupInfoStore,
            DeviceBodyStore deviceBodyStore,
            ReeferBodyStore reeferBodyStore)
        {
            _instance = this;
            _messageBoxService = messageBoxService;
            _modelDataService = modelData;
            _deviceInfoStore = deviceInfoStore;
            _setupInfoStore = setupInfoStore;
            _deviceBodyStore = deviceBodyStore;
            _reeferBodyStore = reeferBodyStore;
            Initialize();
        }

        private void Initialize()
        {
            ToDeviceInfoCommand = new RelayCommand<object>(ToDeviceInfo);
            ToSetupInfoCommand = new RelayCommand<object>(ToSetupInfo);
            ToDeviceBodyCommand = new RelayCommand<object>(ToDeviceBody);
            ToReeferBodyCommand = new RelayCommand<object>(ToReeferBody);
            ToStartDataCommand = new RelayCommand<object>(ToStartData);
            ToStartCommandCommand = new RelayCommand<object>(ToStartCommand);
            _modelDataService._dataValuesList = new List<byte[]>();
        }

        private void ToDeviceInfo(object _)
        {
            _modelDataService.SetDataValues(new List<byte[]>
            {
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Code.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.DeviceNumber.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Major.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Minor.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Revision.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.DbgIdCode.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.PwrCSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.RccCSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.FlashSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.FlashOBR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.LwdgSR.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CurStandbyCount.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.LastGeofenceIndex.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.UsimIMSI.ToString().Trim(), 20, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Rssi.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.MCCMNC.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Lac.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CellID.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.WireType.ToString().Trim(), 20, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.ActiveBand.ToString().Trim(), 30, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CellOperator.ToString().Trim(), 30, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Ccpr.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CommPeriod.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.GpsTimeout.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.GpsStableTime.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.WireConnTimeout.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.RetryCount.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.RcCount.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.TotalStandbyCount.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.AccelShockUpper.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.SetTempLower.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.SetTempUpper.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.HumidLower.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.HumidUpper.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.StateChangedAlarm.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.CutOffVoltage.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.Voltage.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceInfoModel.IsCharging ? "1" : "0", 1),
            });
            IsDeviceInfoEnabled = false;
            IsSetupInfoEnabled = true;
        }

        private void ToSetupInfo(object _)
        {
            _modelDataService.SetDataValues(new List<byte[]>
            {
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.Code.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.CCPR.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.CommPeriod.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.GpsTimeout.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.GpsStableTime.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.WireConnTimeOut.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.RetryCount.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.RcCount.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.TotalStandbyCount.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.AccelShockUpper.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.SetTempLower.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.SetTempUpper.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.HumidLower.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.HumidUpper.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.StateChangeAlarm.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentSetupInfoModel.CutOffVoltage.ToString().Trim(), 2),
            });
            IsSetupInfoEnabled = false;
            IsStartDataEnabled = true;
        }

        private void ToStartData(object _)
        {
            IsStartDataEnabled = false;
            IsDeviceDataEnabled = true;
        }

        private void ToDeviceBody(object _)
        {
            _modelDataService.SetDataValues(new List<byte[]>
            {
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Code.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Index.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.DeviceNumber.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Year.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Month.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Day.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Hour.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Min.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Second.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.GPSEnable.ToString().Trim(), 1, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LatDegree.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LatDegreePoint1.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LatDegreePoint2.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LatDegreePoint3.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.NS.ToString().Trim(), 1, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LongDegree.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LongDegreePoint1.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LongDegreePoint2.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.LongDegreePoint3.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.EW.ToString().Trim(), 1, true),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Speed.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.MaxSpeed.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.IsCharging ? "1" : "0", 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Battery.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Temp.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.AcclX.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.AcclY.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.AcclZ.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.Alarm.ToString().Trim(), 4),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.GeofenceInOutIndex.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.GeofenceInOutState.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentDeviceBodyModel.CommCode.ToString().Trim(), 1)
            });
            IsDeviceDataEnabled = false;
            IsReeferDataEnabled = true;
        }

        private void ToReeferBody(object _)
        {
            _modelDataService.SetDataValues(new List<byte[]>
            {
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.ContainerSN.ToString().Trim(), 11, true),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Sp.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Ss.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Dss.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Rs.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Eos.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Ambs.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Dchs.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Sgs.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Tintern.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Tfc.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.AirExchange.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.TotalCurrent.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Usda1.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Usda2.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Usda3.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Cts.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Humid.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.HumiditySet.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.O2.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.O2Set.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Co2.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Co2Set.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.ModeType.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Hrp.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Lrp.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Phase3Voltage.ToString().Trim(), 3),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Phase3Current.ToString().Trim(), 6),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Pt.ToString().Trim(), 2),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Ifc.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.DefrostInter.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.IsoStatus.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Status.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Alarms.ToString().Trim(), 16),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.PrivateAlarms.ToString().Trim(), 32),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.Controller.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.HwVer.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.SwVer.ToString().Trim(), 1),
                _modelDataService.GetStringsToByteArray(CurrentReeferBodyModel.EtcCode.ToString().Trim(), 1)
            });
            IsReeferDataEnabled = false;
            IsStartCommandEnabled = true;
        }

        private void ToStartCommand(object _)
        {
            IsStartCommandEnabled = false;
            IsDeviceInfoEnabled = true;
        }

        public bool IsDeviceInfoEnabled
        {
            get { return _isDeviceInfoEnabled; }
            set
            {
                if (_isDeviceInfoEnabled != null)
                {
                    _isDeviceInfoEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSetupInfoEnabled
        {
            get { return _isSetupInfoEnabled; }
            set
            {
                if (_isSetupInfoEnabled != null)
                {
                    _isSetupInfoEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsStartDataEnabled
        {
            get { return _isStartDataEnabled; }
            set
            {
                if (_isStartDataEnabled != null)
                {
                    _isStartDataEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDeviceDataEnabled
        {
            get { return _isDeviceDataEnabled; }
            set
            {
                if (_isDeviceDataEnabled != null)
                {
                    _isDeviceDataEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsReeferDataEnabled
        {
            get { return _isReeferDataEnabled; }
            set
            {
                if (_isReeferDataEnabled != null)
                {
                    _isReeferDataEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsStartCommandEnabled
        {
            get { return _isStartCommandEnabled; }
            set
            {
                if (_isStartCommandEnabled != null)
                {
                    _isStartCommandEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

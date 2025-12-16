using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver10
{
    public class SensorBodyViewModelVer10 : ViewModelBase
    {
        private static SensorBodyViewModelVer10 _instance;
        public SensorBodyViewModelVer10 Instance { get { if (_instance == null) _instance = new SensorBodyViewModelVer10(); return _instance; } }

        private SensorBodyStore _sensorBodyStore;

        private SensorBodyModel _sensorBodyModel;
        public SensorBodyModel SensorBodyModel { get { if (_sensorBodyModel == null) _sensorBodyModel = Instance._sensorBodyStore._currentSensorBody = new SensorBodyModel(); return _sensorBodyModel; } }


        public SensorBodyViewModelVer10() { }

        public SensorBodyViewModelVer10(SensorBodyStore sensorBodyStore)
        {
            _instance = this;
            _sensorBodyStore = sensorBodyStore;
        }

        public string Date
        {
            get { return SensorBodyModel.Date; }
            set
            {
                if (SensorBodyModel.Date != null)
                {
                    SensorBodyModel.Date = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Time
        {
            get { return SensorBodyModel.Time; }
            set
            {
                if (SensorBodyModel.Time != null)
                {
                    SensorBodyModel.Time = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ActivePower
        {
            get { return SensorBodyModel.ActivePower; }
            set
            {
                if (SensorBodyModel.ActivePower != null)
                {
                    SensorBodyModel.ActivePower = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AccumulatedPower
        {
            get { return SensorBodyModel.AccumulatedPower; }
            set
            {
                if (SensorBodyModel.AccumulatedPower != null)
                {
                    SensorBodyModel.AccumulatedPower = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Error
        {
            get { return SensorBodyModel.Error; }
            set
            {
                if (SensorBodyModel.Error != null)
                {
                    SensorBodyModel.Error = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9
{
    public class SensorBodyViewModelVer9 : ViewModelBase
    {
        private static SensorBodyViewModelVer9 _instance;
        public SensorBodyViewModelVer9 Instance { get { if (_instance == null) _instance = new SensorBodyViewModelVer9(); return _instance; } }

        private SensorBodyStore _sensorBodyStore;

        private SensorBodyModel _sensorBodyModel;
        public SensorBodyModel SensorBodyModel { get { if (_sensorBodyModel == null) _sensorBodyModel = Instance._sensorBodyStore._currentSensorBody = new SensorBodyModel(); return _sensorBodyModel; } }


        public SensorBodyViewModelVer9() { }

        public SensorBodyViewModelVer9(SensorBodyStore sensorBodyStore)
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

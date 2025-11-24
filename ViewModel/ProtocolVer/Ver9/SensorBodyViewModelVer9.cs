using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel.ProtocolVer.Ver9
{
    public class SensorBodyViewModelVer9 : ViewModelBase
    {
        public ICommand ToAddSensorDataCommand { get; set; }
        public ObservableCollection<string> ItemsCollection { get; set; }
        private static SensorBodyViewModelVer9 _instance;
        public SensorBodyViewModelVer9 Instance { get { if (_instance == null) _instance = new SensorBodyViewModelVer9(); return _instance; } }

        private SensorBodyStore _sensorBodyStore;

        private SensorBodyModel _sensorBodyModel;
        public SensorBodyModel SensorBodyModel { get { if (_sensorBodyModel == null) _sensorBodyModel = Instance._sensorBodyStore._currentSensorBody = new SensorBodyModel(); return _sensorBodyModel; } }

        private List<short> _countSensorDataList { get; set; } = new List<short>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private short _countSensorData { get; set; } = 0;

        public SensorBodyViewModelVer9() { }

        public SensorBodyViewModelVer9(SensorBodyStore sensorBodyStore)
        {
            _instance = this;
            Instance._sensorBodyStore = sensorBodyStore;
            ItemsCollection = new ObservableCollection<string>();
            ToAddSensorDataCommand = new RelayCommand<object>(ToAddSensorData);
        }

        private void ToAddSensorData(object _)
        {
            ItemsCollection.Clear();
            for (int index = 2; index < 5; index++)
            {
                ItemsCollection.Add($"TextBlock {index}");
                //GridRowNo = (short)index;
            }
        }

        private short _gridRowNo { get; set; } = 2;
        public short GridRowNo
        {
            get { return _countSensorData; }
            set
            {
                if (_gridRowNo != null)
                {
                    _gridRowNo = value;
                    OnPropertyChanged();
                }
            }
        }

        public short CountSensorData
        {
            get { return _countSensorData; }
            set
            {
                if (_countSensorData != null)
                {
                    _countSensorData = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<short> CountSensorDataList
        {
            get { return _countSensorDataList; }
            set
            {
                if (_countSensorDataList != null)
                {
                    _countSensorDataList = value;
                    OnPropertyChanged();
                }
            }
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

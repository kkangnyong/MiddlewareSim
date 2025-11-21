using SimReeferMiddlewareSystemWPF.Model;
using SimReeferMiddlewareSystemWPF.Store;

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
            Instance._sensorBodyStore = sensorBodyStore;
        }

        //public string ContainerSN
        //{
        //    get { return SensorBodyModel.ContainerSN; }
        //    set
        //    {
        //        if (SensorBodyModel.ContainerSN != null)
        //        {
        //            SensorBodyModel.ContainerSN = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public string Sp
        //{
        //    get { return SensorBodyModel.Sp; }
        //    set
        //    {
        //        if (SensorBodyModel.Sp != null)
        //        {
        //            SensorBodyModel.Sp = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public string Ss
        //{
        //    get { return SensorBodyModel.Ss; }
        //    set
        //    {
        //        if (SensorBodyModel.Ss != null)
        //        {
        //            SensorBodyModel.Ss = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
    }
}

using SimReeferMiddlewareSystemWPF.Command;
using SimReeferMiddlewareSystemWPF.Inteface;
using SimReeferMiddlewareSystemWPF.Interface;
using SimReeferMiddlewareSystemWPF.Store;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class DeviceBodyViewModel : ViewModelBase, IDeviceBody
    {
        //private string code = "23";
        //public string Code
        //{
        //    get { return code; }
        //    set { 
        //        if (code != value) 
        //        {
        //            code = value;
        //            OnPropertyChanged();
        //        } 
        //    }
        //}
        //public string Index
        //{
        //    get; set;
        //}
        //public string DeviceNumber
        //{
        //    get; set;
        //}
        private readonly INavigationService _navigationService;
        public ICommand ToProtocolCommand { get; set; }
        private void ToProtocol(object _)
        {
            _navigationService.Navigate(Service.NaviType.ProtocolView);
        }
        public ICommand ToApplyCommand { get; set; }
        private void ToApply(object _)
        {
            SetDeviceBodyValues();
            byte code = 0;
            //if (!byte.TryParse(txt_code.Text.Trim(), out code)) code = 0;

            Event?.Invoke(this, EventDatas = new UserControlEventArgs(_dataValuesList, _totalDataBytesLength, code));
            MessageBox.Show("Apply!!!");
        }

        public DeviceBodyViewModel() { }

        public DeviceBodyViewModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;
            ToProtocolCommand = new RelayCommand<object>(ToProtocol);
            ToApplyCommand = new RelayCommand<object>(ToApply);
        }

        public UserControlEventArgs EventDatas { get; set; }

        public event EventHandler<UserControlEventArgs> Event;
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetDeviceBodyValues()
        {
            if (_dataValuesList != null && _dataValuesList.Count > 0)
            {
                _dataValuesList.Clear();
                _totalDataBytesLength = 0;
            }

            _dataValuesList.AddRange(new List<byte[]>
            {
                //GetStringsToByteArray(txt_code.Text.Trim(), 1),
                //GetStringsToByteArray(txt_idx.Text.Trim(), 2),
                //GetStringsToByteArray(txt_deviceNumber.Text.Trim(), 4),
                //GetStringsToByteArray(txt_year.Text.Trim(), 1),
                //GetStringsToByteArray(txt_month.Text.Trim(), 1),
                //GetStringsToByteArray(txt_day.Text.Trim(), 1),
                //GetStringsToByteArray(txt_hour.Text.Trim(), 1),
                //GetStringsToByteArray(txt_min.Text.Trim(), 1),
                //GetStringsToByteArray(txt_sec.Text.Trim(), 1),
                //GetStringsToByteArray(txt_gpsEnable.Text.Trim(), 1, true),
                //GetStringsToByteArray(txt_lat_degree_int.Text.Trim(), 1),
                //GetStringsToByteArray(txt_lat_degree_point1.Text.Trim(), 1),
                //GetStringsToByteArray(txt_lat_degree_point2.Text.Trim(), 1),
                //GetStringsToByteArray(txt_lat_degree_point3.Text.Trim(), 1),
                //GetStringsToByteArray(txt_ns.Text.Trim(), 1, true),
                //GetStringsToByteArray(txt_long_degree_int.Text.Trim(), 1),
                //GetStringsToByteArray(txt_long_degree_point1.Text.Trim(), 1),
                //GetStringsToByteArray(txt_long_degree_point2.Text.Trim(), 1),
                //GetStringsToByteArray(txt_long_degree_point3.Text.Trim(), 1),
                //GetStringsToByteArray(txt_ew.Text.Trim(), 1, true),
                //GetStringsToByteArray(txt_speed.Text.Trim(), 2),
                //GetStringsToByteArray(txt_maxSpeed.Text.Trim(), 2),
                //GetStringsToByteArray(txt_isCharging.Text.Trim(), 1),
                //GetStringsToByteArray(txt_battery.Text.Trim(), 2),
                //GetStringsToByteArray(txt_temp.Text.Trim(), 2),
                //GetStringsToByteArray(txt_accl_X.Text.Trim(), 2),
                //GetStringsToByteArray(txt_accl_Y.Text.Trim(), 2),
                //GetStringsToByteArray(txt_accl_Z.Text.Trim(), 2),
                //GetStringsToByteArray(txt_alarm.Text.Trim(), 4),
                //GetStringsToByteArray(txt_geofenceInout_index.Text.Trim(), 2),
                //GetStringsToByteArray(txt_geofenceInout_state.Text.Trim(), 1),
                //GetStringsToByteArray(txt_commCode.Text.Trim(), 1)
            });
        }

        //public void btn_send_Click(object sender, EventArgs e)
        //{
        //    SetDeviceBodyValues();
        //    byte code = 0;
        //    //if (!byte.TryParse(txt_code.Text.Trim(), out code)) code = 0;

        //    //Event?.Invoke(this, EventDatas = new UserControlEventArgs(this.Name, _dataValuesList, _totalDataBytesLength, code));
        //}
    }
}

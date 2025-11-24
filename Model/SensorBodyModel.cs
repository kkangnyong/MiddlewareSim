namespace SimReeferMiddlewareSystemWPF.Model
{
    public class SensorBodyModel
    {
        private string _date = "25,11,24";
        private string _time = "15,19,10";
        private string _activePower = "777.111";
        private string _accumulatedPower = "100000.111";
        private string _error = "0x0000";

        public string Date
        {
            get { return _date; }
            set
            {
                if (_date != null)
                {
                    _date = value;
                }
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                if (_time != null)
                {
                    _time = value;
                }
            }
        }

        public string ActivePower
        {
            get { return _activePower; }
            set
            {
                if (_activePower != null)
                {
                    _activePower = value;
                }
            }
        }

        public string AccumulatedPower
        {
            get { return _accumulatedPower; }
            set
            {
                if (_accumulatedPower != null)
                {
                    _accumulatedPower = value;
                }
            }
        }

        public string Error
        {
            get { return _error; }
            set
            {
                if (_error != null)
                {
                    _error = value;
                }
            }
        }
    }
}

using SimReeferMiddlewareSystemWPF.Model;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class IDGenerateInfoRegistStore
    {
        private IDGenerateInfoModel? _currentIDGenerateInfo;
        public IDGenerateInfoModel? CurrentIDGenerateInfo
        {
            get { return _currentIDGenerateInfo; }
            set
            {
                _currentIDGenerateInfo = value;
                if (CurrentIDGenerateInfoChanged != null)
                {
                    CurrentIDGenerateInfoChanged?.Invoke(_currentIDGenerateInfo);
                    _currentIDGenerateInfo = null;
                }
            }
        }
        public Action<IDGenerateInfoModel>? CurrentIDGenerateInfoChanged { get; set; }
    }
}

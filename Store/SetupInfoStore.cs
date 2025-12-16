using SimReeferMiddlewareSystemWPF.Model;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class SetupInfoStore
    {
        public SetupInfoModel? _currentSetupInfo;
        public Action<SetupInfoModel>? CurrentSetupInfoChanged { get; set; }
    }
}

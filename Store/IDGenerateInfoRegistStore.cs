using SimReeferMiddlewareSystemWPF.Model;

namespace SimReeferMiddlewareSystemWPF.Store
{
    public class IDGenerateInfoRegistStore
    {
        public Action<IDGenerateInfoModel>? CurrentIDGenerateInfoChanged { get; set; }
    }
}

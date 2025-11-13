using SimReeferMiddlewareSystemWPF.Store;

namespace SimReeferMiddlewareSystemWPF.Inteface
{
    public interface IEvent
    {
        public event EventHandler<UserControlEventArgs> Event;
        public UserControlEventArgs EventDatas { get; set; }
    }
}

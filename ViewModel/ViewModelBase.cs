using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimReeferMiddlewareSystemWPF.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected virtual void NotifyCatcher(object sender, PropertyChangedEventArgs e)
        //{
        //    TryChangeProperty(sender, e);
        //}

        //// sender는 NotifyCatcher가 PropertyChanged에 등록되어 있고, 이 메서드가 호출된 시점에서 방금 막 속성값이 변경된 개체
        //protected bool TryChangeProperty(object sender, PropertyChangedEventArgs e)
        //{
        //    // 바뀐 속성 이름
        //    var pname = e.PropertyName;
        //    // 속성 이름으로 현재 개체에서 속성 정보를 가져온다.
        //    var pinfo = this.GetType().GetProperty(pname);

        //    // 가져와진게 없다 = 동일한 이름의 속성이 없다.
        //    if (pinfo == null) return false;

        //    // 가져와진게 있고, 해당 속성에 set 메서드가 존재하면 그 속성의 값을 바뀐 속성의 값을 가져와 동일하게 변경한다.
        //    pinfo.SetMethod?.Invoke(this, new object[] { sender.GetType().GetProperty(e.PropertyName).GetValue(sender) });

        //    return true;
        //}
    }
}

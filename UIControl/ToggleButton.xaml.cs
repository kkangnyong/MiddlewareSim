using System.Windows;
using System.Windows.Controls;

namespace SimReeferMiddlewareSystemWPF.UIControl
{
    /// <summary>
    /// ToggleButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        public ToggleButton()
        {
            InitializeComponent();
        }

        // 1. 외부에 노출할 의존성 속성 (Dependency Property) 정의
        public static readonly DependencyProperty IsToggledProperty =
            DependencyProperty.Register(
                "IsToggled",
                typeof(bool),
                typeof(ToggleButton),
                new PropertyMetadata(false));
        //new PropertyMetadata(false, OnIsToggledChanged));

        // 2. C# 속성 래퍼 (Wrapper)
        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        // 3. 속성 변경 콜백 핸들러 (선택 사항)
        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // 속성이 변경될 때 추가 로직이 필요하면 여기에 구현합니다.
            // (예: 내부 ToggleButton의 IsChecked와 동기화는 XAML 바인딩으로 이미 처리됨)
        }

        // 4. 외부에서 구독할 수 있는 이벤트 정의

        public Action? ToggleOn { get; set; }
        public Action? ToggleOff { get; set; }

        // 5. 내부 ToggleButton의 상태 변경 시 이벤트 발생
        private void InternalToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            // IsToggled 속성을 true로 업데이트 (XAML TwoWay 바인딩이 없으면 필요)
            IsToggled = true;
            if (ToggleOn != null) ToggleOn.Invoke();
        }

        private void InternalToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // IsToggled 속성을 false로 업데이트 (XAML TwoWay 바인딩이 없으면 필요)
            IsToggled = false;
            if (ToggleOff != null) ToggleOff?.Invoke();
        }
    }
}
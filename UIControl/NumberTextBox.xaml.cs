using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SimReeferMiddlewareSystemWPF.UIControl
{
    /// <summary>
    /// NumberTextBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+"); // 숫자, 마이너스 기호, 소수점만 허용
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

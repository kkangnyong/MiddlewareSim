using System.Windows.Controls;
using System.Windows.Documents;

namespace SimReeferMiddlewareSystemWPF.View.Menu
{
    /// <summary>
    /// SendManual.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SendManual : UserControl
    {
        public SendManual()
        {
            InitializeComponent();
        }

        private void MyRichTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            string richText = new TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.Document.ContentEnd).Text.Trim();
            if (!string.IsNullOrEmpty(richText) && richText.Equals("Please Input Send Packet Data!!!"))
            {
                MyRichTextBox.Document.Blocks.Clear();
            }
        }
    }
}

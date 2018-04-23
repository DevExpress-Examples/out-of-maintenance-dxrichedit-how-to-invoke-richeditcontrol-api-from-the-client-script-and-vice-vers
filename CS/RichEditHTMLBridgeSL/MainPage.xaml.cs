using System.Windows.Browser;
using System.Windows.Controls;

namespace RichEditHTMLBridgeSL {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();

            HtmlPage.RegisterScriptableObject("skPage", this);
        }

        [ScriptableMember()]
        public void RichEditAppendText(string text) {
            richEditControl1.Document.AppendText(text);
        }

        [ScriptableMember()]
        public void RichEditCreate() {
            richEditControl1.CreateNewDocument();
        }

        private void btnShowText_Click(object sender, System.Windows.RoutedEventArgs e) {
            HtmlPage.Window.Invoke("showText", richEditControl1.Text);
        }
    }
}

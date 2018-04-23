Imports Microsoft.VisualBasic
Imports System.Windows.Browser
Imports System.Windows.Controls

Namespace RichEditHTMLBridgeSL
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			HtmlPage.RegisterScriptableObject("skPage", Me)
		End Sub

		<ScriptableMember()> _
		Public Sub RichEditAppendText(ByVal text As String)
			richEditControl1.Document.AppendText(text)
		End Sub

		<ScriptableMember()> _
		Public Sub RichEditCreate()
			richEditControl1.CreateNewDocument()
		End Sub

		Private Sub btnShowText_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
			HtmlPage.Window.Invoke("showText", richEditControl1.Text)
		End Sub
	End Class
End Namespace

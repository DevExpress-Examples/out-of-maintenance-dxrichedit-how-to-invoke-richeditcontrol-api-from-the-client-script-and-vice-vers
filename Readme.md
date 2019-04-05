<!-- default file list -->
*Files to look at*:

* [Silverlight.js](./CS/RichEditHTMLBridgeSL.Web/Silverlight.js) (VB: [Silverlight.js](./VB/RichEditHTMLBridgeSL.Web/Silverlight.js))
* [MainPage.xaml](./CS/RichEditHTMLBridgeSL/MainPage.xaml) (VB: [MainPage.xaml](./VB/RichEditHTMLBridgeSL/MainPage.xaml))
* [MainPage.xaml.cs](./CS/RichEditHTMLBridgeSL/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/RichEditHTMLBridgeSL/MainPage.xaml.vb))
<!-- default file list end -->
# DXRichEdit - How to invoke RichEditControl API from the client script and vice versa


<p>To invoke RichEditControl API from the client script, do the following:</p><p>1) Register a managed Silverlight page object for scriptable access from JavaScript code as follows: </p>

```cs
   public partial class MainPage : UserControl {        public MainPage() {            InitializeComponent();            HtmlPage.RegisterScriptableObject("skPage", this);        }<newline/>
       ... 
```

<p>2) Add the managed method you wish to call from your JavaScript code. You must prefix it with the <strong>[ScriptableMember]</strong> attribute:</p>

```cs
       [ScriptableMember()]        public void RichEditCreate() {            richEditControl1.CreateNewDocument();        }
```

<p> </p><p>3) In JavaScript, you can now call directly to your Silverlight function. This can be done through the document object: </p>

```js
   var host = document.getElementById('silverlightPlugIn');    host.Content.skPage.RichEditCreate();
```

<p> </p><p>where 'silverlightPlugIn' is the ID of the Silverlight plug-in in the hosting page.</p><p><br />
To invoke the client script function from the Silverlight code, you just need to call the <strong>HtmlPage.Window.Invoke()</strong> method with the specified JavaScript function name:</p><p>        

```cs
HtmlPage.Window.Invoke("showText", richEditControl1.Text);
```

 </p>

```js
   function showText(text) {        alert(text);    }
```

<p> </p><p>The sample application is illustrated in the screenshot below.</p><p><img src="https://raw.githubusercontent.com/DevExpress-Examples/dxrichedit-how-to-invoke-richeditcontrol-api-from-the-client-script-and-vice-versa-e3486/11.1.7+/media/bcd4560c-c6fc-48c7-a768-8daea9ed6892.png"></p><p><strong>Note:</strong> Not all RichEditControl functionality can be activated from JavaScript. For instance, the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfRichEditRichEditControl_LoadDocumenttopic293"><u>RichEditControl.LoadDocument Method</u></a> call will fail because of the corresponding Silverlight platform restriction (see the <a href="http://stackoverflow.com/questions/2730823/call-openfiledialog-silverlight-from-javascript"><u>Call OpenFileDialog Silverlight from JavaScript</u></a> webpage).</p><p><strong>See Also:</strong><br />
<a href="http://blogs.silverlight.net/blogs/msnow/archive/2008/07/08/tip-of-the-day-15-communicating-between-javascript-amp-silverlight.aspx"><u>Silverlight Tip of the Day #15 – Communicating between JavaScript & Silverlight</u></a></p>

<br/>



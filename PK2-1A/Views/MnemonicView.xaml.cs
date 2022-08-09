using cip_blue.ViewModels;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cip_blue.Views
{
    
    /// <summary>
    /// Interaction logic for MnemonicView.xaml
    /// </summary>
    public partial class MnemonicView : UserControl
    {
        public MnemonicView()
        {
            InitializeComponent();
            home = new Uri("http://stp10/d/DqT9rWj7k/tsip-f-pressov-4101-4102-andand-pvs?orgId=1&from=now-6h&to=now&refresh=5s&viewPanel=24");
            home1 = new Uri("http://stp10/d/DqT9rWj7k/tsip-f-pressov-4101-4102-andand-pvs?orgId=1&refresh=5s&viewPanel=33");
        }
        public Uri home;
        public Uri home1;
        bool _isNavigating = false;
        private async void WebView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            var vhod= (Microsoft.Web.WebView2.Wpf.WebView2)sender;

            vhod.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            string script = File.ReadAllText("Mouse.js");
            await vhod.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(script);
          //  webView.ZoomFactor = 0.6;
            //  IntPtr windowHandle = new WindowInteropHelper(sampleWindow).EnsureHandle();

            //webView2.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

            //  webView2.CoreWebView2.Settings.IsScriptEnabled = false;
            // webView2.CoreWebView2.Navigate("");

        }

        bool IsWebViewValid()
        {
            try
            {
                return webView != null && webView.CoreWebView2 != null;
            }
            catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException)
            {
                return false;
            }
        }


        void RefreshCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsWebViewValid() && !_isNavigating;
        }

        void RefreshCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.Reload();
        }
        void GoToPageCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && !_isNavigating;
        }

        void HomeCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && !_isNavigating;
        }

        async void HomeCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {

            await webView.EnsureCoreWebView2Async();
            await webView1.EnsureCoreWebView2Async();
            //var rawUrl = (string)e.Parameter;
            //Uri uri = null;

            //if (Uri.IsWellFormedUriString(rawUrl, UriKind.Absolute))
            //{
            //    uri = new Uri(rawUrl);
            //}
            //else if (!rawUrl.Contains(" ") && rawUrl.Contains("."))
            //{
            //    // An invalid URI contains a dot and no spaces, try tacking http:// on the front.
            //    uri = new Uri("http://" + rawUrl);
            //}
            //else
            //{
            //    // Otherwise treat it as a web search.
            //    uri = new Uri("https://bing.com/search?q=" +
            //        String.Join("+", Uri.EscapeDataString(rawUrl).Split(new string[] { "%20" }, StringSplitOptions.RemoveEmptyEntries)));
            //}

            // Setting webView.Source will not trigger a navigation if the Source is the same
            // as the previous Source.  CoreWebView.Navigate() will always trigger a navigation.
            webView.CoreWebView2.Navigate(home.ToString());
            webView1.CoreWebView2.Navigate(home1.ToString());
        }
        private void webView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            //HwndSource hwnd = (HwndSource)PresentationSource.FromVisual(this);

            //if (hwnd != null)
            //{
            //    hwnd.AddHook(new HwndSourceHook(WndProc));
            //}


          //  JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(e.WebMessageAsJson);

            //switch (jsonObject[0].ToString())
            //{
            //    case "click":
            //        //MessageBox.Show(jsonObject.Value);
            //        break;

            //}


        }

    }

    public partial class DraggablePopup : Popup
    {
        public DraggablePopup()
        {
            var thumb = new Thumb
            {
                Width = 0,
                Height = 0,
            };
           // ContentCanvas.Children.Add(thumb);

            MouseDown += (sender, e) =>
            {
                thumb.RaiseEvent(e);
            };

            thumb.DragDelta += (sender, e) =>
            {
                HorizontalOffset += e.HorizontalChange;
                VerticalOffset += e.VerticalChange;
            };
        }
    }
}

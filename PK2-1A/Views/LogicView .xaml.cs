using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;

namespace cip_blue.Views
{

    /// <summary>
    /// Interaction logic for LogicView.xaml
    /// </summary>
    public partial class LogicView : UserControl
    {
       

        public Uri home;
        public static RoutedCommand InjectScriptCommand = new RoutedCommand();
        public static RoutedCommand NavigateWithWebResourceRequestCommand = new RoutedCommand();
        public static RoutedCommand DOMContentLoadedCommand = new RoutedCommand();
        public static RoutedCommand GetCookiesCommand = new RoutedCommand();
        public static RoutedCommand SuspendCommand = new RoutedCommand();
        public static RoutedCommand ResumeCommand = new RoutedCommand();
        public static RoutedCommand CheckUpdateCommand = new RoutedCommand();
        public static RoutedCommand NewBrowserVersionCommand = new RoutedCommand();
        public static RoutedCommand PdfToolbarSaveCommand = new RoutedCommand();
        public static RoutedCommand CustomClientCertificateSelectionCommand = new RoutedCommand();
        public static RoutedCommand DeferredCustomCertificateDialogCommand = new RoutedCommand();
        public static RoutedCommand BackgroundColorCommand = new RoutedCommand();

        public static RoutedCommand AddOrUpdateCookieCommand = new RoutedCommand();
        public static RoutedCommand DeleteCookiesCommand = new RoutedCommand();
        public static RoutedCommand DeleteAllCookiesCommand = new RoutedCommand();
        public static RoutedCommand SetUserAgentCommand = new RoutedCommand();
        public static RoutedCommand PasswordAutosaveCommand = new RoutedCommand();
        public static RoutedCommand GeneralAutofillCommand = new RoutedCommand();
        public static RoutedCommand PinchZoomCommand = new RoutedCommand();
        public static RoutedCommand SwipeNavigationCommand = new RoutedCommand();
        bool _isNavigating = false;
        
        CoreWebView2Settings _webViewSettings;
        CoreWebView2Settings WebViewSettings
        {
            get
            {
                if (_webViewSettings == null && webView?.CoreWebView2 != null)
                {
                    _webViewSettings = webView.CoreWebView2.Settings;
                }
                return _webViewSettings;
            }
        }
        CoreWebView2Environment _webViewEnvironment;
        CoreWebView2Environment WebViewEnvironment
        {
            get
            {
                if (_webViewEnvironment == null && webView?.CoreWebView2 != null)
                {
                    _webViewEnvironment = webView.CoreWebView2.Environment;
                }
                return _webViewEnvironment;
            }
        }
        public LogicView()
        {
            
            InitializeComponent();
           
            AttachControlEventHandlers(webView);

           
            home = new Uri("http://stp10/d/DqT9rWj7k/tsip-f-pressov-4101-4102?orgId=1");
        }

       
    private async void WebView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
           
            webView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            string script = File.ReadAllText("Mouse.js");
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(script);
          //  IntPtr windowHandle = new WindowInteropHelper(sampleWindow).EnsureHandle();

            //webView2.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;

            //  webView2.CoreWebView2.Settings.IsScriptEnabled = false;
            // webView2.CoreWebView2.Navigate("");

        }

        void AttachControlEventHandlers(WebView2 control)
        {
            control.NavigationStarting += WebView_NavigationStarting;
            control.NavigationCompleted += WebView_NavigationCompleted;


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


            void BackCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = webView != null && webView.CanGoBack;
            }

            void BackCmdExecuted(object target, ExecutedRoutedEventArgs e)
            {
                webView.GoBack();
            }

            void ForwardCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = webView != null && webView.CanGoForward;
            }

            void ForwardCmdExecuted(object target, ExecutedRoutedEventArgs e)
            {
                webView.GoForward();
            }

            void RefreshCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = IsWebViewValid() && !_isNavigating;
            }

            void RefreshCmdExecuted(object target, ExecutedRoutedEventArgs e)
            {
                webView.Reload();
            }

            void BrowseStopCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = IsWebViewValid() && _isNavigating;
            }

            void BrowseStopCmdExecuted(object target, ExecutedRoutedEventArgs e)
            {
                webView.Stop();
            }

            void WebViewRequiringCmdsCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = webView != null;
            }

            void CoreWebView2RequiringCmdsCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = IsWebViewValid();
            }
        }


        private bool _isControlInVisualTree = true;

        void RemoveControlFromVisualTree(WebView2 control)
        {
            Layout.Children.Remove(control);
            _isControlInVisualTree = false;
        }

        void AttachControlToVisualTree(WebView2 control)
        {
            Layout.Children.Add(control);
            _isControlInVisualTree = true;
        }

        WebView2 GetReplacementControl(bool useNewEnvironment)
        {
            WebView2 replacementControl = new WebView2();
            ((System.ComponentModel.ISupportInitialize)(replacementControl)).BeginInit();
            // Setup properties and bindings.
            if (useNewEnvironment)
            {
                // Create a new CoreWebView2CreationProperties instance so the environment
                // is made anew.
                replacementControl.CreationProperties = new CoreWebView2CreationProperties();
                replacementControl.CreationProperties.BrowserExecutableFolder = webView.CreationProperties.BrowserExecutableFolder;
                replacementControl.CreationProperties.Language = webView.CreationProperties.Language;
                replacementControl.CreationProperties.UserDataFolder = webView.CreationProperties.UserDataFolder;
                shouldAttachEnvironmentEventHandlers = true;
            }
            else
            {
                replacementControl.CreationProperties = webView.CreationProperties;
            }
            Binding urlBinding = new Binding()
            {
                Source = replacementControl,
                Path = new PropertyPath("Source"),
                Mode = BindingMode.OneWay
            };
            //url.SetBinding(TextBox.TextProperty, urlBinding);

            AttachControlEventHandlers(replacementControl);
            replacementControl.Source = webView.Source ?? new Uri("https://www.bing.com");
            ((System.ComponentModel.ISupportInitialize)(replacementControl)).EndInit();

            return replacementControl;
        }

        void WebView_ProcessFailed(object sender, CoreWebView2ProcessFailedEventArgs e)
        {
            void ReinitIfSelectedByUser(CoreWebView2ProcessFailedKind kind)
            {
                string caption;
                string message;
                if (kind == CoreWebView2ProcessFailedKind.BrowserProcessExited)
                {
                    caption = "Browser process exited";
                    message = "WebView2 Runtime's browser process exited unexpectedly. Recreate WebView?";
                }
                else
                {
                    caption = "Web page unresponsive";
                    message = "WebView2 Runtime's render process stopped responding. Recreate WebView?";
                }

                var selection = MessageBox.Show(message, caption, MessageBoxButton.YesNo);
                if (selection == MessageBoxResult.Yes)
                {
                    // The control cannot be re-initialized so we setup a new instance to replace it.
                    // Note the previous instance of the control is disposed of and removed from the
                    // visual tree before attaching the new one.
                    if (_isControlInVisualTree)
                    {
                        RemoveControlFromVisualTree(webView);
                    }
                    webView.Dispose();
                    webView = GetReplacementControl(false);
                    AttachControlToVisualTree(webView);
                }
            }

            void ReloadIfSelectedByUser(CoreWebView2ProcessFailedKind kind)
            {
                string caption;
                string message;
                if (kind == CoreWebView2ProcessFailedKind.RenderProcessExited)
                {
                    caption = "Web page unresponsive";
                    message = "WebView2 Runtime's render process exited unexpectedly. Reload page?";
                }
                else
                {
                    caption = "App content frame unresponsive";
                    message = "WebView2 Runtime's render process for app frame exited unexpectedly. Reload page?";
                }

                var selection = MessageBox.Show(message, caption, MessageBoxButton.YesNo);
                if (selection == MessageBoxResult.Yes)
                {
                    webView.Reload();
                }
            }

            bool IsAppContentUri(Uri source)
            {
                // Sample virtual host name for the app's content.
                // See CoreWebView2.SetVirtualHostNameToFolderMapping: https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2.setvirtualhostnametofoldermapping
                return source.Host == "appassets.example";
            }

            switch (e.ProcessFailedKind)
            {
                case CoreWebView2ProcessFailedKind.BrowserProcessExited:
                    // Once the WebView2 Runtime's browser process has crashed,
                    // the control becomes virtually unusable as the process exit
                    // moves the CoreWebView2 to its Closed state. Most calls will
                    // become invalid as they require a backing browser process.
                    // Remove the control from the visual tree so the framework does
                    // not atempt to redraw it, which would call the invalid methods.
                    RemoveControlFromVisualTree(webView);
                    goto case CoreWebView2ProcessFailedKind.RenderProcessUnresponsive;
                case CoreWebView2ProcessFailedKind.RenderProcessUnresponsive:
                    System.Threading.SynchronizationContext.Current.Post((_) =>
                    {
                        ReinitIfSelectedByUser(e.ProcessFailedKind);
                    }, null);
                    break;
                case CoreWebView2ProcessFailedKind.RenderProcessExited:
                    System.Threading.SynchronizationContext.Current.Post((_) =>
                    {
                        ReloadIfSelectedByUser(e.ProcessFailedKind);
                    }, null);
                    break;
                case CoreWebView2ProcessFailedKind.FrameRenderProcessExited:
                    // A frame-only renderer has exited unexpectedly. Check if reload is needed.
                    // In this sample we only reload if the app's content has been impacted.
                    foreach (CoreWebView2FrameInfo frameInfo in e.FrameInfosForFailedProcess)
                    {
                        if (IsAppContentUri(new System.Uri(frameInfo.Source)))
                        {
                            goto case CoreWebView2ProcessFailedKind.RenderProcessExited;
                        }
                    }
                    break;
                default:
                    // Show the process failure details. Apps can collect info for their logging purposes.
                    StringBuilder messageBuilder = new StringBuilder();
                    messageBuilder.AppendLine($"Process kind: {e.ProcessFailedKind}");
                    messageBuilder.AppendLine($"Reason: {e.Reason}");
                    messageBuilder.AppendLine($"Exit code: {e.ExitCode}");
                    messageBuilder.AppendLine($"Process description: {e.ProcessDescription}");
                    System.Threading.SynchronizationContext.Current.Post((_) =>
                    {
                        MessageBox.Show(messageBuilder.ToString(), "Child process failed", MessageBoxButton.OK);
                    }, null);
                    break;
            }
        }

        double ZoomStep()
        {
            if (webView.ZoomFactor < 1)
            {
                return 0.25;
            }
            else if (webView.ZoomFactor < 2)
            {
                return 0.5;
            }
            else
            {
                return 1;
            }
        }

        void IncreaseZoomCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.ZoomFactor += ZoomStep();
        }

        void DecreaseZoomCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (webView != null) && (webView.ZoomFactor - ZoomStep() > 0.0);
        }

        void DecreaseZoomCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.ZoomFactor -= ZoomStep();
        }

        void BackgroundColorCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            System.Drawing.Color backgroundColor = System.Drawing.Color.FromName(e.Parameter.ToString());
            webView.DefaultBackgroundColor = backgroundColor;
        }


        void AddOrUpdateCookieCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            CoreWebView2Cookie cookie = webView.CoreWebView2.CookieManager.CreateCookie("CookieName", "CookieValue", ".bing.com", "/");
            webView.CoreWebView2.CookieManager.AddOrUpdateCookie(cookie);
        }

        void DeleteAllCookiesCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.CoreWebView2.CookieManager.DeleteAllCookies();
        }

        void DeleteCookiesCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.CoreWebView2.CookieManager.DeleteCookiesWithDomainAndPath("CookieName", ".bing.com", "/");
        }


        void DOMContentLoadedCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.CoreWebView2.DOMContentLoaded += (object sender, CoreWebView2DOMContentLoadedEventArgs arg) =>
            {
                _ = webView.ExecuteScriptAsync("let " +
                                          "content=document.createElement(\"h2\");content.style.color=" +
                                          "'blue';content.textContent= \"This text was added by the " +
                                          "host app\";document.body.appendChild(content);");
            };
            webView.NavigateToString(@"<!DOCTYPE html><h1>DOMContentLoaded sample page</h1><h2>The content below will be added after DOM content is loaded </h2>");
        }

        void PasswordAutosaveCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            WebViewSettings.IsPasswordAutosaveEnabled = !WebViewSettings.IsPasswordAutosaveEnabled;
        }
        void GeneralAutofillCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            WebViewSettings.IsGeneralAutofillEnabled = !WebViewSettings.IsGeneralAutofillEnabled;
        }



        void PinchZoomCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            WebViewSettings.IsPinchZoomEnabled = !WebViewSettings.IsPinchZoomEnabled;
            MessageBox.Show("Pinch Zoom is" + (WebViewSettings.IsPinchZoomEnabled ? " enabled " : " disabled ") + "after the next navigation.");
        }



        // Update download progress
        void UpdateProgress(CoreWebView2DownloadOperation download)
        {
            download.BytesReceivedChanged += delegate (object sender, Object e)
            {
                // Here developer can update download dialog to show progress of a
                // download using `download.BytesReceived` and `download.TotalBytesToReceive`
            };

            download.StateChanged += delegate (object sender, Object e)
            {
                switch (download.State)
                {
                    case CoreWebView2DownloadState.InProgress:
                        break;
                    case CoreWebView2DownloadState.Interrupted:
                        // Here developer can take different actions based on `download.InterruptReason`.
                        // For example, show an error message to the end user.
                        break;
                    case CoreWebView2DownloadState.Completed:
                        break;
                }
            };
        }

        // Turn off client certificate selection dialog using ClientCertificateRequested event handler
        // that disables the dialog. This example hides the default client certificate dialog and
        // always chooses the last certificate without prompting the user.
        private bool _isCustomClientCertificateSelection = false;
   

        void GoToPageCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && !_isNavigating;
        }
        void RefreshCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsWebViewValid() && !_isNavigating;
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
        void BackCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && webView.CanGoBack;
        }

        void BackCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.GoBack();
        }

        void HomeCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && !_isNavigating;
        }

        async void HomeCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async();

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
        }

        void ForwardCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = webView != null && webView.CanGoForward;
        }

        void ForwardCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.GoForward();
        }

        void RefreshCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            webView.Reload();
        }
        async void GoToPageCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async();

            var rawUrl = (string)e.Parameter;
            Uri uri = null;

            if (Uri.IsWellFormedUriString(rawUrl, UriKind.Absolute))
            {
                uri = new Uri(rawUrl);
            }
            else if (!rawUrl.Contains(" ") && rawUrl.Contains("."))
            {
                // An invalid URI contains a dot and no spaces, try tacking http:// on the front.
                uri = new Uri("http://" + rawUrl);
            }
            else
            {
                // Otherwise treat it as a web search.
                uri = new Uri("https://bing.com/search?q=" +
                    String.Join("+", Uri.EscapeDataString(rawUrl).Split(new string[] { "%20" }, StringSplitOptions.RemoveEmptyEntries)));
            }

            // Setting webView.Source will not trigger a navigation if the Source is the same
            // as the previous Source.  CoreWebView.Navigate() will always trigger a navigation.
            webView.CoreWebView2.Navigate(uri.ToString());
        }



        bool _allowWebViewShortcutKeys = true;
        bool _allowShortcutsEventRegistered = false;
        public bool AllowWebViewShortcutKeys
        {
            get => _allowWebViewShortcutKeys;
            set
            {
                _allowWebViewShortcutKeys = value;
                if (webView.CoreWebView2 != null)
                {
                    WebViewSettings.AreBrowserAcceleratorKeysEnabled = value;
                }
                else if (!_allowShortcutsEventRegistered)
                {
                    _allowShortcutsEventRegistered = true;
                    webView.CoreWebView2InitializationCompleted += (sender, e) =>
                    {
                        if (e.IsSuccess)
                        {
                            WebViewSettings.AreBrowserAcceleratorKeysEnabled = _allowWebViewShortcutKeys;
                        }
                    };
                }
            }
        }


        void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            _isNavigating = true;
            RequeryCommands();
        }

        void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            _isNavigating = false;
            RequeryCommands();
        }

        private bool shouldAttachEnvironmentEventHandlers = true;


        private bool shouldAttemptReinitOnBrowserExit = false;




        private void CloseWebViewForUpdate()
        {
            // We dispose of the control so the internal WebView objects are released
            // and the associated browser process exits.
            shouldAttemptReinitOnBrowserExit = true;
            RemoveControlFromVisualTree(webView);
            webView.Dispose();
        }

        private static void OnShowNextWebResponseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LogicView window = (LogicView)d;
            if ((bool)e.NewValue)
            {
                window.webView.CoreWebView2.WebResourceResponseReceived += window.CoreWebView2_WebResourceResponseReceived;
            }
            else
            {
                window.webView.CoreWebView2.WebResourceResponseReceived -= window.CoreWebView2_WebResourceResponseReceived;
            }
        }

        public static readonly DependencyProperty ShowNextWebResponseProperty = DependencyProperty.Register(
            nameof(ShowNextWebResponse),
            typeof(Boolean),
            typeof(LogicView),
            new PropertyMetadata(false, OnShowNextWebResponseChanged));

        public bool ShowNextWebResponse
        {
            get => (bool)this.GetValue(ShowNextWebResponseProperty);
            set => this.SetValue(ShowNextWebResponseProperty, value);
        }

        async void CoreWebView2_WebResourceResponseReceived(object sender, CoreWebView2WebResourceResponseReceivedEventArgs e)
        {
            ShowNextWebResponse = false;

            CoreWebView2WebResourceRequest request = e.Request;
            CoreWebView2WebResourceResponseView response = e.Response;

            string caption = "Web Resource Response Received";
            // Start with capacity 64 for minimum message size
            StringBuilder messageBuilder = new StringBuilder(64);
            string HttpMessageContentToString(System.IO.Stream content) => content == null ? "[null]" : "[data]";
            

            // Request
            messageBuilder.AppendLine("Request");
            messageBuilder.AppendLine($"URI: {request.Uri}");
            messageBuilder.AppendLine($"Method: {request.Method}");
            messageBuilder.AppendLine("Headers:");
         //  AppendHeaders(request.Headers);
            messageBuilder.AppendLine($"Content: {HttpMessageContentToString(request.Content)}");
            messageBuilder.AppendLine();

            // Response
            messageBuilder.AppendLine("Response");
            messageBuilder.AppendLine($"Status: {response.StatusCode}");
            messageBuilder.AppendLine($"Reason: {response.ReasonPhrase}");
            messageBuilder.AppendLine("Headers:");
          //  AppendHeaders(response.Headers);
            try
            {
                Stream content = await response.GetContentAsync();
                messageBuilder.AppendLine($"Content: {HttpMessageContentToString(content)}");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                messageBuilder.AppendLine($"Content: [failed to load]");
            }

            MessageBox.Show(messageBuilder.ToString(), caption);
        }

        void RequeryCommands()
        {
            // Seems like there should be a way to bind CanExecute directly to a bool property
            // so that the binding can take care keeping CanExecute up-to-date when the property's
            // value changes, but apparently there isn't.  Instead we listen for the WebView events
            // which signal that one of the underlying bool properties might have changed and
            // bluntly tell all commands to re-check their CanExecute status.
            //
            // Another way to trigger this re-check would be to create our own bool dependency
            // properties on this class, bind them to the underlying properties, and implement a
            // PropertyChangedCallback on them.  That arguably more directly binds the status of
            // the commands to the WebView's state, but at the cost of having an extraneous
            // dependency property sitting around for each underlying property, which doesn't seem
            // worth it, especially given that the WebView API explicitly documents which events
            // signal the property value changes.
            CommandManager.InvalidateRequerySuggested();
        }

        
      private const int WM_LBUTTONDOWN = 0x0201;

      private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_PARENTNOTIFY = 0x0210;
        protected IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_LBUTTONDOWN || msg == WM_RBUTTONDOWN || msg == WM_PARENTNOTIFY)
            {
                handled = true;
                return IntPtr.Zero;
            }

            return IntPtr.Zero;
        }

        private void webView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            //HwndSource hwnd = (HwndSource)PresentationSource.FromVisual(this);

            //if (hwnd != null)
            //{
            //    hwnd.AddHook(new HwndSourceHook(WndProc));
            //}
           

            JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(e.WebMessageAsJson);

            //switch (jsonObject[0].ToString())
            //{
            //    case "click":
            //        //MessageBox.Show(jsonObject.Value);
            //        break;

            //}


        }
    }

    //private void UserControl_Loaded(object sender, RoutedEventArgs e)
    //{
    //    (this.DataContext as LogicViewModel).Subscribe();
    //}

    //private void UserControl_Unloaded(object sender, RoutedEventArgs e)
    //{
    //    (this.DataContext as LogicViewModel).Unsubscribe();
    //}
}


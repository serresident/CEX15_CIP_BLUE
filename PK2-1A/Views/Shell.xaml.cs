using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using cip_blue.ViewModels;


namespace cip_blue.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        //A window receives this message when the user chooses a command from the Window menu, or when the user chooses the maximize button, minimize button, restore button, or close button.
        public const Int32 WM_SYSCOMMAND = 0x112;

        //Draws a horizontal dividing line.This flag is used only in a drop-down menu, submenu, or shortcut menu.The line cannot be grayed, disabled, or highlighted.
        public const Int32 MF_SEPARATOR = 0x800;

        //Specifies that an ID is a position index into the menu and not a command ID.
        public const Int32 MF_BYPOSITION = 0x400;


        //Specifies that the menu item is a text string.
        public const Int32 MF_STRING = 0x0;

        //Menu Ids for our custom menu items
        public const Int32 _UserItem = 1000;

        public Shell()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr systemMenuHandle = getSystemMenu(out HwndSource hwndSource);

            //Insert our custom menu items
            InsertMenu(systemMenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty); //Add a menu seperator
            InsertMenu(systemMenuHandle, 6, MF_BYPOSITION, _UserItem, userAutorizationStatus); //Add a setting menu item

            hwndSource.AddHook(new HwndSourceHook(WndProc));
            var secondScreen = Screen.AllScreens.Where(s => s.Primary).FirstOrDefault();

            if (secondScreen != null)
            {
                if(!this.IsLoaded)
                    this.WindowStartupLocation = WindowStartupLocation.Manual;

                var workingArea = secondScreen.WorkingArea;
                this.Left = workingArea.Left;
                this.Top = workingArea.Top;
                this.Width = workingArea.Width;
                this.Height = workingArea.Height;

                if (this.IsLoaded)
                    this.WindowState = WindowState.Maximized;
            }


            (this.DataContext as ShellViewModel).Subscribe();
            (this.DataContext as ShellViewModel).OnLoad();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (this.DataContext as ShellViewModel).OnClosing();
            (this.DataContext as ShellViewModel).Unsubscribe();

        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        [DllImport("user32.dll")]
        static extern bool ModifyMenu(IntPtr hMenu, Int32 uPosition, Int32 uFlags, Int32 uIDItem, string lpNewItem);

        private string userAutorizationStatus = "Log In";


        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Check if the SystemCommand message has been executed
            if (msg == WM_SYSCOMMAND)
            {
                //check which menu item was clicked
                switch (wParam.ToInt32())
                {
                    case _UserItem:

                        var dc = (DataContext as ShellViewModel);
                        if (dc.User.IsAuthorized)
                        {
                            userAutorizationStatus = "Log In";
                            dc.User.IsAuthorized = false;
                          
                    
                        }

                        else
                        {
                            // userAutorizationStatus = "Log In";
                            dc.InputPassword();
                            userAutorizationStatus = dc.User.IsAuthorized ? "Log Out" : "Log In";
                         
                        }

                        //dc.IsAuthorized = !dc.IsAuthorized;

                        IntPtr systemMenuHandle = getSystemMenu(out HwndSource hwndSource);

                        ModifyMenu(systemMenuHandle, 6, MF_BYPOSITION, _UserItem, userAutorizationStatus);

                        //ModifyMenu(systemMenuHandle, SC_MOVE, MF_BYCOMMAND | MF_GRAYED, 0, hwndSource. info.dwTypeData);
                        //ModifyMenu(systemMenuHandle, 6, MF_BYPOSITION, 6, "111");


                        handled = true;

                        //hwndSource.AddHook(new HwndSourceHook(WndProc));
                        break;
                }
            }
            control_panel.UpdateLayout();
            return IntPtr.Zero;
        }

        IntPtr getSystemMenu(out HwndSource hwndSource)
        {
            IntPtr windowhandle = new WindowInteropHelper(this).Handle;
            hwndSource = HwndSource.FromHwnd(windowhandle);

            //Get the handle for the system menu
            return GetSystemMenu(windowhandle, false);
        }

     
    }
}

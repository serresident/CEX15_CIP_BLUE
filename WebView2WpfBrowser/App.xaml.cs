// Copyright (C) Microsoft Corporation. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;

namespace WebView2WpfBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public bool newRuntimeEventHandled = false;

        public App()
        {
           // InitializeComponent();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LinkedList<ScreenInformation.WpfScreen> screens = ScreenInformation.GetAllScreens();

            try
            {
                
                var mon = screens.Where(t => t.metrics.top != 0 || t.metrics.left != 0).First();
                var window = new MainWindow();



                window.Top = mon.metrics.top;
                window.Left = mon.metrics.left;

                window.Show();
                window.WindowState = WindowState.Maximized;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message+ "/// " + screens.Count() + "counts // top " + screens.First().metrics.top.ToString() + "// left " + screens.First().metrics.left.ToString());
                var window = new MainWindow();



              

                window.Show();
                window.WindowState = WindowState.Maximized;
            }


            //foreach (var screen in screens)
            //{
            //    var window = new MainWindow();

            //    //Console.WriteLine("Metrics {0} {1}", screen.metrics.top, screen.metrics.left);

            //    window.Top = screen.metrics.top;
            //    window.Left = screen.metrics.left;

            //    window.Show();
            //    window.WindowState = WindowState.Maximized;
            //}
        }
    }

    public class ScreenInformation
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct ScreenRect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lpRect, MonitorEnumProc callback, int dwData);

        private delegate bool MonitorEnumProc(IntPtr hDesktop, IntPtr hdc, ref ScreenRect pRect, int dwData);

        public class WpfScreen
        {
            public WpfScreen(ScreenRect prect)
            {
                metrics = prect;
            }

            public ScreenRect metrics;
        }

        static LinkedList<WpfScreen> allScreens = new LinkedList<WpfScreen>();

        public static LinkedList<WpfScreen> GetAllScreens()
        {
            ScreenInformation.GetMonitorCount();
            return allScreens;
        }

        public static int GetMonitorCount()
        {
            allScreens.Clear();
            int monCount = 0;
            MonitorEnumProc callback = (IntPtr hDesktop, IntPtr hdc, ref ScreenRect prect, int d) =>
            {
                Console.WriteLine("Left {0}", prect.left);
                Console.WriteLine("Right {0}", prect.right);
                Console.WriteLine("Top {0}", prect.top);
                Console.WriteLine("Bottom {0}", prect.bottom);
                allScreens.AddLast(new WpfScreen(prect));
                return ++monCount > 0;
            };

            if (EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, callback, 0))
                Console.WriteLine("You have {0} monitors", monCount);
            else
                Console.WriteLine("An error occured while enumerating monitors");

            return monCount;
        }
    }

}

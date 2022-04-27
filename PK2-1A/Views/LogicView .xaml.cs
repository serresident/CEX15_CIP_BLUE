using cip_blue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for LogicView.xaml
    /// </summary>
    public partial class LogicView : UserControl
    {
        public LogicView()
        {
            InitializeComponent();
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
}

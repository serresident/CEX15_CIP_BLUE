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

namespace cip_blue.Dialogs
{
    /// <summary>
    /// Interaction logic for RebootDialog.xaml
    /// </summary>
    public partial class RebootDialog : UserControl
    {
        public RebootDialog()
        {
            InitializeComponent();
        }

        private void WatermarkPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (this.DataContext as RebootDialogViewModel).Password = _watermarkPasswordBox.Password;
        }

    }
}

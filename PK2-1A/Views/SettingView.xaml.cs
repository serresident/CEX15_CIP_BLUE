using cip_blue.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace cip_blue.Views
{
    /// <summary>
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        private readonly PropertyDefinition propertyDefinition;
        public SettingView(ProcessDataTcp pd)
        {
            InitializeComponent();
            propertyDefinition = new PropertyDefinition();
            foreach (PropertyInfo pi in pd.GetType().GetProperties())
            {

                if (pi.GetCustomAttribute<SettingAttribute>(false) != null)
                {
                    propertyDefinition.TargetProperties.Add(pi.Name);
                }
            }

            PG.PropertyDefinitions.Add(propertyDefinition);

            PG.SelectedObject = pd;

        }
        private void OnClose(object sender, RoutedEventArgs e)
        {
            PG.SelectedObject = null;
        }

    }
}

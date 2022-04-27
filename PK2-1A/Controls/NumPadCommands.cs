using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cip_blue.Controls
{
    public static class NumPadCommands
    {
        private static RoutedCommand _numPadButtonClickCommand = new RoutedCommand();

        public static RoutedCommand NumPadButtonClick
        {
            get
            {
                return _numPadButtonClickCommand;
            }
        }
    }

}

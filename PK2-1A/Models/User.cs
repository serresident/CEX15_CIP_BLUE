using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Models
{
    public class User : BindableBase
    {
        public bool isAuthorized = false;
        public bool IsAuthorized
        {
            get { return isAuthorized; }
            set { SetProperty(ref isAuthorized, value); }
        }
    }

}

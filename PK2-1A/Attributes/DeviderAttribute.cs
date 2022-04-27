using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DeviderAttribute : Attribute
    {
        private Single devider;

        public DeviderAttribute(Single devider)
        {
            this.devider = devider;
        }

        public virtual Single Devider
        {
            get { return devider; }
        }
    }

}

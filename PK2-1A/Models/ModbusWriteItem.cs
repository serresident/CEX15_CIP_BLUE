using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Models
{
    public enum Distination
    {
        COIL,
        HOLDING
    }
    public class ModbusWriteItem
    {
        public Distination Distination;
        public int Addr { get; set; }
        public object Val { get; set; }
    }

}

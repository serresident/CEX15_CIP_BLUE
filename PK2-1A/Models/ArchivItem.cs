using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Models
{
    public class ArchivItem
    {
        public ArchivItem()
        {
            MeasuresName = new List<string>();
            MeasuresCaption = new List<string>();
        }
        public string Title { get; set; }
        public List<string> MeasuresName { get; set; }
        public List<string> MeasuresCaption { get; set; }

        public double MaxY { get; set; }

        public bool IsGroup { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}

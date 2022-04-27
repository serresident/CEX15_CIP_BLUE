using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ArchivAttribute : Attribute
    {
        private string title;
        private string group;
        private double maxY;
        private string color;

        public ArchivAttribute(string title, double maxY = double.NaN, string group = "", string color = "LightSeaGreen")
        {
            this.title = title;
            this.maxY = maxY;
            this.group = group;
            this.color = color;
        }

        public virtual string Title
        {
            get { return title; }
        }

        public virtual string Group
        {
            get { return group; }
        }

        public virtual double MaxY
        {
            get { return maxY; }
        }

        public virtual string Color
        {
            get { return color; }
        }

        //public virtual Brush Color
        //{
        //    get
        //    {
        //        Color c = (Color)ColorConverter.ConvertFromString(color);
        //        return new SolidColorBrush(c);
        //    }
        //}

    }

}

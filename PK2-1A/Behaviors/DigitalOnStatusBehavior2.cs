using AITSW.PCPANEL.WPF;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PK2_1A.Behaviors
{
    public class DigitalOnStatusBehavior : Behavior<ControlBase>
    {
        private StatesStandard state;

        public static readonly DependencyProperty OnStatusProperty = DependencyProperty.Register("OnStatus", typeof(bool), typeof(DigitalOnStatusBehavior), new PropertyMetadata(false, (d, e) => ((DigitalOnStatusBehavior)d).Update()));

        //public static readonly DependencyProperty OnColor1Property = DependencyProperty.Register("OnColor1", typeof(System.Windows.Media.Color), typeof(DigitalOnStatusBehavior), new PropertyMetadata(System.Windows.Media.Colors.GreenYellow, (d, e) => ((DigitalOnStatusBehavior)d).UpdateColor()));
        //public static readonly DependencyProperty OnColor2Property = DependencyProperty.Register("OnColor2", typeof(System.Windows.Media.Color), typeof(DigitalOnStatusBehavior), new PropertyMetadata(System.Windows.Media.Colors.Transparent, (d, e) => ((DigitalOnStatusBehavior)d).UpdateColor()));

        //public System.Windows.Media.Color OnColor1
        //{
        //    get { return (System.Windows.Media.Color)GetValue(OnColor1Property); }
        //    set { SetValue(OnColor1Property, value); }
        //}

        //public System.Windows.Media.Color OnColor2
        //{
        //    get { return (System.Windows.Media.Color)GetValue(OnColor2Property); }
        //    set { SetValue(OnColor2Property, value); }
        //}

        private System.Windows.Media.Color onColor1;
        public System.Windows.Media.Color OnColor1
        {
            get { return onColor1; }
            set { onColor1 = value; }
        }

        private System.Windows.Media.Color onColor2;
        public System.Windows.Media.Color OnColor2
        {
            get { return onColor2; }
            set { onColor2 = value; }
        }


        private void Update()
        {
            if (AssociatedObject != null)
            {
                state.Active = OnStatus;
            }
        }

        //private void UpdateColor()
        //{
        //    if (AssociatedObject != null)
        //    {
        //        //this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1 };
        //        if (OnColor2 != System.Windows.Media.Colors.Transparent)
        //            this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1, Color2 = OnColor2, ColorMode = ColorMode.Pulse };
        //        else
        //            this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1 };
        //    }
        //}

        public bool OnStatus
        {
            get { return (bool)GetValue(OnStatusProperty); }
            set { SetValue(OnStatusProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.Colors = new ControlColors();

                if (OnColor2 != System.Windows.Media.Color.FromScRgb(0, 0, 0, 0))
                    this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1, Color2 = OnColor2, ColorMode = ColorMode.Pulse };
                else
                    this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1 };

                state = new StatesStandard();
                this.AssociatedObject.States = state;
            }
            Update();
        }

        protected override void OnDetaching()
        {
            //

            base.OnDetaching();
        }
    }
}

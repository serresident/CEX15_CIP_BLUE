using AITSW.PCPANEL.WPF;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace cip_blue.Behaviors
{
    public class DigitalOnStatusBehavior : Behavior<ControlBase>
    {
        //private StatesStandard state;
        private StatesBool state;

        public static readonly DependencyProperty OnStatusProperty = DependencyProperty.Register("OnStatus", typeof(bool), typeof(DigitalOnStatusBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((DigitalOnStatusBehavior)d).Update()));
        public bool OnStatus
        {
            get { return (bool)GetValue(OnStatusProperty); }
            set { SetValue(OnStatusProperty, value); }
        }

        public static readonly DependencyProperty isNotFeedbackProperty = DependencyProperty.Register("IsNotFeedback", typeof(bool), typeof(DigitalOnStatusBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((DigitalOnStatusBehavior)d).Update()));
        public bool IsNotFeedback
        {
            get { return (bool)GetValue(isNotFeedbackProperty); }
            set { SetValue(isNotFeedbackProperty, value); }
        }

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

        private System.Windows.Media.Color defaultColor;
        public System.Windows.Media.Color DefaultColor
        {
            get { return defaultColor; }
            set { defaultColor = value; }
        }

        private System.Windows.Media.Color notConnectColoring;
        public System.Windows.Media.Color NotConnectColoring
        {
            get { return notConnectColoring; }
            set { notConnectColoring = value; }
        }




        //private void Update()
        //{
        //    if (AssociatedObject != null)
        //    {
        //        //state.Active = OnStatus;
        //        //(this.AssociatedObject.States as StatesStandard).Active = OnStatus;
        //    }
        //}

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

        private void Update()
        {
            if (NotConnectColoring != System.Windows.Media.Color.FromScRgb(0, 0, 0, 0))
            {
                if (IsNotFeedback)
                {
                    this.AssociatedObject.Colors.State7Coloring = new ColoringColor() { Color1 = NotConnectColoring };
                    this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = NotConnectColoring };

                }
                    
                else
                {
                    this.AssociatedObject.Colors.State7Coloring = new ColoringColor() { Color1 = DefaultColor };
                    this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1 };
                }
                    
            }
             
           
            //state.Active = OnStatus;
            //(this.AssociatedObject.States as StatesStandard).Active = OnStatus;

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



        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.Colors = new ControlColors();

                if (OnColor2 != System.Windows.Media.Color.FromScRgb(0, 0, 0, 0))
                {
                    this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1, Color2 = OnColor2, ColorMode = ColorMode.Pulse };

                    //if (DefaultColor != System.Windows.Media.Color.FromScRgb(0, 0, 0, 0))
                    //    this.AssociatedObject.Colors.State7Coloring = new ColoringColor() { Color1 = DefaultColor }; //new ColoringColor() { Color1 = this.AssociatedObject.Colors...DefaultColoring..Col };

                }
                else
                {
                    this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = OnColor1 };

                    //if (DefaultColor != System.Windows.Media.Color.FromScRgb(0, 0, 0, 0))
                    //    this.AssociatedObject.Colors.State7Coloring = new ColoringColor() { Color1 = DefaultColor }; //new ColoringColor() { Color1 = this.AssociatedObject.Colors...DefaultColoring..Col };
                }

                if (DefaultColor != System.Windows.Media.Color.FromScRgb(0, 0, 0, 0))
                    this.AssociatedObject.Colors.State7Coloring = new ColoringColor() { Color1 = DefaultColor }; //new ColoringColor() { Color1 = this.AssociatedObject.Colors...DefaultColoring..Col };

                

                if (this.AssociatedObject.States == null)
                    state = new StatesBool();
                else
                    state = (StatesBool)this.AssociatedObject.States;

                state.State7 = true;

                this.AssociatedObject.States = state;

                //this.AssociatedObject.States = new StatesStandard();


                Binding binding = new Binding();
                binding.Source = this;
                binding.Path = new PropertyPath("OnStatus");
                binding.Mode = BindingMode.OneWay;
                binding.IsAsync = true;
                binding.FallbackValue = false;
                BindingOperations.SetBinding(state, StatesBool.State4Property, binding);
                //Binding binding2 = new Binding();
                //binding2.Source = this;
                //binding2.Path = new PropertyPath("IsNotFeedback");
                //binding2.Mode = BindingMode.OneWay;
                //binding2.IsAsync = true;
                //binding2.FallbackValue = false;
                //BindingOperations.SetBinding(state, StatesBool.State4Property, binding2);
                Update();
            }
            
        }

        protected override void OnDetaching()
        {
            //

            base.OnDetaching();
        }
    }
}

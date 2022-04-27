using AITSW.PCPANEL.WPF;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cip_blue.Behaviors
{
    public class DigitalActuatorStatusBehavior : Behavior<ControlBase>
    {
        private StatesStandard actuatorState;

        public static readonly DependencyProperty OnSignalProperty = DependencyProperty.Register("OnSignal", typeof(bool), typeof(DigitalActuatorStatusBehavior), new PropertyMetadata(false, (d, e) => ((DigitalActuatorStatusBehavior)d).Update()));
        public bool OnSignal
        {
            get { return (bool)GetValue(OnSignalProperty); }
            set { SetValue(OnSignalProperty, value); }
        }

        public static readonly DependencyProperty OffSignalProperty = DependencyProperty.Register("OffSignal", typeof(bool), typeof(DigitalActuatorStatusBehavior), new PropertyMetadata(false, (d, e) => ((DigitalActuatorStatusBehavior)d).Update()));
        public bool OffSignal
        {
            get { return (bool)GetValue(OffSignalProperty); }
            set { SetValue(OffSignalProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AssociatedObject != null)
            {

                this.AssociatedObject.Colors = new ControlColors();
                this.AssociatedObject.Colors.State4Coloring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                this.AssociatedObject.Colors.State1Coloring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Red, ColorMode = ColorMode.Blink, Frequency = 1 };
                this.AssociatedObject.Colors.State7Coloring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Red };
                actuatorState = new StatesStandard();
                this.AssociatedObject.States = actuatorState;
            }

            Update();
        }


        protected override void OnDetaching()
        {

            base.OnDetaching();
        }


        private void Update()
        {
            if (AssociatedObject != null)
            {
                actuatorState.Critical = OffSignal == OnSignal;
                actuatorState.Active = OnSignal;
                actuatorState.Standby = OffSignal;

            }
        }

    }

}

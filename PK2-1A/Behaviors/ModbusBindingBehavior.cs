using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using cip_blue.Controls;
using Xceed.Wpf.Toolkit;

namespace cip_blue.Behaviors
{
    public class ModbusBindingBehavior : Behavior<NumPadUpDown>
    {
        private static decimal? befoareAttachValue;

        public static readonly DependencyProperty InternalValueProperty =
                               DependencyProperty.Register("InternalValue", typeof(Single), typeof(ModbusBindingBehavior),
                                   new FrameworkPropertyMetadata(Single.NaN, valueChangedCallback)
                                   {
                                       BindsTwoWayByDefault = true,
                                       DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                                   });

        public Single InternalValue
        {
            get { return (Single)GetValue(InternalValueProperty); }
            set { SetValue(InternalValueProperty, value); }
        }

        private static void valueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumPadUpDown num = ((ModbusBindingBehavior)d).AssociatedObject as NumPadUpDown;
            if (!Single.IsNaN((Single)e.NewValue))
            {
                if (num != null && e.NewValue != e.OldValue)
                    num.Value = Convert.ToDecimal(e.NewValue);
                else
                    befoareAttachValue = Convert.ToDecimal(e.NewValue);
            }
        }

        protected override void OnAttached()
        {
            if (this.AssociatedObject != null)
            {
                base.OnAttached();

                if (befoareAttachValue.HasValue)
                    AssociatedObject.Value = befoareAttachValue.Value;

                //AssociatedObject.CultureInfo = CultureInfo.InvariantCulture;

                AssociatedObject.Spinned += onSpinned;
                AssociatedObject.ValueChanged += onValueChanged;
            }
        }

        private void onSpinned(object sender, SpinEventArgs e)
        {
            ((NumPadUpDown)sender).UpdateValueOnEnterKey = false;
        }

        private void onValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            InternalValue = Decimal.ToSingle((decimal)e.NewValue);
            ((NumPadUpDown)sender).UpdateValueOnEnterKey = true;
        }


        protected override void OnDetaching()
        {
            if (this.AssociatedObject != null)
            {
                AssociatedObject.Spinned -= onSpinned;
                AssociatedObject.ValueChanged -= onValueChanged;
                base.OnDetaching();
            }
        }

        //private void lostFocus()
        //{
        //    // Kill logical focus
        //    FocusManager.SetFocusedElement(FocusManager.GetFocusScope(AssociatedObject), null);
        //    // Kill keyboard focus
        //    Keyboard.ClearFocus();

        //}

    }
}

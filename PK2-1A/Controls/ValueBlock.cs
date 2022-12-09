using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace cip_blue.Controls
{
    [TemplatePart(Name = "PART_Caption", Type = typeof(TextBox))]
    public class ValueBlock : Control
    {
        public string Caption
        {
            get { return (string)this.GetValue(CaptionProperty); }
            set { this.SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
          "Caption", typeof(string), typeof(ValueBlock), new PropertyMetadata(string.Empty));


        public string Value
        {
            get { return (string)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
          "Value", typeof(string), typeof(ValueBlock), new UIPropertyMetadata("0.0", onValueChanged));

        float mem_plus;
        private static void onValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          


            if (e.NewValue.ToString() != "???")
                if (e.NewValue.ToString() != "NaN")
                    if (float.Parse(e.NewValue.ToString()) < float.Parse("-9998"))
                    {
                       
                        (d as ValueBlock).ValueColor = Brushes.Yellow;
                        (d as ValueBlock).SetCurrentValue(ValueProperty, "???");


                        if (float.Parse(e.NewValue.ToString()) == float.Parse("-10000"))
                            (d as ValueBlock).ValueColor = Brushes.PaleVioletRed;

                        //  (d as ValueBlock).ToolTip = "Сигнал вне диапазона 4-20ма.\n Требуется диагностика КИПиА";
                        ToolTip tt = new ToolTip();


                        tt.Content = "Сигнал вне диапазона 4-20ма.\n Требуется диагностика КИПиА";

                        if (float.Parse(e.NewValue.ToString()) == float.Parse("-10000"))
                        {
                            tt.Content = "нет питания";
                           
                        }    
                           


                        (d as ValueBlock).ToolTip = tt;
                        tt.Foreground = Brushes.Red;
                        //    tt.StaysOpen = true;
                    }
                 else
                    {
                        (d as ValueBlock).ValueColor = Brushes.LawnGreen;
                        (d as ValueBlock).ToolTip = "Значение получаемое с модуля";
                        //(d as ValueBlock).BeginStoryboard


                    }
                         
        }

        public string Unit
        {
            get { return (string)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
          "Unit", typeof(string), typeof(ValueBlock), new PropertyMetadata(string.Empty));

        public Brush ValueColor
        {
            get { return (System.Windows.Media.Brush)this.GetValue(ValueColorProperty); }
            set { this.SetValue(ValueColorProperty, value); }
        }
        public static readonly DependencyProperty ValueColorProperty = DependencyProperty.Register(
            "ValueColor", typeof(Brush), typeof(ValueBlock), new PropertyMetadata(new SolidColorBrush(Colors.Green)));

        static ValueBlock()
        {
            ForegroundProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata(Brushes.White, OnForegroundChanged));
            WidthProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata((double)100));
            HeightProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata((double)50));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata(typeof(ValueBlock)));

        }

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            MethodInfo mi = typeof(DependencyPropertyChangedEventArgs).GetMethod("get_OperationType",
                                                                                  BindingFlags.NonPublic |
                                                                                  BindingFlags.Instance);
            var v = mi.Invoke(e, null);

            if ((e.NewValue != Brushes.White) && (v.ToString() == "AddChild"))
            {
                ((ValueBlock)d).Foreground = Brushes.White;
            }
            else
            {
                ((ValueBlock)d).Foreground = (SolidColorBrush)(e.NewValue);
            }
        }
    }



}

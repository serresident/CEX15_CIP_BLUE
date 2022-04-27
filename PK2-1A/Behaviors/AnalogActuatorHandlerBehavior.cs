using AITSW.PCPANEL.WPF;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using cip_blue.Controls;

namespace cip_blue.Behaviors
{
    public class AnalogActuatorHandlerBehavior : Behavior<ControlBase>
    {
        private OptionsBehavior handleControlBehavior;

        private Popup popupPanel;
        private Border manualActivateBorder;
        private TextBlock manualTextBlock;

        public static readonly DependencyProperty IsManProperty = DependencyProperty.Register("IsMan", typeof(bool), typeof(AnalogActuatorHandlerBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) => ((AnalogActuatorHandlerBehavior)d).Update()));
        public bool IsMan
        {
            get { return (bool)GetValue(IsManProperty); }
            set { SetValue(IsManProperty, value); }
        }

        public static readonly DependencyProperty OutProperty = DependencyProperty.Register("Out", typeof(Single), typeof(AnalogActuatorHandlerBehavior), new FrameworkPropertyMetadata(default(Single), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Single Out
        {
            get { return (Single)GetValue(OutProperty); }
            set { SetValue(OutProperty, value); }
        }

        private System.Windows.Controls.Primitives.PlacementMode placementMode = System.Windows.Controls.Primitives.PlacementMode.Bottom;
        public System.Windows.Controls.Primitives.PlacementMode PlacementMode
        {
            get { return placementMode; }
            set
            {
                placementMode = value;
            }
        }


        private string units = "%";
        public string Units
        {
            get { return units; }
            set
            {
                units = value;
            }
        }

        private decimal maxValue = 100;
        public decimal MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
            }
        }

        private int hspacing = 10; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing
        {
            get { return hspacing; }
            set
            {
                hspacing = value;
            }
        }

        private int vspacing = 10; // сдвиг метки( А -Р) по вертикали
        public int VSpacing
        {
            get { return vspacing; }
            set
            {
                vspacing = value;
            }
        }


        private int popShiftH = 10; // сдвиг метки( А -Р) по горизонтали
        public int PopShiftH
        {
            get { return popShiftH; }
            set
            {
                hspacing = value;
            }
        }

        private int popShiftW = 10; // сдвиг метки( А -Р) по вертикали
        public int PopShiftW
        {
            get { return popShiftW; }
            set
            {
                popShiftW = value;
            }
        }


        private bool showAutoLabel = false;
        public bool ShowAutoLabel
        {
            get { return showAutoLabel; }
            set
            {
                showAutoLabel = value;
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AssociatedObject != null)
            {

                this.AssociatedObject.Cursor = Cursors.Hand;

                //popup
                popupPanel = new Popup();
                popupPanel.AllowsTransparency = true;

                Border popupBorder = new Border();
                popupBorder.BorderBrush = Brushes.DimGray;
                popupBorder.BorderThickness = new Thickness(2, 2, 2, 2);
                popupBorder.Background = Brushes.LemonChiffon; //Brushes.PeachPuff;
                popupBorder.CornerRadius = new CornerRadius(3);

                StackPanel layout = new StackPanel();
                layout.Orientation = Orientation.Vertical;
                layout.Margin = new Thickness(10, 10, 10, 10);

                Xceed.Wpf.Toolkit.MaterialCheckBox popupCheckBox = new Xceed.Wpf.Toolkit.MaterialCheckBox();
                popupCheckBox.IsThreeState = false;
                popupCheckBox.Content = "Ручной режим";

                Binding binding = new Binding();// ("IsMan");
                binding.Source = this;
                binding.Path = new PropertyPath("IsMan");
                BindingOperations.SetBinding(popupCheckBox, CheckBox.IsCheckedProperty, binding);

                //Xceed.Wpf.Toolkit.ToggleSwitch popupToggleSwitch = new Xceed.Wpf.Toolkit.ToggleSwitch();
                //popupToggleSwitch.Width = 80;
                //popupToggleSwitch.Height = 25;
                //popupToggleSwitch.ThumbHeight = 25;
                //popupToggleSwitch.ThumbWidth = 24;
                //popupToggleSwitch.Margin = new Thickness(0, 5, 0, 0);
                //popupToggleSwitch.CheckedContent = CheckedLabel;
                //popupToggleSwitch.UncheckedContent = UncheckedLabel;
                //popupToggleSwitch.CheckedBackground = Brushes.Lime;
                //popupToggleSwitch.UncheckedBackground = Brushes.LightPink;

                //Binding binding2 = new Binding();
                //binding2.Source = this;
                //binding2.Path = new PropertyPath("Out");
                //binding2.Mode = BindingMode.TwoWay;
                //popupToggleSwitch.SetBinding(Xceed.Wpf.Toolkit.ToggleSwitch.IsCheckedProperty, binding2);

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Margin = new Thickness(0, 5, 0, 0);

                NumPadUpDown popupNumPadUpDown = new NumPadUpDown();
                popupNumPadUpDown.VerticalAlignment = VerticalAlignment.Center;
                popupNumPadUpDown.Width = 100;
                //popupCalculatorUpDown.Margin = new Thickness(0, 5, 0, 0);
                popupNumPadUpDown.FormatString = "F1";
                popupNumPadUpDown.Increment = 1;
                popupNumPadUpDown.Minimum = 0;
                popupNumPadUpDown.Maximum = MaxValue;
                popupNumPadUpDown.EnterClosesNumPad = true;
                popupNumPadUpDown.UpdateValueOnEnterKey = true;
              //  popupNumPadUpDown.Foreground = Brushes.Black;
                Binding binding2 = new Binding();
                binding2.Source = this;
                binding2.Path = new PropertyPath("Out");
                binding2.Mode = BindingMode.TwoWay;
                popupNumPadUpDown.SetBinding(NumPadUpDown.ValueProperty, binding2);

                //close button
                Xceed.Wpf.Toolkit.MaterialButton popupCloseButton = new Xceed.Wpf.Toolkit.MaterialButton();
                popupCloseButton.Content = "X";
                popupCloseButton.Width = 20;
                popupCloseButton.Height = 20;
                //  popupCloseButton.MaterialForeground= Brushes.White;
                popupCloseButton.MaterialAccentBrush = Brushes.Red;
                popupCloseButton.Foreground = Brushes.White;
                popupCloseButton.HorizontalAlignment = HorizontalAlignment.Right;
                popupCloseButton.Click += (o, e) =>
                {
                    popupPanel.IsOpen = false;
                };

                //settings
                Expander settings = new Expander();
                settings.Visibility = Visibility.Collapsed;

                TextBlock unitsText = new TextBlock();
                unitsText.VerticalAlignment = VerticalAlignment.Center;
                unitsText.Margin = new Thickness(5, 0, 0, 0);
                unitsText.FontWeight = FontWeights.Bold;
                unitsText.Text = Units;

                stackPanel.Children.Add(popupNumPadUpDown);
                stackPanel.Children.Add(unitsText);

                layout.Children.Add(popupCloseButton);
                layout.Children.Add(popupCheckBox);
                layout.Children.Add(stackPanel);

                layout.Children.Add(settings);

                popupBorder.Child = layout;

                popupPanel.Child = popupBorder;

                popupPanel.PlacementTarget = this.AssociatedObject;
                popupPanel.Placement = PlacementMode;
          //    popupPanel.MouseMove += new MouseEventHandler(pop_MouseMove);

                handleControlBehavior = new OptionsBehavior();
                handleControlBehavior.FeedbackOnPressed = true;
                this.AssociatedObject.OptionsBehavior = handleControlBehavior;


                // для ручного режима
                var position = AssociatedObject.Height;

                manualActivateBorder = new Border();
                manualActivateBorder.BorderThickness = new Thickness(1);
                manualActivateBorder.BorderBrush = Brushes.Black;

                manualTextBlock = new TextBlock();
                manualTextBlock.Foreground = Brushes.Black;
                manualTextBlock.FontWeight = FontWeights.Bold;
                manualTextBlock.VerticalAlignment = VerticalAlignment.Center;
                manualTextBlock.HorizontalAlignment = HorizontalAlignment.Center;

                manualActivateBorder.Child = manualTextBlock;
                manualActivateBorder.Height = 18;
                manualActivateBorder.Width = 18;

                var left = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(manualActivateBorder, left + HSpacing);
                var top = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(manualActivateBorder, top + VSpacing);

                var canvas = (Canvas)(AssociatedObject.Parent);

                canvas.Children.Add(manualActivateBorder);

                //var idx1 = Canvas.GetZIndex(AssociatedObject);
                //Canvas.SetZIndex(AssociatedObject, 1);
                //Canvas.SetZIndex(manualActivateBorder, 0);


                this.AssociatedObject.Click += onClick;

                Update();
            }


        }


        private void OnUIReady(object sender, System.EventArgs e)
        {
            popupPanel.Width = ((Canvas)popupPanel.Parent).ActualWidth;
            popupPanel.Height = ((Canvas)popupPanel.Parent).ActualHeight;
           
        }

        void pop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                popupPanel.PlacementRectangle = new Rect(new Point(e.GetPosition((Canvas)popupPanel.Parent).X,
                    e.GetPosition((Canvas)popupPanel.Parent).Y), new Point(1, 1));

            }
        }



        private void onClick(object sender, RoutedEventArgs e)
        {
            popupPanel.IsOpen = !popupPanel.IsOpen;
            //Out = true;
        }

        protected override void OnDetaching()
        {

            this.AssociatedObject.Click -= onClick;

            base.OnDetaching();
        }

        private void Update()
        {
            if (AssociatedObject != null)
            {
                if (IsMan)
                {
                    manualActivateBorder.Visibility = Visibility.Visible;
                    manualActivateBorder.Background = Brushes.Yellow;
                    manualTextBlock.Text = "Р";
                }
                else
                {
                    if (!ShowAutoLabel)
                        manualActivateBorder.Visibility = Visibility.Hidden;
                    else
                        manualActivateBorder.Visibility = Visibility.Visible;
                    manualActivateBorder.Background = Brushes.Lime;
                    manualTextBlock.Text = "A";
                }
            }
        }

    }

}

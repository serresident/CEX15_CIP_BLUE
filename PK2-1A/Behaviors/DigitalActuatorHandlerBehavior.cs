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
using Xceed.Wpf.Toolkit;

namespace cip_blue.Behaviors
{
    public class DigitalActuatorHandlerBehavior : Behavior<ControlBase>
    {
        private OptionsBehavior handleControlBehavior;

        private Popup popupPanel;
        private Border manualActivateBorder;
        private TextBlock manualTextBlock;

        public static readonly DependencyProperty IsManProperty = DependencyProperty.Register("IsMan", typeof(bool), typeof(DigitalActuatorHandlerBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) => ((DigitalActuatorHandlerBehavior)d).Update()));
        public bool IsMan
        {
            get { return (bool)GetValue(IsManProperty); }
            set { SetValue(IsManProperty, value); }
        }

        public static readonly DependencyProperty OutProperty = DependencyProperty.Register("Out", typeof(bool), typeof(DigitalActuatorHandlerBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool Out
        {
            get { return (bool)GetValue(OutProperty); }
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

        private string checkedLabel = "ОТКР";
        public string CheckedLabel
        {
            get { return checkedLabel; }
            set
            {
                checkedLabel = value;
            }
        }

        private string uncheckedLabel = "ЗАКР";
        public string UncheckedLabel
        {
            get { return uncheckedLabel; }
            set
            {
                uncheckedLabel = value;
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

                ChildWindow window = new ChildWindow();
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

                Xceed.Wpf.Toolkit.ToggleSwitch popupToggleSwitch = new Xceed.Wpf.Toolkit.ToggleSwitch();
                popupToggleSwitch.Width = 100;
                popupToggleSwitch.Height = 25;
                popupToggleSwitch.CornerRadius = new CornerRadius(2);
                popupToggleSwitch.ThumbHeight = 25;
                popupToggleSwitch.ThumbWidth = 24;
                popupToggleSwitch.Margin = new Thickness(0, 5, 0, 0);
                popupToggleSwitch.CheckedContent = CheckedLabel;
                popupToggleSwitch.UncheckedContent = UncheckedLabel;
                popupToggleSwitch.CheckedBackground = Brushes.Lime;
                popupToggleSwitch.UncheckedBackground = Brushes.LightPink;

                Binding binding2 = new Binding();
                binding2.Source = this;
                binding2.Path = new PropertyPath("Out");
                binding2.Mode = BindingMode.TwoWay;
                popupToggleSwitch.SetBinding(Xceed.Wpf.Toolkit.ToggleSwitch.IsCheckedProperty, binding2);



                layout.Children.Add(popupCloseButton);
              //  layout.Children.Add(popupCheckBox);
                layout.Children.Add(popupToggleSwitch);
                popupBorder.Child = layout;

                popupPanel.Child = popupBorder;

                popupPanel.PlacementTarget = this.AssociatedObject;
                popupPanel.Placement = PlacementMode;


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
                manualActivateBorder.Height = 14;
                manualActivateBorder.Width = 14;

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

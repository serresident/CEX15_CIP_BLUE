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
using System.Windows.Shapes;

namespace cip_blue.Behaviors
{
    public class Digital_OnOFF_status : Behavior<ControlBase>
    {
        private OptionsBehavior handleControlBehavior;

        private Popup popupPanel;
        private Border openBorder;
        private Border closeBorder;
        private TextBlock openTextBlock;
        private TextBlock closeTextBlock;
        private Arrow open;

        public static readonly DependencyProperty isOpenValveProperty = DependencyProperty.Register("isOpenValve", typeof(bool), typeof(Digital_OnOFF_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) => ((Digital_OnOFF_status)d).Update()));
        public bool isOpenValve
        {
            get { return (bool)GetValue(isOpenValveProperty); }
            set { SetValue(isOpenValveProperty, value); }
        }

        public static readonly DependencyProperty isCloseValveProperty = DependencyProperty.Register("isCloseValve", typeof(bool), typeof(Digital_OnOFF_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) => ((Digital_OnOFF_status)d).Update()));
        public bool isCloseValve
        {
            get { return (bool)GetValue(isCloseValveProperty); }
            set { SetValue(isCloseValveProperty, value); }
        }

        private System.Windows.Controls.Primitives.PlacementMode placementMode = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
        public System.Windows.Controls.Primitives.PlacementMode PlacementMode
        {
            get { return placementMode; }
            set
            {
                placementMode = value;
            }
        }


        private int hspacing = -14; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing
        {
            get { return hspacing; }
            set
            {
                hspacing = value;
            }
        }

        private int vspacing1 = 30; // сдвиг метки( А -Р) по вертикали
        public int VSpacing1
        {
            get { return vspacing1; }
            set
            {
                vspacing1 = value;
            }
        }





        private int hspacing1 = -14; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing1
        {
            get { return hspacing1; }
            set
            {
                hspacing1 = value;
            }
        }

        private int vspacing = -5; // сдвиг метки( А -Р) по вертикали
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



                //  popupPanel.IsOpen =! popupCloseButton.IsEnabledChanged;

                //Binding binding = new Binding();// ("IsMan");
                //binding.Source = this;
                //binding.Path = new PropertyPath("IsMan");
                //BindingOperations.SetBinding(popupCheckBox, CheckBox.IsCheckedProperty, binding);

                Xceed.Wpf.Toolkit.ToggleSwitch popupToggleSwitch = new Xceed.Wpf.Toolkit.ToggleSwitch();
                popupToggleSwitch.Width = 100;
                popupToggleSwitch.Height = 25;
                popupToggleSwitch.CornerRadius = new CornerRadius(2);
                popupToggleSwitch.ThumbHeight = 25;
                popupToggleSwitch.ThumbWidth = 24;
                popupToggleSwitch.Margin = new Thickness(0, 10, 0, 0);
                popupToggleSwitch.CheckedContent = CheckedLabel;
                popupToggleSwitch.UncheckedContent = UncheckedLabel;
                popupToggleSwitch.CheckedBackground = Brushes.Lime;
                popupToggleSwitch.UncheckedBackground = Brushes.LightPink;

                Binding binding2 = new Binding();
                binding2.Source = this;
                binding2.Path = new PropertyPath("Out");
                binding2.Mode = BindingMode.TwoWay;
                popupToggleSwitch.SetBinding(Xceed.Wpf.Toolkit.ToggleSwitch.IsCheckedProperty, binding2);



                //   layout.Children.Add(popupCheckBox);
                layout.Children.Add(popupCloseButton);
                layout.Children.Add(popupToggleSwitch);

                popupBorder.Child = layout;

                popupPanel.Child = popupBorder;

                popupPanel.PlacementTarget = this.AssociatedObject;
                popupPanel.Placement = PlacementMode.Bottom;


                handleControlBehavior = new OptionsBehavior();
                handleControlBehavior.FeedbackOnPressed = true;
                this.AssociatedObject.OptionsBehavior = handleControlBehavior;



                // для ручного режима
                var position = AssociatedObject.Height;

                openBorder = new Border();
                openBorder.BorderThickness = new Thickness(1);
                openBorder.BorderBrush = Brushes.Black;

                openTextBlock = new TextBlock();
                openTextBlock.Foreground = Brushes.Black;
                openTextBlock.FontWeight = FontWeights.Bold;
                openTextBlock.VerticalAlignment = VerticalAlignment.Center;
                openTextBlock.HorizontalAlignment = HorizontalAlignment.Center;

                open = new Arrow();
                open.RotateAngle = 90;

                open.Colors = new ControlColors();
                open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                open.Width = 22;
                open.Height = 22;

                openBorder.Child = openTextBlock;
                openBorder.Height = 14;
                openBorder.Width = 14;
                openBorder.CornerRadius = new CornerRadius(15);


              
                closeBorder = new Border();
                closeBorder.BorderThickness = new Thickness(1);
                closeBorder.BorderBrush = Brushes.Black;

                closeTextBlock = new TextBlock();
                closeTextBlock.Foreground = Brushes.Black;
                closeTextBlock.FontWeight = FontWeights.Bold;
                closeTextBlock.VerticalAlignment = VerticalAlignment.Center;
                closeTextBlock.HorizontalAlignment = HorizontalAlignment.Center;

                closeBorder.Child = closeTextBlock;
                closeBorder.Height = 13;
                closeBorder.Width = 13;
                closeBorder.CornerRadius = new CornerRadius(15);

                var left = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(openBorder, left + HSpacing);
                var top = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(openBorder, top + VSpacing);

                var left1 = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(closeBorder, left1 + HSpacing1);
                var top1 = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(closeBorder, top1 + VSpacing1);

                var left2 = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(open, left1 + HSpacing1);
                var top2= Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(open, top1 + VSpacing1);

                var canvas = (Canvas)(AssociatedObject.Parent);

                canvas.Children.Add(openBorder);
                canvas.Children.Add(closeBorder);
                canvas.Children.Add(open);

                openBorder.Visibility = Visibility.Visible;
                openTextBlock.Foreground = Brushes.White; ;
                openTextBlock.Text = "О";

                closeBorder.Visibility = Visibility.Visible;
                closeTextBlock.Foreground = Brushes.White; ;
                closeTextBlock.Text = "З";
                //var idx1 = Canvas.GetZIndex(AssociatedObject);
                //Canvas.SetZIndex(AssociatedObject, 1);
                //Canvas.SetZIndex(openBorder, 0);


                // this.AssociatedObject.Click += onClick;

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

           // this.AssociatedObject.Click -= onClick;

            base.OnDetaching();
        }


        private void Update()
        {
            if (AssociatedObject != null)
            {
                if (isOpenValve)
                {
                   
                    openBorder.Background = Brushes.Green;
                    open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Gray };

                }
                else
                {
                    openBorder.Background = Brushes.Gray;
                    open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Gray };
                }    
                



                 if (isCloseValve)
                {
                    
                    closeBorder.Background = Brushes.Red;
                  
                }
                else
                {
                  
                    closeBorder.Background = Brushes.Gray;

                }
                   

              
            }
        }

    }

}

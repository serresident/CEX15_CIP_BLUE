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
    public class Valve_status : Behavior<ControlBase>
    {
        private OptionsBehavior handleControlBehavior;

        private Popup popupPanel;
        private Border openBorder;
        private Border closeBorder;
        private TextBlock openTextBlock;
        private TextBlock closeTextBlock;
        private Arrow open;
        private Arrow close;
        private ColoringColor red = new ColoringColor() { Color1 = System.Windows.Media.Colors.Red };
        private ColoringColor green = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
        private ColoringColor darkSlateGray = new ColoringColor() { Color1 = System.Windows.Media.Colors.DarkSlateGray };
        private ColoringColor WarningColor = new ColoringColor() { Color1 = System.Windows.Media.Colors.DarkOrange };
        public static readonly DependencyProperty isOpenValveProperty = DependencyProperty.Register("isOpenValve", typeof(bool), typeof(Valve_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((Valve_status)d).Update()));
        public bool isOpenValve
        {
            get { return (bool)GetValue(isOpenValveProperty); }
            set { SetValue(isOpenValveProperty, value); }
        }

        public static readonly DependencyProperty isCloseValveProperty = DependencyProperty.Register("isCloseValve", typeof(bool), typeof(Valve_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((Valve_status)d).Update()));
        public bool isCloseValve
        {
            get { return (bool)GetValue(isCloseValveProperty); }
            set { SetValue(isCloseValveProperty, value); }
        }
        public static readonly DependencyProperty isNotFeedbackProperty = DependencyProperty.Register("isNotFeedback", typeof(bool), typeof(Valve_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, (d, e) => ((Valve_status)d).Update()));
        public bool isNotFeedback
        {
            get { return (bool)GetValue(isNotFeedbackProperty); }
            set { SetValue(isNotFeedbackProperty, value); }
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


        private int hspacing = 18; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing
        {
            get { return hspacing; }
            set
            {
                hspacing = value;
            }
        }


        private int rotareAngleOpen = -90; // 
        public int RotareAnggeOpen
        {
            get { return rotareAngleOpen; }
            set
            {
                rotareAngleOpen = value;
            }
        }
        private int rotareAngleClose = 90; // 
        public int RotareAnggeClose
        {
            get { return rotareAngleClose; }
            set
            {
                rotareAngleClose = value;
            }
        }

        private int vspacing1 = 4; // сдвиг метки( А -Р) по вертикали
        public int VSpacing1
        {
            get { return vspacing1; }
            set
            {
                vspacing1 = value;
            }
        }





        private int hspacing1 = 18; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing1
        {
            get { return hspacing1; }
            set
            {
                hspacing1 = value;
            }
        }

        private int vspacing = 18; // сдвиг метки( А -Р) по вертикали
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




                handleControlBehavior = new OptionsBehavior();
                handleControlBehavior.FeedbackOnPressed = true;
                this.AssociatedObject.OptionsBehavior = handleControlBehavior;



                // для ручного режима
                var position = AssociatedObject.Height;


                open = new Arrow();
                open.RotateAngle = RotareAnggeOpen;

                open.Colors = new ControlColors();
                //open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                open.Width = 18;
                open.Height = 18;
                open .ToolTip = "Состояние концевика клапана \n на ОТКРЫТИЕ \n ( ЗЕЛЕНЫЙ = Сигнал подается /СЕРЫЙ= Сигнала не подается)\n Если ОРАНЖЕВЫЙ - нет связи с модулем ,  за устранением в обратитесь службу КИПиА ";
                
                close = new Arrow();
                close.RotateAngle = RotareAnggeClose;
                close.ToolTip = "Состояние концевика клапана \n на ЗАКРЫТИЕ \n ( КРАСНЫЙ =  Сигнал подается/СЕРЫЙ= Сигнала не подается) \n Если ОРАНЖЕВЫЙ нет связи с модулем, за устранением в обратитесь службу КИПиА";
                close.Colors = new ControlColors();
                //open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                close.Width = 18;
                close.Height = 18;



                var left = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(open, left + HSpacing);
                var top = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(open, top + VSpacing);

                var left1 = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(close, left1 + HSpacing1);
                var top1 = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(close, top1 + VSpacing1);



                var canvas = (Canvas)(AssociatedObject.Parent);


                canvas.Children.Add(open);
                canvas.Children.Add(close);


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

                    open.Colors.DefaultColoring = green;
                    open.ToolTip = "Состояние концевика ОТКРЫТИЯ: контакт  ЗАМКНУТ"; 


                }
                else
                {
                    if (!isNotFeedback)
                    {
                        open.Colors.DefaultColoring = darkSlateGray;
                        open.ToolTip = "Состояние концевика ОТКРЫТИЯ: контакт  РАЗОМКНУТ";
                    }
                       
                    else
                    {
                        open.Colors.DefaultColoring = WarningColor;
                        open.ToolTip = "Состояние концевика ОТКРЫТИЯ:нет связи с модулем ,  за устранением в обратитесь службу КИПиА ";
                    }
                        
                }




                if (isCloseValve)
                {


                    close.Colors.DefaultColoring = red;
                    close.ToolTip = "Состояние концевика ЗАКРЫТИЯ: контакт  ЗАМКНУТ";


                }
                else
                {
                    if(!isNotFeedback)
                    {
                        close.ToolTip = "Состояние концевика ЗАКРЫТИЯ: контакт  РАЗОМКНУТ";
                        close.Colors.DefaultColoring = darkSlateGray;
                    }
                    else
                    {
                        close.Colors.DefaultColoring = WarningColor;
                        open.ToolTip = "Состояние концевика ЗАКРЫТИЯ: НЕТ связи с модулем ,  за устранением в обратитесь службу КИПиА ";
                        
                    }
                        
                }



            }
        }

    }

}

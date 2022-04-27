using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace cip_blue.Controls
{
    [TemplatePart(Name = PART_NumPadPopup, Type = typeof(Popup))]
    [TemplatePart(Name = PART_NumPad, Type = typeof(NumPad))]
    public class NumPadUpDown : DecimalUpDown
    {
        private const string PART_NumPadPopup = "PART_NumPadPopup";
        private const string PART_NumPad = "PART_NumPad";

        #region Members

        private Popup _numPadPopup;
        private NumPad _numPad;
        private Decimal? _initialValue;

        #endregion //Members

        #region Properties

        #region DisplayText

        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(NumPadUpDown), new UIPropertyMetadata("0"));
        public string DisplayText
        {
            get
            {
                return (string)GetValue(DisplayTextProperty);
            }
            set
            {
                SetValue(DisplayTextProperty, value);
            }
        }

        #endregion //DisplayText

        #region EnterClosesNumPad

        public static readonly DependencyProperty EnterClosesNumPadProperty = DependencyProperty.Register("EnterClosesNumPad", typeof(bool), typeof(NumPadUpDown), new UIPropertyMetadata(false));
        public bool EnterClosesNumPad
        {
            get
            {
                return (bool)GetValue(EnterClosesNumPadProperty);
            }
            set
            {
                SetValue(EnterClosesNumPadProperty, value);
            }
        }

        #endregion //EnterClosesNumPad

        #region IsOpen

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(NumPadUpDown), new UIPropertyMetadata(false, OnIsOpenChanged));
        public bool IsOpen
        {
            get
            {
                return (bool)GetValue(IsOpenProperty);
            }
            set
            {
                SetValue(IsOpenProperty, value);
            }
        }

        private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumPadUpDown numPadUpDown = o as NumPadUpDown;
            if (numPadUpDown != null)
                numPadUpDown.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
        }

        protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
        {
            if (newValue)
                _initialValue = this.UpdateValueOnEnterKey ? this.ConvertTextToValue(this.TextBox.Text) : this.Value;
        }

        #endregion //IsOpen


        #region Precision

        public static readonly DependencyProperty PrecisionProperty = DependencyProperty.Register("Precision", typeof(int), typeof(NumPadUpDown), new UIPropertyMetadata(6));
        public int Precision
        {
            get
            {
                return (int)GetValue(PrecisionProperty);
            }
            set
            {
                SetValue(PrecisionProperty, value);
            }
        }

        #endregion //Precision

        #endregion //Properties

        #region Constructors

        static NumPadUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumPadUpDown), new FrameworkPropertyMetadata(typeof(NumPadUpDown)));
        }

        public NumPadUpDown()
        {
            Keyboard.AddKeyDownHandler(this, OnKeyDown);
            Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, OnMouseDownOutsideCapturedElement);
            this.Foreground = Brushes.LawnGreen;
            this.Background = Brushes.Black;


        }

        #endregion //Constructors

        #region Base Class Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_numPadPopup != null)
                _numPadPopup.Opened -= NumPadPopup_Opened;

            _numPadPopup = GetTemplateChild(PART_NumPadPopup) as Popup;

            if (_numPadPopup != null)
                _numPadPopup.Opened += NumPadPopup_Opened;

            if (_numPad != null)
                _numPad.ValueChanged -= OnNumPadValueChanged;

            _numPad = GetTemplateChild(PART_NumPad) as NumPad;

            if (_numPad != null)
                _numPad.Value = this.Value;

            if (_numPad != null)
                _numPad.ValueChanged += OnNumPadValueChanged;
        }

        private void OnNumPadValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (_numPad != null)
            {
                if (this.IsBetweenMinMax(_numPad.Value))
                {
                    if (this.UpdateValueOnEnterKey)
                    {
                        this.TextBox.Text = (_numPad.Value != null) ? _numPad.Value.Value.ToString(this.FormatString, this.CultureInfo) : null;
                    }
                    else
                    {
                        this.Value = _numPad.Value;
                    }

                    CloseNumPadUpDown();

                    //FocusManager.SetFocusedElement(FocusManager.GetFocusScope(TextBox), null); //!!!!!!!!!!!!
                    //Keyboard.ClearFocus();  //!!!!!!!!!!!!
                }
            }
        }

        #endregion //Base Class Overrides

        #region Event Handlers

        void NumPadPopup_Opened(object sender, EventArgs e)
        {
            if (_numPad != null)
            {
                var initValue = this.UpdateValueOnEnterKey ? this.ConvertTextToValue(this.TextBox.Text) : this.Value;
                _numPad.InitializeToValue(initValue);
                _numPad.Focus();
            }
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            if (IsOpen && EnterClosesNumPad)
            {
                var buttonType = NumPadUtilities.GetNumPadButtonTypeFromText(e.Text);
                if (buttonType == NumPad.NumPadButtonType.Enter)
                {
                    CloseNumPadUpDown();
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsOpen)
            {
                if (e.Key == Key.Enter)
                {
                    //if (this.UpdateValueOnEnterKey)
                    //{
                    //    this.TextBox.Text = (_initialValue != null) ? _initialValue.Value.ToString(this.FormatString, this.CultureInfo) : null;
                    //}
                    //else
                    //{
                    //    this.Value = _initialValue;
                    //}
                    FocusManager.SetFocusedElement(FocusManager.GetFocusScope(this.TextBox), null); //!!!!!!!!!!!!
                    Keyboard.ClearFocus();  //!!!!!!!!!!!!
                    e.Handled = true;
                }

                if (KeyboardUtilities.IsKeyModifyingPopupState(e))
                {
                    IsOpen = true;
                    // NumPad will get focus in NumPadPopup_Opened().

                    e.Handled = true;
                }
            }
            else
            {
                if (KeyboardUtilities.IsKeyModifyingPopupState(e))
                {
                    CloseNumPadUpDown();
                    e.Handled = true;
                }
                else if (e.Key == Key.Escape)
                {
                    if (EnterClosesNumPad)
                    {
                        if (this.UpdateValueOnEnterKey)
                        {
                            this.TextBox.Text = (_initialValue != null) ? _initialValue.Value.ToString(this.FormatString, this.CultureInfo) : null;
                        }
                        else
                        {
                            this.Value = _initialValue;
                        }
                    }
                    CloseNumPadUpDown();
                    e.Handled = true;
                }
            }
        }

        private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
        {
            CloseNumPadUpDown();
        }

        #endregion //Event Handlers

        #region Methods

        private void CloseNumPadUpDown()
        {
            if (IsOpen)
                IsOpen = false;
            ReleaseMouseCapture();

        }

        #endregion //Methods

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);

        //    if (e.Key != Key.Enter)
        //        return;

        //    FocusManager.SetFocusedElement(FocusManager.GetFocusScope(TextBox), null); //!!!!!!!!!!!!
        //    Keyboard.ClearFocus();  //!!!!!!!!!!!!

        //}



    }

}

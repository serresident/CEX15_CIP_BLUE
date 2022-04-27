using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;


namespace cip_blue.Controls
{
    [TemplatePart(Name = PART_NumPadButtonPanel, Type = typeof(ContentControl))]
    public class NumPad : Control
    {
        private const string PART_NumPadButtonPanel = "PART_NumPadButtonPanel";

        #region Members

        private ContentControl _buttonPanel;
        private bool _showNewNumber = true;
        private decimal _previousValue;
        private Operation _lastOperation = Operation.Enter;
        private readonly Dictionary<Button, DispatcherTimer> _timers = new Dictionary<Button, DispatcherTimer>();

        #endregion //Members

        #region Enumerations

        public enum NumPadButtonType
        {
            //Add,
            Back,
            Cancel,
            Clear,
            Decimal,
            //Divide,
            Eight,
            Enter,
            Five,
            Four,
            Fraction,
            //MAdd,
            //MC,
            //MR,
            //MS,
            //MSub,
            //Multiply,
            Negate,
            Nine,
            None,
            One,
            //Percent,
            Seven,
            Six,
            //Sqrt,
            //Subtract,
            Three,
            Two,
            Zero
        }

        public enum Operation
        {
            //Add,
            //Subtract,
            //Divide,
            //Multiply,
            //Percent,
            //Sqrt,
            //Fraction,
            Enter,
            Clear,
            Negate
        }

        #endregion //Enumerations

        #region Properties

        #region NumPadButtonPanelTemplate

        public static readonly DependencyProperty NumPadButtonPanelTemplateProperty = DependencyProperty.Register("NumPadButtonPanelTemplate"
          , typeof(ControlTemplate), typeof(NumPad), new UIPropertyMetadata(null));
        public ControlTemplate NumPadButtonPanelTemplate
        {
            get
            {
                return (ControlTemplate)GetValue(NumPadButtonPanelTemplateProperty);
            }
            set
            {
                SetValue(NumPadButtonPanelTemplateProperty, value);
            }
        }

        #endregion //NumPadButtonPanelTemplate

        #region NumPadButtonType

        public static readonly DependencyProperty NumPadButtonTypeProperty = DependencyProperty.RegisterAttached("NumPadButtonType", typeof(NumPadButtonType), typeof(NumPad), new UIPropertyMetadata(NumPadButtonType.None, OnNumPadButtonTypeChanged));
        public static NumPadButtonType GetNumPadButtonType(DependencyObject target)
        {
            return (NumPadButtonType)target.GetValue(NumPadButtonTypeProperty);
        }
        public static void SetNumPadButtonType(DependencyObject target, NumPadButtonType value)
        {
            target.SetValue(NumPadButtonTypeProperty, value);
        }
        private static void OnNumPadButtonTypeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            OnNumPadButtonTypeChanged(o, (NumPadButtonType)e.OldValue, (NumPadButtonType)e.NewValue);
        }
        private static void OnNumPadButtonTypeChanged(DependencyObject o, NumPadButtonType oldValue, NumPadButtonType newValue)
        {
            Button button = o as Button;
            button.CommandParameter = newValue;
            if (button.Content == null)
            {
                button.Content = NumPadUtilities.GetNumPadButtonContent(newValue);
            }

        }

        #endregion //NumPadButtonType

        #region DisplayText

        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText", typeof(string), typeof(NumPad), new UIPropertyMetadata("0", OnDisplayTextChanged));
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

        private static void OnDisplayTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumPad NumPad = o as NumPad;
            if (NumPad != null)
                NumPad.OnDisplayTextChanged((string)e.OldValue, (string)e.NewValue);
        }

        protected virtual void OnDisplayTextChanged(string oldValue, string newValue)
        {
            // TODO: Add your property changed side-effects. Descendants can override as well.
        }

        #endregion //DisplayText

        #region Precision

        public static readonly DependencyProperty PrecisionProperty = DependencyProperty.Register("Precision", typeof(int), typeof(NumPad), new UIPropertyMetadata(6));
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

        #region Value

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(decimal?), typeof(NumPad), new FrameworkPropertyMetadata(default(decimal), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged));
        public decimal? Value
        {
            get
            {
                return (decimal?)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumPad NumPad = o as NumPad;
            if (NumPad != null)
                NumPad.OnValueChanged((decimal?)e.OldValue, (decimal?)e.NewValue);
        }

        protected virtual void OnValueChanged(decimal? oldValue, decimal? newValue)
        {
            SetDisplayText(newValue);

            RoutedPropertyChangedEventArgs<object> args = new RoutedPropertyChangedEventArgs<object>(oldValue, newValue);
            args.RoutedEvent = ValueChangedEvent;
            RaiseEvent(args);
        }

        #endregion //Value

        #endregion //Properties

        #region Constructors

        static NumPad()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumPad), new FrameworkPropertyMetadata(typeof(NumPad)));
        }

        public NumPad()
        {

            CommandBindings.Add(new CommandBinding(NumPadCommands.NumPadButtonClick, ExecuteNumPadButtonClick));
            AddHandler(MouseDownEvent, new MouseButtonEventHandler(NumPad_OnMouseDown), true);
        }

        #endregion //Constructors

        #region Base Class Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _buttonPanel = GetTemplateChild(PART_NumPadButtonPanel) as ContentControl;
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            var buttonType = NumPadUtilities.GetNumPadButtonTypeFromText(e.Text);
            if (buttonType != NumPadButtonType.None)
            {
                SimulateNumPadButtonClick(buttonType);
                ProcessNumPadButton(buttonType);
            }
        }




        #endregion //Base Class Overrides

        #region Event Handlers

        private void NumPad_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsFocused)
            {
                Focus();
                e.Handled = true;
            }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= Timer_Tick;

            if (_timers.ContainsValue(timer))
            {
                var button = _timers.Where(x => x.Value == timer).Select(x => x.Key).FirstOrDefault();
                if (button != null)
                {
                    VisualStateManager.GoToState(button, button.IsMouseOver ? "MouseOver" : "Normal", true);
                    _timers.Remove(button);
                }
            }
        }

        #endregion //Event Handlers

        #region Methods

        internal void InitializeToValue(decimal? value)
        {
            _previousValue = 0;

            _showNewNumber = true;
            Value = value;
            // Since the display text may be out of sync
            // with "Value", this call will force the
            // text update if Value was already equal to
            // the value parameter.
            this.SetDisplayText(value);
        }

        private void HandleOperation()
        {
            //if (_lastOperation == Operation.Enter)
            //    return;

            try
            {
                Value = Decimal.Round(HandleValue(_lastOperation), Precision);
                SetDisplayText(Value); //Set DisplayText even when Value doesn't change
            }
            catch
            {
                Value = null;
                DisplayText = "ERROR";
            }
        }

        private void SetDisplayText(decimal? newValue)
        {
            if (newValue.HasValue && (newValue.Value != 0))
                DisplayText = newValue.ToString();
            else
                DisplayText = "0";
        }

        private void HandleOperation(Operation newOperation)
        {
            if (!_showNewNumber)
                HandleOperation();

            _lastOperation = newOperation;
        }

        private void HandleOperation(Operation currentOperation, Operation newOperation)
        {
            _lastOperation = currentOperation;
            HandleOperation();
            _lastOperation = newOperation;
        }

        private decimal HandleValue(Operation operation)
        {
            decimal newValue = decimal.Zero;
            decimal currentValue = NumPadUtilities.ParseDecimal(DisplayText);

            switch (operation)
            {
                case Operation.Negate:
                    newValue = NumPadUtilities.Negate(currentValue);
                    break;
                case Operation.Enter:
                    newValue = currentValue;
                    break;
                default:
                    newValue = decimal.Zero;
                    break;
            }

            return newValue;
        }

        void ProcessBackKey()
        {
            string displayText;
            if (DisplayText.Length > 1 && !(DisplayText.Length == 2 && DisplayText[0] == '-'))
            {
                displayText = DisplayText.Remove(DisplayText.Length - 1, 1);
            }
            else
            {
                displayText = "0";
                _showNewNumber = true;
            }

            DisplayText = displayText;
        }

        private void ProcessNumPadButton(NumPadButtonType buttonType)
        {
            if (NumPadUtilities.IsDigit(buttonType))
                ProcessDigitKey(buttonType);
            else
                ProcessOperationKey(buttonType);
        }

        private void ProcessDigitKey(NumPadButtonType buttonType)
        {
            if (_showNewNumber)
                DisplayText = NumPadUtilities.GetNumPadButtonContent(buttonType);
            else
                DisplayText += NumPadUtilities.GetNumPadButtonContent(buttonType);

            _showNewNumber = false;
        }


        private void ProcessOperationKey(NumPadButtonType buttonType)
        {
            switch (buttonType)
            {
                case NumPadButtonType.Negate:
                    HandleOperation(Operation.Negate, Operation.Enter);
                    break;
                case NumPadButtonType.Enter:
                    HandleOperation(Operation.Enter);
                    break;
                case NumPadButtonType.Clear:
                    HandleOperation(Operation.Clear, Operation.Enter);
                    break;
                case NumPadButtonType.Cancel:
                    DisplayText = _previousValue.ToString();
                    _showNewNumber = true;
                    return;
                case NumPadButtonType.Back:
                    ProcessBackKey();
                    return;
                default:
                    break;
            }

            Decimal.TryParse(DisplayText, out _previousValue);
            _showNewNumber = true;
        }

        private void SimulateNumPadButtonClick(NumPadButtonType buttonType)
        {
            var button = NumPadUtilities.FindButtonByNumPadButtonType(_buttonPanel, buttonType);
            if (button != null)
            {
                VisualStateManager.GoToState(button, "Pressed", true);
                DispatcherTimer timer;
                if (_timers.ContainsKey(button))
                {
                    timer = _timers[button];
                    timer.Stop();
                }
                else
                {
                    timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(100);
                    timer.Tick += Timer_Tick;
                    _timers.Add(button, timer);
                }

                timer.Start();
            }
        }

        #endregion //Methods

        #region Events

        //Due to a bug in Visual Studio, you cannot create event handlers for nullable args in XAML, so I have to use object instead.
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(NumPad));
        public event RoutedPropertyChangedEventHandler<object> ValueChanged
        {
            add
            {
                AddHandler(ValueChangedEvent, value);
            }
            remove
            {
                RemoveHandler(ValueChangedEvent, value);
            }
        }

        #endregion //Events

        #region Commands

        private void ExecuteNumPadButtonClick(object sender, ExecutedRoutedEventArgs e)
        {
            var buttonType = (NumPadButtonType)e.Parameter;
            ProcessNumPadButton(buttonType);
        }

        #endregion //Commands


    }

}

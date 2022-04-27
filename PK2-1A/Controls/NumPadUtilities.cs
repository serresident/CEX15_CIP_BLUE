using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace cip_blue.Controls
{
    static class NumPadUtilities
    {
        public static NumPad.NumPadButtonType GetNumPadButtonTypeFromText(string text)
        {
            switch (text)
            {
                case "0":
                    return NumPad.NumPadButtonType.Zero;
                case "1":
                    return NumPad.NumPadButtonType.One;
                case "2":
                    return NumPad.NumPadButtonType.Two;
                case "3":
                    return NumPad.NumPadButtonType.Three;
                case "4":
                    return NumPad.NumPadButtonType.Four;
                case "5":
                    return NumPad.NumPadButtonType.Five;
                case "6":
                    return NumPad.NumPadButtonType.Six;
                case "7":
                    return NumPad.NumPadButtonType.Seven;
                case "8":
                    return NumPad.NumPadButtonType.Eight;
                case "9":
                    return NumPad.NumPadButtonType.Nine;
                case "\b":
                    return NumPad.NumPadButtonType.Back;
                case "\r":
                case "Ok":
                    return NumPad.NumPadButtonType.Enter;
            }

            //the check for the decimal is not in the switch statement. To help localize we check against the current culture's decimal seperator
            if (text == CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)
                return NumPad.NumPadButtonType.Decimal;

            //check for the escape key
            if (text == ((char)27).ToString())
                return NumPad.NumPadButtonType.Clear;

            return NumPad.NumPadButtonType.None;
        }

        public static Button FindButtonByNumPadButtonType(DependencyObject parent, NumPad.NumPadButtonType type)
        {
            if (parent == null)
                return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child == null)
                    continue;

                object buttonType = child.GetValue(Button.CommandParameterProperty);

                if (buttonType != null && (NumPad.NumPadButtonType)buttonType == type)
                {
                    return child as Button;
                }
                else
                {
                    var result = FindButtonByNumPadButtonType(child, type);

                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public static string GetNumPadButtonContent(NumPad.NumPadButtonType type)
        {
            string content = string.Empty;
            switch (type)
            {
                case NumPad.NumPadButtonType.Back:
                    content = "Back";
                    break;
                case NumPad.NumPadButtonType.Cancel:
                    content = "CE";
                    break;
                case NumPad.NumPadButtonType.Clear:
                    content = "C";
                    break;
                case NumPad.NumPadButtonType.Decimal:
                    content = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                    break;
                case NumPad.NumPadButtonType.Eight:
                    content = "8";
                    break;
                case NumPad.NumPadButtonType.Enter:
                    content = "Ok";
                    break;
                case NumPad.NumPadButtonType.Five:
                    content = "5";
                    break;
                case NumPad.NumPadButtonType.Four:
                    content = "4";
                    break;
                case NumPad.NumPadButtonType.Nine:
                    content = "9";
                    break;
                case NumPad.NumPadButtonType.None:
                    break;
                case NumPad.NumPadButtonType.One:
                    content = "1";
                    break;
                case NumPad.NumPadButtonType.Seven:
                    content = "7";
                    break;
                case NumPad.NumPadButtonType.Negate:
                    content = "+/-";
                    break;
                case NumPad.NumPadButtonType.Six:
                    content = "6";
                    break;
                case NumPad.NumPadButtonType.Three:
                    content = "3";
                    break;
                case NumPad.NumPadButtonType.Two:
                    content = "2";
                    break;
                case NumPad.NumPadButtonType.Zero:
                    content = "0";
                    break;
            }
            return content;
        }

        public static bool IsDigit(NumPad.NumPadButtonType buttonType)
        {
            switch (buttonType)
            {
                case NumPad.NumPadButtonType.Zero:
                case NumPad.NumPadButtonType.One:
                case NumPad.NumPadButtonType.Two:
                case NumPad.NumPadButtonType.Three:
                case NumPad.NumPadButtonType.Four:
                case NumPad.NumPadButtonType.Five:
                case NumPad.NumPadButtonType.Six:
                case NumPad.NumPadButtonType.Seven:
                case NumPad.NumPadButtonType.Eight:
                case NumPad.NumPadButtonType.Nine:
                case NumPad.NumPadButtonType.Decimal:
                    return true;
                default:
                    return false;
            }
        }


        public static decimal ParseDecimal(string text)
        {
            decimal result;
            var success = Decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out result);
            return success ? result : decimal.Zero;
        }

        public static decimal Add(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public static decimal Subtract(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public static decimal Multiply(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public static decimal Divide(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public static decimal Percent(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber / 100M;
        }

        public static decimal SquareRoot(decimal operand)
        {
            return Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(operand)));
        }

        public static decimal Fraction(decimal operand)
        {
            return 1 / operand;
        }

        public static decimal Negate(decimal operand)
        {
            return operand * -1M;
        }
    }

}

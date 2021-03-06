﻿using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Temperature : Quantity
    {
        public enum Units { Fahrenheit, Celsius, Kelvin };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double F { get { return ToFahrenheit(); } }
        public double C { get { return ToCelcius(); } }
        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Temperature()
        {
        }

        public Temperature(Temperature rhs)
        {
            if (rhs == null)
            {
                Value = null;
                OriginalUnits = DisplayUnits;
                return;
            }

            Value = rhs.Value;
            OriginalUnits = rhs.OriginalUnits;
        }

        public Temperature(double value, Units units)
        {
            Value = value;
            OriginalUnits = units;
        }

        public double ToDisplayUnits()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return Convert(value, OriginalUnits, DisplayUnits);
        }

        public double ToFahrenheit()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return Convert(value, OriginalUnits, Units.Fahrenheit);
        }

        public double ToCelcius()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return Convert((double)Value, OriginalUnits, Units.Celsius);
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void TextAndUnits(Temperature temperature, out string temperatureText, out Units temperatureUnits)
        {
            if (temperature == null)
            {
                temperatureText = String.Empty;
                temperatureUnits = DisplayUnits;
            }
            else
            {
                temperatureText = temperature.Text;
                temperatureUnits = temperature.OriginalUnits;
            }

        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            switch (fromUnits)
            {
                case Units.Fahrenheit:
                    switch (toUnits)
                    {
                        case Units.Fahrenheit: return value;
                        case Units.Celsius: return (value - 32) * 5.0 / 9.0;
                        case Units.Kelvin: return ((value - 32) * 5.0 / 9.0) + 273.15;
                        default:
                            return Double.NaN;
                    }

                case Units.Celsius:
                    switch (toUnits)
                    {
                        case Units.Fahrenheit: return value * 9.0 / 5.0 + 32;
                        case Units.Celsius: return value;
                        case Units.Kelvin: return value + 273.15;
                        default:
                            return Double.NaN;
                    }

                case Units.Kelvin:
                    switch (toUnits)
                    {
                        case Units.Fahrenheit: return (value - 273.15) * 9.0 / 5.0 + 32;
                        case Units.Celsius: return value - 273.15;
                        case Units.Kelvin: return value;
                        default:
                            return Double.NaN;
                    }

                default:
                    return Double.NaN;
            }
        }

        public static double Convert(Temperature value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return Convert((double)value.Value, value.OriginalUnits, toUnits);
        }

        // Takes the Fahrenheit and Celsius values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Temperature FahrenheitOrCelsius(double? fahrenheit, double? celsius)
        {
            // both are null, then so is the value
            if (!fahrenheit.HasValue && !celsius.HasValue)
                return new Temperature();

            if (!fahrenheit.HasValue)
                return new Temperature((double)celsius, Units.Celsius);

            if (!celsius.HasValue)
                return new Temperature((double)fahrenheit, Units.Fahrenheit);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)celsius;
            if (celsius == (int)celsius)
                return new Temperature(value, Units.Celsius);

            // meters were not whole, so default to feet regardless
            return new Temperature((double)fahrenheit, Units.Fahrenheit);
        }

        #region Static initialization

        static Temperature()
        {
            DisplayUnits = Units.Fahrenheit;
        }

        #endregion
    }
}

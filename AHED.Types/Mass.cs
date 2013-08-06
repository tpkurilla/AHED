using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Mass : Quantity
    {
        public enum Units { Pounds, Kilograms, Grams, Milligrams, Micrograms };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double Lbs { get { return ToPounds(); } }
        public double Kg { get { return ToKilograms(); } }
        public double Micrograms { get { return ToMicrograms(); } }

        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Mass()
        {
        }

        public Mass(Mass rhs)
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

        public Mass(double value, Units units)
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

            return value * Conversions[OriginalUnits][DisplayUnits];
        }

        public double ToPounds()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Pounds];
        }

        public double ToKilograms()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Kilograms];
        }

        private double ToMicrograms()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Micrograms];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void TextAndUnits(Mass mass, out string massText, out Units massUnits)
        {
            if (mass == null)
            {
                massText = String.Empty;
                massUnits = DisplayUnits;
            }
            else
            {
                massText = mass.Text;
                massUnits = mass.OriginalUnits;
            }

        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Mass value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the pounds and kilogram values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Mass PoundsOrKilograms(double? pounds, double? kilograms)
        {
            bool poundsNull = (pounds == null);
            bool kilogramsNull = (kilograms == null);

            // both are null, then so is the value
            if (poundsNull && kilogramsNull)
                return new Mass();

            if (poundsNull)
                return new Mass((double)kilograms, Units.Kilograms);

            if (kilogramsNull)
                return new Mass((double)pounds, Units.Pounds);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)kilograms;
            if (kilograms == (int)kilograms)
                return new Mass(value, Units.Kilograms);

            // meters were not whole, so default to feet regardless
            return new Mass((double)pounds, Units.Pounds);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<Mass.Units, Dictionary<Mass.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.angelfire.com/az/deaflab/measure.html to 15 digits of precision
        // This can be expanded to handle all Weights requiring support
        static Mass()
        {
            const double poundsPerKilogram = 2.20462262184878;
            const double kilogramsPerPound = 0.45359237;

            DisplayUnits = Units.Pounds;

            // From Pounds to...
            var tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = 1.0;
            tbl[Units.Kilograms] = kilogramsPerPound;
            tbl[Units.Grams] = kilogramsPerPound * 1000.0;
            tbl[Units.Milligrams] = kilogramsPerPound * 1000000.0;
            tbl[Units.Micrograms] = kilogramsPerPound * 1000000000.0;
            Conversions[Units.Pounds] = tbl;

            // From Kilograms to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = poundsPerKilogram;
            tbl[Units.Kilograms] = 1.0;
            tbl[Units.Grams] = 1000.0;
            tbl[Units.Milligrams] = 1000000.0;
            tbl[Units.Micrograms] = 1000000000.0;
            Conversions[Units.Kilograms] = tbl;

            // From Grams to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = poundsPerKilogram / 1000.0;     // 1,000 grams/kg
            tbl[Units.Kilograms] = 0.001;
            tbl[Units.Grams] = 1.0;
            tbl[Units.Milligrams] = 1000.0;
            tbl[Units.Micrograms] = 1000000.0;
            Conversions[Units.Kilograms] = tbl;

            // From Milligrams to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = poundsPerKilogram / 100000.0;   // 1,000,000 milligrams/kg
            tbl[Units.Kilograms] = 0.000001;
            tbl[Units.Grams] = 0.001;
            tbl[Units.Milligrams] = 1.0;
            tbl[Units.Micrograms] = 1000.0;
            Conversions[Units.Kilograms] = tbl;

            // From Micrograms to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = poundsPerKilogram / 1000000000.0; // 1,000,000,000 micrograms/kg
            tbl[Units.Kilograms] = 0.000000001;
            tbl[Units.Grams] = 0.000001;
            tbl[Units.Milligrams] = 0.001;
            tbl[Units.Micrograms] = 1.0;
            Conversions[Units.Kilograms] = tbl;

        }

        #endregion
    }
}

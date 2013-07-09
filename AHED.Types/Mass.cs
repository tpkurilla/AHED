using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Mass
    {
        public enum Units { Pounds, Kilograms };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double Lbs { get { return ToPounds(); } }
        public double Kg { get { return ToKilograms(); } }
        public bool HasValue { get { return OriginalValue.HasValue; } }

        public double? OriginalValue { get; set; }
        public Units OriginalUnits { get; set; }

        public Mass()
        {
        }

        public Mass(Mass rhs)
        {
            OriginalValue = rhs.OriginalValue;
            OriginalUnits = rhs.OriginalUnits;
        }

        public Mass(double value, Units units)
        {
            OriginalValue = value;
            OriginalUnits = units;
        }

        public double ToDisplayUnits()
        {
            if (!OriginalValue.HasValue)
                if (!OriginalValue.HasValue)
                    return Double.NaN;

            double value = (double)OriginalValue;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][DisplayUnits];
        }

        public double ToPounds()
        {
            if (!OriginalValue.HasValue)
                if (!OriginalValue.HasValue)
                    return Double.NaN;

            double value = (double)OriginalValue;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Pounds];
        }

        public double ToKilograms()
        {
            if (!OriginalValue.HasValue)
                return Double.NaN;

            double value = (double)OriginalValue;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Kilograms];
        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Mass value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.OriginalValue * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the pounds and kilogram values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Mass PoundsOrKilograms(double? pounds, double? kilograms)
        {
            bool poundsNull = (pounds == null) || (!pounds.HasValue);
            bool kilogramsNull = (kilograms == null) || (!kilograms.HasValue);

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
            DisplayUnits = Units.Pounds;

            // From Pounds to...
            Dictionary<Units, double> tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = 1.0;
            tbl[Units.Kilograms] = 0.45359237;
            Conversions[Units.Pounds] = tbl;

            // From Kilograms to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Pounds] = 2.20462262184878;
            tbl[Units.Kilograms] = 1.0;
            Conversions[Units.Kilograms] = tbl;

        }

        #endregion
    }
}

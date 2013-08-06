using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Length : Quantity
    {
        public enum Units { Feet, Inches, Centimeters, Meters };

        public static Units DuInOrCm { get; set; }
        public static Units DuFtOrM { get; set; }
        public double InOrCm { get { return ToInOrCm(); } }
        public double FtOrM { get { return ToFtOrM(); } }

        public double In { get { return ToInches(); } }
        public double Ft { get { return ToFeet(); } }
        public double M { get { return ToMeters(); } }
        public double Cm { get { return ToCentimeters(); } }
        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Length()
        {
        }

        public Length(Length rhs)
        {
            if (rhs == null)
            {
                Value = null;
                OriginalUnits = DuFtOrM;
                return;
            }

            Value = rhs.Value;
            OriginalUnits = rhs.OriginalUnits;
        }

        public Length(double value, Units units)
        {
            Value = value;
            OriginalUnits = units;
        }

        public double ToInOrCm()
        {
            if (!Value.HasValue)
                if (!Value.HasValue)
                    return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][DuInOrCm];
        }

        public double ToFtOrM()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][DuFtOrM];
        }

        public double ToInches()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Inches];
        }

        public double ToCentimeters()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Centimeters];
        }

        public double ToFeet()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Feet];
        }

        public double ToMeters()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Meters];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void InOrCmTextAndUnits(Length length, out string lengthText, out Units lengthUnits)
        {
            if (length == null)
            {
                lengthText = String.Empty;
                lengthUnits = DuInOrCm;
            }
            else
            {
                lengthText = length.Text;
                lengthUnits = length.OriginalUnits;
            }

        }

        public static void FtOrMTextAndUnits(Length length, out string lengthText, out Units lengthUnits)
        {
            if (length == null)
            {
                lengthText = String.Empty;
                lengthUnits = DuFtOrM;
            }
            else
            {
                lengthText = length.Text;
                lengthUnits = length.OriginalUnits;
            }

        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Length value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the feet and meters values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Length FeetOrMeters(double? feet, double? meters)
        {
            bool feetNull = (feet == null);
            bool metersNull = (meters == null);

            // both are null, then so is the value
            if (feetNull && metersNull)
                return new Length();

            if (feetNull)
                return new Length((double)meters, Units.Meters);

            if (metersNull)
                return new Length((double)feet, Units.Feet);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)meters;
            if (meters == (int)meters)
                return new Length(value, Units.Meters);

            // meters were not whole, so default to feet regardless
            return new Length((double)feet, Units.Feet);
        }

        // Takes the inches and centimeters values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Length InchesOrCentimeters(double? inches, double? centimeters)
        {
            bool inchesNull = (inches == null);
            bool centimetersNull = (centimeters == null);

            // both are null, then so is the value
            if (inchesNull && centimetersNull)
                return new Length();

            if (inchesNull)
                return new Length((double)centimeters, Units.Centimeters);

            if (centimetersNull)
                return new Length((double)inches, Units.Inches);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)centimeters;
            if (centimeters == (int)centimeters)
                return new Length(value, Units.Centimeters);

            // centimeters were not whole, so default to inches regardless
            return new Length((double)inches, Units.Inches);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<Length.Units, Dictionary<Length.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.angelfire.com/az/deaflab/measure.html to 15 digits of precision
        // This can be expanded to handle all lengths requiring support
        static Length()
        {
            DuInOrCm = Units.Inches;
            DuFtOrM = Units.Feet;

            // From Feet to...
            var tbl = new Dictionary<Units, double>();
            tbl[Units.Feet] = 1.0;
            tbl[Units.Meters] = 0.3048;
            tbl[Units.Inches] = 12;
            tbl[Units.Centimeters] = 30.48;
            Conversions[Units.Feet] = tbl;

            // From Meters to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Feet] = 3.28083989501312;
            tbl[Units.Meters] = 1.0;
            tbl[Units.Inches] = 39.3700787401575;
            tbl[Units.Centimeters] = 100;
            Conversions[Units.Meters] = tbl;

            // From Inches to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Feet] = 1.0 / 12.0;
            tbl[Units.Meters] = 0.0254;
            tbl[Units.Inches] = 1.0;
            tbl[Units.Centimeters] = 2.54;
            Conversions[Units.Inches] = tbl;

            // From Centimeters to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Feet] = 0.0328083989501312;
            tbl[Units.Meters] = 1.0 / 100.0;
            tbl[Units.Inches] = 0.393700787401575;
            tbl[Units.Centimeters] = 1.0;
            Conversions[Units.Inches] = tbl;
        }

        #endregion
    }
}

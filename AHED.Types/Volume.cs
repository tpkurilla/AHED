using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Volume : Quantity
    {
        public enum Units { Gallons, Liters };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double Gal { get { return ToGallons(); } }
        public double L { get { return ToLiters(); } }
        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Volume()
        {
        }

        public Volume(Volume rhs)
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

        public Volume(double value, Units units)
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

        public double ToGallons()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Gallons];
        }

        public double ToLiters()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Liters];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void TextAndUnits(Volume volume, out string volumeText, out Units volumeUnits)
        {
            if (volume == null)
            {
                volumeText = String.Empty;
                volumeUnits = DisplayUnits;
            }
            else
            {
                volumeText = volume.Text;
                volumeUnits = volume.OriginalUnits;
            }
        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Volume value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the pounds and kilogram values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Volume GallonsOrLiters(double? gallons, double? liters)
        {
            bool gallonsNull = (gallons == null);
            bool litersNull = (liters == null);

            // both are null, then so is the value
            if (gallonsNull && litersNull)
                return new Volume();

            if (gallonsNull)
                return new Volume((double)liters, Units.Liters);

            if (litersNull)
                return new Volume((double)gallons, Units.Gallons);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)liters;
            if (liters == (int)liters)
                return new Volume(value, Units.Liters);

            // meters were not whole, so default to feet regardless
            return new Volume((double)gallons, Units.Gallons);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<Volume.Units, Dictionary<Volume.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.angelfire.com/az/deaflab/measure.html to 15 digits of precision
        // This can be expanded to handle all Volumes requiring support
        static Volume()
        {
            DisplayUnits = Units.Gallons;

            // From Gallons to...
            var tbl = new Dictionary<Units, double>();
            tbl[Units.Gallons] = 1.0;
            tbl[Units.Liters] = 3.785411784;
            Conversions[Units.Gallons] = tbl;

            // From Liters to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Gallons] = 0.264172052358148;
            tbl[Units.Liters] = 1.0;
            Conversions[Units.Liters] = tbl;

        }

        #endregion
    }
}

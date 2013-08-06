using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Area : Quantity
    {
        public enum Units { Acres, Hectares };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double Acre { get { return ToAcres(); } }
        public double Hect { get { return ToHectares(); } }
        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Area()
        {
        }

        public Area(Area rhs)
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

        public Area(double value, Units units)
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

        public double ToAcres()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Acres];
        }

        public double ToHectares()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Hectares];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void TextAndUnits(Area area, out string areaText, out Units areaUnits)
        {
            if (area == null)
            {
                areaText = String.Empty;
                areaUnits = DisplayUnits;
            }
            else
            {
                areaText = area.Text;
                areaUnits = area.OriginalUnits;
            }

        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Area value, Units toUnits)
        {
            if (value == null || !value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the acres and hectares values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Area AcresOrHectares(double? acres, double? hectares)
        {
            bool acresNull = (acres == null);
            bool hectaresNull = (hectares == null);

            // both are null, then so is the value
            if (acresNull && hectaresNull)
                return new Area();

            if (acresNull)
                return new Area((double)hectares, Units.Hectares);

            if (hectaresNull)
                return new Area((double)acres, Units.Acres);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)hectares;
            if (hectares == (int)hectares)
                return new Area(value, Units.Hectares);

            // meters were not whole, so default to feet regardless
            return new Area((double)acres, Units.Acres);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static readonly Dictionary<Area.Units, Dictionary<Area.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.angelfire.com/az/deaflab/measure.html to 15 digits of precision
        // This can be expanded to handle all Areas requiring support
        static Area()
        {
            DisplayUnits = Units.Acres;

            // From Acres to...
            var tbl = new Dictionary<Units, double>();
            tbl[Units.Acres] = 1.0;
            tbl[Units.Hectares] = 0.45359237;
            Conversions[Units.Acres] = tbl;

            // From Hectares to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Acres] = 2.20462262184878;
            tbl[Units.Hectares] = 1.0;
            Conversions[Units.Hectares] = tbl;

        }

        #endregion
    }
}

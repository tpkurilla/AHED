using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class MassPerVolume
    {
        public enum Units { PoundsPerGallon, GramsPerLiter };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double Lbs { get { return ToPoundsPerGallon(); } }
        public double Kg { get { return ToGramsPerLiter(); } }
        public bool HasValue { get { return OriginalValue.HasValue; } }

        public double? OriginalValue { get; set; }
        public Units OriginalUnits { get; set; }

        public MassPerVolume()
        {
        }

        public MassPerVolume(MassPerVolume rhs)
        {
            OriginalValue = rhs.OriginalValue;
            OriginalUnits = rhs.OriginalUnits;
        }

        public MassPerVolume(double value, Units units)
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

        public double ToPoundsPerGallon()
        {
            if (!OriginalValue.HasValue)
                if (!OriginalValue.HasValue)
                    return Double.NaN;

            double value = (double)OriginalValue;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.PoundsPerGallon];
        }

        public double ToGramsPerLiter()
        {
            if (!OriginalValue.HasValue)
                return Double.NaN;

            double value = (double)OriginalValue;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.GramsPerLiter];
        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(MassPerVolume value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.OriginalValue * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the pounds/gallon and grams/liter values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static MassPerVolume PpgOrGpl(double? poundsPerGallon, double? gPerLiter)
        {
            bool ppgNull = (poundsPerGallon == null) || (!poundsPerGallon.HasValue);
            bool gplNull = (gPerLiter == null) || (!gPerLiter.HasValue);

            // both are null, then so is the value
            if (ppgNull && gplNull)
                return new MassPerVolume();

            if (ppgNull)
                return new MassPerVolume((double)gPerLiter, Units.GramsPerLiter);

            if (gplNull)
                return new MassPerVolume((double)poundsPerGallon, Units.PoundsPerGallon);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)gPerLiter;
            if (gPerLiter == (int)gPerLiter)
                return new MassPerVolume(value, Units.GramsPerLiter);

            // meters were not whole, so default to feet regardless
            return new MassPerVolume((double)poundsPerGallon, Units.PoundsPerGallon);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<MassPerVolume.Units, Dictionary<MassPerVolume.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.angelfire.com/az/deaflab/measure.html to 15 digits of precision
        // This can be expanded to handle all MassPerVolumes requiring support
        static MassPerVolume()
        {
            DisplayUnits = Units.PoundsPerGallon;

            // From Pounds/Gallon to...
            Dictionary<Units, double> tbl = new Dictionary<Units, double>();
            tbl[Units.PoundsPerGallon] = 1.0;
            tbl[Units.GramsPerLiter] = 2204.62262184878 / 3.785411784; // Lb/gal * g/Lb * gal/L
            Conversions[Units.PoundsPerGallon] = tbl;

            // From Grams/Liter to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.PoundsPerGallon] = 3.785411784 / 2204.62262184878; // g/L * L/gal * Lb/g
            tbl[Units.GramsPerLiter] = 1.0;
            Conversions[Units.GramsPerLiter] = tbl;

        }

        #endregion
    }
}

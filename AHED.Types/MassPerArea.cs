﻿using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class MassPerArea : Quantity
    {
        public enum Units { MicrogramsPerSquareCm };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double C2 { get { return ToMicrogramsPerSquareCm(); } }
        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public MassPerArea()
        {
        }

        public MassPerArea(MassPerArea rhs)
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

        public MassPerArea(double value, Units units)
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

        public double ToMicrogramsPerSquareCm()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.MicrogramsPerSquareCm];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void TextAndUnits(MassPerArea mass, out string massText, out Units massUnits)
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

        public static double Convert(MassPerArea value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<MassPerArea.Units, Dictionary<MassPerArea.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values to 15 digits of precision
        // This can be expanded to handle all MassPerVolumes requiring support
        static MassPerArea()
        {
            DisplayUnits = Units.MicrogramsPerSquareCm;

            // From uG / cm2 to...
            var tbl = new Dictionary<Units, double>();
            tbl[Units.MicrogramsPerSquareCm] = 1.0;
            Conversions[Units.MicrogramsPerSquareCm] = tbl;

        }

        #endregion
    }
}

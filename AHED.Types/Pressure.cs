using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Pressure : Quantity
    {
        public enum Units { Psi, Bar };

        public static Units DisplayUnits { get; set; }
        public double DU { get { return ToDisplayUnits(); } }
        public double Psi { get { return ToPsi(); } }
        public double Bar { get { return ToBar(); } }
        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Pressure()
        {
        }

        public Pressure(Pressure rhs)
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

        public Pressure(double value, Units units)
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

        public double ToPsi()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Psi];
        }

        public double ToBar()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.Bar];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void TextAndUnits(Pressure pressure, out string pressureText, out Units pressureUnits)
        {
            if (pressure == null)
            {
                pressureText = String.Empty;
                pressureUnits = DisplayUnits;
            }
            else
            {
                pressureText = pressure.Text;
                pressureUnits = pressure.OriginalUnits;
            }

        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Pressure value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the psi and bar values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Pressure PsiOrBar(double? psi, double? bar)
        {
            bool psiNull = (psi == null);
            bool barNull = (bar == null);

            // both are null, then so is the value
            if (psiNull && barNull)
                return new Pressure();

            if (psiNull)
                return new Pressure((double)bar, Units.Bar);

            if (barNull)
                return new Pressure((double)psi, Units.Psi);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)bar;
            if (bar == (int)bar)
                return new Pressure(value, Units.Bar);

            // meters were not whole, so default to feet regardless
            return new Pressure((double)psi, Units.Psi);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<Pressure.Units, Dictionary<Pressure.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.convertunits.com/from/psi/to/bar by using 1 bar equals 14.5037738007 psi
        // This can be expanded to handle all Pressures requiring support
        static Pressure()
        {
            DisplayUnits = Units.Psi;

            // From Psi to...
            Dictionary<Units, double> tbl = new Dictionary<Units, double>();
            tbl[Units.Psi] = 1.0;
            tbl[Units.Bar] = 0.068947572800103701220156054084758;
            Conversions[Units.Psi] = tbl;

            // From Bar to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.Psi] = 14.5037738007;
            tbl[Units.Bar] = 1.0;
            Conversions[Units.Bar] = tbl;

        }

        #endregion
    }
}

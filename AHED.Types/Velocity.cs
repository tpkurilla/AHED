using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Velocity : Quantity
    {
        public enum Units { MilesPerHour, KilometersPerHour, MetersPerSecond };

        public static Units DuMphOrKph { get; set; }
        public static Units DuMphOrMps { get; set; }
        public double MphOrKph { get { return ToDuMphOrKph(); } }
        public double MphOrMps { get { return ToDuMphOrMps(); } }

        public double Mph { get { return ToMilesPerHour(); } }
        public double Kph { get { return ToKilometersPerHour(); } }
        public double Mps { get { return ToMetersPerSecond(); } }

        public bool HasValue { get { return Value.HasValue; } }

        public Units OriginalUnits { get; set; }

        public Velocity()
        {
        }

        public Velocity(Velocity rhs)
        {
            if (rhs == null)
            {
                Value = null;
                OriginalUnits = Units.MilesPerHour;
                return;
            }

            Value = rhs.Value;
            OriginalUnits = rhs.OriginalUnits;
        }

        public Velocity(double value, Units units)
        {
            Value = value;
            OriginalUnits = units;
        }

        public double ToDuMphOrKph()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][DuMphOrKph];
        }

        public double ToDuMphOrMps()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][DuMphOrKph];
        }

        public double ToMilesPerHour()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.MilesPerHour];
        }

        public double ToKilometersPerHour()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.KilometersPerHour];
        }

        public double ToMetersPerSecond()
        {
            if (!Value.HasValue)
                return Double.NaN;

            double value = (double)Value;
            if (Double.IsInfinity(value) || Double.IsNaN(value))
                return value;

            return value * Conversions[OriginalUnits][Units.MetersPerSecond];
        }

        public override string UnitsString()
        {
            return OriginalUnits.ToString();
        }

        public static void MphOrKphTextAndUnits(Velocity velocity, out string velocityText, out Units velocityUnits)
        {
            if (velocity == null)
            {
                velocityText = String.Empty;
                velocityUnits = DuMphOrKph;
            }
            else
            {
                velocityText = velocity.Text;
                velocityUnits = velocity.OriginalUnits;
            }

        }

        public static void MphOrMpsTextAndUnits(Velocity velocity, out string velocityText, out Units velocityUnits)
        {
            if (velocity == null)
            {
                velocityText = String.Empty;
                velocityUnits = DuMphOrMps;
            }
            else
            {
                velocityText = velocity.Text;
                velocityUnits = velocity.OriginalUnits;
            }

        }

        public static double Convert(double value, Units fromUnits, Units toUnits)
        {
            return value * Conversions[fromUnits][toUnits];
        }

        public static double Convert(Velocity value, Units toUnits)
        {
            if (!value.HasValue)
                return Double.NaN;

            return (double)value.Value * Conversions[value.OriginalUnits][toUnits];
        }

        // Takes the mph or kph values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Velocity UseMphOrKph(double? mph, double? kph)
        {
            bool mphNull = (mph == null);
            bool kphNull = (kph == null);

            // both are null, then so is the value
            if (mphNull && kphNull)
                return new Velocity();

            if (mphNull)
                return new Velocity((double)kph, Units.KilometersPerHour);

            if (kphNull)
                return new Velocity((double)mph, Units.MilesPerHour);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)kph;
            if (kph == (int)kph)
                return new Velocity(value, Units.KilometersPerHour);

            // meters were not whole, so default to feet regardless
            return new Velocity((double)mph, Units.MilesPerHour);
        }

        // Takes the mph or mps values from a data entry or spreadsheet import,
        // and chooses which is the original value
        public static Velocity UseMphOrMps(double? mph, double? mps)
        {
            bool mphNull = (mph == null);
            bool mpsNull = (mps == null);

            // both are null, then so is the value
            if (mphNull && mpsNull)
                return new Velocity();

            if (mphNull)
                return new Velocity((double)mps, Units.MetersPerSecond);

            if (mpsNull)
                return new Velocity((double)mph, Units.MilesPerHour);

            // At this point, they both have a value, so choose the one that is a whole number if possible
            double value = (double)mps;
            if (mps == (int)mps)
                return new Velocity(value, Units.MetersPerSecond);

            // meters were not whole, so default to feet regardless
            return new Velocity((double)mph, Units.MilesPerHour);
        }

        #region Static conversion data

        // Conversions[fromUnits][toUnits] yields the value with which to multiply from by to get to
        static Dictionary<Velocity.Units, Dictionary<Velocity.Units, double>> Conversions =
            new Dictionary<Units, Dictionary<Units, double>>();

        // Initialize the conversion table.
        // Conversion values extracted from http://www.angelfire.com/az/deaflab/measure.html to 15 digits of precision
        // This can be expanded to handle all Velocitys requiring support
        static Velocity()
        {
            DuMphOrKph = Units.MilesPerHour;
            DuMphOrMps = Units.MilesPerHour;

            // From mph to...
            var tbl = new Dictionary<Units, double>();
            tbl[Units.MilesPerHour] = 1.0;
            tbl[Units.KilometersPerHour] = 1.609344;
            tbl[Units.MetersPerSecond] = 0.44704;
            Conversions[Units.MilesPerHour] = tbl;

            // From kph to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.MilesPerHour] = 0.621371192237334;
            tbl[Units.KilometersPerHour] = 1.0;
            tbl[Units.MetersPerSecond] = 1.0 / 3600.0 * 1000.0;  // kph * 1 hour/3600 secs * 1000 m/km
            Conversions[Units.KilometersPerHour] = tbl;

            // From mps to...
            tbl = new Dictionary<Units, double>();
            tbl[Units.MilesPerHour] = 2.2369362920544;
            tbl[Units.KilometersPerHour] = 3.6;
            tbl[Units.MetersPerSecond] = 1.0;
            Conversions[Units.MetersPerSecond] = tbl;

        }

        #endregion
    }
}

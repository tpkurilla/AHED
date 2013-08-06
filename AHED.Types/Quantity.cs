using System;

namespace AHED.Types
{
    /// <summary>
    /// Base class for all quantities.  Implements basic behavior for handling
    /// the numeric value part of a quantity.  Each subclass must provide its
    /// own implementation of <c>Units</c>.
    /// <br/>
    /// The numeric value, <c>Value</c>, is nullable, and can contain any valid
    /// <c>double</c> value.  <c>Double.NaN</c> is used to represent a value
    /// below Level of Quantification (LOQ), and <c>Double.NegativeInfinity</c>
    /// is used to represent a value below Level of Detection (LOD).
    /// <br/>
    /// This class implements static methods <c>Parse</c> and <c>TryParse</c>
    /// with behavior patterned after <c>System.Double</c>.  Each will accept
    /// a null or empty string as a null value, "LQ" as an LOQ value, and
    /// "LD" as an LOD value.
    /// </summary>
    [Serializable]
    public abstract class Quantity
    {
        /// <summary>
        /// Stores the actual value for this <c>Quantity</c>.
        /// </summary>
        private double? _value;

        /// <summary>
        /// Provides the value for this <c>Quantity</c>.  When its value
        /// changes, the <c>Text</c> property is reset.
        /// </summary>
        public double? Value
        {
            get { return _value; }
            set
            {
                _value = value;
                _text = null;
            }
        }

        /// <summary>
        /// Cache of the string representation for this quantity's numeric value.
        /// <br/>
        /// Once the string value is computed, it is cached here to avoid 
        /// repeated conversion to string.
        /// </summary>
        private string _text;

        /// <summary>
        /// The text representation of the numeric value of this quantity.
        /// </summary>
        public string Text
        {
            get
            {
                if (_text == null)
                    _text = ToString();

                return _text;
            }
        }

        /// <summary>
        /// Converts the numeric value of this quantity to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of this quantity's numeric value.</returns>
        /// <remarks>
        /// To get the string representation of this quantity, including its <c>Units</c>,
        /// use <c>ToFullString</c>.
        /// </remarks>
        public override string ToString()
        {
            if (!Value.HasValue)
                return String.Empty;

            double value = (double)Value;
            if (Double.IsNaN(value))
                return "NQ";

            if (Double.IsNegativeInfinity(value))
                return "ND";

            return value.ToString();
        }

        public abstract string UnitsString();

        public string ToFullString()
        {
            return Text + " " + UnitsString();
        }

        /// <summary>
        /// Converts the string representation of a numeric quantity to its
        /// Nullable floating-point equivalent.
        /// </summary>
        /// <param name="s">A string that contains the nubmer to convert.</param>
        /// <returns>A <c>double?</c> that is equivalent to the numeric value or symbol specified in <c>s</c>.</returns>
        /// <exception cref="ArgumentNullException"><c>s</c> is <b>null</b></exception>
        /// <exception cref="FormatException"><c>s</c> is not in the correct format.</exception>
        /// <exception cref="OverflowException">
        /// <c>s</c> represents a number that is less than <c>Double.MinValue</c> or greater
        /// than <c>Double.MaxValue</c>.
        /// </exception>
        /// <remarks>
        /// The <c>s</c> parameter can be of the form specified for <c>System.Double.Parse</c>, or
        /// be either "NQ", meaning below Level of Quantitification (LOQ), or "ND", meaning below
        /// level of Detection (LOD).
        /// <br/>
        /// Internally, LOQ is represented as <c>Double.NaN</c>, LOD is represented as
        ///  <c>Double.NegativeInfinity</c>, and a null or empty string is represented
        /// as <c>null</c>.
        /// </remarks>
        public static double? Parse(string s)
        {
            if (String.IsNullOrEmpty(s))
                return null;

            // Technically, this will match anything with "NQ" in it, but this
            // avoids creating a trimmed string, and should be good enough.
            if (s.Contains("NQ"))
            {
                return Double.NaN;
            }

            // Technically, this will match anything with "NQ" in it, but this
            // avoids creating a trimmed string, and should be good enough.
            if (s.Contains("ND"))
            {
                return Double.NegativeInfinity;
            }

            return Double.Parse(s);
        }

        /// <summary>
        /// Converts the string representation of a numeric quantity to its <c>double?</c> equivalent.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A string containing the number to convert.</param>
        /// <param name="result">When this method returns, contains the <c>double?</c> equivalent to the
        ///  <c>s</c> parameter, if the conversion succeeded, or null if the conversion failed.  The
        ///  conversion fails if the <c>Double.TryParse</c> call failed, and <c>s</c> was not one of:
        ///  <c>null</c>, "NQ", or "ND".
        /// </param>
        /// <returns><c>true</c> if <c>s</c> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParse(string s, out double? result)
        {
            if (String.IsNullOrEmpty(s))
            {
                result = null;
                return true;
            }

            // Technically, this will match anything with "NQ" in it, but this
            // avoids creating a trimmed string, and should be good enough.
            if (s.Contains("NQ"))
            {
                result = Double.NaN;
                return true;
            }

            // Technically, this will match anything with "NQ" in it, but this
            // avoids creating a trimmed string, and should be good enough.
            if (s.Contains("ND"))
            {
                result = Double.NegativeInfinity;
                return true;
            }

            double value;
            bool suceeded = Double.TryParse(s, out value);
            if (suceeded)
            {
                result = value;
                return true;
            }

            result = null;
            return false;
        }
    }
}

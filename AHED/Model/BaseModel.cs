using System;
using System.Collections.Generic;
using System.ComponentModel;
using AHED.Types;

namespace AHED.Model
{
    public class BaseModel : IDataErrorInfo
    {
        public BaseModel() { }

        #region Quantity Support

        protected void AreaTextAndUnits(Area area, out string areaText, out Area.Units areaUnits)
        {
            if (area == null)
            {
                areaText = String.Empty;
                areaUnits = Area.DisplayUnits;
            }
            else
            {
                areaText = area.ToString();
                areaUnits = area.OriginalUnits;
            }

        }

        protected void LengthInOrCmTextAndUnits(Length length, out string lengthText, out Length.Units lengthUnits)
        {
            if (length == null)
            {
                lengthText = String.Empty;
                lengthUnits = Length.DuInOrCm;
            }
            else
            {
                lengthText = length.ToString();
                lengthUnits = length.OriginalUnits;
            }

        }

        protected void LengthFtOrMTextAndUnits(Length length, out string lengthText, out Length.Units lengthUnits)
        {
            if (length == null)
            {
                lengthText = String.Empty;
                lengthUnits = Length.DuFtOrM;
            }
            else
            {
                lengthText = length.ToString();
                lengthUnits = length.OriginalUnits;
            }

        }

        protected void MassTextAndUnits(Mass mass, out string massText, out Mass.Units massUnits)
        {
            if (mass == null)
            {
                massText = String.Empty;
                massUnits = Mass.DisplayUnits;
            }
            else
            {
                massText = mass.ToString();
                massUnits = mass.OriginalUnits;
            }

        }

        protected void MassPerVolumeTextAndUnits(MassPerVolume mass, out string massText, out MassPerVolume.Units massUnits)
        {
            if (mass == null)
            {
                massText = String.Empty;
                massUnits = MassPerVolume.DisplayUnits;
            }
            else
            {
                massText = mass.ToString();
                massUnits = mass.OriginalUnits;
            }

        }

        protected void PressureTextAndUnits(Pressure pressure, out string pressureText, out Pressure.Units pressureUnits)
        {
            if (pressure == null)
            {
                pressureText = String.Empty;
                pressureUnits = Pressure.DisplayUnits;
            }
            else
            {
                pressureText = pressure.ToString();
                pressureUnits = pressure.OriginalUnits;
            }

        }

        protected void TemperatureTextAndUnits(Temperature temperature, out string temperatureText, out Temperature.Units temperatureUnits)
        {
            if (temperature == null)
            {
                temperatureText = String.Empty;
                temperatureUnits = Temperature.DisplayUnits;
            }
            else
            {
                temperatureText = temperature.ToString();
                temperatureUnits = temperature.OriginalUnits;
            }

        }

        protected void VelocityMphOrKphTextAndUnits(Velocity velocity, out string velocityText, out Velocity.Units velocityUnits)
        {
            if (velocity == null)
            {
                velocityText = String.Empty;
                velocityUnits = Velocity.DuMphOrKph;
            }
            else
            {
                velocityText = velocity.ToString();
                velocityUnits = velocity.OriginalUnits;
            }

        }

        protected void VelocityMphOrMpsTextAndUnits(Velocity velocity, out string velocityText, out Velocity.Units velocityUnits)
        {
            if (velocity == null)
            {
                velocityText = String.Empty;
                velocityUnits = Velocity.DuMphOrMps;
            }
            else
            {
                velocityText = velocity.ToString();
                velocityUnits = velocity.OriginalUnits;
            }

        }

        protected void VolumeTextAndUnits(Volume volume, out string volumeText, out Volume.Units volumeUnits)
        {
            if (volume == null)
            {
                volumeText = String.Empty;
                volumeUnits = Volume.DisplayUnits;
            }
            else
            {
                volumeText = volume.ToString();
                volumeUnits = volume.OriginalUnits;
            }

        }

        #endregion Quantity Support

        #region General Validation

        /// <summary>
        /// Holds any error messages for this <c>WorkerInfo</c>.
        /// </summary>
        Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        // Adds the specified error to the errors collection if it is not already 
        // present, inserting it in the first position if isWarning is false. 
        public void AddError(string propertyName, string error, bool isWarning)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                if (isWarning) _errors[propertyName].Add(error);
                else _errors[propertyName].Insert(0, error);
            }
        }

        // Removes the specified error from the errors collection if it is present. 
        public void RemoveError(string propertyName, string error)
        {
            if (_errors.ContainsKey(propertyName) &&
                _errors[propertyName].Contains(error))
            {
                _errors[propertyName].Remove(error);
                if (_errors[propertyName].Count == 0) _errors.Remove(propertyName);
            }
        }

        /// <summary>
        /// Checks whether string has a non-empty value.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>Whether the string has a value.</returns>
        public static bool IsStringMissing(string str)
        {
            return
                String.IsNullOrEmpty(str)
                || str.Trim() == String.Empty;
        }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return _errors.Count < 1;
            }
        }

        /// <summary>
        /// Constant signifying that any valid number is allowed.
        /// </summary>
        public const bool AnyNumber = false;

        /// <summary>
        /// Constant signifying that only positive numbers are allowed.
        /// </summary>
        public const bool PositiveOnly = true;

        public readonly double? NoLowerBound = null;

        public readonly double? NoUpperBound = null;

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalLoadsMixed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="positiveOnly">Whether only positive values are valid.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalLoadsMixed</c>.</returns>
        public bool ValidateDouble(string str, bool positiveOnly,
                                   string propertyName, string errorText,
                                   out double? value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (positiveOnly && numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = numericValue;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalLoadsMixed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="positiveOnly">Whether only positive values are valid.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalLoadsMixed</c>.</returns>
        public bool ValidateInt(string str, bool positiveOnly,
                                string propertyName, string errorText,
                                out int? value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            int numericValue;
            if (!Int32.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (positiveOnly && numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = numericValue;
            return true;
        }

        public bool ValidateRange(double? value, double? minValue, double? maxValue,
                                  string propertyName, string errorText)
        {
            // if there are no boundaries provided, then simply clear the error
            if (!minValue.HasValue && !maxValue.HasValue)
            {
                RemoveError(propertyName, errorText);
                return true;
            }

            // There is either a lower bound, and upper bound, or both.
            // In any case, if the value is null, then set the error.
            if (!value.HasValue)
            {
                AddError(propertyName, errorText, false);
                return false;
            }

            if ((minValue.HasValue && value < minValue)
                || (maxValue.HasValue && value > maxValue))
            {
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Area</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Area.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Area</c>.</returns>
        public bool ValidateArea(string str, Area.Units units, string propertyName, string errorText, out Area value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Area(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Length</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a length.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Length</c>.</returns>
        public bool ValidateLength(string str, Length.Units units, string propertyName, string errorText, out Length value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Length(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Mass</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Mass.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Mass</c>.</returns>
        public bool ValidateMass(string str, Mass.Units units, string propertyName, string errorText, out Mass value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Mass(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Mass</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Mass.</param>
        /// <param name="units">The units to use for this mass/volume.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Mass</c>.</returns>
        public bool ValidateMassPerVolume(string str, MassPerVolume.Units units, string propertyName, string errorText, out MassPerVolume value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new MassPerVolume(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Pressure</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a pressure.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Pressure</c>.</returns>
        public bool ValidatePressure(string str, Pressure.Units units, string propertyName, string errorText, out Pressure value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Pressure(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Temperature</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, or any value between -50 and 130 degrees Fahrenheit.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Temperature.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Temperature</c>.</returns>
        public bool ValidateTemperature(string str, Temperature.Units units, string propertyName, string errorText, out Temperature value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            double minValue = Types.Temperature.Convert(-50, Types.Temperature.Units.Fahrenheit, units);
            double maxValue = Types.Temperature.Convert(130, Types.Temperature.Units.Fahrenheit, units);

            if (numericValue < minValue || numericValue > maxValue)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Temperature(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Velocity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a velocity.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Velocity</c>.</returns>
        public bool ValidateVelocity(string str, Velocity.Units units, string propertyName, string errorText, out Velocity value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Velocity(numericValue, units);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Volume</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Volume.</param>
        /// <param name="units">The units to use for this velocity.</param>
        /// <param name="propertyName">The property name to use to register/clear errors.</param>
        /// <param name="errorText">The error text to use.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Volume</c>.</returns>
        public bool ValidateVolume(string str, Volume.Units units, string propertyName, string errorText, out Volume value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(propertyName, errorText);
                return true;
            }

            double numericValue;
            if (!Double.TryParse(str, out numericValue))
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            if (numericValue <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
            value = new Volume(numericValue, units);
            return true;
        }

        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                List<string> propertyErrors = null;
                foreach (string key in _errors.Keys)
                    if (_errors.ContainsKey(key))
                    {
                        if (propertyErrors == null)
                            propertyErrors = new List<string>();
                        propertyErrors.Add(String.Join(Environment.NewLine, _errors[key]));
                    }

                if (propertyErrors == null)
                    return null;

                return String.Join(Environment.NewLine, propertyErrors);
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return (!_errors.ContainsKey(propertyName) ? null :
                    String.Join(Environment.NewLine, _errors[propertyName]));
            }
        }

        #endregion

    }
}

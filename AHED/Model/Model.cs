using System;
using System.Collections.Generic;
using System.ComponentModel;
using AHED.Types;

namespace AHED.Model
{
    /// <summary>
    /// Base class for handling the grunt work for any class needing a
    /// "Model" representation; the 'M' in M-V-VM, MVVM.  It implements
    /// the <c>IDataErrorInfo</c> interface in a generic way that can
    /// support any Model sub-class.  It also implements a basic
    /// "original" and "working-copy" model to allow changes to be
    /// either saved or cancelled, as well as a series of methods
    /// for supporting property validation.
    /// </summary>
    /// <typeparam name="T">
    /// Any basic class that can Deep Clone itself and supports property initialization.
    /// </typeparam>
    public class Model<T> : IDataErrorInfo
        where T : class, IDeepClone<T>, IPropertyInitializer, new ()
    {
        #region Events

        public event EventHandler ValueReset;

        protected virtual void RaiseValueReset()
        {
            EventHandler handler = ValueReset;
            if (ValueReset != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion Events

        #region Properties

        /// <summary>
        /// The original, untouched value for the instance of <c>T</c>
        /// being modeled.  Replaced with the current, validated, working
        /// copy in <c>Value</c> when "Save" is pressed.
        /// </summary>
        public T OriginalValue { get; protected set; }

        /// <summary>
        /// The current working copy of the instance of <c>T</c> being
        /// modeled.  Will be reset to a copy of <c>OriginalValue</c>
        /// when "Cancel" is pressed.
        /// </summary>
        public T Value { get; protected set; }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid { get { return _errors.Count < 1; } }

        #endregion Properties

        #region Property Names

        // String constants matching Propertiy names.
        // Declared here to avoid use of string constants inline.

        public const string OriginalValueName = "OriginalValue";
        public const string ValueName = "Value";
        public const string IsValidName = "IsValid";

        #endregion

        #region Creation

        /// <summary>
        /// Basic constructor to handle creation of a new instance
        /// of <c>T</c>.  All properties are guaranteed correctly
        /// initialized by calling the new instance's
        ///  <c>InitializeProperties</c> method.
        /// </summary>
        public Model()
        {
            OriginalValue = new T();
            OriginalValue.InitializeProperties();

            Value = new T();
            Value.InitializeProperties();
        }

        /// <summary>
        /// Constructor to handle initialization using an already
        /// existant instance of <c>T</c>.  If, for some reason,
        /// the <c>value</c> provided is <c>null</c>, then the
        /// same initialization as the basic constructor is used.
        /// Otherwise, the value provided is stored in
        ///  <c>OriginalValue</c>, and a deep clone is created and
        /// stored in <c>Value</c>.
        /// </summary>
        /// <param name="value">An instance of <c>T</c> to be modeled.</param>
        public Model(T value)
        {
            if (value == null)
            {
                OriginalValue = new T();
                OriginalValue.InitializeProperties();

                Value = new T();
                Value.InitializeProperties();
            }
            else
            {
                OriginalValue = value;
                Value = value.DeepClone();
            }
        }

        /// <summary>
        /// Constructor mainly used for deep cloning of a <c>Model</c>.
        /// </summary>
        /// <param name="value">An instance to be deep-cloned.</param>
        public Model(Model<T> value)
        {
            if (value == null)
            {
                OriginalValue = new T();
                OriginalValue.InitializeProperties();

                Value = new T();
                Value.InitializeProperties();
            }
            else
            {
                OriginalValue = value.OriginalValue.DeepClone();
                Value = value.Value.DeepClone();
            }
        }

        #endregion Creation

        #region Public Methods

        /// <summary>
        /// Sets the working copy back to the original values.
        /// <br/>
        /// NOTE: You must call SetProperties on the instance reset.  Could not
        /// find a way to trigger the correct sub-class SetProperties.  Since
        /// sub-classes will generally be created in a ViewModel sub-class,
        /// this should always be handled correctly.
        /// </summary>
        public virtual void Cancel()
        {
            Value = OriginalValue.DeepClone();
            RaiseValueReset();
        }

        /// <summary>
        /// Stores all working values into the original.
        /// </summary>
        public virtual void Save()
        {
            if (!IsValid)
            {
                // The interface should prevent this...
                var name = GetType().Name;
                throw new InvalidOperationException(Properties.Resources.Model_Exception_Cannot_Update + ": " + name);
            }

            OriginalValue = Value.DeepClone();
        }

        public virtual bool Validate()
        {
            return true;
        }

        #endregion Public Methods

        #region General Validation

        /// <summary>
        /// Holds any error messages for this <c>WorkerInfo</c>.
        /// </summary>
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

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

            bool isValid = Quantity.TryParse(str, out value);
            if (!isValid || !value.HasValue)
                return isValid;

            if (positiveOnly && value.Value <= 0)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Area
                {
                    Value = result,
                    OriginalUnits = units
                };

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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Length
                {
                    Value = result,
                    OriginalUnits = units
                };

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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Mass
            {
                Value = result,
                OriginalUnits = units
            };

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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new MassPerVolume
            {
                Value = result,
                OriginalUnits = units
            };

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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Pressure
                {
                    Value = result,
                    OriginalUnits = units
                };

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
            double? result;
            bool isValid = ValidateDouble(str, AnyNumber, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Temperature
            {
                Value = result,
                OriginalUnits = units
            };

            if (!result.HasValue)
                return true;

            double numericValue = result.Value;

            double minValue = Temperature.Convert(-50, Temperature.Units.Fahrenheit, units);
            double maxValue = Temperature.Convert(130, Temperature.Units.Fahrenheit, units);

            if (numericValue < minValue || numericValue > maxValue)
            {
                value = null;
                AddError(propertyName, errorText, false);
                return false;
            }

            RemoveError(propertyName, errorText);
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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Velocity
            {
                Value = result,
                OriginalUnits = units
            };

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
            double? result;
            bool isValid = ValidateDouble(str, PositiveOnly, propertyName, errorText, out result);
            if (!isValid)
            {
                value = null;
                return false;
            }

            value = new Volume
            {
                Value = result,
                OriginalUnits = units
            };

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

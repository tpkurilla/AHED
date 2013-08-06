using System;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Represents a Field Fortification Entry, and has built-in validation logic. 
    /// </summary>
    public class FieldFortEntryModel : Model<FieldFortification.Entry>, IDeepClone<FieldFortEntryModel>
    {
        #region Properties

        public string Description
        {
            get { return Value.Description; }
            set
            {
                if (value != Value.Description)
                {
                    if (ValidateDescription(value))
                        Value.Description = value;
                }
            }
        }

        private string _fortificationLevelText;
        public string FortificationLevel
        {
            get { return _fortificationLevelText; }
            set
            {
                if (value != _fortificationLevelText)
                {
                    double level = 0;
                    if (!ValidateFortificationLevel(value, ref level))
                    {
                        _fortificationLevelText = value;
                    }
                    else
                    {
                        _fortificationLevelText = level.ToString(Culture.Info);
                        Value.FortificationLevel = level;
                    }
                }
            }
        }

        private string _fortificationAdjustmentText;
        public string FortificationAdjustment
        {
            get { return _fortificationAdjustmentText; }
            set
            {
                if (value != _fortificationAdjustmentText)
                {
                    double adjustment = 0;
                    if (!ValidateFortificationAdjustment(value, ref adjustment))
                    {
                        _fortificationAdjustmentText = value;
                    }
                    else
                    {
                        _fortificationAdjustmentText = adjustment.ToString(Culture.Info);
                        Value.FortificationAdjustment = adjustment;
                    }
                }
            }
        }

        #endregion Properties

        #region Creation

        public FieldFortEntryModel(){}

        public FieldFortEntryModel(FieldFortification.Entry entry)
            : base(entry)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public FieldFortEntryModel(FieldFortEntryModel entry)
            : base(entry)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            // Set all Model properties, and trigger all validations
            Description = Value.Description;
            FortificationLevel = Value.FortificationLevel.ToString(Culture.Info);
            FortificationAdjustment = Value.FortificationAdjustment.ToString(Culture.Info);
        }

        public static FieldFortEntryModel Create()
        {
            FieldFortification.Entry entry = FieldFortification.Entry.CreateFieldFortEntry();
            entry.InitializeProperties();

            return new FieldFortEntryModel(entry);
        }

        #endregion // Creation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string DescriptionName = "Description";
        public const string FortificationLevelName = "FortificationLevel";
        public const string FortificationAdjustmentName = "FortificationAdjustment";

        #endregion

        #region Validation

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Description</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field.  Uniqueness is checked by the containing
        /// AllFieldFortEntriesViewModel.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Description</c>.</returns>
        private bool ValidateDescription(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(DescriptionName, Properties.Resources.FieldFortEntry_Description);
                return true;
            }

            AddError(DescriptionName, Properties.Resources.FieldFortEntry_Description, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>FortificationLevel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a fortification level.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>FortificationLevel</c>.</returns>
        private bool ValidateFortificationLevel(string str, ref double value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(FortificationLevelName, Properties.Resources.FieldFortEntry_Fortification_Level, false);
                return false;
            }

            double level;
            if (!Double.TryParse(str, out level))
            {
                AddError(FortificationLevelName, Properties.Resources.FieldFortEntry_Fortification_Level, false);
                return false;
            }

            if (level <= 0)
            {
                AddError(FortificationLevelName, Properties.Resources.FieldFortEntry_Fortification_Level, false);
                return false;
            }

            RemoveError(FortificationLevelName, Properties.Resources.FieldFortEntry_Fortification_Level);
            value = level;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ValidateFortificationAdjustment</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a fortification adjustment.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ValidateFortificationAdjustment</c>.</returns>
        private bool ValidateFortificationAdjustment(string str, ref double value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(FortificationAdjustmentName, Properties.Resources.FieldFortEntry_Fortification_Adjustment, false);
                return false;
            }

            double adjustment;
            if (!Double.TryParse(str, out adjustment))
            {
                AddError(FortificationAdjustmentName, Properties.Resources.FieldFortEntry_Fortification_Adjustment, false);
                return false;
            }

            if (adjustment <= 0)
            {
                AddError(FortificationAdjustmentName, Properties.Resources.FieldFortEntry_Fortification_Adjustment, false);
                return false;
            }

            RemoveError(FortificationAdjustmentName, Properties.Resources.FieldFortEntry_Fortification_Adjustment);
            value = adjustment;
            return true;
        }

        #endregion // Validation

        #region IDeepClone Interface

        FieldFortEntryModel IDeepClone<FieldFortEntryModel>.DeepClone()
        {
            return new FieldFortEntryModel(this);
        }

        #endregion IDeepClone Interface

    }
}

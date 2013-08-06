using System;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class ChangeLogEntryModel : Model<ChangeLogEntry>, IDeepClone<ChangeLogEntryModel>
    {
        private readonly DatabaseModel _parentDatabase;
        private readonly ModelCache<ChangeLogEntryModel, ChangeLogEntry> _cache;

        #region Properties

        private string _dateChanged;
        public string DateChanged
        {
            get { return _dateChanged; }
            set
            {
                if (value != _dateChanged)
                {
                    DateTime dateChanged = DateTime.Now;
                    if (!ValidateDateChanged(value, ref dateChanged))
                        _dateChanged = value;
                    else
                    {
                        Value.DateChanged = dateChanged;
                        _dateChanged = Value.DateChanged.ToShortDateString();
                    }
                }
            }
        }

        public StaticValues.QaStatus Status { get; set; }

        private string _identity;
        public string Identity
        {
            get { return _identity; }
            set
            {
                if (value != _identity)
                {
                    _identity = value;
                    if (ValidateIdentity(value))
                        Value.Identity = value;
                }
            }
        }

        private string _versionMajorText;
        public string VersionMajor
        {
            get { return _versionMajorText; }
            set
            {
                if (value != _versionMajorText)
                {
                    int versionMajor;
                    if (!ValidateVersionMajor(value, out versionMajor))
                        _versionMajorText = value;
                    else
                    {
                        Value.VersionMajor = versionMajor;
                        _versionMajorText = versionMajor.ToString(Culture.Info);
                    }
                }
            }
        }

        private string _versionMinorText;
        public string VersionMinor
        {
            get { return _versionMinorText; }
            set
            {
                if (value != _versionMinorText)
                {
                    int versionMinor;
                    if (!ValidateVersionMinor(value, out versionMinor))
                        _versionMinorText = value;
                    else
                    {
                        Value.VersionMinor = versionMinor;
                        _versionMinorText = versionMinor.ToString(Culture.Info);
                    }
                }
            }
        }

        public CommentModel CommentModel { get; set; }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public new bool IsValid
        {
            get
            {
                return base.IsValid && CommentModel.IsValid;
            }
        }

        #endregion

        #region Creation

        public ChangeLogEntryModel() { }

        public ChangeLogEntryModel(ChangeLogEntry changeLogEntry,
            ModelCache<ChangeLogEntryModel, ChangeLogEntry> cache, DatabaseModel parentDatabase)
            : base(changeLogEntry)
        {
            if (cache == null)
                throw new ArgumentNullException("cache");

            if (parentDatabase == null)
                throw new ArgumentNullException("parentDatabase");

            _parentDatabase = parentDatabase;
            _cache = cache;

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public ChangeLogEntryModel(ChangeLogEntryModel changeLogEntryModel)
            : base(changeLogEntryModel)
        {
            _parentDatabase = changeLogEntryModel._parentDatabase;
            _cache = changeLogEntryModel._cache;

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            DateChanged = Value.DateChanged.ToShortDateString();
            Status = Value.Status;
            Identity = Value.Identity;
            VersionMajor = Value.VersionMajor.ToString(Culture.Info);
            VersionMinor = Value.VersionMinor.ToString(Culture.Info);
            CommentModel = new CommentModel(Value.Comment);
        }

        #endregion Creation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string DateChangedName = "DateChanged";
        public const string StatusName = "Status";
        public const string IdentityName = "Identity";
        public const string VersionMajorName = "VersionMajor";
        public const string VersionMinorName = "VersionMinor";
        public const string CommentName = "Comment";

        #endregion

        #region Validation

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>DateChanged</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field, and must be unique.  Uniqueness is tested elsewhere.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Date.</param>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>DateChanged</c>.</returns>
        private bool ValidateDateChanged(string str, ref DateTime value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(DateChangedName, Properties.Resources.ChangeLogModel_Invalid_DateChanged, false);
                return false;
            }

            DateTime date;
            if (!DateTime.TryParse(str, out date))
            {
                AddError(DateChangedName, Properties.Resources.ChangeLogModel_Invalid_DateChanged, false);
                return false;
            }

            RemoveError(DateChangedName, Properties.Resources.ChangeLogModel_Invalid_DateChanged);
            value = date;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Identity</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field, and must be either match the value of
        /// <c>Crendential.LocalUser</c>, or be a Authenticated identity from
        /// the AHED server.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Identity</c>.</returns>
        private bool ValidateIdentity(string value)
        {
            if (Credential.Validate(value))
            {
                RemoveError(IdentityName, Properties.Resources.Study_Study_Number);
                return true;
            }

            AddError(IdentityName, Properties.Resources.Study_Study_Number, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VersionMajor</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field.  It must be greater than or equal to 1.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Version Major.</param>
        /// <param name="value"><c>str</c> convered to a Version Major.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VersionMajor</c>.</returns>
        private bool ValidateVersionMajor(string str, out int value)
        {
            if (IsStringMissing(str))
            {
                value = 0;
                AddError(VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMajor, false);
                return false;
            }

            int? parsedValue;
            bool isValid = ValidateInt(str, PositiveOnly,
                                       VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMajor,
                                       out parsedValue);
            if (!isValid || parsedValue == null)
            {
                value = 0;
                return false;
            }

            value = (int)parsedValue;
            if (value < _parentDatabase.Value.VersionMajor)
            {
                return false;
            }

            RemoveError(VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMajor);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VersionMinor</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field.  It must be greater than or equal to 1.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Version Minor.</param>
        /// <param name="value"><c>str</c> convered to a Version Major.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VersionMinor</c>.</returns>
        private bool ValidateVersionMinor(string str, out int value)
        {
            if (IsStringMissing(str))
            {
                value = 0;
                AddError(VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMinor, false);
                return false;
            }

            int? parsedValue;
            bool isValid = ValidateInt(str, PositiveOnly,
                                       VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMinor,
                                       out parsedValue);
            if (!isValid || parsedValue == null)
            {
                value = 0;
                AddError(VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMinor, false);
                return false;
            }

            value = (int)parsedValue;
            if (_parentDatabase.Value.VersionMajor < Value.VersionMajor)
            {
                RemoveError(VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMinor);
                return true;
            }

            if (value <= _parentDatabase.Value.VersionMinor)
            {
                AddError(VersionMajorName, Properties.Resources.ChangeLogModel_Invalid_VersionMinor, false);
                return false;
            }

            return true;
        }

        #endregion Validation

        #region IDeepClone Interface

        ChangeLogEntryModel IDeepClone<ChangeLogEntryModel>.DeepClone()
        {
            return new ChangeLogEntryModel(this);
        }

        #endregion IDeepClone Interface
    }
}

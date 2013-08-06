using System;
using System.Collections.Generic;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class DatabaseModel : Model<Database>, IDeepClone<DatabaseModel>
    {
        #region Properties

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    if (!ValidateDescription(value))
                    {
                        _description = value;
                    }
                    else
                    {
                        Value.Description = value;
                        _description = Value.Description;
                    }
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
                    {
                        _versionMajorText = value;
                    }
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
                    {
                        _versionMinorText = value;
                    }
                    else
                    {
                        Value.VersionMinor = versionMinor;
                        _versionMinorText = versionMinor.ToString(Culture.Info);
                    }
                }
            }
        }

        private string _dateCreatedText;
        public string DateCreated
        {
            get { return _dateCreatedText; }
            set
            {
                if (value != _dateCreatedText)
                {
                    DateTime date = DateTime.Now;
                    if (!ValidateDateCreated(value, ref date))
                    {
                        _dateCreatedText = value;
                    }
                    else
                    {
                        Value.DateCreated = date;
                        _dateCreatedText = date.ToShortDateString();
                    }
                }
            }
        }

        private string _dateLastModifiedText;
        public string DateLastModified
        {
            get { return _dateLastModifiedText; }
            set
            {
                if (value != _dateLastModifiedText)
                {
                    DateTime date = DateTime.Now;
                    if (!ValidateDateLastModified(value, ref date))
                    {
                        _dateLastModifiedText = value;
                    }
                    else
                    {
                        Value.DateLastModified = date;
                        _dateLastModifiedText = date.ToShortDateString();
                    }
                }
            }
        }

        public StaticTableModel StaticTable { get; protected set; }

        public ModelCache<StudyModel, Study> Studies { get; set; }
 
        public StaticValues.QaStatus QaStatus { get; set; }

        public ModelCache<ChangeLogEntryModel,ChangeLogEntry> Changes { get; set; }
        public ModelCache<AccessEntryModel,AccessEntry> AccessEntries { get; set; }

        #endregion Properties

        #region Creation

        public DatabaseModel(){}

        public DatabaseModel(Database database)
            : base(database)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public DatabaseModel(DatabaseModel model)
            : base(model)
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
            Description = String.IsNullOrEmpty(Value.Description) ? String.Empty : Value.Description;
            VersionMajor = Value.VersionMajor.ToString(Culture.Info);
            VersionMinor = Value.VersionMinor.ToString(Culture.Info);
            DateCreated = Value.DateCreated.ToShortDateString();
            DateLastModified = Value.DateLastModified.ToShortDateString();

            StaticTable = new StaticTableModel(Value.StaticTable);

            Studies = new ModelCache<StudyModel, Study>(
                (from study in Value.Studies
                 select new StudyModel(study)
                ).ToList());

            QaStatus = Value.Status;

            Changes = new ModelCache<ChangeLogEntryModel,ChangeLogEntry>();
            var entries = new List<ChangeLogEntryModel>(
                (from changeLogEntry in Value.Changes
                 select new ChangeLogEntryModel(changeLogEntry, Changes, this)
                ).ToList());
            Changes.Add(entries);

            AccessEntries = new ModelCache<AccessEntryModel, AccessEntry>();
            var accessEntries = new List<AccessEntryModel>(
                (from accessEntry in Value.AccessEntries
                 select new AccessEntryModel(accessEntry, AccessEntries)
                ).ToList());
            AccessEntries.Add(accessEntries);
        }

        #endregion Creation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string DescriptionName = "Description";
        public const string VersionMajorName = "VersionMajor";
        public const string VersionMinorName = "VersionMinor";
        public const string DateCreatedName = "DateCreated";
        public const string DateLastModifiedName = "DateLastModified";
        public const string StaticTableName = "StaticTable";
        public const string StudiesName = "Studies";
        public const string StatusName = "QaStatus";
        public const string ChangesName = "Changes";
        public const string AccessEntriesName = "AccessEntries";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Description</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field, and must be unique.  Uniqueness is tested elsewhere.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Description</c>.</returns>
        private bool ValidateDescription(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(DescriptionName, Properties.Resources.Study_Study_Number);
                return true;
            }

            AddError(DescriptionName, Properties.Resources.Study_Study_Number, false);
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
                AddError(VersionMajorName, Properties.Resources.DatabaseModel_Invalid_VersionMajor, false);
                return false;
            }

            int? parsedValue;
            bool isValid = ValidateInt(str, PositiveOnly,
                                       VersionMajorName, Properties.Resources.DatabaseModel_Invalid_VersionMajor,
                                       out parsedValue);
            if (!isValid || parsedValue == null)
            {
                value = 0;
                return false;
            }

            value = (int) parsedValue;
            RemoveError(VersionMajorName, Properties.Resources.DatabaseModel_Invalid_VersionMajor);
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
                AddError(VersionMajorName, Properties.Resources.DatabaseModel_Invalid_VersionMinor, false);
                return false;
            }

            int? parsedValue;
            bool isValid = ValidateInt(str, PositiveOnly,
                                       VersionMajorName, Properties.Resources.DatabaseModel_Invalid_VersionMinor,
                                       out parsedValue);
            if (!isValid || parsedValue == null)
            {
                value = 0;
                return false;
            }

            value = (int)parsedValue;
            RemoveError(VersionMajorName, Properties.Resources.DatabaseModel_Invalid_VersionMinor);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ReplicateDate</c>.
        /// <para>
        /// The date entered must be different from today's date.  <c>DateTime</c>
        /// is not Nullable, so it will always have a value, defaulted to "today",
        /// when it is created.
        /// </para>
        /// </summary>
        /// <param name="str">The raw string to validate as a date.</param>
        /// <param name="value">Date parsed if parse was successful.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ReplicateDate</c>.</returns>
        private bool ValidateDateCreated(string str, ref DateTime value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(DateCreatedName, Properties.Resources.DatabaseModel_Invalid_DateCreated, false);
                return false;
            }

            DateTime date;
            if (!DateTime.TryParse(str, out date))
            {
                AddError(DateCreatedName, Properties.Resources.DatabaseModel_Invalid_DateCreated, false);
                return false;
            }

            RemoveError(DateCreatedName, Properties.Resources.DatabaseModel_Invalid_DateCreated);
            value = date;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>DateLastModified</c>.
        /// <para>
        /// The date entered must be different from today's date.  <c>DateTime</c>
        /// is not Nullable, so it will always have a value, defaulted to "today",
        /// when it is created.
        /// </para>
        /// </summary>
        /// <param name="str">The raw string to validate as a date.</param>
        /// <param name="value">Date parsed if parse was successful.</param>
        /// <returns>Whether <c>value</c> is a valid <c>DateLastModified</c>.</returns>
        private bool ValidateDateLastModified(string str, ref DateTime value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(DateLastModifiedName, Properties.Resources.DatabaseModel_Invalid_DateLastModified, false);
                return false;
            }

            DateTime date;
            if (!DateTime.TryParse(str, out date))
            {
                AddError(DateLastModifiedName, Properties.Resources.DatabaseModel_Invalid_DateLastModified, false);
                return false;
            }

            if (date >= Value.DateCreated)
            {
                RemoveError(DateLastModifiedName, Properties.Resources.DatabaseModel_Invalid_DateLastModified);
                value = date;
                return true;
            }

            AddError(DateLastModifiedName, Properties.Resources.DatabaseModel_Invalid_DateLastModified, false);
            return false;
        }

        #endregion


        public DatabaseModel DeepClone()
        {
            return new DatabaseModel(this);
        }
    }
}

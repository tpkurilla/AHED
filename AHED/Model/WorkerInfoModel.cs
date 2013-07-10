using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using AHED.Types;

namespace AHED.Model
{
    /// <summary>
    /// Wraps <c>WorkerInfo</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class WorkerInfoModel : BaseModel
    {
        /// <summary>
        /// The <c>WorkerInfo</c> being wrapped by this model.
        /// </summary>
        private readonly WorkerInfo _workerInfo;
        
        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidTasks = StaticValues.GroupOptions(StaticValues.Groups.Task);

        public readonly List<StaticItem> ValidGenders = StaticValues.GroupOptions(StaticValues.Groups.Gender);

        public readonly List<StaticItem> ValidEmployments = StaticValues.GroupOptions(StaticValues.Groups.Employment);

        public readonly List<StaticItem> ValidSites = StaticValues.GroupOptions(StaticValues.Groups.Site);

        public readonly List<StaticItem> ValidSeasons = StaticValues.GroupOptions(StaticValues.Groups.Season);

        public readonly List<StaticItem> ValidCountries = StaticValues.GroupOptions(StaticValues.Groups.Country);

        #endregion Valid Options for StaticItems

        #region Properties

        public string WorkerId
        {
            get { return _workerInfo.WorkerId; }
            set
            {
                if (_workerInfo.WorkerId != value && ValidateWorkerId(value))
                {
                    _workerInfo.WorkerId = value;
                }
            }
        }

        public string ReplicateId
        {
            get { return _workerInfo.ReplicateId; }
            set
            {
                if (value != _workerInfo.ReplicateId)
                {
                    if (ValidateReplicateId(value))
                        _workerInfo.ReplicateId = value;
                }
            }
        }

        public StaticItem Task
        {
            get { return _workerInfo.Task; }
            set
            {
                if (value != _workerInfo.Task)
                {
                    if (ValidateTask(value))
                        _workerInfo.Task = value;
                }
            }
        }

        private string _ageText;
        public string Age
        {
            get { return _ageText; }
            set
            {
                if (_ageText != value)
                {
                    int? age = null;
                    if (!ValidateAge(value, ref age))
                    {
                        _ageText = value;
                    }
                    else
                    {
                        _ageText = (age != null) ? age.ToString() : String.Empty;
                        _workerInfo.Age = age;
                    }
                }
            }
        }

        private Length.Units _heightUnits;
        public Length.Units HeightUnits
        {
            get { return _heightUnits; }
            set
            {
                if (value != _heightUnits)
                {
                    _heightUnits = value;
                    _heightText =
                        (_workerInfo.Height != null)
                            ? Length.Convert(_workerInfo.Height, _heightUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _heightText;
        public string Height
        {
            get { return _heightText; }
            set
            {
                if (value != _heightText)
                {
                    Length newHeight;
                    if (ValidateHeight(value, out newHeight))
                    {
                        _workerInfo.Height = newHeight;
                        _heightText =
                            (newHeight != null)
                                ? Length.Convert(newHeight, _heightUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Mass.Units _weightUnits;
        public Mass.Units WeightUnits
        {
            get { return _weightUnits; }
            set
            {
                if (value != _weightUnits)
                {
                    _weightUnits = value;
                    _weightText =
                        (_workerInfo.Weight != null)
                            ? Mass.Convert(_workerInfo.Weight, _weightUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _weightText;
        public string Weight
        {
            get { return _weightText; }
            set
            {
                if (value != _weightText)
                {
                    Mass newWeight;
                    if (ValidateWeight(value, out newWeight))
                    {
                        _workerInfo.Weight = newWeight;
                        _weightText =
                            (newWeight != null)
                                ? Mass.Convert(newWeight, _weightUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        public StaticItem Gender
        {
            get { return _workerInfo.Gender; }
            set
            {
                if (_workerInfo.Gender != value)
                {
                    ValidateGender(value);
                    _workerInfo.Gender = value;
                }
            }
        }

        private string _yearsExperienceText;

        public string YearsExperience
        {
            get { return _yearsExperienceText; }
            set
            {
                if (_yearsExperienceText != value)
                {
                    int? yearsExperience = null;
                    if (!ValidateYearsExperience(value, ref yearsExperience))
                    {
                        _yearsExperienceText = value;
                    }
                    else
                    {
                        _yearsExperienceText = (yearsExperience != null) ? yearsExperience.ToString() : String.Empty;
                        _workerInfo.YearsExperience = yearsExperience;
                    }
                }
            }
        }

        public StaticItem Employment
        {
            get { return _workerInfo.Employment; }
            set
            {
                if (value != _workerInfo.Employment)
                {
                    if (ValidateEmployment(value))
                        _workerInfo.Employment = value;
                }
            }
        }

        public string Biomonitoring
        {
            get { return _workerInfo.Biomonitoring; }
            set
            {
                if (value !=_workerInfo.Biomonitoring)
                {
                    if (ValidateBiomonitoring(value))
                        _workerInfo.Biomonitoring = value;
                }
            }
        }

        private string _replicateDateText;
        public string ReplicateDate
        {
            get { return _replicateDateText; }
            set
            {
                if (value != _replicateDateText)
                {
                    DateTime date = DateTime.Now;
                    if (ValidateReplicateDate(value, ref date))
                    {
                        _workerInfo.ReplicateDate = date;
                        _replicateDateText = date.ToShortDateString();
                    }
                }
            }
        }

        public StaticItem Site
        {
            get { return _workerInfo.Site; }
            set
            {
                if (_workerInfo.Site != value)
                {
                    if (ValidateSite(value))
                        _workerInfo.Site = value;
                }
            }
        }

        public StaticItem Season
        {
            get { return _workerInfo.Season; }
            set
            {
                if (_workerInfo.Season != value)
                {
                    if (ValidateSeason(value))
                        _workerInfo.Season = value;
                }
            }
        }

        public StaticItem Country
        {
            get { return _workerInfo.Country; }
            set
            {
                if (_workerInfo.Country != value)
                {
                    if (ValidateCountry(value))
                        _workerInfo.Country = value;
                }
            }
        }

        public string StateProvince
        {
            get { return _workerInfo.StateProvince; }
            set
            {
                if (_workerInfo.StateProvince != value)
                {
                    if (ValidateStateProvence(value))
                        _workerInfo.StateProvince = value;
                }
            }
        }

        public string CountyLocale
        {
            get { return _workerInfo.CountyLocale; }
            set
            {
                if (_workerInfo.CountyLocale != value)
                {
                    if (ValidateCountyLocale(value))
                        _workerInfo.CountyLocale = value;
                }
            }
        }

        public string Town
        {
            get { return _workerInfo.Town; }
            set
            {
                if (_workerInfo.Town != value)
                {
                    if (ValidateTown(value))
                        _workerInfo.Town = value;
                }
            }
        }

        #endregion

        #region Constructor

        WorkerInfoModel(WorkerInfo workerInfo)
        {
            _workerInfo = workerInfo;

            // Now set all Model properties, and trigger all validations
            WorkerId = workerInfo.WorkerId;
            ReplicateId = workerInfo.ReplicateId;
            Task = workerInfo.Task;
            Age = workerInfo.Age.HasValue ? workerInfo.Age.ToString() : String.Empty;
            LengthInOrCmTextAndUnits(workerInfo.Height, out _heightText, out _heightUnits);
            MassTextAndUnits(workerInfo.Weight, out _weightText, out _weightUnits);
            Gender = workerInfo.Gender;
            YearsExperience = workerInfo.YearsExperience.HasValue ? workerInfo.YearsExperience.ToString() : String.Empty;
            Employment = workerInfo.Employment;
            Biomonitoring = workerInfo.Biomonitoring;
            ReplicateDate = workerInfo.ReplicateDate.ToShortDateString();
            Site = workerInfo.Site;
            Season = workerInfo.Season;
            Country = workerInfo.Country;
            StateProvince = workerInfo.StateProvince;
            CountyLocale = workerInfo.CountyLocale;
            Town = workerInfo.Town;
        }

        #endregion

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string WORKER_ID = "WorkerId";
        public const string REPLICATE_ID = "ReplicateId";
        public const string TASK = "Task";
        public const string AGE = "Age";
        public const string HEIGHT = "Height";
        public const string WEIGHT = "Weight";
        public const string GENDER = "Gender";
        public const string YEARS_EXPERIENCE = "YearsExperience";
        public const string EMPLOYMENT = "Employment";
        public const string BIOMONITORING = "Biomonitoring";
        public const string REPLICATE_DATE = "ReplicateDate";
        public const string SITE = "Site";
        public const string SEASON = "Season";
        public const string COUNTRY = "Country";
        public const string STATE_PROVINCE = "StateProvince";
        public const string COUNTY_LOCALE = "CountyLocale";
        public const string TOWN = "Town";

        public const string HEIGHT_UNITS = "HeightUnits";   // Property of this model, not WorkerInfo
        public const string WEIGHT_UNITS = "WeightUnits";   // Property of this model, not WorkerInfo

        #endregion

        #region General Validation

        /// <summary>
        /// Cached value for today's date.  Used to insure an actual date
        /// is entered when this replicate is created.
        /// </summary>
        private readonly string _dateCreated = DateTime.Now.ToShortDateString();

        /// <summary>
        /// Collection of all Properties to be validated.
        /// <remarks>
        ///     <b>NOTE</b>: These string MUST match the actual property names!
        /// </remarks>
        /// </summary>
        static SortedSet<string> ValidatedProperties;

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>WorkerId</c>.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>WorkerId</c>.</returns>
        private bool ValidateWorkerId(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(WORKER_ID, Properties.Resources.WorkerInfo_Missing_Id);
                return true;
            }

            AddError(WORKER_ID, Properties.Resources.WorkerInfo_Missing_Id, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ReplicateId</c>.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ReplicateId</c>.</returns>
        private bool ValidateReplicateId(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(REPLICATE_ID, Properties.Resources.WorkerInfo_Missing_Replicate_Id);
                return true;
            }

            AddError(REPLICATE_ID, Properties.Resources.WorkerInfo_Missing_Replicate_Id, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Task</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Task] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Task</c>.</returns>
        private bool ValidateTask(StaticItem value)
        {
            if (ValidTasks.Contains(value))
            {
                RemoveError(TASK, Properties.Resources.WorkerInfo_Invalid_Task);
                return true;
            }

            AddError(TASK, Properties.Resources.WorkerInfo_Invalid_Task, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Age</c>.
        /// </summary>
        /// <remarks>
        /// Only ages null and 10-127 are accepted.
        /// </remarks>
        /// <param name="str">The raw string to validate as an Age.</param>
        /// <param name="value"><c>str</c> convered to an Age.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Age</c>.</returns>
        private bool ValidateAge(string str, ref int? value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(AGE,Properties.Resources.WorkerInfo_Invalid_Age);
                return true;
            }

            int age;
            if (!Int32.TryParse(str, out age))
            {
                AddError(AGE,Properties.Resources.WorkerInfo_Invalid_Age, false);
                return false;
            }

            if (age < 10 || age > 127)
            {
                AddError(AGE, Properties.Resources.WorkerInfo_Invalid_Age, false);
                return false;
            }

            RemoveError(AGE, Properties.Resources.WorkerInfo_Invalid_Age);
            value = age;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Height</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Height.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Height</c>.</returns>
        private bool ValidateHeight(string str, out Length value)
        {
            return ValidateLength(str, _heightUnits,
                                  HEIGHT, Properties.Resources.WorkerInfo_Invalid_Height,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Weight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a Height.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Weight</c>.</returns>
        private bool ValidateWeight(string str, out Mass value)
        {
            return ValidateMass(str, _weightUnits,
                                WEIGHT, Properties.Resources.WorkerInfo_Invalid_Weight,
                                out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Gender</c>.
        /// </summary>
        /// <remarks>
        /// Accepts members of <c>StaticValues.GroupOptions[Groups.Gender]</c>.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Gender</c>.</returns>
        private bool ValidateGender(StaticItem value)
        {
            bool isValid = true;
            if (ValidGenders.Contains(value))
            {
                RemoveError(GENDER, Properties.Resources.WorkerInfo_Invalid_Gender);
            }
            else
            {
                AddError(GENDER, Properties.Resources.WorkerInfo_Invalid_Gender, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>YearsExperience</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as YearsExperience.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>YearsExperience</c>.</returns>
        private bool ValidateYearsExperience(string str, ref int? value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(YEARS_EXPERIENCE, Properties.Resources.WorkerInfo_Invalid_Years_Experience);
                return true;
            }

            int years;
            if (!Int32.TryParse(str, out years))
            {
                AddError(YEARS_EXPERIENCE, Properties.Resources.WorkerInfo_Invalid_Years_Experience, false);
                return false;
            }

            if (years > 0)
            {
                AddError(YEARS_EXPERIENCE, Properties.Resources.WorkerInfo_Invalid_Years_Experience, false);
                return false;
            }

            RemoveError(YEARS_EXPERIENCE, Properties.Resources.WorkerInfo_Invalid_Years_Experience);
            value = years;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Employment</c>.
        /// </summary>
        /// <remarks>
        /// Accepts members of <c>StaticValues.GroupOptions[Groups.Employment]</c>.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Employment</c>.</returns>
        private bool ValidateEmployment(StaticItem value)
        {
            if (ValidEmployments.Contains(value))
            {
                RemoveError(EMPLOYMENT, Properties.Resources.WorkerInfo_Invalid_Employment);
                return true;
            }

            AddError(EMPLOYMENT, Properties.Resources.WorkerInfo_Invalid_Employment, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Biomonitoring</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Biomonitoring</c>.</returns>
        private bool ValidateBiomonitoring(string value)
        {
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
        private bool ValidateReplicateDate(string str, ref DateTime value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(REPLICATE_DATE, Properties.Resources.WorkerInfo_Invalid_Replicate_Date, false);
                return false;
            }

            DateTime date;
            if (!DateTime.TryParse(str, out date))
            {
                AddError(REPLICATE_DATE, Properties.Resources.WorkerInfo_Invalid_Replicate_Date, false);
                return false;
            }

            if (date.ToShortDateString() != _dateCreated)
            {
                RemoveError(REPLICATE_DATE, Properties.Resources.WorkerInfo_Invalid_Replicate_Date);
                value = date;
                return true;
            }

            AddError(REPLICATE_DATE, Properties.Resources.WorkerInfo_Invalid_Replicate_Date, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Site</c>.
        /// </summary>
        /// <remarks>
        /// Accepts members of <c>StaticValues.GroupOptions[Groups.Site]</c>.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Site</c>.</returns>
        private bool ValidateSite(StaticItem value)
        {
            if (ValidEmployments.Contains(value))
            {
                RemoveError(SITE, Properties.Resources.WorkerInfo_Invalid_Site);
                return true;
            }

            AddError(SITE, Properties.Resources.WorkerInfo_Invalid_Site, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Season</c>.
        /// </summary>
        /// <remarks>
        /// Accepts members of <c>StaticValues.GroupOptions[Groups.Season]</c>.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Season</c>.</returns>
        private bool ValidateSeason(StaticItem value)
        {
            if (ValidEmployments.Contains(value))
            {
                RemoveError(SEASON, Properties.Resources.WorkerInfo_Invalid_Season);
                return true;
            }

            AddError(SEASON, Properties.Resources.WorkerInfo_Invalid_Season, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Country</c>.
        /// </summary>
        /// <remarks>
        /// Accepts members of <c>StaticValues.GroupOptions[Groups.Country]</c>.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Country</c>.</returns>
        private bool ValidateCountry(StaticItem value)
        {
            if (ValidEmployments.Contains(value))
            {
                RemoveError(COUNTRY, Properties.Resources.WorkerInfo_Invalid_Country);
                return true;
            }
            
            AddError(COUNTRY, Properties.Resources.WorkerInfo_Invalid_Country, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>StateProvence</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>StateProvence</c>.</returns>
        private bool ValidateStateProvence(string value)
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>CountyLocale</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>CountyLocale</c>.</returns>
        private bool ValidateCountyLocale(string value)
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Town</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Town</c>.</returns>
        private bool ValidateTown(string value)
        {
            return true;
        }

        #endregion

        #endregion

    }
}

using System;
using System.Collections.Generic;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>WorkerInfo</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class WorkerInfoModel : Model<WorkerInfo>, IDeepClone<WorkerInfoModel>
    {
        private readonly StudyModel _parentStudy;

        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidTasks = StaticValues.GroupOptions(StaticValues.Groups.Task);

        public readonly List<StaticItem> ValidGenders = StaticValues.GroupOptions(StaticValues.Groups.Gender);

        public readonly List<StaticItem> ValidEmployments = StaticValues.GroupOptions(StaticValues.Groups.Employment);

        public readonly List<StaticItem> ValidSites = StaticValues.GroupOptions(StaticValues.Groups.Site);

        public readonly List<StaticItem> ValidSeasons = StaticValues.GroupOptions(StaticValues.Groups.Season);

        public readonly List<StaticItem> ValidCountries = StaticValues.GroupOptions(StaticValues.Groups.Country);

        #endregion Valid Options for StaticItems

        #region Properties

        public string Id
        {
            get
            {
                return (IsStringMissing(WorkerId) ? String.Empty : WorkerId)
                       + Properties.Resources.MonitoringUnit_Id_Separator
                       + (IsStringMissing(ReplicateId) ? String.Empty : ReplicateId);
            }
        }

        public string WorkerId
        {
            get { return Value.WorkerId; }
            set
            {
                if (value != Value.WorkerId)
                {
                    if (ValidateWorkerId(value))
                    {
                        Value.WorkerId = String.IsNullOrEmpty(value) ? null : value;
                    }
                }
            }
        }

        public string ReplicateId
        {
            get { return Value.ReplicateId; }
            set
            {
                if (value != Value.ReplicateId)
                {
                    if (ValidateReplicateId(value))
                    {
                        Value.ReplicateId = String.IsNullOrEmpty(value) ? null : value;
                    }
                }
            }
        }

        public StaticItem Task
        {
            get { return Value.Task; }
            set
            {
                if (value != Value.Task)
                {
                    if (ValidateTask(value))
                    {
                        Value.Task = value;
                    }
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
                    int? age;
                    if (!ValidateAge(value, out age))
                    {
                        _ageText = value;
                    }
                    else
                    {
                        _ageText = (age != null) ? age.ToString() : String.Empty;
                        Value.Age = age;
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
                        (Value.Height != null)
                            ? Length.Convert(Value.Height, _heightUnits).ToString(Culture.Info)
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
                        Value.Height = newHeight;
                        _heightText =
                            (newHeight != null)
                                ? Length.Convert(newHeight, _heightUnits).ToString(Culture.Info)
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
                        (Value.Weight != null)
                            ? Mass.Convert(Value.Weight, _weightUnits).ToString(Culture.Info)
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
                        Value.Weight = newWeight;
                        _weightText =
                            (newWeight != null)
                                ? Mass.Convert(newWeight, _weightUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        public StaticItem Gender
        {
            get { return Value.Gender; }
            set
            {
                if (value != Value.Gender)
                {
                    if (ValidateGender(value))
                    {
                        Value.Gender = value;
                    }
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
                    int? yearsExperience;
                    if (!ValidateYearsExperience(value, out yearsExperience))
                    {
                        _yearsExperienceText = value;
                    }
                    else
                    {
                        _yearsExperienceText = (yearsExperience != null) ? yearsExperience.ToString() : String.Empty;
                        Value.YearsExperience = yearsExperience;
                    }
                }
            }
        }

        public StaticItem Employment
        {
            get { return Value.Employment; }
            set
            {
                if (value != Value.Employment)
                {
                    if (ValidateEmployment(value))
                    {
                        Value.Employment = value;
                    }
                }
            }
        }

        public string Biomonitoring
        {
            get { return Value.Biomonitoring; }
            set
            {
                if (value != Value.Biomonitoring)
                {
                    if (ValidateBiomonitoring(value))
                    {
                        Value.Biomonitoring = value;
                    }
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
                        Value.ReplicateDate = date;
                        _replicateDateText = date.ToShortDateString();
                    }
                }
            }
        }

        public StaticItem Site
        {
            get { return Value.Site; }
            set
            {
                if (Value.Site != value)
                {
                    if (ValidateSite(value))
                    {
                        Value.Site = value;
                    }
                }
            }
        }

        public StaticItem Season
        {
            get { return Value.Season; }
            set
            {
                if (Value.Season != value)
                {
                    if (ValidateSeason(value))
                    {
                        Value.Season = value;
                    }
                }
            }
        }

        public StaticItem Country
        {
            get { return Value.Country; }
            set
            {
                if (Value.Country != value)
                {
                    if (ValidateCountry(value))
                    {
                        Value.Country = value;
                    }
                }
            }
        }

        public string StateProvince
        {
            get { return Value.StateProvince; }
            set
            {
                if (Value.StateProvince != value)
                {
                    if (ValidateStateProvence(value))
                    {
                        Value.StateProvince = value;
                    }
                }
            }
        }

        public string CountyLocale
        {
            get { return Value.CountyLocale; }
            set
            {
                if (Value.CountyLocale != value)
                {
                    if (ValidateCountyLocale(value))
                    {
                        Value.CountyLocale = value;
                    }
                }
            }
        }

        public string Town
        {
            get { return Value.Town; }
            set
            {
                if (Value.Town != value)
                {
                    if (ValidateTown(value))
                    {
                        Value.Town = value;
                    }
                }
            }
        }

        #endregion

        #region Creation

        public WorkerInfoModel()
        {
        }

        public WorkerInfoModel(WorkerInfo workerInfo, StudyModel parentStudy)
            : base(workerInfo)
        {
            if (parentStudy == null)
                throw new ArgumentNullException("parentStudy");

            _parentStudy = parentStudy;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private WorkerInfoModel(WorkerInfoModel workerInfo)
            : base(workerInfo)
        {
            if (workerInfo == null)
                throw new ArgumentNullException("workerInfo");

            _parentStudy = workerInfo._parentStudy;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public static WorkerInfoModel Create(StudyModel parentStudy)
        {
            if (parentStudy == null)
                throw new ArgumentNullException("parentStudy");

            var workerInfo = new WorkerInfo();
            workerInfo.InitializeProperties();
            return new WorkerInfoModel(workerInfo, parentStudy);
        }

        public void SetProperties()
        {
            // Now set all Model properties, and trigger all validations
            WorkerId = Value.WorkerId;
            ReplicateId = Value.ReplicateId;
            Task = Value.Task;
            Age = Value.Age.HasValue ? Value.Age.ToString() : String.Empty;
            Length.InOrCmTextAndUnits(Value.Height, out _heightText, out _heightUnits);
            Mass.TextAndUnits(Value.Weight, out _weightText, out _weightUnits);
            Gender = Value.Gender;
            YearsExperience = Value.YearsExperience.HasValue ? Value.YearsExperience.ToString() : String.Empty;
            Employment = Value.Employment;
            Biomonitoring = Value.Biomonitoring;
            ReplicateDate = Value.ReplicateDate.ToShortDateString();
            Site = Value.Site;
            Season = Value.Season;
            Country = Value.Country;
            StateProvince = Value.StateProvince;
            CountyLocale = Value.CountyLocale;
            Town = Value.Town;
        }

        #endregion Creation

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string WorkerIdName = "WorkerId";
        public const string ReplicateIdName = "ReplicateId";
        public const string TaskName = "Task";
        public const string AgeName = "Age";
        public const string HeightName = "Height";
        public const string WeightName = "Weight";
        public const string GenderName = "Gender";
        public const string YearsExperienceName = "YearsExperience";
        public const string EmploymentName = "Employment";
        public const string BiomonitoringName = "Biomonitoring";
        public const string ReplicateDateName = "ReplicateDate";
        public const string SiteName = "Site";
        public const string SeasonName = "Season";
        public const string CountryName = "Country";
        public const string StateProvinceName = "StateProvince";
        public const string CountyLocaleName = "CountyLocale";
        public const string TownName = "Town";

        // Properties of this model, not in WorkerInfo
        public const string HeightUnitsName = "HeightUnits";
        public const string WeightUnitsName = "WeightUnits";
        public const string IdName = "Id";

        #endregion

        #region General Validation

        /// <summary>
        /// Cached value for today's date.  Used to insure an actual date
        /// is entered when this replicate is created.
        /// </summary>
        private readonly string _dateCreated = DateTime.Now.ToShortDateString();

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>WorkerId</c>.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>WorkerId</c>.</returns>
        private bool ValidateWorkerId(string value)
        {
            if (IsStringMissing(value))
            {
                AddError(WorkerIdName, Properties.Resources.WorkerInfo_Missing_Id, false);
                return false;
            }

            // We have a value, not make sure it isn't already in the Study
            string id = value
                        + Properties.Resources.MonitoringUnit_Id_Separator
                        + (String.IsNullOrEmpty(ReplicateId) ? String.Empty : ReplicateId);
            if (_parentStudy.MuIds.Contains(id))
            {
                AddError(WorkerIdName, Properties.Resources.WorkerInfo_Invalid_Id, false);
                return false;
            }

            RemoveError(WorkerIdName, Properties.Resources.WorkerInfo_Missing_Id);
            RemoveError(IdName, Properties.Resources.WorkerInfo_Missing_Id);
            return true;
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
                RemoveError(ReplicateIdName, Properties.Resources.WorkerInfo_Missing_Replicate_Id);
                return true;
            }

            AddError(ReplicateIdName, Properties.Resources.WorkerInfo_Missing_Replicate_Id, false);
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
                RemoveError(TaskName, Properties.Resources.WorkerInfo_Invalid_Task);
                return true;
            }

            AddError(TaskName, Properties.Resources.WorkerInfo_Invalid_Task, false);
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
        private bool ValidateAge(string str, out int? value)
        {
            bool isValid = ValidateInt(str, PositiveOnly,
                                       AgeName, Properties.Resources.WorkerInfo_Invalid_Age,
                                       out value);

            if (value == null)
                return isValid;

            if (value < 10 || value > 127)
            {
                AddError(AgeName, Properties.Resources.WorkerInfo_Invalid_Age, false);
                return false;
            }

            RemoveError(AgeName, Properties.Resources.WorkerInfo_Invalid_Age);
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
                                  HeightName, Properties.Resources.WorkerInfo_Invalid_Height,
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
                                WeightName, Properties.Resources.WorkerInfo_Invalid_Weight,
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
            if (ValidGenders.Contains(value))
            {
                RemoveError(GenderName, Properties.Resources.WorkerInfo_Invalid_Gender);
                return true;
            }

            AddError(GenderName, Properties.Resources.WorkerInfo_Invalid_Gender, false);
            return false;
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
        private bool ValidateYearsExperience(string str, out int? value)
        {
            return ValidateInt(str, PositiveOnly,
                               YearsExperienceName, Properties.Resources.WorkerInfo_Invalid_Years_Experience,
                               out value);
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
                RemoveError(EmploymentName, Properties.Resources.WorkerInfo_Invalid_Employment);
                return true;
            }

            AddError(EmploymentName, Properties.Resources.WorkerInfo_Invalid_Employment, false);
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
                AddError(ReplicateDateName, Properties.Resources.WorkerInfo_Invalid_Replicate_Date, false);
                return false;
            }

            DateTime date;
            if (!DateTime.TryParse(str, out date))
            {
                AddError(ReplicateDateName, Properties.Resources.WorkerInfo_Invalid_Replicate_Date, false);
                return false;
            }

            if (date.ToShortDateString() != _dateCreated)
            {
                RemoveError(ReplicateDateName, Properties.Resources.WorkerInfo_Invalid_Replicate_Date);
                value = date;
                return true;
            }

            AddError(ReplicateDateName, Properties.Resources.WorkerInfo_Invalid_Replicate_Date, false);
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
                RemoveError(SiteName, Properties.Resources.WorkerInfo_Invalid_Site);
                return true;
            }

            AddError(SiteName, Properties.Resources.WorkerInfo_Invalid_Site, false);
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
                RemoveError(SeasonName, Properties.Resources.WorkerInfo_Invalid_Season);
                return true;
            }

            AddError(SeasonName, Properties.Resources.WorkerInfo_Invalid_Season, false);
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
                RemoveError(CountryName, Properties.Resources.WorkerInfo_Invalid_Country);
                return true;
            }
            
            AddError(CountryName, Properties.Resources.WorkerInfo_Invalid_Country, false);
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

        #region IDeepClone Interface

        public WorkerInfoModel DeepClone()
        {
            return new WorkerInfoModel(this);
        }

        #endregion IDeepClone Interface

    }
}

using System;
using AHED.Data.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class WorkerInfoViewModel : SimpleViewModel<WorkerInfoModel, WorkerInfo>
    {
        #region Fields

        #region Valid Options for StaticItems

        private StaticItem[] _taskOptions;

        private StaticItem[] _genderOptions;

        private StaticItem[] _employmentOptions;

        private StaticItem[] _siteOptions;

        private StaticItem[] _seasonOptions;

        private StaticItem[] _countryOptions;

        #endregion Valid Options for StaticItems

        #region Valid Units Options for properties

        private Length.Units[] _heightUnitsOptions;

        private Mass.Units[] _weightUnitsOptions;

        #endregion Valid Units Options for properties

        #endregion // Fields

        #region Constructor

        public WorkerInfoViewModel(WorkerInfoModel workerInfoModel)
            : base(workerInfoModel)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            // initialize all the properties...should trigger bindings to display for the first time
            WorkerId = Model.WorkerId;
            ReplicateId = Model.ReplicateId;
            Task = Model.Task;
            Age = Model.Age;
            HeightUnits = Model.HeightUnits;
            Height = Model.Height;
            WeightUnits = Model.WeightUnits;
            Weight = Model.Weight;
            Gender = Model.Gender;
            YearsExperience = Model.YearsExperience;
            Employment = Model.Employment;
            Biomonitoring = Model.Biomonitoring;
            ReplicateDate = Model.ReplicateDate;
            Site = Model.Site;
            Season = Model.Season;
            Country = Model.Country;
            StateProvince = Model.StateProvince;
            CountyLocale = Model.CountyLocale;
            Town = Model.Town;
        }

        #endregion // Constructor

        #region Presentation Properties

        public override string DisplayName
        {
            get { return Model.Id; }
        }

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for Task selector.
        /// </summary>
        public StaticItem[] TaskOptions
        {
            get
            {
                return _taskOptions
                       ?? (_taskOptions = Model.ValidTasks.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for HeightUnits selector.
        /// </summary>
        public Length.Units[] HeightUnitsOptions
        {
            get
            {
                return _heightUnitsOptions
                       ?? (_heightUnitsOptions = new [] {Length.Units.Inches, Length.Units.Centimeters});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WeightUnits selector.
        /// </summary>
        public Mass.Units[] WeightUnitsOptions
        {
            get
            {
                return _weightUnitsOptions
                       ?? (_weightUnitsOptions = new[] {Mass.Units.Pounds, Mass.Units.Kilograms});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Gender selector.
        /// </summary>
        public StaticItem[] GenderOptions
        {
            get
            {
                return _genderOptions
                       ?? (_genderOptions = Model.ValidGenders.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Employment selector.
        /// </summary>
        public StaticItem[] EmploymentOptions
        {
            get
            {
                return _employmentOptions
                       ?? (_employmentOptions = Model.ValidEmployments.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Site selector.
        /// </summary>
        public StaticItem[] SiteOptions
        {
            get
            {
                return _siteOptions
                       ?? (_siteOptions = Model.ValidSites.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Season selector.
        /// </summary>
        public StaticItem[] SeasonOptions
        {
            get
            {
                return _seasonOptions
                       ?? (_seasonOptions = Model.ValidSeasons.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Country selector.
        /// </summary>
        public StaticItem[] CountryOptions
        {
            get
            {
                return _countryOptions
                       ?? (_countryOptions = Model.ValidCountries.ToArray());
            }
        }

        #endregion StaticItem Choices

        #endregion Presentation Properties

        #region Properties

        private string _workerId;
        public string WorkerId
        {
            get { return _workerId; }
            set
            {
                if (value == _workerId)
                    return;

                Model.WorkerId = value;
                _workerId = Model.WorkerId;
                base.RaisePropertyChanged(WorkerIdName);
                base.RaisePropertyChanged(IdName);
            }
        }

        private string _replicateId;
        public string ReplicateId
        {
            get { return _replicateId; }
            set
            {
                if (value == _replicateId)
                    return;

                Model.ReplicateId = value;
                _replicateId = Model.ReplicateId;
                base.RaisePropertyChanged(ReplicateIdName);
                base.RaisePropertyChanged(IdName);
            }
        }

        public StaticItem Task
        {
            get { return Model.Task; }
            set
            {
                if (value == Model.Task)
                    return;

                Model.Task = value;
                base.RaisePropertyChanged(TaskName);
            }
        }

        private string _age;
        public string Age
        {
            get { return _age; }
            set
            {
                if (value == _age)
                    return;

                Model.Age = value;
                _age = Model.Age;
                base.RaisePropertyChanged(AgeName);
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
                    base.RaisePropertyChanged(HeightUnitsName);
                    base.RaisePropertyChanged(HeightName);
                }
            }
        }

        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                if (value == _height)
                    return;

                Model.Height = value;
                _height = Model.Height;
                base.RaisePropertyChanged(HeightName);
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
                    base.RaisePropertyChanged(WeightUnitsName);
                    base.RaisePropertyChanged(WeightName);
                }
            }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (value == _weight)
                    return;

                Model.Weight = value;
                _weight = Model.Weight;
                base.RaisePropertyChanged(WeightName);
            }
        }

        public StaticItem Gender
        {
            get { return Model.Gender; }
            set
            {
                if (value == Model.Gender)
                    return;

                Model.Gender = value;
                base.RaisePropertyChanged(GenderName);
            }
        }

        private string _yearsExperience;
        public string YearsExperience
        {
            get { return _yearsExperience; }
            set
            {
                if (value == _yearsExperience)
                    return;

                Model.YearsExperience = value;
                _yearsExperience = Model.YearsExperience;
                base.RaisePropertyChanged(YearsExperienceName);
            }
        }

        public StaticItem Employment
        {
            get { return Model.Employment; }
            set
            {
                if (value == Model.Employment)
                    return;

                Model.Employment = value;
                base.RaisePropertyChanged(EmploymentName);
            }
        }

        private string _biomonitoring;
        public string Biomonitoring
        {
            get { return _biomonitoring; }
            set
            {
                if (value == _biomonitoring)
                    return;

                Model.Biomonitoring = value;
                _biomonitoring = Model.Biomonitoring;
                base.RaisePropertyChanged(BiomonitoringName);
            }
        }

        private string _replicateDate;
        public string ReplicateDate
        {
            get { return _replicateDate; }
            set
            {
                if (value == _replicateDate)
                    return;

                Model.ReplicateDate = value;
                _replicateDate = Model.ReplicateDate;
                base.RaisePropertyChanged(ReplicateDateName);
            }
        }

        public StaticItem Site
        {
            get { return Model.Site; }
            set
            {
                if (value == Model.Site)
                    return;

                Model.Site = value;
                base.RaisePropertyChanged(SiteName);
            }
        }

        public StaticItem Season
        {
            get { return Model.Season; }
            set
            {
                if (value == Model.Season)
                    return;

                Model.Season = value;
                base.RaisePropertyChanged(SeasonName);
            }
        }

        public StaticItem Country
        {
            get { return Model.Country; }
            set
            {
                if (value == Model.Country)
                    return;

                Model.Country = value;
                base.RaisePropertyChanged(CountryName);
            }
        }

        private string _stateProvince;
        public string StateProvince
        {
            get { return _stateProvince; }
            set
            {
                if (value == _stateProvince)
                    return;

                Model.StateProvince = value;
                _stateProvince = Model.StateProvince;
                base.RaisePropertyChanged(StateProvinceName);
            }
        }

        private string _countyLocale;
        public string CountyLocale
        {
            get { return _countyLocale; }
            set
            {
                if (value == _countyLocale)
                    return;

                Model.CountyLocale = value;
                _countyLocale = Model.CountyLocale;
                base.RaisePropertyChanged(CountyLocaleName);
            }
        }

        private string _town;
        public string Town
        {
            get { return _town; }
            set
            {
                if (value == _town)
                    return;

                Model.Town = value;
                _town = Model.Town;
                base.RaisePropertyChanged(TownName);
            }
        }

        #endregion

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

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

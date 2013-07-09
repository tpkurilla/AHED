using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using AHED.Model;
using AHED.Types;
using AHED.Util;

namespace AHED.ViewModel
{
    public class WorkerInfoViewModel : ViewModelBase
    {
        #region Fields

        readonly WorkerInfoModel _workerInfoModel;

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
        {
            if (workerInfoModel == null)
                throw new ArgumentNullException("workerInfoModel");

            _workerInfoModel = workerInfoModel;

            // initialize all the properties...should trigger bindings to display for the first time
            WorkerId = workerInfoModel.WorkerId;
            ReplicateId = workerInfoModel.ReplicateId;
            Task = workerInfoModel.Task;
            Age = workerInfoModel.Age;
            HeightUnits = workerInfoModel.HeightUnits;
            Height = workerInfoModel.Height;
            WeightUnits = workerInfoModel.WeightUnits;
            Weight = workerInfoModel.Weight;
            Gender = workerInfoModel.Gender;
            YearsExperience = workerInfoModel.YearsExperience;
            Employment = workerInfoModel.Employment;
            Biomonitoring = workerInfoModel.Biomonitoring;
            ReplicateDate = workerInfoModel.ReplicateDate;
            Site = workerInfoModel.Site;
            Season = workerInfoModel.Season;
            Country = workerInfoModel.Country;
            StateProvince = workerInfoModel.StateProvince;
            CountyLocale = workerInfoModel.CountyLocale;
            Town = workerInfoModel.Town;
        }

        #endregion // Constructor

        #region Presentation Properties

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for Task selector.
        /// </summary>
        public StaticItem[] TaskOptions
        {
            get
            {
                if (_taskOptions == null)
                {
                    _taskOptions = _workerInfoModel.ValidTasks.ToArray();
                }

                return _taskOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for HeightUnits selector.
        /// </summary>
        public Length.Units[] HeightUnitsOptions
        {
            get
            {
                if (_heightUnitsOptions == null)
                {
                    _heightUnitsOptions = new Length.Units[] { Length.Units.Inches, Length.Units.Centimeters };
                }

                return _heightUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WeightUnits selector.
        /// </summary>
        public Length.Units[] WeightUnitsOptions
        {
            get
            {
                if (_weightUnitsOptions == null)
                {
                    _weightUnitsOptions = new Mass.Units[] { Mass.Units.Pounds, Mass.Units.Kilograms };
                }

                return _heightUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Gender selector.
        /// </summary>
        public StaticItem[] GenderOptions
        {
            get
            {
                if (_genderOptions == null)
                {
                    _genderOptions = _workerInfoModel.ValidGenders.ToArray();
                }

                return _genderOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Employment selector.
        /// </summary>
        public StaticItem[] EmploymentOptions
        {
            get
            {
                if (_employmentOptions == null)
                {
                    _employmentOptions = _workerInfoModel.ValidEmployments.ToArray();
                }

                return _employmentOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Site selector.
        /// </summary>
        public StaticItem[] SiteOptions
        {
            get
            {
                if (_siteOptions == null)
                {
                    _siteOptions = _workerInfoModel.ValidSites.ToArray();
                }

                return _siteOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Season selector.
        /// </summary>
        public StaticItem[] SeasonOptions
        {
            get
            {
                if (_seasonOptions == null)
                {
                    _seasonOptions = _workerInfoModel.ValidSeasons.ToArray();
                }

                return _seasonOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Country selector.
        /// </summary>
        public StaticItem[] CountryOptions
        {
            get
            {
                if (_countryOptions == null)
                {
                    _countryOptions = _workerInfoModel.ValidCountries.ToArray();
                }

                return _countryOptions;
            }
        }

        #endregion StaticItem Choices

        #endregion Presentation Properties

        #region WorkerInfo Properties

        public string WorkerId
        {
            get { return _workerInfoModel.WorkerId; }
            set
            {
                if (value == _workerInfoModel.WorkerId)
                    return;

                _workerInfoModel.WorkerId = value;
                base.OnPropertyChanged(WorkerInfoModel.WORKER_ID);
            }
        }

        public string ReplicateId
        {
            get { return _workerInfoModel.ReplicateId; }
            set
            {
                if (value == _workerInfoModel.ReplicateId)
                    return;

                _workerInfoModel.ReplicateId = value;
                base.OnPropertyChanged(WorkerInfoModel.REPLICATE_ID);
            }
        }

        public StaticItem Task
        {
            get { return _workerInfoModel.Task; }
            set
            {
                if (value == _workerInfoModel.Task)
                    return;

                _workerInfoModel.Task = value;
                base.OnPropertyChanged(WorkerInfoModel.TASK);
            }
        }

        public string Age
        {
            get { return _workerInfoModel.Age; }
            set
            {
                if (value == _workerInfoModel.Age)
                    return;

                _workerInfoModel.Age = value;
                base.OnPropertyChanged(WorkerInfoModel.AGE);
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
                    base.OnPropertyChanged(WorkerInfoModel.HEIGHT_UNITS);
                    base.OnPropertyChanged(WorkerInfoModel.HEIGHT);
                }
            }
        }

        public string Height
        {
            get { return _workerInfoModel.Height; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _workerInfoModel.Height)
                    return;

                _workerInfoModel.Height = value;
                base.OnPropertyChanged(WorkerInfoModel.HEIGHT);
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
                    base.OnPropertyChanged(WorkerInfoModel.WEIGHT_UNITS);
                    base.OnPropertyChanged(WorkerInfoModel.WEIGHT);
                }
            }
        }

        public string Weight
        {
            get { return _workerInfoModel.Weight; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _workerInfoModel.Weight)
                    return;

                _workerInfoModel.Weight = value;
                base.OnPropertyChanged(WorkerInfoModel.WEIGHT);
            }
        }

        public StaticItem Gender
        {
            get { return _workerInfoModel.Gender; }
            set
            {
                if (value == _workerInfoModel.Gender)
                    return;

                _workerInfoModel.Gender = value;
                base.OnPropertyChanged(WorkerInfoModel.GENDER);
            }
        }

        public string YearsExperience
        {
            get { return _workerInfoModel.YearsExperience; }
            set
            {
                if (value == _workerInfoModel.YearsExperience)
                    return;

                _workerInfoModel.YearsExperience = value;
                base.OnPropertyChanged(WorkerInfoModel.YEARS_EXPERIENCE);
            }
        }

        public StaticItem Employment
        {
            get { return _workerInfoModel.Employment; }
            set
            {
                if (value == _workerInfoModel.Employment)
                    return;

                _workerInfoModel.Employment = value;
                base.OnPropertyChanged(WorkerInfoModel.EMPLOYMENT);
            }
        }

        public string Biomonitoring
        {
            get { return _workerInfoModel.Biomonitoring; }
            set
            {
                if (value == _workerInfoModel.Biomonitoring)
                    return;

                _workerInfoModel.Biomonitoring = value;
                base.OnPropertyChanged(WorkerInfoModel.BIOMONITORING);
            }
        }

        public string ReplicateDate
        {
            get { return _workerInfoModel.ReplicateDate; }
            set
            {
                if (value == _workerInfoModel.ReplicateDate)
                    return;

                _workerInfoModel.ReplicateDate = value;
                base.OnPropertyChanged(WorkerInfoModel.REPLICATE_DATE);
            }
        }

        public StaticItem Site
        {
            get { return _workerInfoModel.Site; }
            set
            {
                if (value == _workerInfoModel.Site)
                    return;

                _workerInfoModel.Site = value;
                base.OnPropertyChanged(WorkerInfoModel.SITE);
            }
        }

        public StaticItem Season
        {
            get { return _workerInfoModel.Season; }
            set
            {
                if (value == _workerInfoModel.Season)
                    return;

                _workerInfoModel.Season = value;
                base.OnPropertyChanged(WorkerInfoModel.SEASON);
            }
        }

        public StaticItem Country
        {
            get { return _workerInfoModel.Country; }
            set
            {
                if (value == _workerInfoModel.Country)
                    return;

                _workerInfoModel.Country = value;
                base.OnPropertyChanged(WorkerInfoModel.COUNTRY);
            }
        }

        public string StateProvince
        {
            get { return _workerInfoModel.StateProvince; }
            set
            {
                if (value == _workerInfoModel.StateProvince)
                    return;

                _workerInfoModel.StateProvince = value;
                base.OnPropertyChanged(WorkerInfoModel.STATE_PROVINCE);
            }
        }

        public string CountyLocale
        {
            get { return _workerInfoModel.CountyLocale; }
            set
            {
                if (value == _workerInfoModel.CountyLocale)
                    return;

                _workerInfoModel.CountyLocale = value;
                base.OnPropertyChanged(WorkerInfoModel.COUNTY_LOCALE);
            }
        }

        public string Town
        {
            get { return _workerInfoModel.Town; }
            set
            {
                if (value == _workerInfoModel.Town)
                    return;

                _workerInfoModel.Town = value;
                base.OnPropertyChanged(WorkerInfoModel.TOWN);
            }
        }

        #endregion

    }
}

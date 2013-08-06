using System;

namespace AHED.Types
{
    [Serializable]
    public class WorkerInfo : IDeepClone<WorkerInfo>, IPropertyInitializer
    {
        public string WorkerId { get; set; }
        public string ReplicateId { get; set; }
        public StaticItem Task { get; set; }
        public int? Age { get; set; }
        public Length Height { get; set; }
        public Mass Weight { get; set; }
        public StaticItem Gender { get; set; }
        public int? YearsExperience { get; set; }
        public StaticItem Employment { get; set; }
        public string Biomonitoring { get; set; }
        public DateTime ReplicateDate { get; set; }
        public StaticItem Site { get; set; }
        public StaticItem Season { get; set; }
        public StaticItem Country { get; set; }
        public string StateProvince { get; set; }
        public string CountyLocale { get; set; }
        public string Town { get; set; }

        public WorkerInfo()
        {
        }

        /// <summary>
        /// Makes a deep copy of <c>workerInfo</c>.
        /// </summary>
        /// <param name="workerInfo">WorkerInfo to copy.</param>
        public WorkerInfo(WorkerInfo workerInfo)
        {
            WorkerId = workerInfo.WorkerId;
            ReplicateId = workerInfo.ReplicateId;
            Task = workerInfo.Task;
            Age = workerInfo.Age;
            Height = new Length(workerInfo.Height);
            Weight = new Mass(workerInfo.Weight);
            Gender = workerInfo.Gender;
            YearsExperience = workerInfo.YearsExperience;
            Employment = workerInfo.Employment;
            Biomonitoring = workerInfo.Biomonitoring;
            ReplicateDate = workerInfo.ReplicateDate;
            Site = workerInfo.Site;
            Season = workerInfo.Season;
            Country = workerInfo.Country;
            StateProvince = workerInfo.StateProvince;
            CountyLocale = workerInfo.CountyLocale;
            Town = workerInfo.Town;
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            WorkerId = _template.WorkerId;
            ReplicateId = _template.ReplicateId;
            Task = _template.Task;
            Age = _template.Age;
            Height = new Length(_template.Height);
            Weight = new Mass(_template.Weight);
            Gender = _template.Gender;
            YearsExperience = _template.YearsExperience;
            Employment = _template.Employment;
            Biomonitoring = _template.Biomonitoring;
            ReplicateDate = _template.ReplicateDate;
            Site = _template.Site;
            Season = _template.Season;
            Country = _template.Country;
            StateProvince = _template.StateProvince;
            CountyLocale = _template.CountyLocale;
            Town = _template.Town;

            return true;
        }

        /// <summary>
        /// Template initialized once to proper default values;
        /// </summary>
        private static WorkerInfo _template;

        /// <summary>
        /// Creates a properly-initialized <c>WorkerInfo</c> instance.  This
        /// is the preferred method for creating a new <c>WorkerInfo</c>
        /// instance.
        /// </summary>
        /// <returns>A properly initialized <c>WorkerInfo</c>.</returns>
        public static WorkerInfo Create()
        {
            if (_template == null)
                CreateTemplate();

            return new WorkerInfo(_template);
        }

        private static void CreateTemplate()
        {
            _template = new WorkerInfo()
            {
                WorkerId = null,
                ReplicateId = null,
                Task = StaticValues.Item(StaticValues.Groups.Task, (int)StaticValues.Task.NotSet),
                Age = null,
                Height = null,
                Weight = null,
                Gender = StaticValues.Item(StaticValues.Groups.Gender, (int)StaticValues.Gender.NotSet),
                YearsExperience = null,
                Employment = StaticValues.Item(StaticValues.Groups.Employment, (int)StaticValues.Employment.NotSet),
                Biomonitoring = null,
                ReplicateDate = DateTime.Now,
                Site = StaticValues.Item(StaticValues.Groups.Site, (int)StaticValues.Site.NotSet),
                Season = StaticValues.Item(StaticValues.Groups.Season, (int)StaticValues.Season.NotSet),
                Country = StaticValues.Item(StaticValues.Groups.Country, (int)StaticValues.Country.NotSet),
                StateProvince = null,
                CountyLocale = null,
                Town = null
            };
        }

        #region IDeepClone Interface

        public WorkerInfo DeepClone()
        {
            return new WorkerInfo(this);
        }

        #endregion IDeepClone Interface

    }
}

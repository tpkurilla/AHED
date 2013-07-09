using System;

namespace AHED.Types
{
    [Serializable]
    public class WorkerInfo
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

        public WorkerInfo(WorkerInfo worker)
        {
            WorkerId = worker.WorkerId;
            ReplicateId = worker.ReplicateId;
            Task = worker.Task;
            Age = worker.Age;
            Height = worker.Height;
            Weight = worker.Weight;
            Weight = worker.Weight;
            Gender = worker.Gender;
            YearsExperience = worker.YearsExperience;
            Employment = worker.Employment;
            Biomonitoring = worker.Biomonitoring;
            ReplicateDate = worker.ReplicateDate;
            Site = worker.Site;
            Season = worker.Season;
            Country = worker.Country;
            StateProvince = worker.StateProvince;
            CountyLocale = worker.CountyLocale;
            Town = worker.Town;
        }
    }
}

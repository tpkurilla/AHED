using System;
using System.Collections.Generic;
using System.Linq;

namespace AHED.Types
{
    [Serializable]
    public class Study : IDeepClone<Study>, IPropertyInitializer
    {
        public string StudyNumber { get; set; }
        public string ReviewerId { get; set; }
        public bool Metric { get; set; }
        public StaticValues.QaStatus QaStatus { get; set; }
        public List<MonitoringUnit> MonitoringUnits { get; set; }
        public List<FieldFortification> FieldFortifications { get; set; }

        public Study(){}

        /// <summary>
        /// Makes a deep copy of <c>study</c>.
        /// </summary>
        /// <param name="study">Study to copy.</param>
        public Study(Study study)
        {
            if (study == null)
                throw new ArgumentNullException("study");

            StudyNumber = study.StudyNumber;
            ReviewerId = study.ReviewerId;
            Metric = study.Metric;
            QaStatus = study.QaStatus;
            MonitoringUnits = (from mu in study.MonitoringUnits
                               select new MonitoringUnit(mu)
                              ).ToList();
            FieldFortifications = (from ff in study.FieldFortifications
                                   select new FieldFortification(ff)
                                  ).ToList();
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            StudyNumber = _template.StudyNumber;
            ReviewerId = _template.ReviewerId;
            Metric = _template.Metric;
            QaStatus = _template.QaStatus;
            MonitoringUnits = (from monitoringUnit in _template.MonitoringUnits
                               select new MonitoringUnit(monitoringUnit)
                              ).ToList();
            FieldFortifications = (from fieldFort in _template.FieldFortifications
                                   select new FieldFortification(fieldFort)
                                  ).ToList();

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new Study()
            {
                StudyNumber = String.Empty,
                ReviewerId = String.Empty,
                Metric = false,
                QaStatus = StaticValues.QaStatus.NotSet,
                MonitoringUnits = new List<MonitoringUnit>(),
                FieldFortifications = new List<FieldFortification>()
            };
        }

        private static Study _template;

        public static Study Create()
        {
            if (_template == null)
                CreateTemplate();

            return new Study(_template);
        }

        public Study DeepClone()
        {
            throw new NotImplementedException();
        }
    }
}

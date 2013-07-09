using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class Study
    {
        public string StudyNumber { get; set; }
        public string ReviewerId { get; set; }
        public bool Metric { get; set; }
        public StaticValues.QaStatus QaStatus { get; set; }
        public List<MonitoringUnit> MonitoringUnits { get; set; }
        public List<FieldFortification> FieldFortifications { get; set; }

        public Study()
        {
            MonitoringUnits = new List<MonitoringUnit>();
            FieldFortifications = new List<FieldFortification>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class FieldFortification
    {
        /// <summary>
        /// Event ID assigned by the Data Entry person.
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// Must be a <c>StaticValues.DosimeterDescriptions</c> enumeration value specified
        /// in <c>StaticValues.DosimeterGroups.FieldFortification</c> list in
        /// <c>StaticValues.DosimeterGroupLocations</c>.
        /// </summary>
        public StaticItem DosimeterDescription { get; set; }

        /// <summary>
        /// List of all Monitoring Units this Field Fortification applies to.  If this
        /// list is empty, then it applies to all Monitoring Units in the <c>Study</c>
        /// containing this Field Fortification.
        /// </summary>
        public List<MonitoringUnitId> MonitoringUnitIds { get; set; }

        /// <summary>
        /// A non-empty list of <c>FieldFortification.Entry</c> used for adjusting
        /// the measurements of Monitoring Units associated with this Field
        /// Fortification.
        /// </summary>
        public List<Entry> Entries { get; set; }

        public FieldFortification()
        {
            EventId = "ID not set";
            DosimeterDescription = null;
            Entries = new List<Entry>();
            MonitoringUnitIds = new List<MonitoringUnitId>();
        }

        public FieldFortification(FieldFortification fieldFortification)
        {
            EventId = fieldFortification.EventId;
            DosimeterDescription = fieldFortification.DosimeterDescription;
            Entries = new List<Entry>(fieldFortification.Entries);
            MonitoringUnitIds = new List<MonitoringUnitId>(fieldFortification.MonitoringUnitIds);
        }

        public FieldFortification(string eventId, StaticItem dosimeterDescription)
        {
            EventId = eventId;
            DosimeterDescription = dosimeterDescription;
            Entries = new List<Entry>();
            MonitoringUnitIds = new List<MonitoringUnitId>();
        }

        [Serializable]
        public struct Entry
        {
            /// <summary>
            /// Annotation meaningful to the Data Entry person.  e.g., "low", "mid", "high", etc.
            /// </summary>
            public string Description { get; set; }

            public double FortificationLevel { get; set; }

            public double FortificationAdjustment { get; set; }
        }

        public struct MonitoringUnitId
        {
            public string WorkerId { get; set; }
            public string ReplicateId { get; set; }
        }
    }
}

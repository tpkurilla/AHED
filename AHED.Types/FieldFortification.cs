using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class FieldFortification : IDeepClone<FieldFortification>, IPropertyInitializer
    {
        /// <summary>
        /// Event ID assigned by the Data Entry person.
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// Must be a <c>StaticValues.DosimeterDescriptions</c> enumeration value specified
        /// in <c>StaticValues.DosimeterGroups.FieldFortification</c> list in
        /// <c>StaticValues.DosimeterGroupDescriptions</c>.
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
        }

        /// <summary>
        /// Makes a deep copy of <c>fieldFortification</c>.
        /// </summary>
        /// <param name="fieldFortification">FieldFortification to copy.</param>
        public FieldFortification(FieldFortification fieldFortification)
        {
            EventId = fieldFortification.EventId;
            DosimeterDescription = fieldFortification.DosimeterDescription;
            Entries = (from entry in fieldFortification.Entries
                       select new Entry(entry)
                      ).ToList();
            MonitoringUnitIds = (from muId in fieldFortification.MonitoringUnitIds
                                 select new MonitoringUnitId(muId)
                                ).ToList();
        }

        private static FieldFortification _template;

        public static FieldFortification Create()
        {
            if (_template == null)
                CreateTemplate();

            return new FieldFortification(_template);
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            EventId = _template.EventId;
            DosimeterDescription = _template.DosimeterDescription;
            Entries = new List<Entry>();
            MonitoringUnitIds = new List<MonitoringUnitId>();

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new FieldFortification()
            {
                EventId = String.Empty,
                DosimeterDescription = StaticValues.Item(StaticValues.Groups.DosimeterDescriptions, (int)StaticValues.DosimeterDescriptions.NotSet),
                Entries = new List<Entry>(),
                MonitoringUnitIds = new List<MonitoringUnitId>()
            };
        }

        FieldFortification IDeepClone<FieldFortification>.DeepClone()
        {
            return new FieldFortification(this);
        }

        [Serializable]
        public class Entry : IDeepClone<Entry>, IPropertyInitializer
        {
            /// <summary>
            /// Annotation meaningful to the Data Entry person.  e.g., "low", "mid", "high", etc.
            /// </summary>
            public string Description { get; set; }

            public double FortificationLevel { get; set; }

            public double FortificationAdjustment { get; set; }

            public Entry(){}

            public Entry(Entry entry)
            {
                Description = entry.Description;
                FortificationLevel = entry.FortificationLevel;
                FortificationAdjustment = entry.FortificationAdjustment;
            }

            private static Entry _entryTemplate;

            public static Entry CreateFieldFortEntry()
            {
                if (_entryTemplate == null)
                {
                    _entryTemplate = new Entry()
                        {
                            Description = String.Empty,
                            FortificationLevel = 0.0,
                            FortificationAdjustment = 0.0
                        };
                }

                return new Entry(_entryTemplate);
            }

            public bool InitializeProperties()
            {
                Description = String.Empty;
                FortificationLevel = 0.0;
                FortificationAdjustment = 0.0;

                return true;
            }

            Entry IDeepClone<Entry>.DeepClone()
            {
                return new Entry(this);
            }
        }

        public class MonitoringUnitId : IDeepClone<MonitoringUnitId>, IPropertyInitializer
        {
            public string WorkerId { get; set; }
            public string ReplicateId { get; set; }

            public MonitoringUnitId(){}

            public MonitoringUnitId(MonitoringUnitId muId)
            {
                WorkerId = muId.WorkerId;
                ReplicateId = muId.ReplicateId;
            }

            public static MonitoringUnitId Create()
            {
                return new MonitoringUnitId()
                    {
                        WorkerId = String.Empty,
                        ReplicateId = String.Empty
                    };
            }

            public bool InitializeProperties()
            {
                WorkerId = String.Empty;
                ReplicateId = String.Empty;

                return true;
            }

            MonitoringUnitId IDeepClone<MonitoringUnitId>.DeepClone()
            {
                return new MonitoringUnitId(this);
            }
        }
    }
}

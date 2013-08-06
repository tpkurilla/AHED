using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class DosimeterMeasurement : IDeepClone<DosimeterMeasurement>, IPropertyInitializer
    {
        /// <summary>
        /// Input Dosimeter Group.  Must be in the <c>StaticValues.DosimeterGroups</c>
        /// enumeration group.  Used to get a list of PPE body parts, and then
        /// PPE clothing choices.
        /// </summary>
        public StaticItem Group { get; set; }

        /// <summary>
        /// Input Dosimeter Description.  Must be in the <c>StaticValues.DosimeterLocations</c>
        /// enumeration group.
        /// </summary>
        public StaticItem Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Measurement Measurement { get; set; }
        public List<PpeLayer> PpeLayers { get; set; }
        public List<OuterMeasurement> OuterMeasurements { get; set; }

        public DosimeterMeasurement()
        {
        }

        public DosimeterMeasurement(StaticItem dosimeterGroup)
        {
            Group = dosimeterGroup;
            CachedStaticItem csi = StaticValues.Lookup(StaticValues.Groups.DosimeterDescriptions, (int)StaticValues.DosimeterDescriptions.NotSet);
            Description = csi.Item;
            Measurement = new Measurement(dosimeterGroup.ItemId == (int)StaticValues.DosimeterGroups.Head);
            PpeLayers = new List<PpeLayer>();
            OuterMeasurements = new List<OuterMeasurement>();
        }

        public DosimeterMeasurement(DosimeterMeasurement measurement)
        {
            Group = measurement.Group;
            Description = measurement.Description;
            Measurement = new Measurement(measurement.Measurement);
            PpeLayers = new List<PpeLayer>(measurement.PpeLayers);          // Deep copy not needed since all are references anyway
            OuterMeasurements = (from outerMeasurement in measurement.OuterMeasurements
                                 select new OuterMeasurement(outerMeasurement)
                                ).ToList();
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            Group = _template.Group;
            Description = _template.Description;
            Measurement = new Measurement(_template.Measurement);
            PpeLayers = new List<PpeLayer>(_template.PpeLayers);          // Deep copy not needed since all are references anyway
            OuterMeasurements = (from outerMeasurement in _template.OuterMeasurements
                                 select new OuterMeasurement(outerMeasurement)
                                ).ToList();

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new DosimeterMeasurement()
            {
                Group = StaticValues.Item(StaticValues.Groups.DosimeterGroups, (int)StaticValues.DosimeterGroups.NotSet),
                Description = StaticValues.Item(StaticValues.Groups.DosimeterDescriptions, (int)StaticValues.DosimeterDescriptions.NotSet),
                Measurement = Measurement.Create(),
                PpeLayers = new List<PpeLayer>(),
                OuterMeasurements = new List<OuterMeasurement>()
            };
        }

        private static DosimeterMeasurement _template;

        public static DosimeterMeasurement Create(StaticItem dosimeterGroup)
        {
            if (_template == null)
                CreateTemplate();

            var result = new DosimeterMeasurement(_template);
            if (dosimeterGroup != null)
            {
                result.Group = dosimeterGroup;
                result.Measurement.HasSize = (dosimeterGroup.ItemId == (int) StaticValues.DosimeterGroups.Head);
            }

            return result;
        }

        public DosimeterMeasurement DeepClone()
        {
            return new DosimeterMeasurement(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class DosimeterMeasurement
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
        public List<StaticItem> Layers { get; set; }
        public List<PpeMeasurement> PpeMeasurements { get; set; }

        public DosimeterMeasurement()
        {
            CachedStaticItem csi = StaticValues.Lookup(StaticValues.Groups.DosimeterDescriptions, (int)StaticValues.DosimeterDescriptions.NotSet);
            Description = csi.Item;
        }

        public DosimeterMeasurement(StaticItem description)
        {
            Description = description;
        }

        public DosimeterMeasurement(CachedStaticItem cachedStaticItem)
        {
            Description = cachedStaticItem.Item;
        }
    }
}

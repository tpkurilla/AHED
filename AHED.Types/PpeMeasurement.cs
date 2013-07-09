using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    [Serializable]
    public class PpeMeasurement : Measurement
    {
        /// <summary>
        /// Must be a <c>StaticValues.PpeBodyParts</c> enumeration/entry.
        /// </summary>
        public StaticItem BodyPart { get; set; }

        public StaticItem Clothing { get; set; }
    }
}

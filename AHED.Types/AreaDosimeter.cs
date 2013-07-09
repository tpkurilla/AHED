using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    [Serializable]
    public class AreaDosimeterMeasurement : DosimeterMeasurement
    {
        /// <summary>
        /// Size of this dosimeter in cm^2.
        /// </summary>
        public double Size { get; set; }

        public AreaDosimeterMeasurement()
            : base()
        {
        }

        public AreaDosimeterMeasurement(StaticItem description)
            : base(description)
        {
        }
    }
}

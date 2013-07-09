using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class Measurement
    {
        /// <summary>
        /// Must be in the <c>StaticValues.DosimeterMatrices</c> enumeration group.
        /// </summary>
        public StaticItem InputDosimeterMatrix { get; set; }

        /// <summary>
        /// Value is generally in milligrams.
        /// </summary>
        public Mass InputResidue { get; set; }

        /// <summary>
        /// Level of quantization.
        /// </summary>
        public Mass InputLoq { get; set; }

        /// <summary>
        /// Level of detection.
        /// </summary>
        public Mass InputLod { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class Measurement : IDeepClone<Measurement>, IPropertyInitializer
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

        public bool HasSize { get; set; }

        public double? Size { get; set; }

        /// <summary>
        /// Allows easy by-name initialization at instantiation.
        /// </summary>
        public Measurement(){}

        public Measurement(bool hasSize)
        {
            InputDosimeterMatrix = StaticValues.Item(StaticValues.Groups.DosimeterMatrices,
                                                     (int)StaticValues.DosimeterMatrices.NotSet);
            InputResidue = new Mass(0.0, Mass.Units.Micrograms);
            InputLoq = new Mass(0.0, Mass.Units.Micrograms);
            InputLod = new Mass(0.0, Mass.Units.Micrograms);
            HasSize = hasSize;
            Size = 0;
        }

        /// <summary>
        /// Makes a deep copy of <c>measurement</c>.
        /// </summary>
        /// <param name="measurement">Measurement to copy.</param>
        public Measurement(Measurement measurement)
        {
            InputDosimeterMatrix = measurement.InputDosimeterMatrix;
            InputResidue = new Mass(measurement.InputResidue);
            InputLoq = new Mass(measurement.InputLoq);
            InputLod = new Mass(measurement.InputLod);
            HasSize = measurement.HasSize;
            Size = measurement.Size;
        }

        public bool InitializeProperties()
        {
            InputDosimeterMatrix = StaticValues.Item(StaticValues.Groups.DosimeterMatrices,
                                                     (int)StaticValues.DosimeterMatrices.NotSet);
            InputResidue = new Mass(0.0, Mass.Units.Micrograms);
            InputLoq = new Mass(0.0, Mass.Units.Micrograms);
            InputLod = new Mass(0.0, Mass.Units.Micrograms);
            HasSize = false;
            Size = 0;

            return true;
        }

        /// <summary>
        /// Creates a properly-initialized <c>Measurement</c> instance.  This
        /// is the preferred method for creating a new <c>Measurement</c>
        /// instance.
        /// </summary>
        /// <returns>A properly initialized <c>Measurement</c>.</returns>
        public static Measurement Create(bool hasSize = false)
        {
            return new Measurement(hasSize);
        }

        public Measurement DeepClone()
        {
            return new Measurement(this);
        }
    }
}

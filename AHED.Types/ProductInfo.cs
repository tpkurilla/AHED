using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class ProductInfo
    {
        public StaticItem ActionOfPesticide { get; set; }
        public StaticItem Formulation { get; set; }
        public StaticItem Package { get; set; }
        public Mass PackageWeight { get; set; }
        public Volume PackageVolume { get; set; }
        public double? VaporPressure { get; set; }
        public double? PercentageAiByWeight { get; set; }
        public MassPerVolume AiMassPerVolume { get; set; }
        public double? VaporPressureAtC { get; set; }
        public string VaporPressureCitation { get; set; }

        public ProductInfo()
        {
        }

        public ProductInfo(ProductInfo prod)
        {
            ActionOfPesticide = prod.ActionOfPesticide;
            Formulation = prod.Formulation;
            Package = prod.Package;
            PackageWeight = prod.PackageWeight;
            PackageVolume = prod.PackageVolume;
            VaporPressure = prod.VaporPressure;
            PercentageAiByWeight = prod.PercentageAiByWeight;
            AiMassPerVolume = prod.AiMassPerVolume;
            VaporPressureCitation = prod.VaporPressureCitation;
        }
    }
}

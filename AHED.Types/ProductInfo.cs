using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class ProductInfo : IDeepClone<ProductInfo>, IPropertyInitializer
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

        /// <summary>
        /// Makes a deep copy of <c>prodInfo</c>
        /// </summary>
        /// <param name="prodInfo"></param>
        public ProductInfo(ProductInfo prodInfo)
        {
            ActionOfPesticide = prodInfo.ActionOfPesticide;
            Formulation = prodInfo.Formulation;
            Package = prodInfo.Package;
            PackageWeight = new Mass(prodInfo.PackageWeight);
            PackageVolume = new Volume(prodInfo.PackageVolume);
            VaporPressure = prodInfo.VaporPressure;
            PercentageAiByWeight = prodInfo.PercentageAiByWeight;
            AiMassPerVolume = new MassPerVolume(prodInfo.AiMassPerVolume);
            VaporPressureAtC = prodInfo.VaporPressureAtC;
            VaporPressureCitation = prodInfo.VaporPressureCitation;
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            ActionOfPesticide = _template.ActionOfPesticide;
            Formulation = _template.Formulation;
            Package = _template.Package;
            PackageWeight = new Mass(_template.PackageWeight);
            PackageVolume = new Volume(_template.PackageVolume);
            VaporPressure = _template.VaporPressure;
            PercentageAiByWeight = _template.PercentageAiByWeight;
            AiMassPerVolume = new MassPerVolume(_template.AiMassPerVolume);
            VaporPressureAtC = _template.VaporPressureAtC;
            VaporPressureCitation = _template.VaporPressureCitation;

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new ProductInfo()
            {
                ActionOfPesticide = StaticValues.Item(StaticValues.Groups.Pesticide, (int)StaticValues.Pesticide.NotSet),
                Formulation = StaticValues.Item(StaticValues.Groups.Formulation, (int)StaticValues.Formulation.NotSet),
                Package = StaticValues.Item(StaticValues.Groups.Package, (int)StaticValues.Package.NotSet),
                PackageWeight = null,
                VaporPressure = null,
                PercentageAiByWeight = null,
                AiMassPerVolume = null,
                VaporPressureAtC = null,
                VaporPressureCitation = null
            };
        }

        private static ProductInfo _template;

        public static ProductInfo Create()
        {
            if (_template == null)
                CreateTemplate();

            return new ProductInfo(_template);
        }

        public ProductInfo DeepClone()
        {
            return new ProductInfo(this);
        }
    }
}

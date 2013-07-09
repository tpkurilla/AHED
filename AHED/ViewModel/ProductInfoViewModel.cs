using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHED.Model;
using AHED.Types;

namespace AHED.ViewModel
{
    public class ProductInfoViewModel : ViewModelBase
    {
        #region Fields

        readonly ProductInfoModel _productInfo;

        StaticItem[] _pesticideOptions;

        StaticItem[] _formulationOptions;

        StaticItem[] _packageOptions;

        #endregion // Fields

        #region Constructor

        public ProductInfoViewModel(ProductInfoModel productInfo)
        {
            if (productInfo == null)
                throw new ArgumentNullException("productInfo");

            _productInfo = productInfo;
        }

        #endregion // Constructor

        #region Presentation Properties

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for Task selector.
        /// </summary>
        public StaticItem[] PesticideOptions
        {
            get
            {
                if (_pesticideOptions == null)
                {
                    _pesticideOptions = _productInfo.ValidPesticides.ToArray();
                }

                return _pesticideOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Gender selector.
        /// </summary>
        public StaticItem[] FormulationOptions
        {
            get
            {
                if (_formulationOptions == null)
                {
                    _formulationOptions = _productInfo.ValidFormulations.ToArray();
                }

                return _formulationOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Employment selector.
        /// </summary>
        public StaticItem[] PackageOptions
        {
            get
            {
                if (_packageOptions == null)
                {
                    _packageOptions = _productInfo.ValidPackages.ToArray();
                }

                return _packageOptions;
            }
        }

        #endregion StaticItem Choices

        #endregion Presentation Properties

        #region ProductInfo Properties

        public StaticItem ActionOfPesticide
        {
            get { return _productInfo.ActionOfPesticide; }
            set
            {
                if (value == _productInfo.ActionOfPesticide)
                    return;

                _productInfo.ActionOfPesticide = value;
                base.OnPropertyChanged(ProductInfoModel.ACTION_OF_PESTICIDE);
            }
        }

        public StaticItem Formulation
        {
            get { return _productInfo.Formulation; }
            set
            {
                if (value == _productInfo.Formulation)
                    return;

                _productInfo.Formulation = value;
                base.OnPropertyChanged(ProductInfoModel.FORMULATION);
            }
        }

        public StaticItem Package
        {
            get { return _productInfo.Package; }
            set
            {
                if (value == _productInfo.Package)
                    return;

                _productInfo.Package = value;
                base.OnPropertyChanged(ProductInfoModel.PACKAGE);
            }
        }

        public Mass PackageWeight
        {
            get { return _productInfo.PackageWeight; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _productInfo.PackageWeight)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _productInfo.PackageWeight.OriginalUnits
                    && value.OriginalValue == _productInfo.PackageWeight.OriginalValue)
                    return;

                _productInfo.PackageWeight = value;
                base.OnPropertyChanged(ProductInfoModel.PACKAGE_WEIGHT);
            }
        }

        public Volume PackageVolume
        {
            get { return _productInfo.PackageVolume; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _productInfo.PackageVolume)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _productInfo.PackageVolume.OriginalUnits
                    && value.OriginalValue == _productInfo.PackageVolume.OriginalValue)
                    return;

                _productInfo.PackageVolume = value;
                base.OnPropertyChanged(ProductInfoModel.PACKAGE_VOLUME);
            }
        }

        public double? VaporPressure
        {
            get { return _productInfo.VaporPressure; }
            set
            {
                if (value == _productInfo.VaporPressure)
                    return;

                _productInfo.VaporPressure = value;
                base.OnPropertyChanged(ProductInfoModel.VAPOR_PRESSURE);
            }
        }

        public double? PercentageAiByWeight
        {
            get { return _productInfo.PercentageAiByWeight; }
            set
            {
                if (value == _productInfo.PercentageAiByWeight)
                    return;

                _productInfo.PercentageAiByWeight = value;
                base.OnPropertyChanged(ProductInfoModel.PERCENTAGE_AI_BY_WEIGHT);
            }
        }

        public MassPerVolume AiMassPerVolume
        {
            get { return _productInfo.AiMassPerVolume; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _productInfo.AiMassPerVolume)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _productInfo.AiMassPerVolume.OriginalUnits
                    && value.OriginalValue == _productInfo.AiMassPerVolume.OriginalValue)
                    return;

                _productInfo.AiMassPerVolume = value;
                base.OnPropertyChanged(ProductInfoModel.AI_MASS_PER_VOLUME);
            }
        }

        public double? VaporPressureAtC
        {
            get { return _productInfo.VaporPressureAtC; }
            set
            {
                if (value == _productInfo.VaporPressureAtC)
                    return;

                _productInfo.VaporPressureAtC = value;
                base.OnPropertyChanged(ProductInfoModel.VAPOR_PRESSURE_AT_C);
            }
        }

        public string VaporPressureCitation
        {
            get { return _productInfo.VaporPressureCitation; }
            set
            {
                if (value == _productInfo.VaporPressureCitation)
                    return;

                _productInfo.VaporPressureCitation = value;
                base.OnPropertyChanged(ProductInfoModel.VAPOR_PRESSURE_CITATION);
            }
        }

        #endregion

    }
}

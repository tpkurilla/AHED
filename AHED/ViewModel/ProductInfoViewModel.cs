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

        #region Valid Options for StaticItems

        StaticItem[] _pesticideOptions;

        StaticItem[] _formulationOptions;

        StaticItem[] _packageOptions;

        #endregion Valid Options for StaticItems

        #region Valid Units Options for properties

        private Mass.Units[] _packageWeightUnitsOptions;

        private Volume.Units[] _packageVolumeUnitsOptions;

        private MassPerVolume.Units[] _aiMassPerVolumeUnitsOptions;

        #endregion Valid Units Options for properties

        #endregion // Fields

        #region Constructor

        public ProductInfoViewModel(ProductInfoModel productInfo)
        {
            if (productInfo == null)
                throw new ArgumentNullException("productInfo");

            _productInfo = productInfo;

            ActionOfPesticide = productInfo.ActionOfPesticide;
            Formulation = productInfo.Formulation;
            Package = productInfo.Package;
            PackageWeight = productInfo.PackageWeight;
            PackageVolume = productInfo.PackageVolume;
            VaporPressure = productInfo.VaporPressure;
            PercentageAiByWeight = productInfo.PercentageAiByWeight;
            AiMassPerVolume = productInfo.AiMassPerVolume;
            VaporPressureAtC = productInfo.VaporPressureAtC;
            VaporPressureCitation = productInfo.VaporPressureCitation;
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

        #region Units Choices

        /// <summary>
        /// Returns an array of valid choices for PackageWeightUnits selector.
        /// </summary>
        public Mass.Units[] PackageWeightUnitsOptions
        {
            get
            {
                if (_packageWeightUnitsOptions == null)
                {
                    _packageWeightUnitsOptions = new Mass.Units[] { Mass.Units.Pounds, Mass.Units.Kilograms };
                }

                return _packageWeightUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for PackageVolumeUnits selector.
        /// </summary>
        public Volume.Units[] PackageVolumeUnitsOptions
        {
            get
            {
                if (_packageVolumeUnitsOptions == null)
                {
                    _packageVolumeUnitsOptions = new Volume.Units[] { Volume.Units.Gallons, Volume.Units.Liters };
                }

                return _packageVolumeUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for AiMassPerVolumeUnits selector.
        /// </summary>
        public MassPerVolume.Units[] AiMassPerVolumeUnitsOptions
        {
            get
            {
                if (_aiMassPerVolumeUnitsOptions == null)
                {
                    _aiMassPerVolumeUnitsOptions = new MassPerVolume.Units[] { MassPerVolume.Units.PoundsPerGallon, MassPerVolume.Units.GramsPerLiter };
                }

                return _aiMassPerVolumeUnitsOptions;
            }
        }

        #endregion Units Choices

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

        public Mass.Units PackageWeightUnits
        {
            get { return _productInfo.PackageWeightUnits; }
            set
            {
                if (value != _productInfo.PackageWeightUnits)
                {
                    _productInfo.PackageWeightUnits = value;
                    base.OnPropertyChanged(ProductInfoModel.PACKAGE_WEIGHT_UNITS);
                    base.OnPropertyChanged(ProductInfoModel.PACKAGE_WEIGHT);
                }
            }
        }

        public string PackageWeight
        {
            get { return _productInfo.PackageWeight; }
            set
            {
                if (value == _productInfo.PackageWeight)
                    return;

                _productInfo.PackageWeight = value;
                base.OnPropertyChanged(ProductInfoModel.PACKAGE_WEIGHT);
            }
        }

        public Volume.Units PackageVolumeUnits
        {
            get { return _productInfo.PackageVolumeUnits; }
            set
            {
                if (value != _productInfo.PackageVolumeUnits)
                {
                    _productInfo.PackageVolumeUnits = value;
                    base.OnPropertyChanged(ProductInfoModel.PACKAGE_VOLUME_UNITS);
                    base.OnPropertyChanged(ProductInfoModel.PACKAGE_VOLUME);
                }
            }
        }

        public string PackageVolume
        {
            get { return _productInfo.PackageVolume; }
            set
            {
                if (value == _productInfo.PackageVolume)
                    return;

                _productInfo.PackageVolume = value;
                base.OnPropertyChanged(ProductInfoModel.PACKAGE_VOLUME);
            }
        }

        public string VaporPressure
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

        public string PercentageAiByWeight
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

        public string AiMassPerVolume
        {
            get { return _productInfo.AiMassPerVolume; }
            set
            {
                if (value == _productInfo.AiMassPerVolume)
                    return;

                _productInfo.AiMassPerVolume = value;
                base.OnPropertyChanged(ProductInfoModel.AI_MASS_PER_VOLUME);
            }
        }

        public string VaporPressureAtC
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

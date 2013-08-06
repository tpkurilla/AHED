using System;
using AHED.Data.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class ProductInfoViewModel : SimpleViewModel<ProductInfoModel,ProductInfo>
    {
        #region Fields

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
            : base(productInfo)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            ActionOfPesticide = Model.ActionOfPesticide;
            Formulation = Model.Formulation;
            Package = Model.Package;
            PackageWeight = Model.PackageWeight;
            PackageVolume = Model.PackageVolume;
            VaporPressure = Model.VaporPressure;
            PercentageAiByWeight = Model.PercentageAiByWeight;
            AiMassPerVolume = Model.AiMassPerVolume;
            VaporPressureAtC = Model.VaporPressureAtC;
            VaporPressureCitation = Model.VaporPressureCitation;
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
                return _pesticideOptions
                       ?? (_pesticideOptions = Model.ValidPesticides.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Gender selector.
        /// </summary>
        public StaticItem[] FormulationOptions
        {
            get
            {
                return _formulationOptions
                       ?? (_formulationOptions = Model.ValidFormulations.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Employment selector.
        /// </summary>
        public StaticItem[] PackageOptions
        {
            get
            {
                return _packageOptions
                       ?? (_packageOptions = Model.ValidPackages.ToArray());
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
                return _packageWeightUnitsOptions
                       ?? (_packageWeightUnitsOptions = new[] {Mass.Units.Pounds, Mass.Units.Kilograms});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for PackageVolumeUnits selector.
        /// </summary>
        public Volume.Units[] PackageVolumeUnitsOptions
        {
            get
            {
                return _packageVolumeUnitsOptions
                       ?? (_packageVolumeUnitsOptions = new[] {Volume.Units.Gallons, Volume.Units.Liters});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for AiMassPerVolumeUnits selector.
        /// </summary>
        public MassPerVolume.Units[] AiMassPerVolumeUnitsOptions
        {
            get
            {
                return _aiMassPerVolumeUnitsOptions
                       ?? (_aiMassPerVolumeUnitsOptions = new[] {MassPerVolume.Units.PoundsPerGallon, MassPerVolume.Units.GramsPerLiter});
            }
        }

        #endregion Units Choices

        #endregion Presentation Properties

        #region Properties

        private StaticItem _actionOfPesticide;
        public StaticItem ActionOfPesticide
        {
            get { return _actionOfPesticide; }
            set
            {
                if (value == _actionOfPesticide)
                    return;

                Model.ActionOfPesticide = value;
                _actionOfPesticide = Model.ActionOfPesticide;
                base.RaisePropertyChanged(ProductInfoModel.ActionOfPesticideName);
            }
        }

        private StaticItem _formulation;
        public StaticItem Formulation
        {
            get { return _formulation; }
            set
            {
                if (value == _formulation)
                    return;

                Model.Formulation = value;
                _formulation = Model.Formulation;
                base.RaisePropertyChanged(ProductInfoModel.FormulationName);
            }
        }

        private StaticItem _package;
        public StaticItem Package
        {
            get { return _package; }
            set
            {
                if (value == _package)
                    return;

                Model.Package = value;
                _package = Model.Package;
                base.RaisePropertyChanged(ProductInfoModel.PackageName);
            }
        }

        private Mass.Units _packageWeightUnits;
        public Mass.Units PackageWeightUnits
        {
            get { return _packageWeightUnits; }
            set
            {
                if (value == _packageWeightUnits)
                    return;

                Model.PackageWeightUnits = value;
                _packageWeightUnits = Model.PackageWeightUnits;
                base.RaisePropertyChanged(ProductInfoModel.PackageWeightUnitsName);
                base.RaisePropertyChanged(ProductInfoModel.PackageWeightName);
            }
        }

        private string _packageWeight;
        public string PackageWeight
        {
            get { return _packageWeight; }
            set
            {
                if (value == _packageWeight)
                    return;

                Model.PackageWeight = value;
                _packageWeight = Model.PackageWeight;
                base.RaisePropertyChanged(ProductInfoModel.PackageWeightName);
            }
        }

        private Volume.Units _packageVolumeUnits;
        public Volume.Units PackageVolumeUnits
        {
            get { return _packageVolumeUnits; }
            set
            {
                if (value == _packageVolumeUnits)
                    return;

                Model.PackageVolumeUnits = value;
                _packageVolumeUnits = Model.PackageVolumeUnits;
                base.RaisePropertyChanged(ProductInfoModel.PackageVolumeUnitsName);
                base.RaisePropertyChanged(ProductInfoModel.PackageVolumeName);
            }
        }

        private string _packageVolume;
        public string PackageVolume
        {
            get { return _packageVolume; }
            set
            {
                if (value == _packageVolume)
                    return;

                Model.PackageVolume = value;
                _packageVolume = Model.PackageVolume;
                base.RaisePropertyChanged(ProductInfoModel.PackageVolumeName);
            }
        }

        private string _vaporPressure;
        public string VaporPressure
        {
            get { return _vaporPressure; }
            set
            {
                if (value == _vaporPressure)
                    return;

                Model.VaporPressure = value;
                _vaporPressure = Model.VaporPressure;
                base.RaisePropertyChanged(ProductInfoModel.VaporPressureName);
            }
        }

        private string _percentageAiByWeight;
        public string PercentageAiByWeight
        {
            get { return _percentageAiByWeight; }
            set
            {
                if (value == _percentageAiByWeight)
                    return;

                Model.PercentageAiByWeight = value;
                _percentageAiByWeight = Model.PercentageAiByWeight;
                base.RaisePropertyChanged(ProductInfoModel.PercentageAiByWeightName);
            }
        }

        private string _aiMassPerVolume;
        public string AiMassPerVolume
        {
            get { return _aiMassPerVolume; }
            set
            {
                if (value == _aiMassPerVolume)
                    return;

                Model.AiMassPerVolume = value;
                _aiMassPerVolume = Model.AiMassPerVolume;
                base.RaisePropertyChanged(ProductInfoModel.AiMassPerVolumeName);
            }
        }

        private string _vaporPressureAtC;
        public string VaporPressureAtC
        {
            get { return _vaporPressureAtC; }
            set
            {
                if (value == _vaporPressureAtC)
                    return;

                Model.VaporPressureAtC = value;
                _vaporPressureAtC = Model.VaporPressureAtC;
                base.RaisePropertyChanged(ProductInfoModel.VaporPressureAtCName);
            }
        }

        private string _vaporPressureCitation;
        public string VaporPressureCitation
        {
            get { return _vaporPressureCitation; }
            set
            {
                if (value == _vaporPressureCitation)
                    return;

                Model.VaporPressureCitation = value;
                _vaporPressureCitation = Model.VaporPressureCitation;
                base.RaisePropertyChanged(ProductInfoModel.VaporPressureCitationName);
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

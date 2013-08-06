using System;
using System.Collections.Generic;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>ProductInfo</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class ProductInfoModel : Model<ProductInfo>, IDeepClone<ProductInfoModel>
    {
        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidPesticides = StaticValues.GroupOptions(StaticValues.Groups.Pesticide);

        public readonly List<StaticItem> ValidFormulations = StaticValues.GroupOptions(StaticValues.Groups.Formulation);

        public readonly List<StaticItem> ValidPackages = StaticValues.GroupOptions(StaticValues.Groups.Package);

        #endregion Valid Options for StaticItems

        #region Properties

        public StaticItem ActionOfPesticide
        {
            get { return Value.ActionOfPesticide; }
            set
            {
                if (value != Value.ActionOfPesticide)
                {
                    if (ValidateActionOfPesticide(value))
                        Value.ActionOfPesticide = value;
                }
            }
        }

        public StaticItem Formulation
        {
            get { return Value.Formulation; }
            set
            {
                if (Value.Formulation != value)
                {
                    if (ValidateFormulation(value))
                        Value.Formulation = value;
                }
            }
        }

        public StaticItem Package
        {
            get { return Value.Package; }
            set
            {
                if (Value.Package != value)
                {
                    if (ValidatePackage(value))
                        Value.Package = value;
                }
            }
        }

        private Mass.Units _packageWeightUnits;
        public Mass.Units PackageWeightUnits
        {
            get { return _packageWeightUnits; }
            set
            {
                if (value != _packageWeightUnits)
                {
                    _packageWeightUnits = value;
                    _packageWeightText =
                        (Value.PackageWeight != null)
                            ? Mass.Convert(Value.PackageWeight, _packageWeightUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _packageWeightText;
        public string PackageWeight
        {
            get { return _packageWeightText; }
            set
            {
                if (value != _packageWeightText)
                {
                    Mass weight;
                    if (ValidatePackageWeight(value, out weight))
                    {
                        Value.PackageWeight = weight;
                        _packageWeightText =
                            (weight != null)
                                ? Mass.Convert(weight, _packageWeightUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Volume.Units _packageVolumeUnits;
        public Volume.Units PackageVolumeUnits
        {
            get { return _packageVolumeUnits; }
            set
            {
                if (value != _packageVolumeUnits)
                {
                    _packageVolumeUnits = value;
                    _packageVolumeText =
                        (Value.PackageVolume != null)
                            ? Volume.Convert(Value.PackageVolume, _packageVolumeUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _packageVolumeText;
        public string PackageVolume
        {
            get { return _packageVolumeText; }
            set
            {
                if (value != _packageVolumeText)
                {
                    Volume volume;
                    if (ValidatePackageVolume(value, out volume))
                    {
                        Value.PackageVolume = volume;
                        _packageVolumeText =
                            (volume != null)
                                ? Volume.Convert(volume, _packageVolumeUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private string _vaporPressureText;
        public string VaporPressure
        {
            get { return _vaporPressureText; }
            set
            {
                if (value != _vaporPressureText)
                {
                    double? pressure;
                    if (!ValidateVaporPressure(value, out pressure))
                    {
                        _vaporPressureText = value;
                    }
                    else
                    {
                        Value.VaporPressure = pressure;
                        _vaporPressureText = (pressure != null) ? pressure.ToString() : String.Empty;
                    }
                }
            }
        }

        private string _percentageAiByWeightText;
        public string PercentageAiByWeight
        {
            get { return _percentageAiByWeightText; }
            set
            {
                if (value != _percentageAiByWeightText)
                {
                    double? pressure;
                    if (!ValidatePercentageAiByWeight(value, out pressure))
                    {
                        _percentageAiByWeightText = value;
                    }
                    else
                    {
                        Value.PercentageAiByWeight = pressure;
                        _percentageAiByWeightText = (pressure != null) ? pressure.ToString() : String.Empty;
                    }
                }
            }
        }

        private MassPerVolume.Units _aiMassPerVolumeUnits;
        public MassPerVolume.Units AiMassPerVolumeUnits
        {
            get { return _aiMassPerVolumeUnits; }
            set
            {
                if (value != _aiMassPerVolumeUnits)
                {
                    _aiMassPerVolumeUnits = value;
                    _aiMassPerVolumeText =
                        (Value.PackageVolume != null)
                            ? MassPerVolume.Convert(Value.AiMassPerVolume, _aiMassPerVolumeUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _aiMassPerVolumeText;
        public string AiMassPerVolume
        {
            get { return _aiMassPerVolumeText; }
            set
            {
                if (value != _aiMassPerVolumeText)
                {
                    MassPerVolume aiMassPerVolume;
                    if (ValidateAiMassPerVolume(value, out aiMassPerVolume))
                    {
                        Value.AiMassPerVolume = aiMassPerVolume;
                        _aiMassPerVolumeText =
                            (aiMassPerVolume != null)
                                ? MassPerVolume.Convert(aiMassPerVolume, _aiMassPerVolumeUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private string _vaporePressureAtCText;
        public string VaporPressureAtC
        {
            get { return _vaporePressureAtCText; }
            set
            {
                if (value != _vaporePressureAtCText)
                {
                    double? pressure;
                    if (!ValidateVaporPressureAtC(value, out pressure))
                    {
                        _vaporePressureAtCText = value;
                    }
                    else
                    {
                        Value.VaporPressureAtC = pressure;
                        _vaporePressureAtCText = (pressure != null) ? pressure.ToString() : String.Empty;
                    }
                }
            }
        }

        private string _vaporPressureCitationText;
        public string VaporPressureCitation
        {
            get { return _vaporPressureCitationText; }
            set
            {
                if (value != _vaporPressureCitationText)
                {
                    if (!ValidateVaporPressureCitation(value))
                    {
                        _vaporPressureCitationText = value;
                    }
                    else
                    {
                        _vaporPressureCitationText = value;
                        Value.VaporPressureCitation = value;
                    }
                }
            }
        }

        #endregion // Properties

        #region Constructor

        public ProductInfoModel(){}

        public ProductInfoModel(ProductInfo productInfo)
            : base(productInfo)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public ProductInfoModel(ProductInfoModel model)
            : base(model)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            // Now set all Model properties, and trigger all validations
            ActionOfPesticide = Value.ActionOfPesticide;
            Formulation = Value.Formulation;
            Package = Value.Package;
            Mass.TextAndUnits(Value.PackageWeight, out _packageWeightText, out _packageWeightUnits);
            Volume.TextAndUnits(Value.PackageVolume, out _packageVolumeText, out _packageVolumeUnits);
            VaporPressure = Value.VaporPressure.HasValue ? Value.VaporPressure.ToString() : String.Empty;
            PercentageAiByWeight = Value.PercentageAiByWeight.HasValue ? Value.PercentageAiByWeight.ToString() : String.Empty;
            MassPerVolume.TextAndUnits(Value.AiMassPerVolume, out _aiMassPerVolumeText, out _aiMassPerVolumeUnits);
            VaporPressureAtC = Value.VaporPressureAtC.HasValue ? Value.VaporPressureAtC.ToString() : String.Empty;
            VaporPressureCitation = Value.VaporPressureCitation;
        }

        #endregion

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string ActionOfPesticideName = "ActionOfPesticide";
        public const string FormulationName = "Formulation";
        public const string PackageName = "Package";
        public const string PackageWeightName = "PackageWeight";
        public const string PackageVolumeName = "PackageVolume";
        public const string VaporPressureName = "VaporPressure";
        public const string PercentageAiByWeightName = "PercentageAiByWeight";
        public const string AiMassPerVolumeName = "AiMassPerVolume";
        public const string VaporPressureAtCName = "VaporPressureAtC";
        public const string VaporPressureCitationName = "VaporPressureCitation";

        // Not properties of MixingInfo, but properties for this model
        public const string PackageWeightUnitsName = "PackageWeightUnits";
        public const string PackageVolumeUnitsName = "PackageVolumeUnits";
        public const string AiMassPerVolumeUnitsName = "AiMassPerVolumeUnits";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ActionOfPesticide</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Pesticide] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ActionOfPesticide</c>.</returns>
        private bool ValidateActionOfPesticide(StaticItem value)
        {
            if (ValidPesticides.Contains(value))
            {
                RemoveError(ActionOfPesticideName, Properties.Resources.ProductInfo_Invalid_Action_of_Pesticide);
                return true;
            }

            AddError(ActionOfPesticideName, Properties.Resources.ProductInfo_Invalid_Action_of_Pesticide, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Formulation</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Formulation] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Formulation</c>.</returns>
        private bool ValidateFormulation(StaticItem value)
        {
            if (ValidFormulations.Contains(value))
            {
                RemoveError(FormulationName, Properties.Resources.ProductInfo_Invalid_Formulation);
                return true;
            }
            
            AddError(FormulationName, Properties.Resources.ProductInfo_Invalid_Formulation, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Package</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Package] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Package</c>.</returns>
        private bool ValidatePackage(StaticItem value)
        {
            if (ValidPackages.Contains(value))
            {
                RemoveError(PackageName, Properties.Resources.ProductInfo_Invalid_Package);
                return true;
            }

            AddError(PackageName, Properties.Resources.ProductInfo_Invalid_Package, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PackageWeight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a weight.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PackageWeight</c>.</returns>
        private bool ValidatePackageWeight(string str, out Mass value)
        {
            return ValidateMass(str, _packageWeightUnits,
                                PackageWeightName, Properties.Resources.ProductInfo_Invalid_Package_Weight,
                                out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PackageVolume</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a volume.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PackageVolume</c>.</returns>
        private bool ValidatePackageVolume(string str, out Volume value)
        {
            return ValidateVolume(str, _packageVolumeUnits,
                                  PackageVolumeName, Properties.Resources.ProductInfo_Invalid_Package_Volume,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VaporPressure</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VaporPressure</c>.</returns>
        private bool ValidateVaporPressure(string str, out double? value)
        {
            return ValidateDouble(str, PositiveOnly,
                                  VaporPressureName, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PercentageAiByWeight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PercentageAiByWeight</c>.</returns>
        private bool ValidatePercentageAiByWeight(string str, out double? value)
        {
            return ValidateDouble(str, PositiveOnly,
                                  PercentageAiByWeightName, Properties.Resources.ProductInfo_Invalid_Percentage_AI_by_Weight,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>AiMassPerVolume</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a mass per volume.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>AiMassPerVolume</c>.</returns>
        private bool ValidateAiMassPerVolume(string str, out MassPerVolume value)
        {
            return ValidateMassPerVolume(str, _aiMassPerVolumeUnits,
                                         AiMassPerVolumeName, Properties.Resources.ProductInfo_Invalid_AI_Mass_per_Volume,
                                         out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VaporPressureAtC</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a vapor pressure.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VaporPressureAtC</c>.</returns>
        private bool ValidateVaporPressureAtC(string str, out double? value)
        {
            return ValidateDouble(str, PositiveOnly,
                                  VaporPressureAtCName, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure_at_C,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VaporPressureCitation</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VaporPressureCitation</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateVaporPressureCitation(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        public ProductInfoModel DeepClone()
        {
            return new ProductInfoModel(this);
        }

        #endregion IDeepClone Interface
    }
}

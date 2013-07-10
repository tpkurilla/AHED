using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using AHED.Types;

namespace AHED.Model
{
    /// <summary>
    /// Wraps <c>ProductInfo</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class ProductInfoModel : BaseModel
    {
        /// <summary>
        /// The <c>WorkerInfo</c> being wrapped by this model.
        /// </summary>
        private readonly ProductInfo _productInfo;

        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidPesticides = StaticValues.GroupOptions(StaticValues.Groups.Pesticide);

        public readonly List<StaticItem> ValidFormulations = StaticValues.GroupOptions(StaticValues.Groups.Formulation);

        public readonly List<StaticItem> ValidPackages = StaticValues.GroupOptions(StaticValues.Groups.Package);

        #endregion Valid Options for StaticItems

        #region Properties

        public StaticItem ActionOfPesticide
        {
            get { return _productInfo.ActionOfPesticide; }
            set
            {
                if (value != _productInfo.ActionOfPesticide)
                {
                    if (ValidateActionOfPesticide(value))
                        _productInfo.ActionOfPesticide = value;
                }
            }
        }

        public StaticItem Formulation
        {
            get { return _productInfo.Formulation; }
            set
            {
                if (_productInfo.Formulation != value)
                {
                    if (ValidateFormulation(value))
                        _productInfo.Formulation = value;
                }
            }
        }

        public StaticItem Package
        {
            get { return _productInfo.Package; }
            set
            {
                if (_productInfo.Package != value)
                {
                    if (ValidatePackage(value))
                        _productInfo.Package = value;
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
                        (_productInfo.PackageWeight != null)
                            ? Mass.Convert(_productInfo.PackageWeight, _packageWeightUnits).ToString()
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
                        _productInfo.PackageWeight = weight;
                        _packageWeightText =
                            (weight != null)
                                ? Mass.Convert(weight, _packageWeightUnits).ToString()
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
                        (_productInfo.PackageVolume != null)
                            ? Volume.Convert(_productInfo.PackageVolume, _packageVolumeUnits).ToString()
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
                        _productInfo.PackageVolume = volume;
                        _packageVolumeText =
                            (volume != null)
                                ? Volume.Convert(volume, _packageVolumeUnits).ToString()
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
                        _productInfo.VaporPressure = pressure;
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
                    if (!ValidateVaporPressure(value, out pressure))
                    {
                        _percentageAiByWeightText = value;
                    }
                    else
                    {
                        _productInfo.PercentageAiByWeight = pressure;
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
                        (_productInfo.PackageVolume != null)
                            ? MassPerVolume.Convert(_productInfo.AiMassPerVolume, _aiMassPerVolumeUnits).ToString()
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
                        _productInfo.AiMassPerVolume = aiMassPerVolume;
                        _aiMassPerVolumeText =
                            (aiMassPerVolume != null)
                                ? MassPerVolume.Convert(aiMassPerVolume, _aiMassPerVolumeUnits).ToString()
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
                        _productInfo.VaporPressureAtC = pressure;
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
                        _productInfo.VaporPressureCitation = value;
                    }
                }
            }
        }

        #endregion // Properties

        #region Constructor

        ProductInfoModel(ProductInfo productInfo)
        {
            _productInfo = productInfo;

            // Now set all Model properties, and trigger all validations
            ActionOfPesticide = productInfo.ActionOfPesticide;
            Formulation = productInfo.Formulation;
            Package = productInfo.Package;
            MassTextAndUnits(productInfo.PackageWeight, out _packageWeightText, out _packageWeightUnits);
            VolumeTextAndUnits(productInfo.PackageVolume, out _packageVolumeText, out _packageVolumeUnits);
            VaporPressure = productInfo.VaporPressure.HasValue ? productInfo.VaporPressure.ToString() : String.Empty;
            PercentageAiByWeight = productInfo.PercentageAiByWeight.HasValue ? productInfo.PercentageAiByWeight.ToString() : String.Empty;
            MassPerVolumeTextAndUnits(productInfo.AiMassPerVolume, out _aiMassPerVolumeText, out _aiMassPerVolumeUnits);
            VaporPressureAtC = productInfo.VaporPressureAtC.HasValue ? productInfo.VaporPressureAtC.ToString() : String.Empty;
            VaporPressureCitation = productInfo.VaporPressureCitation;
        }

        #endregion

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string ACTION_OF_PESTICIDE = "ActionOfPesticide";
        public const string FORMULATION = "Formulation";
        public const string PACKAGE = "Package";
        public const string PACKAGE_WEIGHT = "PackageWeight";
        public const string PACKAGE_VOLUME = "PackageVolume";
        public const string VAPOR_PRESSURE = "VaporPressure";
        public const string PERCENTAGE_AI_BY_WEIGHT = "PercentageAiByWeight";
        public const string AI_MASS_PER_VOLUME = "AiMassPerVolume";
        public const string VAPOR_PRESSURE_AT_C = "VaporPressureAtC";
        public const string VAPOR_PRESSURE_CITATION = "VaporPressureCitation";

        // Not properties of MixingInfo, but properties for this model
        public const string PACKAGE_WEIGHT_UNITS = "PackageWeightUnits";
        public const string PACKAGE_VOLUME_UNITS = "PackageVolumeUnits";
        public const string AI_MASS_PER_VOLUME_UNITS = "AiMassPerVolumeUnits";

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
                RemoveError(ACTION_OF_PESTICIDE, Properties.Resources.ProductInfo_Invalid_Action_of_Pesticide);
                return true;
            }

            AddError(ACTION_OF_PESTICIDE, Properties.Resources.ProductInfo_Invalid_Action_of_Pesticide, false);
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
                RemoveError(FORMULATION, Properties.Resources.ProductInfo_Invalid_Formulation);
                return true;
            }
            
            AddError(FORMULATION, Properties.Resources.ProductInfo_Invalid_Formulation, false);
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
                RemoveError(PACKAGE, Properties.Resources.ProductInfo_Invalid_Package);
                return true;
            }

            AddError(PACKAGE, Properties.Resources.ProductInfo_Invalid_Package, false);
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
                                PACKAGE_WEIGHT, Properties.Resources.ProductInfo_Invalid_Package_Weight,
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
                                  PACKAGE_VOLUME, Properties.Resources.ProductInfo_Invalid_Package_Volume,
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
                                  VAPOR_PRESSURE, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure,
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
                                  PERCENTAGE_AI_BY_WEIGHT, Properties.Resources.ProductInfo_Invalid_Percentage_AI_by_Weight,
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
                                         AI_MASS_PER_VOLUME, Properties.Resources.ProductInfo_Invalid_AI_Mass_per_Volume,
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
                                  VAPOR_PRESSURE_AT_C, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure_at_C,
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
        private bool ValidateVaporPressureCitation(string value)
        {
            return true;
        }

        #endregion

        #endregion
    }
}

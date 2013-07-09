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
                if (_productInfo.ActionOfPesticide != value)
                {
                    ValidateActionOfPesticide(value);
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
                    ValidateFormulation(value);
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
                    ValidatePackage(value);
                    _productInfo.Package = value;
                }
            }
        }

        public Mass PackageWeight
        {
            get { return _productInfo.PackageWeight; }
            set
            {
                if (_productInfo.PackageWeight != value)
                {
                    ValidatePackageWeight(value);
                    _productInfo.PackageWeight = value;
                }
            }
        }

        public Volume PackageVolume
        {
            get { return _productInfo.PackageVolume; }
            set
            {
                if (_productInfo.PackageVolume != value)
                {
                    ValidatePackageVolume(value);
                    _productInfo.PackageVolume = value;
                }
            }
        }

        public double? VaporPressure
        {
            get { return _productInfo.VaporPressure; }
            set
            {
                if (_productInfo.VaporPressure != value)
                {
                    ValidateVaporPressure(value);
                    _productInfo.VaporPressure = value;
                }
            }
        }

        public double? PercentageAiByWeight
        {
            get { return _productInfo.PercentageAiByWeight; }
            set
            {
                if (_productInfo.PercentageAiByWeight != value)
                {
                    ValidatePercentageAiByWeight(value);
                    _productInfo.PercentageAiByWeight = value;
                }
            }
        }

        public MassPerVolume AiMassPerVolume
        {
            get { return _productInfo.AiMassPerVolume; }
            set
            {
                if (_productInfo.AiMassPerVolume != value)
                {
                    ValidateAiMassPerVolume(value);
                    _productInfo.AiMassPerVolume = value;
                }
            }
        }

        public double? VaporPressureAtC
        {
            get { return _productInfo.VaporPressureAtC; }
            set
            {
                if (_productInfo.VaporPressureAtC != value)
                {
                    ValidateVaporPressureAtC(value);
                    _productInfo.VaporPressureAtC = value;
                }
            }
        }

        public string VaporPressureCitation
        {
            get { return _productInfo.VaporPressureCitation; }
            set
            {
                if (_productInfo.VaporPressureCitation != value)
                {
                    ValidateVaporPressureCitation(value);
                    _productInfo.VaporPressureCitation = value;
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
            PackageWeight = productInfo.PackageWeight;
            PackageVolume = productInfo.PackageVolume;
            VaporPressure = productInfo.VaporPressure;
            PercentageAiByWeight = productInfo.PercentageAiByWeight;
            AiMassPerVolume = productInfo.AiMassPerVolume;
            VaporPressureAtC = productInfo.VaporPressureAtC;
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
            bool isValid = true;
            if (ValidPesticides.Contains(value))
            {
                RemoveError(ACTION_OF_PESTICIDE, Properties.Resources.ProductInfo_Invalid_Action_of_Pesticide);
            }
            else
            {
                AddError(ACTION_OF_PESTICIDE, Properties.Resources.ProductInfo_Invalid_Action_of_Pesticide, false);
                isValid = false;
            }

            return isValid;
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
            bool isValid = true;
            if (ValidFormulations.Contains(value))
            {
                RemoveError(FORMULATION, Properties.Resources.ProductInfo_Invalid_Formulation);
            }
            else
            {
                AddError(FORMULATION, Properties.Resources.ProductInfo_Invalid_Formulation, false);
                isValid = false;
            }

            return isValid;
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
            bool isValid = true;
            if (ValidPackages.Contains(value))
            {
                RemoveError(PACKAGE, Properties.Resources.ProductInfo_Invalid_Package);
            }
            else
            {
                AddError(PACKAGE, Properties.Resources.ProductInfo_Invalid_Package, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PackageWeight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PackageWeight</c>.</returns>
        private bool ValidatePackageWeight(Mass value)
        {
            bool isValid = true;
            if (!value.HasValue || value.OriginalValue > 0)
                RemoveError(PACKAGE_WEIGHT, Properties.Resources.ProductInfo_Invalid_Package_Weight);
            else
            {
                AddError(PACKAGE_WEIGHT, Properties.Resources.ProductInfo_Invalid_Package_Weight, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PackageVolume</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PackageVolume</c>.</returns>
        private bool ValidatePackageVolume(Volume value)
        {
            bool isValid = true;
            if (!value.HasValue || value.OriginalValue > 0)
                RemoveError(PACKAGE_VOLUME, Properties.Resources.ProductInfo_Invalid_Package_Volume);
            else
            {
                AddError(PACKAGE_VOLUME, Properties.Resources.ProductInfo_Invalid_Package_Volume, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VaporPressure</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VaporPressure</c>.</returns>
        private bool ValidateVaporPressure(double? value)
        {
            bool isValid = true;
            if (!value.HasValue || value > 0)
                RemoveError(VAPOR_PRESSURE, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure);
            else
            {
                AddError(VAPOR_PRESSURE, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PercentageAiByWeight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PercentageAiByWeight</c>.</returns>
        private bool ValidatePercentageAiByWeight(double? value)
        {
            bool isValid = true;
            if (!value.HasValue || value > 0)
                RemoveError(PERCENTAGE_AI_BY_WEIGHT, Properties.Resources.ProductInfo_Invalid_Percentage_AI_by_Weight);
            else
            {
                AddError(PERCENTAGE_AI_BY_WEIGHT, Properties.Resources.ProductInfo_Invalid_Percentage_AI_by_Weight, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>AiMassPerVolume</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>AiMassPerVolume</c>.</returns>
        private bool ValidateAiMassPerVolume(MassPerVolume value)
        {
            bool isValid = true;
            if (!value.HasValue || value.OriginalValue > 0)
                RemoveError(AI_MASS_PER_VOLUME, Properties.Resources.ProductInfo_Invalid_AI_Mass_per_Volume);
            else
            {
                AddError(AI_MASS_PER_VOLUME, Properties.Resources.ProductInfo_Invalid_AI_Mass_per_Volume, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VaporPressureAtC</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VaporPressureAtC</c>.</returns>
        private bool ValidateVaporPressureAtC(double? value)
        {
            bool isValid = true;
            if (!value.HasValue || value > 0)
                RemoveError(VAPOR_PRESSURE_AT_C, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure_at_C);
            else
            {
                AddError(VAPOR_PRESSURE_AT_C, Properties.Resources.ProductInfo_Invalid_Vapor_Pressure_at_C, false);
                isValid = false;
            }

            return isValid;
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

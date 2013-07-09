using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using AHED.Types;

namespace AHED.Model
{
    /// <summary>
    /// Wraps <c>MixingInfo</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class MixingInfoModel : BaseModel
    {
        /// <summary>
        /// The <c>MixingInfo</c> being wrapped by this model.
        /// </summary>
        private readonly MixingInfo _mixingInfo;

        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidEquipmentLoadeds = StaticValues.GroupOptions(StaticValues.Groups.MixingEquipmentLoaded);

        public readonly List<StaticItem> ValidEngineeringControls = StaticValues.GroupOptions(StaticValues.Groups.MixLoadEngControls);

        public readonly List<StaticItem> ValidReportings = StaticValues.GroupOptions(StaticValues.Groups.Reporting);

        public readonly List<StaticItem> ValidSetupEquipments = StaticValues.GroupOptions(StaticValues.Groups.MixingSetupEquipment);

        public readonly List<StaticItem> ValidDiluents = StaticValues.GroupOptions(StaticValues.Groups.Diluent);

        #endregion Valid Options for StaticItems

        #region Properties

        public StaticItem EquipmentLoaded
        {
            get { return _mixingInfo.EquipmentLoaded; }
            set
            {
                if (_mixingInfo.EquipmentLoaded != value)
                {
                    if (ValidateEquipmentLoaded(value))
                        _mixingInfo.EquipmentLoaded = value;
                }
            }
        }

        public StaticItem EngineeringControls
        {
            get { return _mixingInfo.EngineeringControls; }
            set
            {
                if (_mixingInfo.EngineeringControls != value)
                {
                    if (ValidateEngineeringControls(value))
                        _mixingInfo.EngineeringControls = value;
                }
            }
        }

        public StaticItem Cleanup
        {
            get { return _mixingInfo.Cleanup; }
            set
            {
                if (_mixingInfo.Cleanup != value)
                {
                    if (ValidateCleanup(value))
                        _mixingInfo.Cleanup = value;
                }
            }
        }

        public StaticItem Repairs
        {
            get { return _mixingInfo.Repairs; }
            set
            {
                if (_mixingInfo.Repairs != value)
                {
                    if (ValidateRepairs(value))
                        _mixingInfo.Repairs = value;
                }
            }
        }

        public string IncidentalExposure
        {
            get { return _mixingInfo.IncidentalExposure; }
            set
            {
                if (_mixingInfo.IncidentalExposure != value)
                {
                    if (ValidateIncidentalExposure(value))
                        _mixingInfo.IncidentalExposure = value;
                }
            }
        }

        public string EngineeringControlsMakeModel
        {
            get { return _mixingInfo.EngineeringControlsMakeModel; }
            set
            {
                if (_mixingInfo.EngineeringControlsMakeModel != value)
                {
                    if (ValidateEngineeringControlsMakeModel(value))
                        _mixingInfo.EngineeringControlsMakeModel = value;
                }
            }
        }

        public string ProcedureAndEquipment
        {
            get { return _mixingInfo.ProcedureAndEquipment; }
            set
            {
                if (_mixingInfo.ProcedureAndEquipment != value)
                {
                    if (ValidateProcedureAndEquipment(value))
                        _mixingInfo.ProcedureAndEquipment = value;
                }
            }
        }

        public StaticItem SetupEquipment
        {
            get { return _mixingInfo.SetupEquipment; }
            set
            {
                if (_mixingInfo.SetupEquipment != value)
                {
                    if (ValidateSetupEquipment(value))
                        _mixingInfo.SetupEquipment = value;
                }
            }
        }

        public StaticItem Diluent
        {
            get { return _mixingInfo.Diluent; }
            set
            {
                if (_mixingInfo.Diluent != value)
                {
                    if (ValidateDiluent(value))
                        _mixingInfo.Diluent = value;
                }
            }
        }

        public string Additives
        {
            get { return _mixingInfo.Additives; }
            set
            {
                if (_mixingInfo.Additives != value)
                {
                    if (ValidateAdditives(value))
                        _mixingInfo.Additives = value;
                }
            }
        }

        private Volume.Units _premixTankCapacityUnits;
        public Volume.Units PremixTankCapacityUnits
        {
            get { return _premixTankCapacityUnits; }
            set
            {
                if (value != _premixTankCapacityUnits)
                {
                    _premixTankCapacityUnits = value;
                    _premixTankCapacityText =
                        (_mixingInfo.PremixTankCapacity != null)
                            ? Volume.Convert(_mixingInfo.PremixTankCapacity, _premixTankCapacityUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _premixTankCapacityText;
        public string PremixTankCapacity
        {
            get { return _premixTankCapacityText; }
            set
            {
                if (value != _premixTankCapacityText)
                {
                    Volume capacity;
                    if (ValidatePremixTankCapacity(value, out capacity))
                    {
                        _mixingInfo.PremixTankCapacity = capacity;
                        _premixTankCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _premixTankCapacityUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Volume.Units _sprayerTankCapacityUnits;
        public Volume.Units SprayerTankCapacityUnits
        {
            get { return _sprayerTankCapacityUnits; }
            set
            {
                if (value != _sprayerTankCapacityUnits)
                {
                    _sprayerTankCapacityUnits = value;
                    _sprayerTankCapacityText =
                        (_mixingInfo.SprayerTankCapacity != null)
                            ? Volume.Convert(_mixingInfo.SprayerTankCapacity, _sprayerTankCapacityUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _sprayerTankCapacityText;
        public string SprayerTankCapacity
        {
            get { return _sprayerTankCapacityText; }
            set
            {
                if (value != _sprayerTankCapacityText)
                {
                    Volume capacity;
                    if (ValidateSprayerTankCapacity(value, out capacity))
                    {
                        _mixingInfo.SprayerTankCapacity = capacity;
                        _sprayerTankCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _sprayerTankCapacityUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Volume.Units _hopperCapacityUnits;
        public Volume.Units HopperCapacityUnits
        {
            get { return _hopperCapacityUnits; }
            set
            {
                if (value != _hopperCapacityUnits)
                {
                    _hopperCapacityUnits = value;
                    _hopperCapacityText =
                        (_mixingInfo.HopperCapacity != null)
                            ? Volume.Convert(_mixingInfo.HopperCapacity, _hopperCapacityUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _hopperCapacityText;
        public string HopperCapacity
        {
            get { return _hopperCapacityText; }
            set
            {
                if (value != _hopperCapacityText)
                {
                    Volume capacity;
                    if (ValidateHopperCapacity(value, out capacity))
                    {
                        _mixingInfo.HopperCapacity = capacity;
                        _hopperCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _hopperCapacityUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private string _totalLoadsMixedText;
        public string TotalLoadsMixed
        {
            get { return _totalLoadsMixedText; }
            set
            {
                if (value != _totalLoadsMixedText)
                {
                    double? totalLoadsMixed;
                    if (!ValidateTotalLoadsMixed(value, out totalLoadsMixed))
                    {
                        _totalLoadsMixedText = value;
                    }
                    else
                    {
                        _mixingInfo.TotalLoadsMixed = totalLoadsMixed;
                        _totalLoadsMixedText = (totalLoadsMixed != null) ? totalLoadsMixed.ToString() : String.Empty;
                    }
                }
            }
        }

        private Mass.Units _totalAiMixedUnits;
        public Mass.Units TotalAiMixedUnits
        {
            get { return _totalAiMixedUnits; }
            set
            {
                if (value != _totalAiMixedUnits)
                {
                    _totalAiMixedUnits = value;
                    _totalAiMixedText =
                        (_mixingInfo.TotalAiMixed != null)
                            ? Mass.Convert(_mixingInfo.TotalAiMixed, _totalAiMixedUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _totalAiMixedText;
        public string TotalAiMixed
        {
            get { return _totalAiMixedText; }
            set
            {
                if (value != _totalAiMixedText)
                {
                    Mass totalAiMixed;
                    if (!ValidateTotalAiMixed(value, out totalAiMixed))
                    {
                        _totalAiMixedText = value;
                    }
                    else
                    {
                        _mixingInfo.TotalAiMixed = totalAiMixed;
                        _totalAiMixedText =
                            (totalAiMixed != null)
                                ? Mass.Convert(totalAiMixed, _totalAiMixedUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Volume.Units _finalSprayVolumeMixedUnits;
        public Volume.Units FinalSprayVolumeMixedUnits
        {
            get { return _finalSprayVolumeMixedUnits; }
            set
            {
                if (value != _finalSprayVolumeMixedUnits)
                {
                    _finalSprayVolumeMixedUnits = value;
                    _finalSprayVolumeMixedText =
                        (_mixingInfo.FinalSprayVolumeMixed != null)
                            ? Volume.Convert(_mixingInfo.FinalSprayVolumeMixed, _finalSprayVolumeMixedUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _finalSprayVolumeMixedText;
        public string FinalSprayVolumeMixed
        {
            get { return _finalSprayVolumeMixedText; }
            set
            {
                if (value != _finalSprayVolumeMixedText)
                {
                    Volume capacity;
                    if (!ValidateFinalSprayVolumeMixed(value, out capacity))
                    {
                        _finalSprayVolumeMixedText = value;
                    }
                    else
                    {
                        _mixingInfo.FinalSprayVolumeMixed = capacity;
                        _finalSprayVolumeMixedText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _finalSprayVolumeMixedUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private string _humidityMaxText;
        public string HumidityMax
        {
            get { return _humidityMaxText; }
            set
            {
                if (value != _humidityMaxText)
                {
                    double? humidity;
                    if (!ValidateHumidityMax(value, out humidity))
                    {
                        _humidityMaxText = value;
                    }
                    else
                    {
                        _humidityMaxText = (humidity != null) ? humidity.ToString() : String.Empty;
                        _mixingInfo.HumidityMax = humidity;
                    }
                }
            }
        }

        private string _humidityMinText;
        public string HumidityMin
        {
            get { return _humidityMinText; }
            set
            {
                if (value != _humidityMinText)
                {
                    double? humidity;
                    if (!ValidateHumidityMin(value, out humidity))
                    {
                        _humidityMinText = value;
                    }
                    else
                    {
                        _mixingInfo.HumidityMin = humidity;
                        _humidityMinText = (humidity != null) ? humidity.ToString() : String.Empty;
                    }
                }
            }
        }

        private string _humidityText;
        public string Humidity
        {
            get { return _humidityText; }
            set
            {
                if (value != _humidityText)
                {
                    double? humidity;
                    if (!ValidateHumidity(value, out humidity))
                    {
                        _humidityText = value;
                    }
                    else
                    {
                        _mixingInfo.Humidity = humidity;
                        _humidityText = (humidity != null) ? humidity.ToString() : String.Empty;
                    }
                }
            }
        }

        private Temperature.Units _temperatureMaxUnits;
        public Temperature.Units TemperatureMaxUnits
        {
            get { return _temperatureMaxUnits; }
            set
            {
                if (value != _temperatureMaxUnits)
                {
                    _temperatureMaxUnits = value;
                    _temperatureMaxText =
                        (_mixingInfo.TemperatureMax != null)
                            ? Types.Temperature.Convert(_mixingInfo.TemperatureMax, _temperatureMaxUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _temperatureMaxText;
        public string TemperatureMax
        {
            get { return _temperatureMaxText; }
            set
            {
                if (value != _temperatureMaxText)
                {
                    Temperature temperature;
                    if (!ValidateTemperatureMax(value, out temperature))
                    {
                        _temperatureMaxText = value;
                    }
                    else
                    {
                        _mixingInfo.TemperatureMax = temperature;
                        _temperatureMaxText =
                            (temperature != null)
                                ? Types.Temperature.Convert(temperature, _temperatureMaxUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Temperature.Units _temperatureMinUnits;
        public Temperature.Units TemperatureMinUnits
        {
            get { return _temperatureMinUnits; }
            set
            {
                if (value != _temperatureMinUnits)
                {
                    _temperatureMinUnits = value;
                    _temperatureMinText =
                        (_mixingInfo.TemperatureMin != null)
                            ? Types.Temperature.Convert(_mixingInfo.TemperatureMin, _temperatureMinUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _temperatureMinText;
        public string TemperatureMin
        {
            get { return _temperatureMinText; }
            set
            {
                if (value != _temperatureMinText)
                {
                    Temperature temperature;
                    if (!ValidateTemperatureMin(value, out temperature))
                    {
                        _temperatureMinText = value;
                    }
                    else
                    {
                        _mixingInfo.TemperatureMin = temperature;
                        _temperatureMinText =
                            (temperature != null)
                                ? Types.Temperature.Convert(temperature, _temperatureMinUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Temperature.Units _temperatureUnits;
        public Temperature.Units TemperatureUnits
        {
            get { return _temperatureUnits; }
            set
            {
                if (value != _temperatureMinUnits)
                {
                    _temperatureUnits = value;
                    _temperatureMinText =
                        (_mixingInfo.Temperature != null)
                            ? Types.Temperature.Convert(_mixingInfo.Temperature, _temperatureUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _temperatureText;
        public string Temperature
        {
            get { return _temperatureText; }
            set
            {
                if (value != _temperatureText)
                {
                    Temperature temperature;
                    if (!ValidateTemperature(value, out temperature))
                    {
                        _temperatureText = value;
                    }
                    else
                    {
                        _mixingInfo.Temperature = temperature;
                        _temperatureText =
                            (temperature != null)
                                ? Types.Temperature.Convert(temperature, _temperatureUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Velocity.Units _windSpeedMaxUnits;
        public Velocity.Units WindSpeedMaxUnits
        {
            get { return _windSpeedMaxUnits; }
            set
            {
                if (value != _windSpeedMaxUnits)
                {
                    _windSpeedMaxUnits = value;
                    _windSpeedMaxText =
                        (_mixingInfo.WindSpeedMax != null)
                            ? Velocity.Convert(_mixingInfo.WindSpeedMax, _windSpeedMaxUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _windSpeedMaxText;
        public string WindSpeedMax
        {
            get { return _windSpeedMaxText; }
            set
            {
                if (value != _windSpeedMaxText)
                {
                    Velocity speed;
                    if (!ValidateWindSpeedMax(value, out speed))
                    {
                        _windSpeedMaxText = value;
                    }
                    else
                    {
                        _mixingInfo.WindSpeedMax = speed;
                        _windSpeedMaxText =
                            (speed != null)
                                ? Velocity.Convert(speed, _windSpeedMaxUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Velocity.Units _windSpeedMinUnits;
        public Velocity.Units WindSpeedMinUnits
        {
            get { return _windSpeedMinUnits; }
            set
            {
                if (value != _windSpeedMinUnits)
                {
                    _windSpeedMinUnits = value;
                    _windSpeedMinText =
                        (_mixingInfo.WindSpeedMin != null)
                            ? Velocity.Convert(_mixingInfo.WindSpeedMin, _windSpeedMinUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _windSpeedMinText;
        public string WindSpeedMin
        {
            get { return _windSpeedMinText; }
            set
            {
                if (value != _windSpeedMinText)
                {
                    Velocity speed;
                    if (!ValidateWindSpeedMin(value, out speed))
                    {
                        _windSpeedMinText = value;
                    }
                    else
                    {
                        _mixingInfo.WindSpeedMin = speed;
                        _windSpeedMinText =
                            (speed != null)
                                ? Velocity.Convert(speed, _windSpeedMinUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        private Velocity.Units _windSpeedUnits;
        public Velocity.Units WindSpeedUnits
        {
            get { return _windSpeedUnits; }
            set
            {
                if (value != _windSpeedUnits)
                {
                    _windSpeedUnits = value;
                    _windSpeedText =
                        (_mixingInfo.WindSpeedMin != null)
                            ? Velocity.Convert(_mixingInfo.WindSpeed, _windSpeedUnits).ToString()
                            : String.Empty;
                }
            }
        }

        private string _windSpeedText;
        public string WindSpeed
        {
            get { return _windSpeedText; }
            set
            {
                if (value != _windSpeedText)
                {
                    Velocity speed;
                    if (!ValidateWindSpeed(value, out speed))
                    {
                        _windSpeedText = value;
                    }
                    else
                    {
                        _mixingInfo.WindSpeedMin = speed;
                        _windSpeedText =
                            (speed != null)
                                ? Velocity.Convert(speed, _windSpeedUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        #endregion

        #region Constructor

        MixingInfoModel(MixingInfo mixingInfo)
        {
            _mixingInfo = mixingInfo;

            // Now set all Model properties, and trigger all validations
            EquipmentLoaded = mixingInfo.EquipmentLoaded;
            EngineeringControls = mixingInfo.EngineeringControls;
            Cleanup = mixingInfo.Cleanup;
            Repairs = mixingInfo.Repairs;
            IncidentalExposure = mixingInfo.IncidentalExposure;
            EngineeringControlsMakeModel = mixingInfo.EngineeringControlsMakeModel;
            ProcedureAndEquipment = mixingInfo.ProcedureAndEquipment;
            SetupEquipment = mixingInfo.SetupEquipment;
            Diluent = mixingInfo.Diluent;
            Additives = mixingInfo.Additives;
            VolumeTextAndUnits(mixingInfo.PremixTankCapacity, out _premixTankCapacityText, out _premixTankCapacityUnits);
            VolumeTextAndUnits(mixingInfo.SprayerTankCapacity, out _sprayerTankCapacityText, out _sprayerTankCapacityUnits);
            VolumeTextAndUnits(mixingInfo.HopperCapacity, out _hopperCapacityText, out _hopperCapacityUnits);
            TotalLoadsMixed = mixingInfo.TotalLoadsMixed.HasValue ? mixingInfo.TotalLoadsMixed.ToString() : String.Empty;
            MassTextAndUnits(mixingInfo.TotalAiMixed, out _totalAiMixedText, out _totalAiMixedUnits);
            VolumeTextAndUnits(mixingInfo.FinalSprayVolumeMixed, out _finalSprayVolumeMixedText, out _finalSprayVolumeMixedUnits);
            HumidityMax = mixingInfo.HumidityMax.HasValue ? mixingInfo.HumidityMax.ToString() : String.Empty;
            HumidityMin = mixingInfo.HumidityMin.HasValue ? mixingInfo.HumidityMin.ToString() : String.Empty;
            Humidity = mixingInfo.Humidity.HasValue ? mixingInfo.Humidity.ToString() : String.Empty;
            TemperatureTextAndUnits(mixingInfo.TemperatureMax, out _temperatureMaxText, out _temperatureMaxUnits);
            TemperatureTextAndUnits(mixingInfo.TemperatureMin, out _temperatureMinText, out _temperatureMinUnits);
            TemperatureTextAndUnits(mixingInfo.Temperature, out _temperatureText, out _temperatureUnits);
            VelocityMphOrMpsTextAndUnits(mixingInfo.WindSpeedMax, out _windSpeedMaxText, out _windSpeedMaxUnits);
            VelocityMphOrMpsTextAndUnits(mixingInfo.WindSpeedMin, out _windSpeedMinText, out _windSpeedMinUnits);
            VelocityMphOrMpsTextAndUnits(mixingInfo.WindSpeed, out _windSpeedText, out _windSpeedUnits);
        }

        #endregion

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string EQUIPMENT_LOADED = "EquipmentLoaded";
        public const string ENGINEERING_CONTROLS = "EngineeringControls";
        public const string CLEANUP = "Cleanup";
        public const string REPAIRS = "Repairs";
        public const string INCIDENTAL_EXPOSURE = "IncidentalExposure";
        public const string ENG_CONTROLS_MAKE_MODEL = "EngineeringControlsMakeModel";
        public const string PROC_AND_EQUIPMENT = "ProcedureAndEquipment";
        public const string SETUP_EQUIPMENT = "SetupEquipment";
        public const string DILUENT = "Diluent";
        public const string ADDITIVES = "Additives";
        public const string PREMIX_TANK_CAPACITY = "PremixTankCapacity";
        public const string SPRAYER_TANK_CAPACITY = "SprayerTankCapacity";
        public const string HOPPER_CAPACITY = "HopperCapacity";
        public const string TOTAL_LOADS_MIXED = "TotalLoadsMixed";
        public const string TOTAL_AI_MIXED = "TotalAiMixed";
        public const string FINAL_SPRAY_VOLUME_MIXED = "FinalSprayVolumeMixed";
        public const string HUMIDITY_MAX = "HumidityMax";
        public const string HUMIDITY_MIN = "HumidityMin";
        public const string HUMIDITY = "Humidity";
        public const string TEMPERATURE_MAX = "TemperatureMax";
        public const string TEMPERATURE_MIN = "TemperatureMin";
        public const string TEMPERATURE = "Temperature";
        public const string WIND_SPEED_MAX = "WindSpeedMax";
        public const string WIND_SPEED_MIN = "WindSpeedMin";
        public const string WIND_SPEED = "WindSpeed";

        // Not properties of MixingInfo, but properties for this model
        public const string PREMIX_TANK_CAPACITY_UNITS = "PremixTankCapacityUnits";
        public const string SPRAYER_TANK_CAPACITY_UNITS = "SprayerTankCapacityUnits";
        public const string HOPPER_CAPACITY_UNITS = "HopperCapacityUnits";
        public const string TOTAL_AI_MIXED_UNITS = "TotalAiMixedUnits";
        public const string FINAL_SPRAY_VOLUME_MIXED_UNITS = "FinalSprayVolumeMixedUnits";
        public const string TEMPERATURE_MAX_UNITS = "TemperatureMaxUnits";
        public const string TEMPERATURE_MIN_UNITS = "TemperatureMinUnits";
        public const string TEMPERATURE_UNITS = "TemperatureUnits";
        public const string WIND_SPEED_MAX_UNITS = "WindSpeedMaxUnits";
        public const string WIND_SPEED_MIN_UNITS = "WindSpeedMinUnits";
        public const string WIND_SPEED_UNITS = "WindSpeedUnits";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>MixingEquipmentLoaded</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[MixingEquipmentLoaded] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>MixingEquipmentLoaded</c>.</returns>
        private bool ValidateEquipmentLoaded(StaticItem value)
        {
            bool isValid = true;
            if (ValidEquipmentLoadeds.Contains(value))
            {
                RemoveError(EQUIPMENT_LOADED, Properties.Resources.MixingInfo_Invalid_Equipment_Loaded);
            }
            else
            {
                AddError(EQUIPMENT_LOADED, Properties.Resources.MixingInfo_Invalid_Equipment_Loaded, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringControls</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[MixLoadEngControls] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringControls</c>.</returns>
        private bool ValidateEngineeringControls(StaticItem value)
        {
            bool isValid = true;
            if (ValidEngineeringControls.Contains(value))
            {
                RemoveError(ENGINEERING_CONTROLS, Properties.Resources.MixingInfo_Invalid_MixLoad_Eng_Controls);
            }
            else
            {
                AddError(ENGINEERING_CONTROLS, Properties.Resources.MixingInfo_Invalid_MixLoad_Eng_Controls, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Cleanup</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Reporting] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Cleanup</c>.</returns>
        private bool ValidateCleanup(StaticItem value)
        {
            bool isValid = true;
            if (ValidReportings.Contains(value))
            {
                RemoveError(CLEANUP, Properties.Resources.MixingInfo_Invalid_Cleanup);
            }
            else
            {
                AddError(CLEANUP, Properties.Resources.MixingInfo_Invalid_Cleanup, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Repairs</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Reporting] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Repairs</c>.</returns>
        private bool ValidateRepairs(StaticItem value)
        {
            bool isValid = true;
            if (ValidReportings.Contains(value))
            {
                RemoveError(REPAIRS, Properties.Resources.MixingInfo_Invalid_Repairs);
            }
            else
            {
                AddError(REPAIRS, Properties.Resources.MixingInfo_Invalid_Repairs, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>IncidentalExposure</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>IncidentalExposure</c>.</returns>
        private bool ValidateIncidentalExposure(string value)
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringControlsMakeModel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringControlsMakeModel</c>.</returns>
        private bool ValidateEngineeringControlsMakeModel(string value)
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ProcedureAndEquipment</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ProcedureAndEquipment</c>.</returns>
        private bool ValidateProcedureAndEquipment(string value)
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>SetupEquipment</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[MixingSetupEquipment] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>SetupEquipment</c>.</returns>
        private bool ValidateSetupEquipment(StaticItem value)
        {
            bool isValid = true;
            if (ValidSetupEquipments.Contains(value))
            {
                RemoveError(SETUP_EQUIPMENT, Properties.Resources.MixingInfo_Invalid_Setup_Equipment);
            }
            else
            {
                AddError(SETUP_EQUIPMENT, Properties.Resources.MixingInfo_Invalid_Setup_Equipment, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Diluent</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Diluent] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Diluent</c>.</returns>
        private bool ValidateDiluent(StaticItem value)
        {
            bool isValid = true;
            if (ValidDiluents.Contains(value))
            {
                RemoveError(DILUENT, Properties.Resources.MixingInfo_Invalid_Diluent);
            }
            else
            {
                AddError(DILUENT, Properties.Resources.MixingInfo_Invalid_Diluent, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Additives</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Additives</c>.</returns>
        private bool ValidateAdditives(string value)
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>PremixTankCapacity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a capacity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>PremixTankCapacity</c>.</returns>
        private bool ValidatePremixTankCapacity(string str, out Volume value)
        {
            return ValidateVolume(str, _premixTankCapacityUnits,
                                    PREMIX_TANK_CAPACITY, Properties.Resources.MixingInfo_Invalid_PremixTankCapacity,
                                    out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>SprayerTankCapacity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a capacity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>SprayerTankCapacity</c>.</returns>
        private bool ValidateSprayerTankCapacity(string str, out Volume value)
        {
            return ValidateVolume(str, _sprayerTankCapacityUnits,
                                    SPRAYER_TANK_CAPACITY, Properties.Resources.MixingInfo_Invalid_SprayerTankCapacity,
                                    out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>HopperCapacity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a capacity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>HopperCapacity</c>.</returns>
        private bool ValidateHopperCapacity(string str, out Volume value)
        {
            return ValidateVolume(str, _hopperCapacityUnits,
                                    HOPPER_CAPACITY, Properties.Resources.MixingInfo_Invalid_HopperCapacity,
                                    out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalLoadsMixed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalLoadsMixed</c>.</returns>
        private bool ValidateTotalLoadsMixed(string str, out double? value)
        {
            return ValidateDouble(str, PositiveOnly,
                                  TOTAL_LOADS_MIXED, Properties.Resources.MixingInfo_Invalid_Total_Loads_Mixed,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalAIMixed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a mass.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalAIMixed</c>.</returns>
        private bool ValidateTotalAiMixed(string str, out Mass value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(TOTAL_AI_MIXED, Properties.Resources.MixingInfo_Invalid_TotalAiMixed);
                return true;
            }

            double mass;
            if (!Double.TryParse(str, out mass))
            {
                value = null;
                AddError(TOTAL_AI_MIXED, Properties.Resources.MixingInfo_Invalid_TotalAiMixed, false);
                return false;
            }

            if (mass <= 0)
            {
                value = null;
                AddError(TOTAL_AI_MIXED, Properties.Resources.MixingInfo_Invalid_TotalAiMixed, false);
                return false;
            }

            RemoveError(TOTAL_AI_MIXED, Properties.Resources.MixingInfo_Invalid_TotalAiMixed);
            value = new Mass(mass, _totalAiMixedUnits);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>FinalSprayVolumeMixed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a volume.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>FinalSprayVolumeMixed</c>.</returns>
        private bool ValidateFinalSprayVolumeMixed(string str, out Volume value)
        {
            if (String.IsNullOrEmpty(str))
            {
                value = null;
                RemoveError(FINAL_SPRAY_VOLUME_MIXED, Properties.Resources.MixingInfo_Invalid_FinalSprayVolumeMixed);
                return true;
            }

            double capacity = 0;
            if (!Double.TryParse(str, out capacity))
            {
                value = null;
                AddError(FINAL_SPRAY_VOLUME_MIXED, Properties.Resources.MixingInfo_Invalid_FinalSprayVolumeMixed, false);
                return false;
            }

            if (capacity <= 0)
            {
                value = null;
                AddError(FINAL_SPRAY_VOLUME_MIXED, Properties.Resources.MixingInfo_Invalid_FinalSprayVolumeMixed, false);
                return false;
            }

            RemoveError(FINAL_SPRAY_VOLUME_MIXED, Properties.Resources.MixingInfo_Invalid_FinalSprayVolumeMixed);
            value = new Volume(capacity, _finalSprayVolumeMixedUnits);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>HumidityMax</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value from 0 to 100.
        /// Also checks that HumidityMax &gt;= HumidityMin.
        /// </remarks>
        /// <param name="str">The raw string to validate as a humidity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>HumidityMax</c>.</returns>
        private bool ValidateHumidityMax(string str, out double? value)
        {
            bool isValid = ValidateDouble(str, PositiveOnly,
                                          HUMIDITY_MAX, Properties.Resources.MixingInfo_Invalid_HumidityMax,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HUMIDITY_MAX, Properties.Resources.MixingInfo_Invalid_HumidityMax);
            }

            // Check whether there is an issue with the current minimum
            ValidateRange(value, _mixingInfo.HumidityMin, NoUpperBound,
                          HUMIDITY_MAX, Properties.Resources.MixingInfo_Invalid_HumidityMaxMin);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>HumidityMin</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value from 0 to 100.
        /// Also checks that HumidityMin &lt;= HumidityMax.
        /// </remarks>
        /// <param name="str">The raw string to validate as a humidity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>HumidityMin</c>.</returns>
        private bool ValidateHumidityMin(string str, out double? value)
        {
            bool isValid = ValidateDouble(str, PositiveOnly,
                                          HUMIDITY_MIN, Properties.Resources.MixingInfo_Invalid_HumidityMin,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HUMIDITY_MIN, Properties.Resources.MixingInfo_Invalid_HumidityMin);
            }

            // Check whether there is an issue with the current maximum
            ValidateRange(value, NoLowerBound, _mixingInfo.HumidityMax,
                          HUMIDITY_MIN, Properties.Resources.MixingInfo_Invalid_HumidityMinMax);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Humidity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value from 0 to 100.
        /// Also checks that HumidityMin &lt;= Humidity &lt;= HumidityMax.
        /// </remarks>
        /// <param name="str">The raw string to validate as a humidity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Humidity</c>.</returns>
        private bool ValidateHumidity(string str, out double? value)
        {
            bool isValid = ValidateDouble(str, PositiveOnly,
                                          HUMIDITY, Properties.Resources.MixingInfo_Invalid_Humidity,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HUMIDITY, Properties.Resources.MixingInfo_Invalid_Humidity);
            }

            // Check whether there is an issue with the current minimum or maximum
            ValidateRange(value, _mixingInfo.HumidityMin, _mixingInfo.HumidityMax,
                          HUMIDITY, Properties.Resources.MixingInfo_Invalid_HumidityBetween);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TemperatureMax</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between -50 and +130 Fahrenheit.
        /// Also checks that TemperatureMax &gt;= TemperatureMin.
        /// </remarks>
        /// <param name="str">The raw string to validate as a humidity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TemperatureMax</c>.</returns>
        private bool ValidateTemperatureMax(string str, out Temperature value)
        {
            bool isValid = ValidateTemperature(str, _temperatureMaxUnits,
                                               TEMPERATURE_MAX, Properties.Resources.MixingInfo_Invalid_TemperatureMax,
                                               out value);

            // Check whether there is an issue with the current maximum
            ValidateRange(value.OriginalValue, _mixingInfo.TemperatureMin.OriginalValue, NoUpperBound, 
                          TEMPERATURE_MAX, Properties.Resources.MixingInfo_Invalid_TemperatureMaxMin);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TemperatureMin</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between -50 and +130 Fahrenheit.
        /// </remarks>
        /// <param name="str">The raw string to validate as a temperature.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TemperatureMin</c>.</returns>
        private bool ValidateTemperatureMin(string str, out Temperature value)
        {
            bool isValid = ValidateTemperature(str, _temperatureMinUnits,
                                               TEMPERATURE_MIN, Properties.Resources.MixingInfo_Invalid_TemperatureMin,
                                               out value);

            // Check whether there is an issue with the current maximum
            ValidateRange(value.OriginalValue, NoLowerBound, _mixingInfo.TemperatureMax.OriginalValue,
                          TEMPERATURE_MIN, Properties.Resources.MixingInfo_Invalid_HumidityMaxMin);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Temperature</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between -50 and +130 Fahrenheit.
        /// Also checks that TemperatureMin &lt;= Temperature &lt;= TemperatureMax.
        /// </remarks>
        /// <param name="str">The raw string to validate as a humidity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Temperature</c>.</returns>
        private bool ValidateTemperature(string str, out Temperature value)
        {
            bool isValid = ValidateTemperature(str, _temperatureUnits,
                                               TEMPERATURE_MIN, Properties.Resources.MixingInfo_Invalid_TemperatureMin,
                                               out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, _mixingInfo.TemperatureMin.OriginalValue, _mixingInfo.TemperatureMax.OriginalValue,
                          TEMPERATURE_MIN, Properties.Resources.MixingInfo_Invalid_TemperatureBetween);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>WindMax</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between 0 and 100 mph.
        /// Also checks that WindSpeedMax &gt;= WindSpeedMin.
        /// </remarks>
        /// <param name="str">The raw string to validate as a velocity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>WindMax</c>.</returns>
        private bool ValidateWindSpeedMax(string str, out Velocity value)
        {
            bool isValid = ValidateVelocity(str, _windSpeedMaxUnits,
                                            WIND_SPEED_MAX, Properties.Resources.MixingInfo_Invalid_WindSpeedMax,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, _mixingInfo.WindSpeedMin.OriginalValue, NoUpperBound,
                          WIND_SPEED_MAX, Properties.Resources.MixingInfo_Invalid_WindSpeedMaxMin);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>WindMin</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between 0 and 100 mph.
        /// Also checks that WindSpeedMin &lt;= WindSpeedMax.
        /// </remarks>
        /// <param name="str">The raw string to validate as a velocity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>WindMin</c>.</returns>
        private bool ValidateWindSpeedMin(string str, out Velocity value)
        {
            bool isValid = ValidateVelocity(str, _windSpeedMinUnits,
                                            WIND_SPEED_MIN, Properties.Resources.MixingInfo_Invalid_WindSpeedMin,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, NoLowerBound, _mixingInfo.WindSpeedMax.OriginalValue,
                          WIND_SPEED_MIN, Properties.Resources.MixingInfo_Invalid_WindSpeedMinMax);

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>WindSpeed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between 0 and 100 mph.
        /// Also checks that WindSpeedMin &lt;= WindSpeed &lt;= WindSpeedMax.
        /// </remarks>
        /// <param name="str">The raw string to validate as a velocity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>WindSpeed</c>.</returns>
        private bool ValidateWindSpeed(string str, out Velocity value)
        {
            bool isValid = ValidateVelocity(str, _windSpeedUnits,
                                            WIND_SPEED, Properties.Resources.MixingInfo_Invalid_WindSpeed,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, _mixingInfo.WindSpeedMin.OriginalValue, _mixingInfo.WindSpeedMax.OriginalValue,
                          WIND_SPEED, Properties.Resources.MixingInfo_Invalid_WindSpeedBetween);

            return isValid;
        }

        #endregion

        #endregion

    }
}

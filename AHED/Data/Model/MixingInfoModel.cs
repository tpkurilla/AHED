using System;
using System.Collections.Generic;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>MixingInfo</c> for editable viewing such as in DataEntry.
    /// <br/>
    /// NOTE: Changes to Units enumerated values are assumed correct.  All other
    /// error checking *should* be in place.
    /// </summary>
    public class MixingInfoModel : Model<MixingInfo>, IDeepClone<MixingInfoModel>
    {
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
            get { return Value.EquipmentLoaded; }
            set
            {
                if (value != Value.EquipmentLoaded)
                {
                    if (ValidateEquipmentLoaded(value))
                        Value.EquipmentLoaded = value;
                }
            }
        }

        public StaticItem EngineeringControls
        {
            get { return Value.EngineeringControls; }
            set
            {
                if (Value.EngineeringControls != value)
                {
                    if (ValidateEngineeringControls(value))
                        Value.EngineeringControls = value;
                }
            }
        }

        public StaticItem Cleanup
        {
            get { return Value.Cleanup; }
            set
            {
                if (Value.Cleanup != value)
                {
                    if (ValidateCleanup(value))
                        Value.Cleanup = value;
                }
            }
        }

        public StaticItem Repairs
        {
            get { return Value.Repairs; }
            set
            {
                if (Value.Repairs != value)
                {
                    if (ValidateRepairs(value))
                        Value.Repairs = value;
                }
            }
        }

        public string IncidentalExposure
        {
            get { return Value.IncidentalExposure; }
            set
            {
                if (Value.IncidentalExposure != value)
                {
                    if (ValidateIncidentalExposure(value))
                        Value.IncidentalExposure = value;
                }
            }
        }

        public string EngineeringControlsMakeModel
        {
            get { return Value.EngineeringControlsMakeModel; }
            set
            {
                if (Value.EngineeringControlsMakeModel != value)
                {
                    if (ValidateEngineeringControlsMakeModel(value))
                        Value.EngineeringControlsMakeModel = value;
                }
            }
        }

        public string ProcedureAndEquipment
        {
            get { return Value.ProcedureAndEquipment; }
            set
            {
                if (Value.ProcedureAndEquipment != value)
                {
                    if (ValidateProcedureAndEquipment(value))
                        Value.ProcedureAndEquipment = value;
                }
            }
        }

        public StaticItem SetupEquipment
        {
            get { return Value.SetupEquipment; }
            set
            {
                if (Value.SetupEquipment != value)
                {
                    if (ValidateSetupEquipment(value))
                        Value.SetupEquipment = value;
                }
            }
        }

        public StaticItem Diluent
        {
            get { return Value.Diluent; }
            set
            {
                if (Value.Diluent != value)
                {
                    if (ValidateDiluent(value))
                        Value.Diluent = value;
                }
            }
        }

        public string Additives
        {
            get { return Value.Additives; }
            set
            {
                if (Value.Additives != value)
                {
                    if (ValidateAdditives(value))
                        Value.Additives = value;
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
                        (Value.PremixTankCapacity != null)
                            ? Volume.Convert(Value.PremixTankCapacity, _premixTankCapacityUnits).ToString(Culture.Info)
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
                        Value.PremixTankCapacity = capacity;
                        _premixTankCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _premixTankCapacityUnits).ToString(Culture.Info)
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
                        (Value.SprayerTankCapacity != null)
                            ? Volume.Convert(Value.SprayerTankCapacity, _sprayerTankCapacityUnits).ToString(Culture.Info)
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
                        Value.SprayerTankCapacity = capacity;
                        _sprayerTankCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _sprayerTankCapacityUnits).ToString(Culture.Info)
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
                        (Value.HopperCapacity != null)
                            ? Volume.Convert(Value.HopperCapacity, _hopperCapacityUnits).ToString(Culture.Info)
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
                        Value.HopperCapacity = capacity;
                        _hopperCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _hopperCapacityUnits).ToString(Culture.Info)
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
                        Value.TotalLoadsMixed = totalLoadsMixed;
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
                        (Value.TotalAiMixed != null)
                            ? Mass.Convert(Value.TotalAiMixed, _totalAiMixedUnits).ToString(Culture.Info)
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
                        Value.TotalAiMixed = totalAiMixed;
                        _totalAiMixedText =
                            (totalAiMixed != null)
                                ? Mass.Convert(totalAiMixed, _totalAiMixedUnits).ToString(Culture.Info)
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
                        (Value.FinalSprayVolumeMixed != null)
                            ? Volume.Convert(Value.FinalSprayVolumeMixed, _finalSprayVolumeMixedUnits).ToString(Culture.Info)
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
                        Value.FinalSprayVolumeMixed = capacity;
                        _finalSprayVolumeMixedText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _finalSprayVolumeMixedUnits).ToString(Culture.Info)
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
                        Value.HumidityMax = humidity;
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
                        Value.HumidityMin = humidity;
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
                        Value.Humidity = humidity;
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
                        (Value.TemperatureMax != null)
                            ? Types.Temperature.Convert(Value.TemperatureMax, _temperatureMaxUnits).ToString(Culture.Info)
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
                        Value.TemperatureMax = temperature;
                        _temperatureMaxText =
                            (temperature != null)
                                ? Types.Temperature.Convert(temperature, _temperatureMaxUnits).ToString(Culture.Info)
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
                        (Value.TemperatureMin != null)
                            ? Types.Temperature.Convert(Value.TemperatureMin, _temperatureMinUnits).ToString(Culture.Info)
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
                        Value.TemperatureMin = temperature;
                        _temperatureMinText =
                            (temperature != null)
                                ? Types.Temperature.Convert(temperature, _temperatureMinUnits).ToString(Culture.Info)
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
                        (Value.Temperature != null)
                            ? Types.Temperature.Convert(Value.Temperature, _temperatureUnits).ToString(Culture.Info)
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
                        Value.Temperature = temperature;
                        _temperatureText =
                            (temperature != null)
                                ? Types.Temperature.Convert(temperature, _temperatureUnits).ToString(Culture.Info)
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
                        (Value.WindSpeedMax != null)
                            ? Velocity.Convert(Value.WindSpeedMax, _windSpeedMaxUnits).ToString(Culture.Info)
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
                        Value.WindSpeedMax = speed;
                        _windSpeedMaxText =
                            (speed != null)
                                ? Velocity.Convert(speed, _windSpeedMaxUnits).ToString(Culture.Info)
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
                        (Value.WindSpeedMin != null)
                            ? Velocity.Convert(Value.WindSpeedMin, _windSpeedMinUnits).ToString(Culture.Info)
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
                        Value.WindSpeedMin = speed;
                        _windSpeedMinText =
                            (speed != null)
                                ? Velocity.Convert(speed, _windSpeedMinUnits).ToString(Culture.Info)
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
                        (Value.WindSpeedMin != null)
                            ? Velocity.Convert(Value.WindSpeed, _windSpeedUnits).ToString(Culture.Info)
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
                        Value.WindSpeedMin = speed;
                        _windSpeedText =
                            (speed != null)
                                ? Velocity.Convert(speed, _windSpeedUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        #endregion

        #region Creation

        public MixingInfoModel(){}

        public MixingInfoModel(MixingInfo mixingInfo)
            : base(mixingInfo)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public MixingInfoModel(MixingInfoModel model)
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
            EquipmentLoaded = Value.EquipmentLoaded;
            EngineeringControls = Value.EngineeringControls;
            Cleanup = Value.Cleanup;
            Repairs = Value.Repairs;
            IncidentalExposure = Value.IncidentalExposure;
            EngineeringControlsMakeModel = Value.EngineeringControlsMakeModel;
            ProcedureAndEquipment = Value.ProcedureAndEquipment;
            SetupEquipment = Value.SetupEquipment;
            Diluent = Value.Diluent;
            Additives = Value.Additives;
            Volume.TextAndUnits(Value.PremixTankCapacity, out _premixTankCapacityText, out _premixTankCapacityUnits);
            Volume.TextAndUnits(Value.SprayerTankCapacity, out _sprayerTankCapacityText, out _sprayerTankCapacityUnits);
            Volume.TextAndUnits(Value.HopperCapacity, out _hopperCapacityText, out _hopperCapacityUnits);
            TotalLoadsMixed = Value.TotalLoadsMixed.HasValue ? Value.TotalLoadsMixed.ToString() : String.Empty;
            Mass.TextAndUnits(Value.TotalAiMixed, out _totalAiMixedText, out _totalAiMixedUnits);
            Volume.TextAndUnits(Value.FinalSprayVolumeMixed, out _finalSprayVolumeMixedText, out _finalSprayVolumeMixedUnits);
            HumidityMax = Value.HumidityMax.HasValue ? Value.HumidityMax.ToString() : String.Empty;
            HumidityMin = Value.HumidityMin.HasValue ? Value.HumidityMin.ToString() : String.Empty;
            Humidity = Value.Humidity.HasValue ? Value.Humidity.ToString() : String.Empty;
            Types.Temperature.TextAndUnits(Value.TemperatureMax, out _temperatureMaxText, out _temperatureMaxUnits);
            Types.Temperature.TextAndUnits(Value.TemperatureMin, out _temperatureMinText, out _temperatureMinUnits);
            Types.Temperature.TextAndUnits(Value.Temperature, out _temperatureText, out _temperatureUnits);
            Velocity.MphOrMpsTextAndUnits(Value.WindSpeedMax, out _windSpeedMaxText, out _windSpeedMaxUnits);
            Velocity.MphOrMpsTextAndUnits(Value.WindSpeedMin, out _windSpeedMinText, out _windSpeedMinUnits);
            Velocity.MphOrMpsTextAndUnits(Value.WindSpeed, out _windSpeedText, out _windSpeedUnits);
        }

        public static MixingInfoModel Create()
        {
            return new MixingInfoModel(MixingInfo.Create());
        }

        #endregion Creation

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string EquipmentLoadedName = "EquipmentLoaded";
        public const string EngineeringControlsName = "EngineeringControls";
        public const string CleanupName = "Cleanup";
        public const string RepairsName = "Repairs";
        public const string IncidentalExposureName = "IncidentalExposure";
        public const string EngineeringControlsMakeModelName = "EngineeringControlsMakeModel";
        public const string ProcedureAndEquipmentName = "ProcedureAndEquipment";
        public const string SetupEquipmentName = "SetupEquipment";
        public const string DiluentName = "Diluent";
        public const string AdditivesName = "Additives";
        public const string PremixTankCapacityName = "PremixTankCapacity";
        public const string SprayerTankCapacityName = "SprayerTankCapacity";
        public const string HopperCapacityName = "HopperCapacity";
        public const string TotalLoadsMixedName = "TotalLoadsMixed";
        public const string TotalAiMixedName = "TotalAiMixed";
        public const string FinalSprayVolumeMixedName = "FinalSprayVolumeMixed";
        public const string HumidityMaxName = "HumidityMax";
        public const string HumidityMinName = "HumidityMin";
        public const string HumidityName = "Humidity";
        public const string TemperatureMaxName = "TemperatureMax";
        public const string TemperatureMinName = "TemperatureMin";
        public const string TemperatureName = "Temperature";
        public const string WindSpeedMaxName = "WindSpeedMax";
        public const string WindSpeedMinName = "WindSpeedMin";
        public const string WindSpeedName = "WindSpeed";

        // Not properties of MixingInfo, but properties for this model
        public const string PremixTankCapacityUnitsName = "PremixTankCapacityUnits";
        public const string SprayerTankCapacityUnitsName = "SprayerTankCapacityUnits";
        public const string HopperCapacityUnitsName = "HopperCapacityUnits";
        public const string TotalAiMixedUnitsName = "TotalAiMixedUnits";
        public const string FinalSprayVolumeMixedUnitsName = "FinalSprayVolumeMixedUnits";
        public const string TemperatureMaxUnitsName = "TemperatureMaxUnits";
        public const string TemperatureMinUnitsName = "TemperatureMinUnits";
        public const string TemperatureUnitsName = "TemperatureUnits";
        public const string WindSpeedMaxUnitsName = "WindSpeedMaxUnits";
        public const string WindSpeedMinUnitsName = "WindSpeedMinUnits";
        public const string WindSpeedUnitsName = "WindSpeedUnits";

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
            if (value == null || ValidEquipmentLoadeds.Contains(value))
            {
                RemoveError(EquipmentLoadedName, Properties.Resources.MixingInfo_Invalid_Equipment_Loaded);
                return true;
            }

            AddError(EquipmentLoadedName, Properties.Resources.MixingInfo_Invalid_Equipment_Loaded, false);
            return false;
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
            if (value == null || ValidEngineeringControls.Contains(value))
            {
                RemoveError(EngineeringControlsName, Properties.Resources.MixingInfo_Invalid_MixLoad_Eng_Controls);
                return true;
            }

            AddError(EngineeringControlsName, Properties.Resources.MixingInfo_Invalid_MixLoad_Eng_Controls, false);
            return false;
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
            if (value == null || ValidReportings.Contains(value))
            {
                RemoveError(CleanupName, Properties.Resources.MixingInfo_Invalid_Cleanup);
                return true;
            }

            AddError(CleanupName, Properties.Resources.MixingInfo_Invalid_Cleanup, false);
            return false;
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
            if (value == null || ValidReportings.Contains(value))
            {
                RemoveError(RepairsName, Properties.Resources.MixingInfo_Invalid_Repairs);
                return true;
            }

            AddError(RepairsName, Properties.Resources.MixingInfo_Invalid_Repairs, false);
            return false;
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
            if (value == null || ValidSetupEquipments.Contains(value))
            {
                RemoveError(SetupEquipmentName, Properties.Resources.MixingInfo_Invalid_Setup_Equipment);
                return true;
            }

            AddError(SetupEquipmentName, Properties.Resources.MixingInfo_Invalid_Setup_Equipment, false);
            return false;
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
            if (value == null || ValidDiluents.Contains(value))
            {
                RemoveError(DiluentName, Properties.Resources.MixingInfo_Invalid_Diluent);
                return true;
            }

            AddError(DiluentName, Properties.Resources.MixingInfo_Invalid_Diluent, false);
            return false;
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
                                    PremixTankCapacityName, Properties.Resources.MixingInfo_Invalid_PremixTankCapacity,
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
                                    SprayerTankCapacityName, Properties.Resources.MixingInfo_Invalid_SprayerTankCapacity,
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
                                    HopperCapacityName, Properties.Resources.MixingInfo_Invalid_HopperCapacity,
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
                                  TotalLoadsMixedName, Properties.Resources.MixingInfo_Invalid_Total_Loads_Mixed,
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
            return ValidateMass(str, _totalAiMixedUnits, TotalAiMixedName,
                                Properties.Resources.MixingInfo_Invalid_TotalAiMixed, out value);
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
            return ValidateVolume(str, _finalSprayVolumeMixedUnits,
                                    FinalSprayVolumeMixedName, Properties.Resources.MixingInfo_Invalid_FinalSprayVolumeMixed,
                                    out value);
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
                                          HumidityMaxName, Properties.Resources.MixingInfo_Invalid_HumidityMax,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HumidityMaxName, Properties.Resources.MixingInfo_Invalid_HumidityMax);
            }

            // Check whether there is an issue with the current minimum
            ValidateRange(value, Value.HumidityMin, NoUpperBound,
                          HumidityMaxName, Properties.Resources.MixingInfo_Invalid_HumidityMaxMin);

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
                                          HumidityMinName, Properties.Resources.MixingInfo_Invalid_HumidityMin,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HumidityMinName, Properties.Resources.MixingInfo_Invalid_HumidityMin);
            }

            // Check whether there is an issue with the current maximum
            ValidateRange(value, NoLowerBound, Value.HumidityMax,
                          HumidityMinName, Properties.Resources.MixingInfo_Invalid_HumidityMinMax);

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
                                          HumidityName, Properties.Resources.MixingInfo_Invalid_Humidity,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HumidityName, Properties.Resources.MixingInfo_Invalid_Humidity);
            }

            // Check whether there is an issue with the current minimum or maximum
            ValidateRange(value, Value.HumidityMin, Value.HumidityMax,
                          HumidityName, Properties.Resources.MixingInfo_Invalid_HumidityBetween);

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
                                               TemperatureMaxName, Properties.Resources.MixingInfo_Invalid_TemperatureMax,
                                               out value);

            // Check whether there is an issue with the current maximum
            ValidateRange(value.Value, Value.TemperatureMin.Value, NoUpperBound, 
                          TemperatureMaxName, Properties.Resources.MixingInfo_Invalid_TemperatureMaxMin);

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
                                               TemperatureMinName, Properties.Resources.MixingInfo_Invalid_TemperatureMin,
                                               out value);

            // Check whether there is an issue with the current maximum
            ValidateRange(value.Value, NoLowerBound, Value.TemperatureMax.Value,
                          TemperatureMinName, Properties.Resources.MixingInfo_Invalid_HumidityMaxMin);

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
                                               TemperatureMinName, Properties.Resources.MixingInfo_Invalid_TemperatureMin,
                                               out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.Value, Value.TemperatureMin.Value, Value.TemperatureMax.Value,
                          TemperatureMinName, Properties.Resources.MixingInfo_Invalid_TemperatureBetween);

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
                                            WindSpeedMaxName, Properties.Resources.MixingInfo_Invalid_WindSpeedMax,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.Value, Value.WindSpeedMin.Value, NoUpperBound,
                          WindSpeedMaxName, Properties.Resources.MixingInfo_Invalid_WindSpeedMaxMin);

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
                                            WindSpeedMinName, Properties.Resources.MixingInfo_Invalid_WindSpeedMin,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.Value, NoLowerBound, Value.WindSpeedMax.Value,
                          WindSpeedMinName, Properties.Resources.MixingInfo_Invalid_WindSpeedMinMax);

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
                                            WindSpeedName, Properties.Resources.MixingInfo_Invalid_WindSpeed,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.Value, Value.WindSpeedMin.Value, Value.WindSpeedMax.Value,
                          WindSpeedName, Properties.Resources.MixingInfo_Invalid_WindSpeedBetween);

            return isValid;
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        public MixingInfoModel DeepClone()
        {
            return new MixingInfoModel(this);
        }

        #endregion IDeepClone Interface
    }
}

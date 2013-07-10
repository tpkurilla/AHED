using System;
using AHED.Model;
using AHED.Types;

namespace AHED.ViewModel
{
    public class MixingInfoViewModel : ViewModelBase
    {
        #region Fields

        readonly MixingInfoModel _mixingInfo;

        #region Valid Options for StaticItems

        StaticItem[] _equipmentLoadedOptions;

        StaticItem[] _engineeringControlsOptions;

        StaticItem[] _reportingOptions;

        StaticItem[] _setupEquipmentOptions;

        StaticItem[] _diluentOptions;

        #endregion Valid Options for StaticItems

        #region Valid Units Options for properties

        private Volume.Units[] _premixTankCapacityUnitsOptions;

        private Volume.Units[] _sprayerTankCapacityUnitsOptions;

        private Volume.Units[] _hopperCapacityUnitsOptions;

        private Mass.Units[] _totalAiMixedUnitsOptions;

        private Volume.Units[] _finalSprayerVolumeMixedUnitsOptions;

        private Temperature.Units[] _temperatureMaxUnitsOptions;

        private Temperature.Units[] _temperatureMinUnitsOptions;

        private Temperature.Units[] _temperatureUnitsOptions;

        private Velocity.Units[] _windSpeedMaxUnitsOptions;

        private Velocity.Units[] _windSpeedMinUnitsOptions;

        private Velocity.Units[] _windSpeedUnitsOptions;

        #endregion Valid Units Options for properties

        #endregion // Fields

        #region Constructor

        public MixingInfoViewModel(MixingInfoModel mixingInfo)
        {
            if (mixingInfo == null)
                throw new ArgumentNullException("mixingInfo");

            _mixingInfo = mixingInfo;
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
            PremixTankCapacity = mixingInfo.PremixTankCapacity;
            PremixTankCapacityUnits = mixingInfo.PremixTankCapacityUnits;
            SprayerTankCapacity = mixingInfo.SprayerTankCapacity;
            SprayerTankCapacityUnits = mixingInfo.PremixTankCapacityUnits;
            HopperCapacity = mixingInfo.HopperCapacity;
            HopperCapacityUnits = mixingInfo.HopperCapacityUnits;
            TotalLoadsMixed = mixingInfo.TotalLoadsMixed;
            TotalAiMixed = mixingInfo.TotalAiMixed;
            TotalAiMixedUnits = mixingInfo.TotalAiMixedUnits;
            FinalSprayVolumeMixed = mixingInfo.FinalSprayVolumeMixed;
            FinalSprayVolumeMixedUnits = mixingInfo.FinalSprayVolumeMixedUnits;
            HumidityMax = mixingInfo.HumidityMax;
            HumidityMin = mixingInfo.HumidityMin;
            Humidity = mixingInfo.Humidity;
            TemperatureMax = mixingInfo.TemperatureMax;
            TemperatureMaxUnits = mixingInfo.TemperatureMaxUnits;
            TemperatureMin = mixingInfo.TemperatureMin;
            TemperatureMinUnits = mixingInfo.TemperatureMinUnits;
            Temperature = mixingInfo.Temperature;
            TemperatureUnits = mixingInfo.TemperatureUnits;
            WindSpeedMax = mixingInfo.WindSpeedMax;
            WindSpeedMaxUnits = mixingInfo.WindSpeedMaxUnits;
            WindSpeedMin = mixingInfo.WindSpeedMin;
            WindSpeedMinUnits = mixingInfo.WindSpeedMinUnits;
            WindSpeed = mixingInfo.WindSpeed;
            WindSpeedUnits = mixingInfo.WindSpeedUnits;
        }

        #endregion // Constructor

        #region Presentation Properties

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for EquipmentLoaded selector.
        /// </summary>
        public StaticItem[] EquipmentLoadedOptions
        {
            get
            {
                if (_equipmentLoadedOptions == null)
                {
                    _equipmentLoadedOptions = _mixingInfo.ValidEquipmentLoadeds.ToArray();
                }

                return _equipmentLoadedOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for EngineeringControls selector.
        /// </summary>
        public StaticItem[] EngineeringControlsOptions
        {
            get
            {
                if (_engineeringControlsOptions == null)
                {
                    _engineeringControlsOptions = _mixingInfo.ValidEngineeringControls.ToArray();
                }

                return _engineeringControlsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Cleanup selector.
        /// </summary>
        public StaticItem[] CleanupOptions
        {
            get
            {
                if (_reportingOptions == null)
                {
                    _reportingOptions = _mixingInfo.ValidReportings.ToArray();
                }

                return _reportingOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Repairs selector.
        /// </summary>
        public StaticItem[] RepairsOptions
        {
            get
            {
                if (_reportingOptions == null)
                {
                    _reportingOptions = _mixingInfo.ValidReportings.ToArray();
                }

                return _reportingOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Season selector.
        /// </summary>
        public StaticItem[] SetupEquipmentOptionsOptions
        {
            get
            {
                if (_setupEquipmentOptions == null)
                {
                    _setupEquipmentOptions = _mixingInfo.ValidSetupEquipments.ToArray();
                }

                return _setupEquipmentOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Country selector.
        /// </summary>
        public StaticItem[] DiluentOptionsOptions
        {
            get
            {
                if (_diluentOptions == null)
                {
                    _diluentOptions = _mixingInfo.ValidDiluents.ToArray();
                }

                return _diluentOptions;
            }
        }

        #endregion StaticItem Choices

        #region Units Choices

        /// <summary>
        /// Returns an array of valid choices for PremixTankCapacityUnits selector.
        /// </summary>
        public Volume.Units[] PremixTankCapacityUnitsOptions
        {
            get
            {
                if (_premixTankCapacityUnitsOptions == null)
                {
                    _premixTankCapacityUnitsOptions = new Volume.Units[] { Volume.Units.Gallons, Volume.Units.Liters };
                }

                return _premixTankCapacityUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for SprayerTankCapacityUnitsOptions selector.
        /// </summary>
        public Volume.Units[] SprayerTankCapacityUnitsOptions
        {
            get
            {
                if (_sprayerTankCapacityUnitsOptions == null)
                {
                    _sprayerTankCapacityUnitsOptions = new Volume.Units[] { Volume.Units.Gallons, Volume.Units.Liters };
                }

                return _sprayerTankCapacityUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for HopperCapacityUnitsOptions selector.
        /// </summary>
        public Volume.Units[] HopperCapacityUnitsOptions
        {
            get
            {
                if (_hopperCapacityUnitsOptions == null)
                {
                    _hopperCapacityUnitsOptions = new Volume.Units[] { Volume.Units.Gallons, Volume.Units.Liters };
                }

                return _hopperCapacityUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TotalAiMixedUnitsOptions selector.
        /// </summary>
        public Mass.Units[] TotalAiMixedUnitsOptions
        {
            get
            {
                if (_totalAiMixedUnitsOptions == null)
                {
                    _totalAiMixedUnitsOptions = new Mass.Units[] { Mass.Units.Pounds, Mass.Units.Kilograms };
                }

                return _totalAiMixedUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for FinalSprayVolumeMixedUnits selector.
        /// </summary>
        public Volume.Units[] FinalSprayVolumeMixedUnitsOptions
        {
            get
            {
                if (_finalSprayerVolumeMixedUnitsOptions == null)
                {
                    _finalSprayerVolumeMixedUnitsOptions = new Volume.Units[] { Volume.Units.Gallons, Volume.Units.Liters };
                }

                return _finalSprayerVolumeMixedUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TemperatureMaxUnits selector.
        /// </summary>
        public Temperature.Units[] TemperatureMaxUnitsOptions
        {
            get
            {
                if (_temperatureMaxUnitsOptions == null)
                {
                    _temperatureMaxUnitsOptions = new Temperature.Units[] { Temperature.Units.Fahrenheit, Temperature.Units.Celsius };
                }

                return _temperatureMaxUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TemperatureMinUnits selector.
        /// </summary>
        public Temperature.Units[] TemperatureMinUnitsOptions
        {
            get
            {
                if (_temperatureMinUnitsOptions == null)
                {
                    _temperatureMinUnitsOptions = new Temperature.Units[] { Temperature.Units.Fahrenheit, Temperature.Units.Celsius };
                }

                return _temperatureMinUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TemperatureUnits selector.
        /// </summary>
        public Temperature.Units[] TemperatureUnitsOptions
        {
            get
            {
                if (_temperatureUnitsOptions == null)
                {
                    _temperatureUnitsOptions = new Temperature.Units[] { Temperature.Units.Fahrenheit, Temperature.Units.Celsius };
                }

                return _temperatureUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WindSpeedMaxUnits selector.
        /// </summary>
        public Velocity.Units[] WindSpeedMaxUnitsOptions
        {
            get
            {
                if (_windSpeedMaxUnitsOptions == null)
                {
                    _windSpeedMaxUnitsOptions = new Velocity.Units[] { Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond };
                }

                return _windSpeedMaxUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WindSpeedMinUnits selector.
        /// </summary>
        public Velocity.Units[] WindSpeedMinUnitsOptions
        {
            get
            {
                if (_windSpeedMinUnitsOptions == null)
                {
                    _windSpeedMinUnitsOptions = new Velocity.Units[] { Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond };
                }

                return _windSpeedMinUnitsOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WindSpeedUnits selector.
        /// </summary>
        public Velocity.Units[] WindSpeedUnitsOptions
        {
            get
            {
                if (_windSpeedUnitsOptions == null)
                {
                    _windSpeedUnitsOptions = new Velocity.Units[] { Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond };
                }

                return _windSpeedUnitsOptions;
            }
        }

        #endregion Units Choices

        #endregion Presentation Properties

        #region MixingInfo Properties

        public StaticItem EquipmentLoaded
        {
            get { return _mixingInfo.EquipmentLoaded; }
            set
            {
                if (value == _mixingInfo.EquipmentLoaded)
                    return;

                _mixingInfo.EquipmentLoaded = value;
                base.OnPropertyChanged(MixingInfoModel.EQUIPMENT_LOADED);
            }
        }

        public StaticItem EngineeringControls
        {
            get { return _mixingInfo.EngineeringControls; }
            set
            {
                if (value == _mixingInfo.EngineeringControls)
                    return;

                _mixingInfo.EngineeringControls = value;
                base.OnPropertyChanged(MixingInfoModel.ENGINEERING_CONTROLS);
            }
        }

        public StaticItem Cleanup
        {
            get { return _mixingInfo.Cleanup; }
            set
            {
                if (value == _mixingInfo.Cleanup)
                    return;

                _mixingInfo.Cleanup = value;
                base.OnPropertyChanged(MixingInfoModel.CLEANUP);
            }
        }

        public StaticItem Repairs
        {
            get { return _mixingInfo.Repairs; }
            set
            {
                if (value == _mixingInfo.Repairs)
                    return;

                _mixingInfo.Repairs = value;
                base.OnPropertyChanged(MixingInfoModel.REPAIRS);
            }
        }

        public string IncidentalExposure
        {
            get { return _mixingInfo.IncidentalExposure; }
            set
            {
                if (value == _mixingInfo.IncidentalExposure)
                    return;

                _mixingInfo.IncidentalExposure = value;
                base.OnPropertyChanged(MixingInfoModel.INCIDENTAL_EXPOSURE);
            }
        }

        public string EngineeringControlsMakeModel
        {
            get { return _mixingInfo.EngineeringControlsMakeModel; }
            set
            {
                if (value == _mixingInfo.EngineeringControlsMakeModel)
                    return;

                _mixingInfo.EngineeringControlsMakeModel = value;
                base.OnPropertyChanged(MixingInfoModel.ENG_CONTROLS_MAKE_MODEL);
            }
        }

        public string ProcedureAndEquipment
        {
            get { return _mixingInfo.ProcedureAndEquipment; }
            set
            {
                if (value == _mixingInfo.ProcedureAndEquipment)
                    return;

                _mixingInfo.ProcedureAndEquipment = value;
                base.OnPropertyChanged(MixingInfoModel.PROC_AND_EQUIPMENT);
            }
        }

        public StaticItem SetupEquipment
        {
            get { return _mixingInfo.SetupEquipment; }
            set
            {
                if (value == _mixingInfo.SetupEquipment)
                    return;

                _mixingInfo.SetupEquipment = value;
                base.OnPropertyChanged(MixingInfoModel.SETUP_EQUIPMENT);
            }
        }

        public StaticItem Diluent
        {
            get { return _mixingInfo.Diluent; }
            set
            {
                if (value == _mixingInfo.Diluent)
                    return;

                _mixingInfo.Diluent = value;
                base.OnPropertyChanged(MixingInfoModel.DILUENT);
            }
        }

        public string Additives
        {
            get { return _mixingInfo.Additives; }
            set
            {
                if (value == _mixingInfo.Additives)
                    return;

                _mixingInfo.Additives = value;
                base.OnPropertyChanged(MixingInfoModel.ADDITIVES);
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
                    _mixingInfo.PremixTankCapacityUnits = value;
                    base.OnPropertyChanged(MixingInfoModel.PREMIX_TANK_CAPACITY_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.PREMIX_TANK_CAPACITY);
                }
            }
        }

        public string PremixTankCapacity
        {
            get { return _mixingInfo.PremixTankCapacity; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _mixingInfo.PremixTankCapacity)
                    return;

                _mixingInfo.PremixTankCapacity = value;
                base.OnPropertyChanged(MixingInfoModel.PREMIX_TANK_CAPACITY);
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
                    base.OnPropertyChanged(MixingInfoModel.SPRAYER_TANK_CAPACITY_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.SPRAYER_TANK_CAPACITY);
                }
            }
        }

        public string SprayerTankCapacity
        {
            get { return _mixingInfo.SprayerTankCapacity; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _mixingInfo.SprayerTankCapacity)
                    return;

                _mixingInfo.SprayerTankCapacity = value;
                base.OnPropertyChanged(MixingInfoModel.SPRAYER_TANK_CAPACITY);
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
                    base.OnPropertyChanged(MixingInfoModel.HOPPER_CAPACITY_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.HOPPER_CAPACITY);
                }
            }
        }

        public string HopperCapacity
        {
            get { return _mixingInfo.HopperCapacity; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _mixingInfo.HopperCapacity)
                    return;

                _mixingInfo.HopperCapacity = value;
                base.OnPropertyChanged(MixingInfoModel.HOPPER_CAPACITY);
            }
        }

        public string TotalLoadsMixed
        {
            get { return _mixingInfo.TotalLoadsMixed; }
            set
            {
                if (value == _mixingInfo.TotalLoadsMixed)
                    return;

                _mixingInfo.TotalLoadsMixed = value;
                base.OnPropertyChanged(MixingInfoModel.TOTAL_LOADS_MIXED);
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
                    base.OnPropertyChanged(MixingInfoModel.TOTAL_AI_MIXED_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.TOTAL_AI_MIXED);
                }
            }
        }

        public string TotalAiMixed
        {
            get { return _mixingInfo.TotalAiMixed; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _mixingInfo.TotalAiMixed)
                    return;

                _mixingInfo.TotalAiMixed = value;
                base.OnPropertyChanged(MixingInfoModel.TOTAL_AI_MIXED);
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
                    base.OnPropertyChanged(MixingInfoModel.FINAL_SPRAY_VOLUME_MIXED_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.FINAL_SPRAY_VOLUME_MIXED);
                }
            }
        }

        public string FinalSprayVolumeMixed
        {
            get { return _mixingInfo.FinalSprayVolumeMixed; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _mixingInfo.FinalSprayVolumeMixed)
                    return;

                _mixingInfo.FinalSprayVolumeMixed = value;
                base.OnPropertyChanged(MixingInfoModel.FINAL_SPRAY_VOLUME_MIXED);
            }
        }

        public string HumidityMax
        {
            get { return _mixingInfo.HumidityMax; }
            set
            {
                if (value == _mixingInfo.HumidityMax)
                    return;

                _mixingInfo.HumidityMax = value;
                base.OnPropertyChanged(MixingInfoModel.HUMIDITY_MAX);
            }
        }

        public string HumidityMin
        {
            get { return _mixingInfo.HumidityMin; }
            set
            {
                if (value == _mixingInfo.HumidityMax)
                    return;

                _mixingInfo.HumidityMin = value;
                base.OnPropertyChanged(MixingInfoModel.HUMIDITY_MIN);
            }
        }

        public string Humidity
        {
            get { return _mixingInfo.Humidity; }
            set
            {
                if (value == _mixingInfo.Humidity)
                    return;

                _mixingInfo.Humidity = value;
                base.OnPropertyChanged(MixingInfoModel.HUMIDITY);
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
                    base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_MAX_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_MAX);
                }
            }
        }

        public string TemperatureMax
        {
            get { return _mixingInfo.TemperatureMax; }
            set
            {
                if (value == _mixingInfo.TemperatureMax)
                    return;

                _mixingInfo.TemperatureMax = value;
                base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_MAX);
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
                    base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_MIN_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_MIN);
                }
            }
        }

        public string TemperatureMin
        {
            get { return _mixingInfo.TemperatureMin; }
            set
            {
                if (value == _mixingInfo.TemperatureMin)
                    return;

                _mixingInfo.TemperatureMin = value;
                base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_MIN);
            }
        }

        private Temperature.Units _temperatureUnits;
        public Temperature.Units TemperatureUnits
        {
            get { return _temperatureUnits; }
            set
            {
                if (value != _temperatureUnits)
                {
                    _temperatureUnits = value;
                    base.OnPropertyChanged(MixingInfoModel.TEMPERATURE_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.TEMPERATURE);
                }
            }
        }

        public string Temperature
        {
            get { return _mixingInfo.Temperature; }
            set
            {
                if (value == _mixingInfo.Temperature)
                    return;

                _mixingInfo.Temperature = value;
                base.OnPropertyChanged(MixingInfoModel.TEMPERATURE);
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
                    base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_MAX_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_MAX);
                }
            }
        }

        public string WindSpeedMax
        {
            get { return _mixingInfo.WindSpeedMax; }
            set
            {
                if (value == _mixingInfo.WindSpeedMax)
                    return;

                _mixingInfo.WindSpeedMax = value;
                base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_MAX);
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
                    base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_MIN_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_MIN);
                }
            }
        }

        public string WindSpeedMin
        {
            get { return _mixingInfo.WindSpeedMin; }
            set
            {
                if (value == _mixingInfo.WindSpeedMin)
                    return;

                _mixingInfo.WindSpeedMin = value;
                base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_MIN);
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
                    base.OnPropertyChanged(MixingInfoModel.WIND_SPEED_UNITS);
                    base.OnPropertyChanged(MixingInfoModel.WIND_SPEED);
                }
            }
        }

        public string WindSpeed
        {
            get { return _mixingInfo.WindSpeed; }
            set
            {
                if (value == _mixingInfo.WindSpeed)
                    return;

                _mixingInfo.WindSpeed = value;
                base.OnPropertyChanged(MixingInfoModel.WIND_SPEED);
            }
        }

        #endregion MixingInfo Properties

    }
}

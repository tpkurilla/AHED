using System;
using AHED.Data.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class MixingInfoViewModel : SimpleViewModel<MixingInfoModel, MixingInfo>
    {
        #region Fields

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

        public MixingInfoViewModel(MixingInfoModel model)
            : base(model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            EquipmentLoaded = Model.EquipmentLoaded;
            EngineeringControls = Model.EngineeringControls;
            Cleanup = Model.Cleanup;
            Repairs = Model.Repairs;
            IncidentalExposure = Model.IncidentalExposure;
            EngineeringControlsMakeModel = Model.EngineeringControlsMakeModel;
            ProcedureAndEquipment = Model.ProcedureAndEquipment;
            SetupEquipment = Model.SetupEquipment;
            Diluent = Model.Diluent;
            Additives = Model.Additives;
            PremixTankCapacity = Model.PremixTankCapacity;
            PremixTankCapacityUnits = Model.PremixTankCapacityUnits;
            SprayerTankCapacity = Model.SprayerTankCapacity;
            SprayerTankCapacityUnits = Model.PremixTankCapacityUnits;
            HopperCapacity = Model.HopperCapacity;
            HopperCapacityUnits = Model.HopperCapacityUnits;
            TotalLoadsMixed = Model.TotalLoadsMixed;
            TotalAiMixed = Model.TotalAiMixed;
            TotalAiMixedUnits = Model.TotalAiMixedUnits;
            FinalSprayVolumeMixed = Model.FinalSprayVolumeMixed;
            FinalSprayVolumeMixedUnits = Model.FinalSprayVolumeMixedUnits;
            HumidityMax = Model.HumidityMax;
            HumidityMin = Model.HumidityMin;
            Humidity = Model.Humidity;
            TemperatureMax = Model.TemperatureMax;
            TemperatureMaxUnits = Model.TemperatureMaxUnits;
            TemperatureMin = Model.TemperatureMin;
            TemperatureMinUnits = Model.TemperatureMinUnits;
            Temperature = Model.Temperature;
            TemperatureUnits = Model.TemperatureUnits;
            WindSpeedMax = Model.WindSpeedMax;
            WindSpeedMaxUnits = Model.WindSpeedMaxUnits;
            WindSpeedMin = Model.WindSpeedMin;
            WindSpeedMinUnits = Model.WindSpeedMinUnits;
            WindSpeed = Model.WindSpeed;
            WindSpeedUnits = Model.WindSpeedUnits;
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
                return _equipmentLoadedOptions
                       ?? (_equipmentLoadedOptions = Model.ValidEquipmentLoadeds.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for EngineeringControls selector.
        /// </summary>
        public StaticItem[] EngineeringControlsOptions
        {
            get
            {
                return _engineeringControlsOptions
                       ?? (_engineeringControlsOptions = Model.ValidEngineeringControls.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Cleanup selector.
        /// </summary>
        public StaticItem[] CleanupOptions
        {
            get
            {
                return _reportingOptions
                       ?? (_reportingOptions = Model.ValidReportings.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Repairs selector.
        /// </summary>
        public StaticItem[] RepairsOptions
        {
            get
            {
                return _reportingOptions
                       ?? (_reportingOptions = Model.ValidReportings.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Season selector.
        /// </summary>
        public StaticItem[] SetupEquipmentOptionsOptions
        {
            get
            {
                return _setupEquipmentOptions
                       ?? (_setupEquipmentOptions = Model.ValidSetupEquipments.ToArray());
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Country selector.
        /// </summary>
        public StaticItem[] DiluentOptionsOptions
        {
            get
            {
                return _diluentOptions
                       ?? (_diluentOptions = Model.ValidDiluents.ToArray());
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
                return _premixTankCapacityUnitsOptions
                       ?? (_premixTankCapacityUnitsOptions = new[] {Volume.Units.Gallons, Volume.Units.Liters});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for SprayerTankCapacityUnitsOptions selector.
        /// </summary>
        public Volume.Units[] SprayerTankCapacityUnitsOptions
        {
            get
            {
                return _sprayerTankCapacityUnitsOptions
                       ?? (_sprayerTankCapacityUnitsOptions = new[] {Volume.Units.Gallons, Volume.Units.Liters});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for HopperCapacityUnitsOptions selector.
        /// </summary>
        public Volume.Units[] HopperCapacityUnitsOptions
        {
            get
            {
                return _hopperCapacityUnitsOptions
                       ?? (_hopperCapacityUnitsOptions = new[] {Volume.Units.Gallons, Volume.Units.Liters});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TotalAiMixedUnitsOptions selector.
        /// </summary>
        public Mass.Units[] TotalAiMixedUnitsOptions
        {
            get
            {
                return _totalAiMixedUnitsOptions
                       ?? (_totalAiMixedUnitsOptions = new[] {Mass.Units.Pounds, Mass.Units.Kilograms});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for FinalSprayVolumeMixedUnits selector.
        /// </summary>
        public Volume.Units[] FinalSprayVolumeMixedUnitsOptions
        {
            get
            {
                return _finalSprayerVolumeMixedUnitsOptions
                       ?? (_finalSprayerVolumeMixedUnitsOptions = new[] {Volume.Units.Gallons, Volume.Units.Liters});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TemperatureMaxUnits selector.
        /// </summary>
        public Temperature.Units[] TemperatureMaxUnitsOptions
        {
            get
            {
                return _temperatureMaxUnitsOptions
                       ?? (_temperatureMaxUnitsOptions = new[] {Types.Temperature.Units.Fahrenheit, Types.Temperature.Units.Celsius});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TemperatureMinUnits selector.
        /// </summary>
        public Temperature.Units[] TemperatureMinUnitsOptions
        {
            get
            {
                return _temperatureMinUnitsOptions
                       ?? (_temperatureMinUnitsOptions = new[] {Types.Temperature.Units.Fahrenheit, Types.Temperature.Units.Celsius});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TemperatureUnits selector.
        /// </summary>
        public Temperature.Units[] TemperatureUnitsOptions
        {
            get
            {
                return _temperatureUnitsOptions
                       ?? (_temperatureUnitsOptions = new[] {Types.Temperature.Units.Fahrenheit, Types.Temperature.Units.Celsius});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WindSpeedMaxUnits selector.
        /// </summary>
        public Velocity.Units[] WindSpeedMaxUnitsOptions
        {
            get
            {
                return _windSpeedMaxUnitsOptions
                       ?? (_windSpeedMaxUnitsOptions = new[] {Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WindSpeedMinUnits selector.
        /// </summary>
        public Velocity.Units[] WindSpeedMinUnitsOptions
        {
            get {
                return _windSpeedMinUnitsOptions
                    ?? (_windSpeedMinUnitsOptions = new [] {Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond});
            }
        }

        /// <summary>
        /// Returns an array of valid choices for WindSpeedUnits selector.
        /// </summary>
        public Velocity.Units[] WindSpeedUnitsOptions
        {
            get
            {
                return _windSpeedUnitsOptions
                       ?? (_windSpeedUnitsOptions = new[] {Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond});
            }
        }

        #endregion Units Choices

        #endregion Presentation Properties

        #region MixingInfo Properties

        private StaticItem _equipmentLoaded;
        public StaticItem EquipmentLoaded
        {
            get { return _equipmentLoaded; }
            set
            {
                if (value == _equipmentLoaded)
                    return;

                Model.EquipmentLoaded = value;
                _equipmentLoaded = Model.EquipmentLoaded;
                base.RaisePropertyChanged(MixingInfoModel.EquipmentLoadedName);
            }
        }

        private StaticItem _engineeringControls;
        public StaticItem EngineeringControls
        {
            get { return _engineeringControls; }
            set
            {
                if (value == _engineeringControls)
                    return;

                Model.EngineeringControls = value;
                _engineeringControls = Model.EngineeringControls;
                base.RaisePropertyChanged(MixingInfoModel.EngineeringControlsName);
            }
        }

        private StaticItem _cleanUp;
        public StaticItem Cleanup
        {
            get { return _cleanUp; }
            set
            {
                if (value == _cleanUp)
                    return;

                Model.Cleanup = value;
                _cleanUp = Model.Cleanup;
                base.RaisePropertyChanged(MixingInfoModel.CleanupName);
            }
        }

        private StaticItem _repairs;
        public StaticItem Repairs
        {
            get { return _repairs; }
            set
            {
                if (value == _repairs)
                    return;

                Model.Repairs = value;
                _repairs = Model.Repairs;
                base.RaisePropertyChanged(MixingInfoModel.RepairsName);
            }
        }

        private string _incidentalExposure;
        public string IncidentalExposure
        {
            get { return _incidentalExposure; }
            set
            {
                if (value == _incidentalExposure)
                    return;

                Model.IncidentalExposure = value;
                _incidentalExposure = Model.IncidentalExposure;
                base.RaisePropertyChanged(MixingInfoModel.IncidentalExposureName);
            }
        }

        private string _engineeringControlsMakeModel;
        public string EngineeringControlsMakeModel
        {
            get { return _engineeringControlsMakeModel; }
            set
            {
                if (value == _engineeringControlsMakeModel)
                    return;

                Model.EngineeringControlsMakeModel = value;
                _engineeringControlsMakeModel = Model.EngineeringControlsMakeModel;
                base.RaisePropertyChanged(MixingInfoModel.EngineeringControlsMakeModelName);
            }
        }

        private string _procedureAndEquipment;
        public string ProcedureAndEquipment
        {
            get { return _procedureAndEquipment; }
            set
            {
                if (value == _procedureAndEquipment)
                    return;

                Model.ProcedureAndEquipment = value;
                _procedureAndEquipment = Model.ProcedureAndEquipment;
                base.RaisePropertyChanged(MixingInfoModel.ProcedureAndEquipmentName);
            }
        }

        private StaticItem _setupEquipment;
        public StaticItem SetupEquipment
        {
            get { return _setupEquipment; }
            set
            {
                if (value == _setupEquipment)
                    return;

                Model.SetupEquipment = value;
                _setupEquipment = Model.SetupEquipment;
                base.RaisePropertyChanged(MixingInfoModel.SetupEquipmentName);
            }
        }

        private StaticItem _diluent;
        public StaticItem Diluent
        {
            get { return _diluent; }
            set
            {
                if (value == _diluent)
                    return;

                Model.Diluent = value;
                _diluent = Model.Diluent;
                base.RaisePropertyChanged(MixingInfoModel.DiluentName);
            }
        }

        private string _additives;
        public string Additives
        {
            get { return _additives; }
            set
            {
                if (value == _additives)
                    return;

                Model.Additives = value;
                _additives = Model.Additives;
                base.RaisePropertyChanged(MixingInfoModel.AdditivesName);
            }
        }

        private Volume.Units _premixTankCapacityUnits;
        public Volume.Units PremixTankCapacityUnits
        {
            get { return _premixTankCapacityUnits; }
            set
            {
                if (value == _premixTankCapacityUnits)
                    return;
                
                Model.PremixTankCapacityUnits = value;
                _premixTankCapacityUnits = value;
                base.RaisePropertyChanged(MixingInfoModel.PremixTankCapacityUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.PremixTankCapacityName);
            }
        }

        private string _premixTankCapacity;
        public string PremixTankCapacity
        {
            get { return _premixTankCapacity; }
            set
            {
                if (value == _premixTankCapacity)
                    return;

                Model.PremixTankCapacity = value;
                _premixTankCapacity = Model.PremixTankCapacity;
                base.RaisePropertyChanged(MixingInfoModel.PremixTankCapacityName);
            }
        }

        private Volume.Units _sprayerTankCapacityUnits;
        public Volume.Units SprayerTankCapacityUnits
        {
            get { return _sprayerTankCapacityUnits; }
            set
            {
                if (value == _sprayerTankCapacityUnits)
                    return;
                
                Model.SprayerTankCapacityUnits = value;
                _sprayerTankCapacityUnits = Model.SprayerTankCapacityUnits;
                base.RaisePropertyChanged(MixingInfoModel.SprayerTankCapacityUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.SprayerTankCapacityName);
            }
        }

        private string _sprayerTankCapacity;
        public string SprayerTankCapacity
        {
            get { return _sprayerTankCapacity; }
            set
            {
                if (value == _sprayerTankCapacity)
                    return;

                Model.SprayerTankCapacity = value;
                _sprayerTankCapacity = Model.SprayerTankCapacity;
                base.RaisePropertyChanged(MixingInfoModel.SprayerTankCapacityName);
            }
        }

        private Volume.Units _hopperCapacityUnits;
        public Volume.Units HopperCapacityUnits
        {
            get { return _hopperCapacityUnits; }
            set
            {
                if (value == _hopperCapacityUnits)
                    return;

                Model.HopperCapacityUnits = value;
                _hopperCapacityUnits = Model.HopperCapacityUnits;
                base.RaisePropertyChanged(MixingInfoModel.HopperCapacityUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.HopperCapacityName);
            }
        }

        private string _hopperCapacity;
        public string HopperCapacity
        {
            get { return _hopperCapacity; }
            set
            {
                if (value == _hopperCapacity)
                    return;

                Model.HopperCapacity = value;
                _hopperCapacity = Model.HopperCapacity;
                base.RaisePropertyChanged(MixingInfoModel.HopperCapacityName);
            }
        }

        private string _totalLoadsMixed;
        public string TotalLoadsMixed
        {
            get { return _totalLoadsMixed; }
            set
            {
                if (value == _totalLoadsMixed)
                    return;

                Model.TotalLoadsMixed = value;
                _totalLoadsMixed = Model.TotalLoadsMixed;
                base.RaisePropertyChanged(MixingInfoModel.TotalLoadsMixedName);
            }
        }

        private Mass.Units _totalAiMixedUnits;
        public Mass.Units TotalAiMixedUnits
        {
            get { return _totalAiMixedUnits; }
            set
            {
                if (value == _totalAiMixedUnits)
                    return;
                
                Model.TotalAiMixedUnits = value;
                _totalAiMixedUnits = Model.TotalAiMixedUnits;
                base.RaisePropertyChanged(MixingInfoModel.TotalAiMixedUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.TotalAiMixedName);
            }
        }

        private string _totalAiMixed;
        public string TotalAiMixed
        {
            get { return _totalAiMixed; }
            set
            {
                if (value == _totalAiMixed)
                    return;

                Model.TotalAiMixed = value;
                _totalAiMixed = Model.TotalAiMixed;
                base.RaisePropertyChanged(MixingInfoModel.TotalAiMixedName);
            }
        }

        private Volume.Units _finalSprayVolumeMixedUnits;
        public Volume.Units FinalSprayVolumeMixedUnits
        {
            get { return _finalSprayVolumeMixedUnits; }
            set
            {
                if (value == _finalSprayVolumeMixedUnits)
                    return;

                Model.FinalSprayVolumeMixedUnits = value;
                _finalSprayVolumeMixedUnits = Model.FinalSprayVolumeMixedUnits;
                base.RaisePropertyChanged(MixingInfoModel.FinalSprayVolumeMixedUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.FinalSprayVolumeMixedName);
            }
        }

        private string _finalSprayVolumeMixed;
        public string FinalSprayVolumeMixed
        {
            get { return _finalSprayVolumeMixed; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _finalSprayVolumeMixed)
                    return;

                Model.FinalSprayVolumeMixed = value;
                _finalSprayVolumeMixed = Model.FinalSprayVolumeMixed;
                base.RaisePropertyChanged(MixingInfoModel.FinalSprayVolumeMixedName);
            }
        }

        private string _humidityMax;
        public string HumidityMax
        {
            get { return _humidityMax; }
            set
            {
                if (value == _humidityMax)
                    return;

                Model.HumidityMax = value;
                _humidityMax = Model.HumidityMax;
                base.RaisePropertyChanged(MixingInfoModel.HumidityMaxName);
            }
        }

        private string _humidityMin;
        public string HumidityMin
        {
            get { return _humidityMin; }
            set
            {
                if (value == _humidityMin)
                    return;

                Model.HumidityMin = value;
                _humidityMin = Model.HumidityMin;
                base.RaisePropertyChanged(MixingInfoModel.HumidityMinName);
            }
        }

        private string _humidity;
        public string Humidity
        {
            get { return _humidity; }
            set
            {
                if (value == _humidity)
                    return;

                Model.Humidity = value;
                _humidity = Model.Humidity;
                base.RaisePropertyChanged(MixingInfoModel.HumidityName);
            }
        }

        private Temperature.Units _temperatureMaxUnits;
        public Temperature.Units TemperatureMaxUnits
        {
            get { return _temperatureMaxUnits; }
            set
            {
                if (value == _temperatureMaxUnits)
                    return;

                Model.TemperatureMaxUnits = value;
                _temperatureMaxUnits = Model.TemperatureMaxUnits;
                base.RaisePropertyChanged(MixingInfoModel.TemperatureMaxUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.TemperatureMaxName);
            }
        }

        private string _temperatureMax;
        public string TemperatureMax
        {
            get { return _temperatureMax; }
            set
            {
                if (value == _temperatureMax)
                    return;

                Model.TemperatureMax = value;
                _temperatureMax = Model.TemperatureMax;
                base.RaisePropertyChanged(MixingInfoModel.TemperatureMaxName);
            }
        }

        private Temperature.Units _temperatureMinUnits;
        public Temperature.Units TemperatureMinUnits
        {
            get { return _temperatureMinUnits; }
            set
            {
                if (value == _temperatureMinUnits)
                    return;

                Model.TemperatureMinUnits = value;
                _temperatureMinUnits = Model.TemperatureMinUnits;
                base.RaisePropertyChanged(MixingInfoModel.TemperatureMinUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.TemperatureMinName);
            }
        }

        private string _temperatureMin;
        public string TemperatureMin
        {
            get { return _temperatureMin; }
            set
            {
                if (value == _temperatureMin)
                    return;

                Model.TemperatureMin = value;
                _temperatureMin = Model.TemperatureMin;
                base.RaisePropertyChanged(MixingInfoModel.TemperatureMinName);
            }
        }

        private Temperature.Units _temperatureUnits;
        public Temperature.Units TemperatureUnits
        {
            get { return _temperatureUnits; }
            set
            {
                if (value == _temperatureUnits)
                    return;

                Model.TemperatureUnits = value;
                _temperatureUnits = Model.TemperatureUnits;
                base.RaisePropertyChanged(MixingInfoModel.TemperatureUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.TemperatureName);
            }
        }

        private string _temperature;
        public string Temperature
        {
            get { return _temperature; }
            set
            {
                if (value == _temperature)
                    return;

                Model.Temperature = value;
                _temperature = Model.Temperature;
                base.RaisePropertyChanged(MixingInfoModel.TemperatureName);
            }
        }

        private Velocity.Units _windSpeedMaxUnits;
        public Velocity.Units WindSpeedMaxUnits
        {
            get { return _windSpeedMaxUnits; }
            set
            {
                if (value == _windSpeedMaxUnits)
                    return;

                Model.WindSpeedMaxUnits = value;
                _windSpeedMaxUnits = Model.WindSpeedMaxUnits;
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedMaxUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedMaxName);
            }
        }

        private string _windSpeedMax;
        public string WindSpeedMax
        {
            get { return _windSpeedMax; }
            set
            {
                if (value == _windSpeedMax)
                    return;

                Model.WindSpeedMax = value;
                _windSpeedMax = Model.WindSpeedMax;
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedMaxName);
            }
        }

        private Velocity.Units _windSpeedMinUnits;
        public Velocity.Units WindSpeedMinUnits
        {
            get { return _windSpeedMinUnits; }
            set
            {
                if (value == _windSpeedMinUnits)
                    return;

                Model.WindSpeedMinUnits = value;
                _windSpeedMinUnits = Model.WindSpeedMinUnits;
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedMinUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedMinName);
            }
        }

        private string _windSpeedMin;
        public string WindSpeedMin
        {
            get { return _windSpeedMin; }
            set
            {
                if (value == _windSpeedMin)
                    return;

                Model.WindSpeedMin = value;
                _windSpeedMin = Model.WindSpeedMin;
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedMinName);
            }
        }

        private Velocity.Units _windSpeedUnits;
        public Velocity.Units WindSpeedUnits
        {
            get { return _windSpeedUnits; }
            set
            {
                if (value == _windSpeedUnits)
                    return;

                Model.WindSpeedUnits = value;
                _windSpeedUnits = Model.WindSpeedUnits;
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedUnitsName);
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedName);
            }
        }

        private string _windSpeed;
        public string WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                if (value == _windSpeed)
                    return;

                Model.WindSpeed = value;
                _windSpeed = Model.WindSpeed;
                base.RaisePropertyChanged(MixingInfoModel.WindSpeedName);
            }
        }

        #endregion MixingInfo Properties

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

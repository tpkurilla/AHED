using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHED.Model;
using AHED.Types;

namespace AHED.ViewModel
{
    public class ApplicationInfoViewModel : ViewModelBase
    {
        #region Fields

        readonly ApplicationInfoModel _applicationInfo;

        #region Valid Options for StaticItems

        StaticItem[] _equipmentUsedOptions;

        StaticItem[] _engineeringControlsOptions;

        StaticItem[] _reportingOptions;

        StaticItem[] _foliageDensityOptions;

        StaticItem[] _diluentOptions;

        #endregion Valid Options for StaticItems

        #region Valid Units Options for properties

        private Length.Units[] _heightUnitsOptions;

        private Mass.Units[] _weightUnitsOptions;

        #endregion Valid Units Options for properties

        #endregion // Fields

        #region Constructor

        public ApplicationInfoViewModel(ApplicationInfoModel applicationInfo)
        {
            if (applicationInfo == null)
                throw new ArgumentNullException("applicationInfo");

            _applicationInfo = applicationInfo;
        }

        #endregion // Constructor

        #region Presentation Properties

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for EquipmentLoaded selector.
        /// </summary>
        public StaticItem[] EquipmentUsedOptions
        {
            get
            {
                if (_equipmentUsedOptions == null)
                {
                    _equipmentUsedOptions = _applicationInfo.ValidEquipmentUseds.ToArray();
                }

                return _equipmentUsedOptions;
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
                    _engineeringControlsOptions = _applicationInfo.ValidEngineeringControls.ToArray();
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
                    _reportingOptions = _applicationInfo.ValidReportings.ToArray();
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
                    _reportingOptions = _applicationInfo.ValidReportings.ToArray();
                }

                return _reportingOptions;
            }
        }

        /// <summary>
        /// Returns an array of valid choices for Season selector.
        /// </summary>
        public StaticItem[] FoliageDensityOptionsOptions
        {
            get
            {
                if (_foliageDensityOptions == null)
                {
                    _foliageDensityOptions = _applicationInfo.ValidFoliageDensities.ToArray();
                }

                return _foliageDensityOptions;
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
                    _diluentOptions = _applicationInfo.ValidDiluents.ToArray();
                }

                return _diluentOptions;
            }
        }

        #endregion StaticItem Choices

        #endregion Presentation Properties

        #region ApplicationInfo Properties

        public StaticItem EquipmentUsed
        {
            get { return _applicationInfo.EquipmentUsed; }
            set
            {
                if (value == _applicationInfo.EquipmentUsed)
                    return;

                _applicationInfo.EquipmentUsed = value;
                base.OnPropertyChanged(ApplicationInfoModel.EQUIPMENT_USED);
            }
        }

        public string EquipmentMonitoringMedia
        {
            get { return _applicationInfo.EquipmentMonitoringMedia; }
            set
            {
                if (value == _applicationInfo.EquipmentMonitoringMedia)
                    return;

                _applicationInfo.EquipmentMonitoringMedia = value;
                base.OnPropertyChanged(ApplicationInfoModel.EQUIPMENT_MONITORING_MEDIA);
            }
        }

        public StaticItem Repairs
        {
            get { return _applicationInfo.Repairs; }
            set
            {
                if (value == _applicationInfo.Repairs)
                    return;

                _applicationInfo.Repairs = value;
                base.OnPropertyChanged(ApplicationInfoModel.REPAIRS);
            }
        }

        public string ApplicationMakeModel
        {
            get { return _applicationInfo.ApplicationMakeModel; }
            set
            {
                if (value == _applicationInfo.ApplicationMakeModel)
                    return;

                _applicationInfo.ApplicationMakeModel = value;
                base.OnPropertyChanged(ApplicationInfoModel.APPLICATION_MAKE_MODEL);
            }
        }

        public string VehicleMakeModel
        {
            get { return _applicationInfo.VehicleMakeModel; }
            set
            {
                if (value == _applicationInfo.VehicleMakeModel)
                    return;

                _applicationInfo.VehicleMakeModel = value;
                base.OnPropertyChanged(ApplicationInfoModel.VEHICLE_MAKE_MODEL);
            }
        }

        public StaticItem Cleanup
        {
            get { return _applicationInfo.Cleanup; }
            set
            {
                if (value == _applicationInfo.Cleanup)
                    return;

                _applicationInfo.Cleanup = value;
                base.OnPropertyChanged(ApplicationInfoModel.CLEANUP);
            }
        }

        public string VehicleDescription
        {
            get { return _applicationInfo.VehicleDescription; }
            set
            {
                if (value == _applicationInfo.VehicleDescription)
                    return;

                _applicationInfo.VehicleDescription = value;
                base.OnPropertyChanged(ApplicationInfoModel.VEHICLE_DESCRIPTION);
            }
        }

        public string IncidentalExposure
        {
            get { return _applicationInfo.IncidentalExposure; }
            set
            {
                if (value == _applicationInfo.IncidentalExposure)
                    return;

                _applicationInfo.IncidentalExposure = value;
                base.OnPropertyChanged(ApplicationInfoModel.INCIDENTAL_EXPOSURE);
            }
        }

        public string CropTreated
        {
            get { return _applicationInfo.CropTreated; }
            set
            {
                if (value == _applicationInfo.CropTreated)
                    return;

                _applicationInfo.CropTreated = value;
                base.OnPropertyChanged(ApplicationInfoModel.CROP_TREATED);
            }
        }

        public StaticItem EngineeringControls
        {
            get { return _applicationInfo.EngineeringControls; }
            set
            {
                if (value == _applicationInfo.EngineeringControls)
                    return;

                _applicationInfo.EngineeringControls = value;
                base.OnPropertyChanged(ApplicationInfoModel.ENGINEERING_CONTROLS);
            }
        }

        public string EngineeringControlsComment
        {
            get { return _applicationInfo.EngineeringControlsComment; }
            set
            {
                if (value == _applicationInfo.EngineeringControlsComment)
                    return;

                _applicationInfo.EngineeringControlsComment = value;
                base.OnPropertyChanged(ApplicationInfoModel.ENGINEERING_CONTROLS_COMMENT);
            }
        }

        public string EngineeringMakeModel
        {
            get { return _applicationInfo.EngineeringMakeModel; }
            set
            {
                if (value == _applicationInfo.EngineeringMakeModel)
                    return;

                _applicationInfo.EngineeringMakeModel = value;
                base.OnPropertyChanged(ApplicationInfoModel.ENGINEERING_MAKE_MODEL);
            }
        }

        public string ProcedureAndEquipment
        {
            get { return _applicationInfo.ProcedureAndEquipment; }
            set
            {
                if (value == _applicationInfo.ProcedureAndEquipment)
                    return;

                _applicationInfo.ProcedureAndEquipment = value;
                base.OnPropertyChanged(ApplicationInfoModel.PROCEDURE_AND_EQUIPMENT);
            }
        }

        public Length.Units HeightUnits
        {
            get { return _applicationInfo.CropHeightUnits; }
            set
            {
                if (value != _applicationInfo.CropHeightUnits)
                {
                    _applicationInfo.CropHeightUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.CROP_HEIGHT_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.CROP_HEIGHT);
                }
            }
        }

        public string CropHeight
        {
            get { return _applicationInfo.CropHeight; }
            set
            {
                if (value == _applicationInfo.CropHeight)
                    return;

                _applicationInfo.CropHeight = value;
                base.OnPropertyChanged(ApplicationInfoModel.CROP_HEIGHT);
            }
        }

        public StaticItem FoliageDensity
        {
            get { return _applicationInfo.FoliageDensity; }
            set
            {
                if (value == _applicationInfo.FoliageDensity)
                    return;

                _applicationInfo.FoliageDensity = value;
                base.OnPropertyChanged(ApplicationInfoModel.FOLIAGE_DENSITY);
            }
        }

        public StaticItem Diluent
        {
            get { return _applicationInfo.Diluent; }
            set
            {
                if (value == _applicationInfo.Diluent)
                    return;

                _applicationInfo.Diluent = value;
                base.OnPropertyChanged(ApplicationInfoModel.DILUENT);
            }
        }

        public string Additives
        {
            get { return _applicationInfo.Additives; }
            set
            {
                if (value == _applicationInfo.Additives)
                    return;

                _applicationInfo.Additives = value;
                base.OnPropertyChanged(ApplicationInfoModel.ADDITIVES);
            }
        }

        public Length.Units SpacingBetweenRowsUnits
        {
            get { return _applicationInfo.SpacingBetweenRowsUnits; }
            set
            {
                if (value != _applicationInfo.SpacingBetweenRowsUnits)
                {
                    _applicationInfo.SpacingBetweenRowsUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.SPACING_BETWEEN_ROWS_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.SPACING_BETWEEN_ROWS);
                }
            }
        }

        public string SpacingBetweenRows
        {
            get { return _applicationInfo.SpacingBetweenRows; }
            set
            {
                if (value == _applicationInfo.SpacingBetweenRows)
                    return;

                _applicationInfo.SpacingBetweenRows = value;
                base.OnPropertyChanged(ApplicationInfoModel.SPACING_BETWEEN_ROWS);
            }
        }

        public Velocity.Units GroundSpeedUnits
        {
            get { return _applicationInfo.GroundSpeedUnits; }
            set
            {
                if (value != _applicationInfo.GroundSpeedUnits)
                {
                    _applicationInfo.GroundSpeedUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.GROUND_SPEED_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.GROUND_SPEED);
                }
            }
        }

        public string GroundSpeed
        {
            get { return _applicationInfo.GroundSpeed; }
            set
            {
                if (value == _applicationInfo.GroundSpeed)
                    return;

                _applicationInfo.GroundSpeed = value;
                base.OnPropertyChanged(ApplicationInfoModel.GROUND_SPEED);
            }
        }

        public Length.Units BoomHeightUnits
        {
            get { return _applicationInfo.BoomHeightUnits; }
            set
            {
                if (value != _applicationInfo.BoomHeightUnits)
                {
                    _applicationInfo.BoomHeightUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.BOOM_HEIGHT_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.BOOM_HEIGHT);
                }
            }
        }

        public string BoomHeight
        {
            get { return _applicationInfo.BoomHeight; }
            set
            {
                if (value == _applicationInfo.BoomHeight)
                    return;

                _applicationInfo.BoomHeight = value;
                base.OnPropertyChanged(ApplicationInfoModel.BOOM_HEIGHT);
            }
        }

        public Length.Units BoomWidthUnits
        {
            get { return _applicationInfo.BoomWidthUnits; }
            set
            {
                if (value != _applicationInfo.BoomWidthUnits)
                {
                    _applicationInfo.BoomWidthUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.BOOM_WIDTH_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.BOOM_WIDTH);
                }
            }
        }

        public string BoomWidth
        {
            get { return _applicationInfo.BoomWidth; }
            set
            {
                if (value == _applicationInfo.BoomWidth)
                    return;

                _applicationInfo.BoomWidth = value;
                base.OnPropertyChanged(ApplicationInfoModel.BOOM_WIDTH);
            }
        }

        public Length.Units SwathWidthUnits
        {
            get { return _applicationInfo.SwathWidthUnits; }
            set
            {
                if (value != _applicationInfo.SwathWidthUnits)
                {
                    _applicationInfo.SwathWidthUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.SWATH_WIDTH_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.SWATH_WIDTH);
                }
            }
        }

        public string SwathWidth
        {
            get { return _applicationInfo.SwathWidth; }
            set
            {
                if (value == _applicationInfo.SwathWidth)
                    return;

                _applicationInfo.SwathWidth = value;
                base.OnPropertyChanged(ApplicationInfoModel.SWATH_WIDTH);
            }
        }

        public Length.Units BandWidthUnits
        {
            get { return _applicationInfo.BandWidthUnits; }
            set
            {
                if (value != _applicationInfo.BandWidthUnits)
                {
                    _applicationInfo.BandWidthUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.BAND_WIDTH_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.BAND_WIDTH);
                }
            }
        }

        public string BandWidth
        {
            get { return _applicationInfo.BandWidth; }
            set
            {
                if (value == _applicationInfo.BandWidth)
                    return;

                _applicationInfo.BandWidth = value;
                base.OnPropertyChanged(ApplicationInfoModel.BAND_WIDTH);
            }
        }

        public Length.Units DepthUnits
        {
            get { return _applicationInfo.DepthUnits; }
            set
            {
                if (value != _applicationInfo.DepthUnits)
                {
                    _applicationInfo.DepthUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.DEPTH_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.DEPTH);
                }
            }
        }

        public string Depth
        {
            get { return _applicationInfo.Depth; }
            set
            {
                if (value == _applicationInfo.Depth)
                    return;

                _applicationInfo.Depth = value;
                base.OnPropertyChanged(ApplicationInfoModel.DEPTH);
            }
        }

        public string DiskSize
        {
            get { return _applicationInfo.DiskSize; }
            set
            {
                if (value == _applicationInfo.DiskSize)
                    return;

                _applicationInfo.DiskSize = value;
                base.OnPropertyChanged(ApplicationInfoModel.DISK_SIZE);
            }
        }

        public string NumberOfNozzles
        {
            get { return _applicationInfo.NumberOfNozzles; }
            set
            {
                if (value == _applicationInfo.NumberOfNozzles)
                    return;

                _applicationInfo.NumberOfNozzles = value;
                base.OnPropertyChanged(ApplicationInfoModel.NUMBER_OF_NOZZLES);
            }
        }

        public string NozzleType
        {
            get { return _applicationInfo.NozzleType; }
            set
            {
                if (value == _applicationInfo.NozzleType)
                    return;

                _applicationInfo.NozzleType = value;
                base.OnPropertyChanged(ApplicationInfoModel.NOZZLE_TYPE);
            }
        }

        public string NozzleModel
        {
            get { return _applicationInfo.NozzleModel; }
            set
            {
                if (value == _applicationInfo.NozzleModel)
                    return;

                _applicationInfo.NozzleModel = value;
                base.OnPropertyChanged(ApplicationInfoModel.NOZZLE_MODEL);
            }
        }

        public Pressure.Units NozzlePressureUnits
        {
            get { return _applicationInfo.NozzlePressureUnits; }
            set
            {
                if (value != _applicationInfo.NozzlePressureUnits)
                {
                    _applicationInfo.NozzlePressureUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.NOZZLE_PRESSURE_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.NOZZLE_PRESSURE);
                }
            }
        }

        public string NozzlePressure
        {
            get { return _applicationInfo.NozzlePressure; }
            set
            {
                if (value == _applicationInfo.NozzlePressure)
                    return;

                _applicationInfo.NozzlePressure = value;
                base.OnPropertyChanged(ApplicationInfoModel.NOZZLE_PRESSURE);
            }
        }

        public Volume.Units SprayerTankCapacityUnits
        {
            get { return _applicationInfo.SprayerTankCapacityUnits; }
            set
            {
                if (value != _applicationInfo.SprayerTankCapacityUnits)
                {
                    _applicationInfo.SprayerTankCapacityUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.SPRAYER_TANK_CAPACITY_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.SPRAYER_TANK_CAPACITY);
                }
            }
        }

        public string SprayerTankCapacity
        {
            get { return _applicationInfo.SprayerTankCapacity; }
            set
            {
                if (value == _applicationInfo.SprayerTankCapacity)
                    return;

                _applicationInfo.SprayerTankCapacity = value;
                base.OnPropertyChanged(ApplicationInfoModel.SPRAYER_TANK_CAPACITY);
            }
        }

        public Volume.Units HopperCapacityUnits
        {
            get { return _applicationInfo.HopperCapacityUnits; }
            set
            {
                if (value != _applicationInfo.HopperCapacityUnits)
                {
                    _applicationInfo.HopperCapacityUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.HOPPER_CAPACITY_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.HOPPER_CAPACITY);
                }
            }
        }

        public string HopperCapacity
        {
            get { return _applicationInfo.HopperCapacity; }
            set
            {
                if (value == _applicationInfo.HopperCapacity)
                    return;

                _applicationInfo.HopperCapacity = value;
                base.OnPropertyChanged(ApplicationInfoModel.HOPPER_CAPACITY);
            }
        }

        public string TotalLoadsApplied
        {
            get { return _applicationInfo.TotalLoadsApplied; }
            set
            {
                if (value == _applicationInfo.TotalLoadsApplied)
                    return;

                _applicationInfo.TotalLoadsApplied = value;
                base.OnPropertyChanged(ApplicationInfoModel.TOTAL_LOADS_APPLIED);
            }
        }

        public Mass.Units TotalAiAppliedUnits
        {
            get { return _applicationInfo.TotalAiAppliedUnits; }
            set
            {
                if (value != _applicationInfo.TotalAiAppliedUnits)
                {
                    _applicationInfo.TotalAiAppliedUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.TOTAL_AI_APPLIED_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.TOTAL_AI_APPLIED);
                }
            }
        }

        public string TotalAiApplied
        {
            get { return _applicationInfo.TotalAiApplied; }
            set
            {
                if (value == _applicationInfo.TotalAiApplied)
                    return;

                _applicationInfo.TotalAiApplied = value;
                base.OnPropertyChanged(ApplicationInfoModel.TOTAL_AI_APPLIED);
            }
        }

        public Volume.Units TotalSprayAppliedUnits
        {
            get { return _applicationInfo.TotalSprayAppliedUnits; }
            set
            {
                if (value != _applicationInfo.TotalSprayAppliedUnits)
                {
                    _applicationInfo.TotalSprayAppliedUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.TOTAL_SPRAY_APPLIED_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.TOTAL_SPRAY_APPLIED);
                }
            }
        }

        public string TotalSprayApplied
        {
            get { return _applicationInfo.TotalSprayApplied; }
            set
            {
                if (value == _applicationInfo.TotalSprayApplied)
                    return;

                _applicationInfo.TotalSprayApplied = value;
                base.OnPropertyChanged(ApplicationInfoModel.TOTAL_SPRAY_APPLIED);
            }
        }

        public Area.Units AreaTreatedUnits
        {
            get { return _applicationInfo.AreaTreatedUnits; }
            set
            {
                if (value != _applicationInfo.AreaTreatedUnits)
                {
                    _applicationInfo.AreaTreatedUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.AREA_TREATED_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.AREA_TREATED);
                }
            }
        }

        public string AreaTreated
        {
            get { return _applicationInfo.AreaTreated; }
            set
            {
                if (value == _applicationInfo.AreaTreated)
                    return;

                _applicationInfo.AreaTreated = value;
                base.OnPropertyChanged(ApplicationInfoModel.AREA_TREATED);
            }
        }

        public string HumidityMax
        {
            get { return _applicationInfo.HumidityMax; }
            set
            {
                if (value == _applicationInfo.HumidityMax)
                    return;

                _applicationInfo.HumidityMax = value;
                base.OnPropertyChanged(ApplicationInfoModel.HUMIDITY_MAX);
            }
        }

        public string HumidityMin
        {
            get { return _applicationInfo.HumidityMin; }
            set
            {
                if (value == _applicationInfo.HumidityMax)
                    return;

                _applicationInfo.HumidityMin = value;
                base.OnPropertyChanged(ApplicationInfoModel.HUMIDITY_MIN);
            }
        }

        public string Humidity
        {
            get { return _applicationInfo.Humidity; }
            set
            {
                if (value == _applicationInfo.Humidity)
                    return;

                _applicationInfo.Humidity = value;
                base.OnPropertyChanged(ApplicationInfoModel.HUMIDITY);
            }
        }

        public Temperature.Units TemperatureMaxUnits
        {
            get { return _applicationInfo.TemperatureMaxUnits; }
            set
            {
                if (value != _applicationInfo.TemperatureMaxUnits)
                {
                    _applicationInfo.TemperatureMaxUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_MAX_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_MAX);
                }
            }
        }

        public string TemperatureMax
        {
            get { return _applicationInfo.TemperatureMax; }
            set
            {
                if (value == _applicationInfo.TemperatureMax)
                    return;

                _applicationInfo.TemperatureMax = value;
                base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_MAX);
            }
        }

        public Temperature.Units TemperatureMinUnits
        {
            get { return _applicationInfo.TemperatureMinUnits; }
            set
            {
                if (value != _applicationInfo.TemperatureMinUnits)
                {
                    _applicationInfo.TemperatureMinUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_MIN_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_MIN);
                }
            }
        }

        public string TemperatureMin
        {
            get { return _applicationInfo.TemperatureMin; }
            set
            {
                if (value == _applicationInfo.TemperatureMin)
                    return;

                _applicationInfo.TemperatureMin = value;
                base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_MIN);
            }
        }

        public Temperature.Units TemperatureUnits
        {
            get { return _applicationInfo.TemperatureUnits; }
            set
            {
                if (value != _applicationInfo.TemperatureUnits)
                {
                    _applicationInfo.TemperatureUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE);
                }
            }
        }

        public string Temperature
        {
            get { return _applicationInfo.Temperature; }
            set
            {
                if (value == _applicationInfo.Temperature)
                    return;

                _applicationInfo.Temperature = value;
                base.OnPropertyChanged(ApplicationInfoModel.TEMPERATURE);
            }
        }

        public Velocity.Units WindSpeedMaxUnits
        {
            get { return _applicationInfo.WindSpeedMaxUnits; }
            set
            {
                if (value != _applicationInfo.WindSpeedMaxUnits)
                {
                    _applicationInfo.WindSpeedMaxUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_MAX_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_MAX);
                }
            }
        }

        public string WindSpeedMax
        {
            get { return _applicationInfo.WindSpeedMax; }
            set
            {
                if (value == _applicationInfo.WindSpeedMax)
                    return;

                _applicationInfo.WindSpeedMax = value;
                base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_MAX);
            }
        }

        public Velocity.Units WindSpeedMinUnits
        {
            get { return _applicationInfo.WindSpeedMinUnits; }
            set
            {
                if (value != _applicationInfo.WindSpeedMinUnits)
                {
                    _applicationInfo.WindSpeedMinUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_MIN_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_MIN);
                }
            }
        }

        public string WindSpeedMin
        {
            get { return _applicationInfo.WindSpeedMin; }
            set
            {
                if (value == _applicationInfo.WindSpeedMin)
                    return;

                _applicationInfo.WindSpeedMin = value;
                base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_MIN);
            }
        }

        public Velocity.Units WindSpeedUnits
        {
            get { return _applicationInfo.WindSpeedUnits; }
            set
            {
                if (value != _applicationInfo.WindSpeedUnits)
                {
                    _applicationInfo.WindSpeedUnits = value;
                    base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED_UNITS);
                    base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED);
                }
            }
        }

        public string WindSpeed
        {
            get { return _applicationInfo.WindSpeed; }
            set
            {
                if (value == _applicationInfo.WindSpeed)
                    return;

                _applicationInfo.WindSpeed = value;
                base.OnPropertyChanged(ApplicationInfoModel.WIND_SPEED);
            }
        }

        #endregion MixingInfo Properties

    }
}

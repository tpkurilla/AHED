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

        #region MixingInfo Properties

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

        public Length CropHeight
        {
            get { return _applicationInfo.CropHeight; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.CropHeight)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.CropHeight.OriginalUnits
                    && value.OriginalValue == _applicationInfo.CropHeight.OriginalValue)
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

        public Length SpacingBetweenRows
        {
            get { return _applicationInfo.SpacingBetweenRows; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.SpacingBetweenRows)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.SpacingBetweenRows.OriginalUnits
                    && value.OriginalValue == _applicationInfo.SpacingBetweenRows.OriginalValue)
                    return;

                _applicationInfo.SpacingBetweenRows = value;
                base.OnPropertyChanged(ApplicationInfoModel.SPACING_BETWEEN_ROWS);
            }
        }

        public Velocity GroundSpeed
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

        public Length BoomHeight
        {
            get { return _applicationInfo.BoomHeight; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.BoomHeight)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.BoomHeight.OriginalUnits
                    && value.OriginalValue == _applicationInfo.BoomHeight.OriginalValue)
                    return;

                _applicationInfo.BoomHeight = value;
                base.OnPropertyChanged(ApplicationInfoModel.BOOM_HEIGHT);
            }
        }

        public Length BoomWidth
        {
            get { return _applicationInfo.BoomWidth; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.BoomWidth)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.BoomWidth.OriginalUnits
                    && value.OriginalValue == _applicationInfo.BoomWidth.OriginalValue)
                    return;

                _applicationInfo.BoomWidth = value;
                base.OnPropertyChanged(ApplicationInfoModel.BOOM_WIDTH);
            }
        }

        public Length SwathWidth
        {
            get { return _applicationInfo.SwathWidth; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.SwathWidth)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.SwathWidth.OriginalUnits
                    && value.OriginalValue == _applicationInfo.SwathWidth.OriginalValue)
                    return;

                _applicationInfo.SwathWidth = value;
                base.OnPropertyChanged(ApplicationInfoModel.SWATH_WIDTH);
            }
        }

        public Length BandWidth
        {
            get { return _applicationInfo.BandWidth; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.BandWidth)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.BandWidth.OriginalUnits
                    && value.OriginalValue == _applicationInfo.BandWidth.OriginalValue)
                    return;

                _applicationInfo.BandWidth = value;
                base.OnPropertyChanged(ApplicationInfoModel.BAND_WIDTH);
            }
        }

        public Length Depth
        {
            get { return _applicationInfo.Depth; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.Depth)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.Depth.OriginalUnits
                    && value.OriginalValue == _applicationInfo.Depth.OriginalValue)
                    return;

                _applicationInfo.Depth = value;
                base.OnPropertyChanged(ApplicationInfoModel.DEPTH);
            }
        }

        public double? DiskSize
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

        public int? NumberOfNozzles
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

        public Pressure NozzlePressure
        {
            get { return _applicationInfo.NozzlePressure; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.NozzlePressure)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.NozzlePressure.OriginalUnits
                    && value.OriginalValue == _applicationInfo.NozzlePressure.OriginalValue)
                    return;

                _applicationInfo.NozzlePressure = value;
                base.OnPropertyChanged(ApplicationInfoModel.NOZZLE_PRESSURE);
            }
        }

        public Volume SprayerTankCapacity
        {
            get { return _applicationInfo.SprayerTankCapacity; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.SprayerTankCapacity)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.SprayerTankCapacity.OriginalUnits
                    && value.OriginalValue == _applicationInfo.SprayerTankCapacity.OriginalValue)
                    return;

                _applicationInfo.SprayerTankCapacity = value;
                base.OnPropertyChanged(ApplicationInfoModel.SPRAYER_TANK_CAPACITY);
            }
        }

        public Volume HopperCapacity
        {
            get { return _applicationInfo.HopperCapacity; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.HopperCapacity)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.HopperCapacity.OriginalUnits
                    && value.OriginalValue == _applicationInfo.HopperCapacity.OriginalValue)
                    return;

                _applicationInfo.HopperCapacity = value;
                base.OnPropertyChanged(ApplicationInfoModel.HOPPER_CAPACITY);
            }
        }

        public double? TotalLoadsApplied
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

        public Mass TotalAiApplied
        {
            get { return _applicationInfo.TotalAiApplied; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.TotalAiApplied)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.TotalAiApplied.OriginalUnits
                    && value.OriginalValue == _applicationInfo.TotalAiApplied.OriginalValue)
                    return;

                _applicationInfo.TotalAiApplied = value;
                base.OnPropertyChanged(ApplicationInfoModel.TOTAL_AI_APPLIED);
            }
        }

        public Volume TotalSprayApplied
        {
            get { return _applicationInfo.TotalSprayApplied; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.TotalSprayApplied)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.TotalSprayApplied.OriginalUnits
                    && value.OriginalValue == _applicationInfo.TotalSprayApplied.OriginalValue)
                    return;

                _applicationInfo.TotalSprayApplied = value;
                base.OnPropertyChanged(ApplicationInfoModel.TOTAL_SPRAY_APPLIED);
            }
        }

        public Area AreaTreated
        {
            get { return _applicationInfo.AreaTreated; }
            set
            {
                // If this is the same object, then it has not changed
                if (value == _applicationInfo.AreaTreated)
                    return;

                // If the units and the values are the same, then it has not changed
                if (value.OriginalUnits == _applicationInfo.AreaTreated.OriginalUnits
                    && value.OriginalValue == _applicationInfo.AreaTreated.OriginalValue)
                    return;

                _applicationInfo.AreaTreated = value;
                base.OnPropertyChanged(ApplicationInfoModel.AREA_TREATED);
            }
        }

        public double? HumidityMax
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

        public double? HumidityMin
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

        public double? Humidity
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

        public Temperature TemperatureMax
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

        public Temperature TemperatureMin
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

        public Temperature Temperature
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

        public Velocity WindSpeedMax
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

        public Velocity WindSpeedMin
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

        public Velocity WindSpeed
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

using System;
using System.Collections.Generic;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>ProductInfo</c> for editable viewing such as in DataEntry.
    /// </summary>
    public class ApplicationInfoModel : Model<ApplicationInfo>, IDeepClone<ApplicationInfoModel>
    {
        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidEquipmentUseds = StaticValues.GroupOptions(StaticValues.Groups.AppEquipment);

        public readonly List<StaticItem> ValidEngineeringControls = StaticValues.GroupOptions(StaticValues.Groups.MixLoadEngControls);

        public readonly List<StaticItem> ValidReportings = StaticValues.GroupOptions(StaticValues.Groups.Reporting);

        public readonly List<StaticItem> ValidFoliageDensities = StaticValues.GroupOptions(StaticValues.Groups.Foliage);

        public readonly List<StaticItem> ValidDiluents = StaticValues.GroupOptions(StaticValues.Groups.Diluent);

        #endregion Valid Options for StaticItems

        #region Properties

        public StaticItem EquipmentUsed
        {
            get { return Value.EquipmentUsed; }
            set
            {
                if (value != Value.EquipmentUsed)
                {
                    if (ValidateEquipmentUsed(value))
                        Value.EquipmentUsed = value;
                }
            }
        }

        private string _equipmentMonitoringMedia;
        public string EquipmentMonitoringMedia
        {
            get { return _equipmentMonitoringMedia; }
            set
            {
                if (value != _equipmentMonitoringMedia)
                {
                    _equipmentMonitoringMedia = value;
                    if (ValidateEquipmentMonitoringMedia(value))
                        Value.EquipmentMonitoringMedia = value;
                }
            }
        }

        public StaticItem Repairs
        {
            get { return Value.Repairs; }
            set
            {
                if (value != Value.Repairs)
                {
                    if (ValidateRepairs(value))
                        Value.Repairs = value;
                }
            }
        }

        private string _applicationMakeModel;
        public string ApplicationMakeModel
        {
            get { return _applicationMakeModel; }
            set
            {
                if (value != Value.ApplicationMakeModel)
                {
                    _applicationMakeModel = value;
                    if (ValidateApplicationMakeModel(value))
                        Value.ApplicationMakeModel = value;
                }
            }
        }

        private string _vehicleMakeModel;
        public string VehicleMakeModel
        {
            get { return _vehicleMakeModel; }
            set
            {
                if (value != _vehicleMakeModel)
                {
                    _vehicleMakeModel = value;
                    if (ValidateVehicleMakeModel(value))
                        Value.VehicleMakeModel = value;
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

        private string _vehicleDescription;
        public string VehicleDescription
        {
            get { return _vehicleDescription; }
            set
            {
                if (value != _vehicleDescription)
                {
                    _vehicleDescription = value;
                    if (ValidateVehicleDescription(value))
                        Value.VehicleDescription = value;
                }
            }
        }

        private string _incidentalExposure;
        public string IncidentalExposure
        {
            get { return Value.IncidentalExposure; }
            set
            {
                if (value != _incidentalExposure)
                {
                    _incidentalExposure = value;
                    if (ValidateIncidentalExposure(value))
                        Value.IncidentalExposure = value;
                }
            }
        }

        private string _cropTreated;
        public string CropTreated
        {
            get { return _cropTreated; }
            set
            {
                if (value != _cropTreated)
                {
                    _cropTreated = value;
                    if (ValidateCropTreated(value))
                        Value.CropTreated = value;
                }
            }
        }

        public StaticItem EngineeringControls
        {
            get { return Value.EngineeringControls; }
            set
            {
                if (value != Value.EngineeringControls)
                {
                    if (ValidateEngineeringControls(value))
                        Value.EngineeringControls = value;
                }
            }
        }

        private string _engineeringControlsComment;
        public string EngineeringControlsComment
        {
            get { return _engineeringControlsComment; }
            set
            {
                if (value != _engineeringControlsComment)
                {
                    _engineeringControlsComment = value;
                    if (ValidateEngineeringControlsComment(value))
                        Value.EngineeringControlsComment = value;
                }
            }
        }

        private string _engineeringMakeModel;
        public string EngineeringMakeModel
        {
            get { return _engineeringMakeModel; }
            set
            {
                if (value != _engineeringMakeModel)
                {
                    _engineeringMakeModel = value;
                    if (ValidateEngineeringMakeModel(value))
                        Value.EngineeringMakeModel = value;
                }
            }
        }

        private string _procedureAndEquipment;
        public string ProcedureAndEquipment
        {
            get { return _procedureAndEquipment; }
            set
            {
                if (value != _procedureAndEquipment)
                {
                    _procedureAndEquipment = value;
                    if (ValidateProcedureAndEquipment(value))
                        Value.ProcedureAndEquipment = value;
                }
            }
        }

        private Length.Units _cropHeightUnits;
        public Length.Units CropHeightUnits
        {
            get { return _cropHeightUnits; }
            set
            {
                if (value != _cropHeightUnits)
                {
                    _cropHeightUnits = value;
                    _cropHeightText =
                        (Value.CropHeight != null)
                            ? Length.Convert(Value.CropHeight, _cropHeightUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _cropHeightText;
        public string CropHeight
        {
            get { return _cropHeightText; }
            set
            {
                if (value != _cropHeightText)
                {
                    Length newHeight;
                    if (ValidateCropHeight(value, out newHeight))
                    {
                        Value.CropHeight = newHeight;
                        _cropHeightText =
                            (newHeight != null)
                                ? Length.Convert(newHeight, _cropHeightUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        public StaticItem FoliageDensity
        {
            get { return Value.FoliageDensity; }
            set
            {
                if (value != Value.FoliageDensity)
                {
                    if (ValidateFoliageDensity(value))
                        Value.FoliageDensity = value;
                }
            }
        }

        public StaticItem Diluent
        {
            get { return Value.Diluent; }
            set
            {
                if (value != Value.Diluent)
                {
                    if (ValidateDiluent(value))
                        Value.Diluent = value;
                }
            }
        }

        private string _additives;
        public string Additives
        {
            get { return _additives; }
            set
            {
                if (value != _additives)
                {
                    _additives = value;
                    if (ValidateAdditives(value))
                        Value.Additives = value;
                }
            }
        }

        private Length.Units _spacingBetweenRowsUnits;
        public Length.Units SpacingBetweenRowsUnits
        {
            get { return _spacingBetweenRowsUnits; }
            set
            {
                if (value != _spacingBetweenRowsUnits)
                {
                    _spacingBetweenRowsUnits = value;
                    _spacingBetweenRowsText =
                        (Value.SpacingBetweenRows != null)
                            ? Length.Convert(Value.SpacingBetweenRows, _spacingBetweenRowsUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _spacingBetweenRowsText;
        public string SpacingBetweenRows
        {
            get { return _spacingBetweenRowsText; }
            set
            {
                if (value != _spacingBetweenRowsText)
                {
                    Length spacing;
                    if (ValidateSpacingBetweenRows(value, out spacing))
                    {
                        Value.SpacingBetweenRows = spacing;
                        _spacingBetweenRowsText =
                            (spacing != null)
                                ? Length.Convert(spacing, _spacingBetweenRowsUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Velocity.Units _groundSpeedUnits;
        public Velocity.Units GroundSpeedUnits
        {
            get { return _groundSpeedUnits; }
            set
            {
                if (value != _groundSpeedUnits)
                {
                    _groundSpeedUnits = value;
                    _spacingBetweenRowsText =
                        (Value.SpacingBetweenRows != null)
                            ? Velocity.Convert(Value.GroundSpeed, _groundSpeedUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _groundSpeedText;
        public string GroundSpeed
        {
            get { return _groundSpeedText; }
            set
            {
                if (value != _groundSpeedText)
                {
                    Velocity speed;
                    if (ValidateGroundSpeed(value, out speed))
                    {
                        Value.GroundSpeed = speed;
                        _groundSpeedText =
                            (speed != null)
                                ? Velocity.Convert(speed, _groundSpeedUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Length.Units _boomHeightUnits;
        public Length.Units BoomHeightUnits
        {
            get { return _boomHeightUnits; }
            set
            {
                if (value != _boomHeightUnits)
                {
                    _boomHeightUnits = value;
                    _boomHeightText =
                        (Value.BoomHeight != null)
                            ? Length.Convert(Value.BoomHeight, _boomHeightUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _boomHeightText;
        public string BoomHeight
        {
            get { return _boomHeightText; }
            set
            {
                if (value != _boomHeightText)
                {
                    Length height;
                    if (ValidateBoomHeight(value, out height))
                    {
                        Value.SpacingBetweenRows = height;
                        _boomHeightText =
                            (height != null)
                                ? Length.Convert(height, _boomHeightUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Length.Units _boomWidthUnits;
        public Length.Units BoomWidthUnits
        {
            get { return _boomWidthUnits; }
            set
            {
                if (value != _boomWidthUnits)
                {
                    _boomWidthUnits = value;
                    _boomWidthText =
                        (Value.BoomWidth != null)
                            ? Length.Convert(Value.BoomWidth, _boomWidthUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _boomWidthText;
        public string BoomWidth
        {
            get { return _boomWidthText; }
            set
            {
                if (value != _boomWidthText)
                {
                    Length width;
                    if (ValidateBoomWidth(value, out width))
                    {
                        Value.BoomWidth = width;
                        _boomWidthText =
                            (width != null)
                                ? Length.Convert(width, _boomWidthUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Length.Units _swathWidthUnits;
        public Length.Units SwathWidthUnits
        {
            get { return _swathWidthUnits; }
            set
            {
                if (value != _swathWidthUnits)
                {
                    _swathWidthUnits = value;
                    _swathWidthText =
                        (Value.SwathWidth != null)
                            ? Length.Convert(Value.SwathWidth, _swathWidthUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _swathWidthText;
        public string SwathWidth
        {
            get { return _swathWidthText; }
            set
            {
                if (value != _swathWidthText)
                {
                    Length width;
                    if (ValidateSwathWidth(value, out width))
                    {
                        Value.SwathWidth = width;
                        _swathWidthText =
                            (width != null)
                                ? Length.Convert(width, _swathWidthUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Length.Units _bandWidthUnits;
        public Length.Units BandWidthUnits
        {
            get { return _bandWidthUnits; }
            set
            {
                if (value != _bandWidthUnits)
                {
                    _bandWidthUnits = value;
                    _bandWidthText =
                        (Value.BandWidth != null)
                            ? Length.Convert(Value.BandWidth, _bandWidthUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _bandWidthText;
        public string BandWidth
        {
            get { return _bandWidthText; }
            set
            {
                if (value != _bandWidthText)
                {
                    Length width;
                    if (ValidateBandWidth(value, out width))
                    {
                        Value.BandWidth = width;
                        _bandWidthText =
                            (width != null)
                                ? Length.Convert(width, _bandWidthUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Length.Units _depthUnits;
        public Length.Units DepthUnits
        {
            get { return _depthUnits; }
            set
            {
                if (value != _depthUnits)
                {
                    _depthUnits = value;
                    _depthText =
                        (Value.Depth != null)
                            ? Length.Convert(Value.Depth, _depthUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _depthText;
        public string Depth
        {
            get { return _depthText; }
            set
            {
                if (value != _depthText)
                {
                    Length depth;
                    if (ValidateDepth(value, out depth))
                    {
                        Value.Depth = depth;
                        _bandWidthText =
                            (depth != null)
                                ? Length.Convert(depth, _depthUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private string _diskSizeText;
        public string DiskSize
        {
            get { return _diskSizeText; }
            set
            {
                if (value != _diskSizeText)
                {
                    double? diskSize;
                    if (!ValidateDiskSize(value, out diskSize))
                    {
                        _diskSizeText = value;
                    }
                    else
                    {
                        Value.DiskSize = diskSize;
                        _diskSizeText = (diskSize != null) ? diskSize.ToString() : String.Empty;
                    }
                }
            }
        }

        private string _numberOfNozzlesText;
        public string NumberOfNozzles
        {
            get { return _numberOfNozzlesText; }
            set
            {
                if (value != _numberOfNozzlesText)
                {
                    int? numberOfNozzles;
                    if (!ValidateNumberOfNozzles(value, out numberOfNozzles))
                    {
                        _numberOfNozzlesText = value;
                    }
                    else
                    {
                        Value.NumberOfNozzles = numberOfNozzles;
                        _numberOfNozzlesText = (numberOfNozzles != null) ? numberOfNozzles.ToString() : String.Empty;
                    }
                }
            }
        }

        private string _nozzleType;
        public string NozzleType
        {
            get { return _nozzleType; }
            set
            {
                if (value != _nozzleType)
                {
                    _nozzleType = value;
                    if (ValidateNozzleType(value))
                        Value.NozzleType = value;
                }
            }
        }

        private string _nozzleModel;
        public string NozzleModel
        {
            get { return _nozzleModel; }
            set
            {
                if (value != _nozzleModel)
                {
                    _nozzleModel = value;
                    if (ValidateNozzleModel(value))
                        Value.NozzleModel = value;
                }
            }
        }

        private Pressure.Units _nozzlePressureUnits;
        public Pressure.Units NozzlePressureUnits
        {
            get { return _nozzlePressureUnits; }
            set
            {
                if (value != _nozzlePressureUnits)
                {
                    _nozzlePressureUnits = value;
                    _nozzlePressureText =
                        (Value.NozzlePressure != null)
                            ? Pressure.Convert(Value.NozzlePressure, _nozzlePressureUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _nozzlePressureText;
        public string NozzlePressure
        {
            get { return _nozzlePressureText; }
            set
            {
                if (value != _nozzlePressureText)
                {
                    Pressure pressure;
                    if (ValidateNozzlePressure(value, out pressure))
                    {
                        Value.NozzlePressure = pressure;
                        _nozzlePressureText =
                            (pressure != null)
                                ? Pressure.Convert(pressure, _nozzlePressureUnits).ToString(Culture.Info)
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

        private string _totalLoadsAppliedText;
        public string TotalLoadsApplied
        {
            get { return _totalLoadsAppliedText; }
            set
            {
                if (value != _totalLoadsAppliedText)
                {
                    double? totalLoadsApplied;
                    if (!ValidateTotalLoadsApplied(value, out totalLoadsApplied))
                    {
                        _totalLoadsAppliedText = value;
                    }
                    else
                    {
                        Value.TotalLoadsApplied = totalLoadsApplied;
                        _totalLoadsAppliedText = (totalLoadsApplied != null) ? totalLoadsApplied.ToString() : String.Empty;
                    }
                }
            }
        }

        private Mass.Units _totalAiAppliedUnits;
        public Mass.Units TotalAiAppliedUnits
        {
            get { return _totalAiAppliedUnits; }
            set
            {
                if (value != _totalAiAppliedUnits)
                {
                    _totalAiAppliedUnits = value;
                    _totalAiAppliedText =
                        (Value.TotalAiApplied != null)
                            ? Mass.Convert(Value.TotalAiApplied, _totalAiAppliedUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _totalAiAppliedText;
        public string TotalAiApplied
        {
            get { return _totalAiAppliedText; }
            set
            {
                if (value != _totalAiAppliedText)
                {
                    Mass totalAiApplied;
                    if (!ValidateTotalAiApplied(value, out totalAiApplied))
                    {
                        _totalAiAppliedText = value;
                    }
                    else
                    {
                        Value.TotalAiApplied = totalAiApplied;
                        _totalAiAppliedText =
                            (totalAiApplied != null)
                                ? Mass.Convert(totalAiApplied, _totalAiAppliedUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Volume.Units _totalSprayAppliedUnits;
        public Volume.Units TotalSprayAppliedUnits
        {
            get { return _totalSprayAppliedUnits; }
            set
            {
                if (value != _totalSprayAppliedUnits)
                {
                    _totalSprayAppliedUnits = value;
                    _totalSprayAppliedText =
                        (Value.TotalSprayApplied != null)
                            ? Volume.Convert(Value.TotalSprayApplied, _totalSprayAppliedUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _totalSprayAppliedText;
        public string TotalSprayApplied
        {
            get { return _totalSprayAppliedText; }
            set
            {
                if (value != _totalSprayAppliedText)
                {
                    Volume capacity;
                    if (!ValidateTotalSprayApplied(value, out capacity))
                    {
                        _totalSprayAppliedText = value;
                    }
                    else
                    {
                        Value.TotalSprayApplied = capacity;
                        _totalSprayAppliedText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _totalSprayAppliedUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Area.Units _areaTreatedUnits;
        public Area.Units AreaTreatedUnits
        {
            get { return _areaTreatedUnits; }
            set
            {
                if (value != _areaTreatedUnits)
                {
                    _areaTreatedUnits = value;
                    _areaTreatedText =
                        (Value.AreaTreated != null)
                            ? Area.Convert(Value.AreaTreated, _areaTreatedUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _areaTreatedText;
        public string AreaTreated
        {
            get { return _areaTreatedText; }
            set
            {
                if (value != _areaTreatedText)
                {
                    Area area;
                    if (!ValidateAreaTreated(value, out area))
                    {
                        _areaTreatedText = value;
                    }
                    else
                    {
                        Value.AreaTreated = area;
                        _areaTreatedText =
                            (area != null)
                                ? Area.Convert(area, _areaTreatedUnits).ToString(Culture.Info)
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
                        Value.HumidityMax = humidity;
                        _humidityMaxText = (humidity != null) ? humidity.ToString() : String.Empty;
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

        #region Constructor

        public ApplicationInfoModel(){}

        public ApplicationInfoModel(ApplicationInfo appInfo)
            : base(appInfo)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public ApplicationInfoModel(ApplicationInfoModel model)
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
            EquipmentUsed = Value.EquipmentUsed;
            EquipmentMonitoringMedia = Value.EquipmentMonitoringMedia;
            Repairs = Value.Repairs;
            ApplicationMakeModel = Value.ApplicationMakeModel;
            VehicleMakeModel = Value.VehicleMakeModel;
            Cleanup = Value.Cleanup;
            VehicleDescription = Value.VehicleDescription;
            IncidentalExposure = Value.IncidentalExposure;
            CropTreated = Value.CropTreated;
            EngineeringControls = Value.EngineeringControls;
            EngineeringControlsComment = Value.EngineeringControlsComment;
            EngineeringMakeModel = Value.EngineeringMakeModel;
            ProcedureAndEquipment = Value.ProcedureAndEquipment;
            Length.InOrCmTextAndUnits(Value.CropHeight, out _cropHeightText, out _cropHeightUnits);
            FoliageDensity = Value.FoliageDensity;
            Diluent = Value.Diluent;
            Additives = Value.Additives;
            Length.FtOrMTextAndUnits(Value.SpacingBetweenRows, out _spacingBetweenRowsText, out _spacingBetweenRowsUnits);
            Velocity.MphOrKphTextAndUnits(Value.GroundSpeed, out _groundSpeedText, out _groundSpeedUnits);
            Length.InOrCmTextAndUnits(Value.BoomHeight, out _boomWidthText, out _boomHeightUnits);
            Length.FtOrMTextAndUnits(Value.BoomWidth, out _boomWidthText, out _boomWidthUnits);
            Length.FtOrMTextAndUnits(Value.SwathWidth, out _swathWidthText, out _swathWidthUnits);
            Length.InOrCmTextAndUnits(Value.BandWidth, out _bandWidthText, out _bandWidthUnits);
            Length.InOrCmTextAndUnits(Value.Depth, out _depthText, out _depthUnits);
            DiskSize = Value.DiskSize.HasValue ? Value.DiskSize.ToString() : String.Empty;
            NumberOfNozzles = Value.NumberOfNozzles.HasValue ? Value.NumberOfNozzles.ToString() : String.Empty;
            NozzleType = Value.NozzleType;
            NozzleModel = Value.NozzleModel;
            Pressure.TextAndUnits(Value.NozzlePressure, out _nozzlePressureText, out _nozzlePressureUnits);
            Volume.TextAndUnits(Value.SprayerTankCapacity, out _sprayerTankCapacityText, out _sprayerTankCapacityUnits);
            Volume.TextAndUnits(Value.HopperCapacity, out _hopperCapacityText, out _hopperCapacityUnits);
            TotalLoadsApplied = Value.TotalLoadsApplied.HasValue ? Value.TotalLoadsApplied.ToString() : String.Empty;
            Mass.TextAndUnits(Value.TotalAiApplied, out _totalAiAppliedText, out _totalAiAppliedUnits);
            Volume.TextAndUnits(Value.TotalSprayApplied, out _totalSprayAppliedText, out _totalSprayAppliedUnits);
            Area.TextAndUnits(Value.AreaTreated, out _areaTreatedText, out _areaTreatedUnits);
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

        #endregion

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string EquipmentUsedName = "EquipmentUsed";
        public const string EquipmentMonitoringMediaName = "EquipmentMonitoringMedia";
        public const string RepairsName = "Repairs";
        public const string ApplicationMakeModelName = "ApplicationMakeModel";
        public const string VehicleMakeModelName = "VehicleMakeModel";
        public const string CleanupName = "Cleanup";
        public const string VehicleDescriptionName = "VehicleDescription";
        public const string IncidentalExposureName = "IncidentalExposure";
        public const string CropTreatedName = "CropTreated";
        public const string EngineeringControlsName = "EngineeringControls";
        public const string EngineeringControlsCommentName = "EngineeringControlsComment";
        public const string EngineeringMakeModelName = "EngineeringMakeModel";
        public const string ProcedureAndEquipmentName = "ProcedureAndEquipment";
        public const string CropHeightName = "CropHeight";
        public const string FoliageDensityName = "FoliageDensity";
        public const string DiluentName = "Diluent";
        public const string AdditivesName = "Additives";
        public const string SpacingBetweenRowsName = "SpacingBetweenRows";
        public const string GroundSpeedName = "GroundSpeed";
        public const string BoomHeightName = "BoomHeight";
        public const string BoomWidthName = "BoomWidth";
        public const string SwathWidthName = "SwathWidth";
        public const string BandWidthName = "BandWidth";
        public const string DepthName = "Depth";
        public const string DiskSizeName = "DiskSize";
        public const string NumberOfNozzlesName = "NumberOfNozzles";
        public const string NozzleTypeName = "NozzleType";
        public const string NozzleModelName = "NozzleModel";
        public const string NozzlePressureName = "NozzlePressure";
        public const string SprayerTankCapacityName = "SprayerTankCapacity";
        public const string HopperCapacityName = "HopperCapacity";
        public const string TotalLoadsAppliedName = "TotalLoadsApplied";
        public const string TotalAiAppliedName = "TotalAiApplied";
        public const string TotalSprayAppliedName = "TotalSprayApplied";
        public const string AreaTreatedName = "AreaTreated";
        public const string HumidityMaxName = "HumidityMax";
        public const string HumidityMinName = "HumidityMin";
        public const string HumidityName = "Humidity";
        public const string TemperatureMaxName = "TemperatureMax";
        public const string TemperatureMinName = "TemperatureMin";
        public const string TemperatureName = "Temperature";
        public const string WindSpeedMaxName = "WindSpeedMax";
        public const string WindSpeedMinName = "WindSpeedMin";
        public const string WindSpeedName = "WindSpeed";

        // Not properties of ApplicationInfo, but properties for this model
        public const string CropHeightUnitsName = "CropHeightUnits";
        public const string SpacingBetweenRowsUnitsName = "SpacingBetweenRowsUnits";
        public const string GroundSpeedUnitsName = "GroundSpeedUnits";
        public const string BoomHeightUnitsName = "BoomHeightUnits";
        public const string BoomWidthUnitsName = "BoomWidthUnits";
        public const string SwathWidthUnitsName = "SwathWidthUnits";
        public const string BandWidthUnitsName = "BandWidthUnits";
        public const string DepthUnitsName = "DepthUnits";
        public const string NozzlePressureUnitsName = "NozzlePressureUnits";
        public const string SprayerTankCapacityUnitsName = "SprayerTankCapacityUnits";
        public const string HopperCapacityUnitsName = "HopperCapacityUnits";
        public const string TotalAiAppliedUnitsName = "TotalAiAppliedUnits";
        public const string TotalSprayAppliedUnitsName = "TotalSprayAppliedUnits";
        public const string AreaTreatedUnitsName = "AreaTreatedUnits";
        public const string TemperatureMaxUnitsName = "TemperatureMaxUnits";
        public const string TemperatureMinUnitsName = "TemperatureMinUnits";
        public const string TemperatureUnitsName = "TemperatureUnits";
        public const string WindSpeedMaxUnitsName = "WindSpeedMaxUnits";
        public const string WindSpeedMinUnitsName = "WindSpeedMinUnits";
        public const string WindSpeedUnitsName = "WindSpeedUnits";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EquipmentUsed</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[AppEquipment] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EquipmentUsed</c>.</returns>
        private bool ValidateEquipmentUsed(StaticItem value)
        {
            if (value == null || ValidEquipmentUseds.Contains(value))
            {
                RemoveError(EquipmentUsedName, Properties.Resources.ApplicationInfo_Invalid_Equipment_Used);
                return true;
            }

            AddError(EquipmentUsedName, Properties.Resources.ApplicationInfo_Invalid_Equipment_Used, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EquipmentMonitoringMedia</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EquipmentMonitoringMedia</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateEquipmentMonitoringMedia(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
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
                RemoveError(RepairsName, Properties.Resources.ApplicationInfo_Invalid_Repairs);
                return true;
            }

            AddError(RepairsName, Properties.Resources.ApplicationInfo_Invalid_Repairs, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ApplicationMakeModel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ApplicationMakeModel</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateApplicationMakeModel(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VehicleMakeModel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VehicleMakeModel</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateVehicleMakeModel(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
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
                RemoveError(CleanupName, Properties.Resources.ApplicationInfo_Invalid_Cleanup);
                return true;
            }

            AddError(CleanupName, Properties.Resources.ApplicationInfo_Invalid_Cleanup, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VehicleDescription</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VehicleDescription</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateVehicleDescription(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>IncidentalExposure</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>IncidentalExposure</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateIncidentalExposure(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>CropTreated</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>CropTreated</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateCropTreated(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringControls</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[AppEngControls] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringControls</c>.</returns>
        private bool ValidateEngineeringControls(StaticItem value)
        {
            if (value == null || ValidEngineeringControls.Contains(value))
            {
                RemoveError(EngineeringControlsName, Properties.Resources.ApplicationInfo_Invalid_Engineering_Controls);
                return true;
            }

            AddError(EngineeringControlsName, Properties.Resources.ApplicationInfo_Invalid_Engineering_Controls, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringControlsComment</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringControlsComment</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateEngineeringControlsComment(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringMakeModel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringMakeModel</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateEngineeringMakeModel(string value)
// ReSharper restore UnusedParameter.Local
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
// ReSharper disable UnusedParameter.Local
        private bool ValidateProcedureAndEquipment(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>CropHeight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a height.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>CropHeight</c>.</returns>
        private bool ValidateCropHeight(string str, out Length value)
        {
            return ValidateLength(str, _cropHeightUnits,
                                  CropHeightName, Properties.Resources.ApplicationInfo_Invalid_CropHeight,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>FoliageDensity</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Foliage] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>FoliageDensity</c>.</returns>
        private bool ValidateFoliageDensity(StaticItem value)
        {
            if (value == null || ValidFoliageDensities.Contains(value))
            {
                RemoveError(FoliageDensityName, Properties.Resources.ApplicationInfo_Invalid_Foliage_Density);
                return true;
            }

            AddError(FoliageDensityName, Properties.Resources.ApplicationInfo_Invalid_Foliage_Density, false);
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
                RemoveError(DiluentName, Properties.Resources.ApplicationInfo_Invalid_Diluent);
                return true;
            }

            AddError(DiluentName, Properties.Resources.ApplicationInfo_Invalid_Diluent, false);
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
// ReSharper disable UnusedParameter.Local
        private bool ValidateAdditives(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>SpacingBetweenRows</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a spacing.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>SpacingBetweenRows</c>.</returns>
        private bool ValidateSpacingBetweenRows(string str, out Length value)
        {
            return ValidateLength(str, _spacingBetweenRowsUnits,
                                  SpacingBetweenRowsName, Properties.Resources.ApplicationInfo_Invalid_SpacingBetweenRows,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>GroundSpeed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a velocity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>GroundSpeed</c>.</returns>
        private bool ValidateGroundSpeed(string str, out Velocity value)
        {
            return ValidateVelocity(str, _groundSpeedUnits,
                                    GroundSpeedName, Properties.Resources.ApplicationInfo_Invalid_GroundSpeed,
                                    out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>BoomHeight</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a height.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>BoomHeight</c>.</returns>
        private bool ValidateBoomHeight(string str, out Length value)
        {
            return ValidateLength(str, _boomHeightUnits,
                                  BoomHeightName, Properties.Resources.ApplicationInfo_Invalid_BoomHeight,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>BoomWidth</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a width.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>BoomWidth</c>.</returns>
        private bool ValidateBoomWidth(string str, out Length value)
        {
            return ValidateLength(str, _boomHeightUnits,
                                  BoomWidthName, Properties.Resources.ApplicationInfo_Invalid_BoomWidth,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>SwathWidth</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a width.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>SwathWidth</c>.</returns>
        private bool ValidateSwathWidth(string str, out Length value)
        {
            return ValidateLength(str, _swathWidthUnits,
                                  SwathWidthName, Properties.Resources.ApplicationInfo_Invalid_SwathWidth,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>BandWidth</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a width.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>BandWidth</c>.</returns>
        private bool ValidateBandWidth(string str, out Length value)
        {
            return ValidateLength(str, _bandWidthUnits,
                                  BandWidthName, Properties.Resources.ApplicationInfo_Invalid_BandWidth,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Depth</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a depth.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Depth</c>.</returns>
        private bool ValidateDepth(string str, out Length value)
        {
            return ValidateLength(str, _depthUnits,
                                  DepthName, Properties.Resources.ApplicationInfo_Invalid_Depth,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>DiskSize</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a size.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>DiskSize</c>.</returns>
        private bool ValidateDiskSize(string str, out double? value)
        {
            return ValidateDouble(str, PositiveOnly,
                                  DiskSizeName, Properties.Resources.ApplicationInfo_Invalid_DiskSize,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>NumberOfNozzles</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a number of nozzles.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>NumberOfNozzles</c>.</returns>
        private bool ValidateNumberOfNozzles(string str, out int? value)
        {
            return ValidateInt(str, PositiveOnly,
                               NumberOfNozzlesName, Properties.Resources.ApplicationInfo_Invalid_NumberOfNozzles,
                               out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>NozzleType</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>NozzleType</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateNozzleType(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>NozzleModel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>NozzleModel</c>.</returns>
// ReSharper disable UnusedParameter.Local
        private bool ValidateNozzleModel(string value)
// ReSharper restore UnusedParameter.Local
        {
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>NozzlePressure</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a pressure.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>NozzlePressure</c>.</returns>
        private bool ValidateNozzlePressure(string str, out Pressure value)
        {
            return ValidatePressure(str, _nozzlePressureUnits,
                                    NozzlePressureName, Properties.Resources.ApplicationInfo_Invalid_NozzlePressure,
                                    out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>SprayerTankCapacity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a capcacity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>SprayerTankCapacity</c>.</returns>
        private bool ValidateSprayerTankCapacity(string str, out Volume value)
        {
            return ValidateVolume(str, _sprayerTankCapacityUnits,
                                    SprayerTankCapacityName, Properties.Resources.ApplicationInfo_Invalid_SprayerTankVolume,
                                    out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>HopperCapacity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a capcacity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>HopperCapacity</c>.</returns>
        private bool ValidateHopperCapacity(string str, out Volume value)
        {
            return ValidateVolume(str, _hopperCapacityUnits,
                                  HopperCapacityName, Properties.Resources.ApplicationInfo_Invalid_HopperCapacity,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalLoadsApplied</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as an amount.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalLoadsApplied</c>.</returns>
        private bool ValidateTotalLoadsApplied(string str, out double? value)
        {
            return ValidateDouble(str, PositiveOnly,
                                  TotalLoadsAppliedName, Properties.Resources.ApplicationInfo_Invalid_TotalLoadsApplied,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalAiApplied</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalAiApplied</c>.</returns>
        private bool ValidateTotalAiApplied(string str, out Mass value)
        {
            return ValidateMass(str, _totalAiAppliedUnits,
                                TotalAiAppliedName, Properties.Resources.ApplicationInfo_Invalid_TotalAiApplied,
                                out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalSprayApplied</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalSprayApplied</c>.</returns>
        private bool ValidateTotalSprayApplied(string str, out Volume value)
        {
            return ValidateVolume(str, _totalSprayAppliedUnits,
                                  TotalSprayAppliedName, Properties.Resources.ApplicationInfo_Invalid_TotalSprayApplied,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>AreaTreated</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>AreaTreated</c>.</returns>
        private bool ValidateAreaTreated(string str, out Area value)
        {
            return ValidateArea(str, _areaTreatedUnits,
                                  AreaTreatedName, Properties.Resources.ApplicationInfo_Invalid_AreaTreated,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>HumidityMax</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value from 0 to 100.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>HumidityMax</c>.</returns>
        private bool ValidateHumidityMax(string str, out double? value)
        {
            bool isValid = ValidateDouble(str, PositiveOnly,
                                          HumidityMaxName, Properties.Resources.ApplicationInfo_Invalid_HumidityMax,
                                          out value);

            if (isValid)
            {
                if (value.HasValue)
                {
                    // Only valid if it is 0-100
                    isValid = ValidateRange(value, 0, 100,
                                            HumidityMaxName, Properties.Resources.ApplicationInfo_Invalid_HumidityMax);
                }

                // Check whether there is an issue with the current minimum
                ValidateRange(value, Value.HumidityMin, NoUpperBound,
                              HumidityMaxName, Properties.Resources.ApplicationInfo_Invalid_HumidityMaxMin);
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>HumidityMin</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value from 0 to 100.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>HumidityMin</c>.</returns>
        private bool ValidateHumidityMin(string str, out double? value)
        {
            bool isValid = ValidateDouble(str, PositiveOnly,
                                          HumidityMinName, Properties.Resources.ApplicationInfo_Invalid_HumidityMin,
                                          out value);

            if (isValid)
            {
                if (value.HasValue)
                {
                    // Only valid if it is 0-100
                    isValid = ValidateRange(value, 0, 100,
                                            HumidityMinName, Properties.Resources.ApplicationInfo_Invalid_HumidityMin);
                }

                // Check whether there is an issue with the current maximum
                ValidateRange(value, NoLowerBound, Value.HumidityMax,
                              HumidityMinName, Properties.Resources.ApplicationInfo_Invalid_HumidityMinMax);
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Humidity</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value from 0 to 100.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Humidity</c>.</returns>
        private bool ValidateHumidity(string str, out double? value)
        {
            bool isValid = ValidateDouble(str, PositiveOnly,
                                          HumidityName, Properties.Resources.ApplicationInfo_Invalid_Humidity,
                                          out value);

            if (isValid)
            {
                if (value.HasValue)
                {
                    // Only valid if it is 0-100
                    isValid = ValidateRange(value, 0, 100,
                                            HumidityName, Properties.Resources.ApplicationInfo_Invalid_Humidity);
                }

                // Check whether there is an issue with the current minimum or maximum
                ValidateRange(value, Value.HumidityMin, Value.HumidityMax,
                              HumidityName, Properties.Resources.ApplicationInfo_Invalid_HumidityBetween);
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TemperatureMax</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between -50 and +130 Fahrenheit.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TemperatureMax</c>.</returns>
        private bool ValidateTemperatureMax(string str, out Temperature value)
        {
            bool isValid = ValidateTemperature(str, _temperatureMaxUnits,
                                               TemperatureMaxName, Properties.Resources.ApplicationInfo_Invalid_TemperatureMax,
                                               out value);

            if (isValid)
            {
                // Check whether there is an issue with the current maximum
                ValidateRange(value.Value, Value.TemperatureMin.Value, NoUpperBound,
                              TemperatureMaxName, Properties.Resources.ApplicationInfo_Invalid_TemperatureMaxMin);
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TemperatureMin</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between -50 and +130 Fahrenheit.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TemperatureMin</c>.</returns>
        private bool ValidateTemperatureMin(string str, out Temperature value)
        {
            bool isValid = ValidateTemperature(str, _temperatureMinUnits,
                                               TemperatureMinName, Properties.Resources.ApplicationInfo_Invalid_TemperatureMin,
                                               out value);

            if (isValid)
            {
                // Check whether there is an issue with the current maximum
                ValidateRange(value.Value, NoLowerBound, Value.TemperatureMax.Value,
                              TemperatureMinName, Properties.Resources.ApplicationInfo_Invalid_TemperatureMinMax);
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Temperature</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any value between -50 and +130 Fahrenheit.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Temperature</c>.</returns>
        private bool ValidateTemperature(string str, out Temperature value)
        {
            bool isValid = ValidateTemperature(str, _temperatureMinUnits,
                                               TemperatureMinName, Properties.Resources.ApplicationInfo_Invalid_Temperature,
                                               out value);

            if (isValid)
            {
                // Check whether there is an issue with the current minimum
                ValidateRange(value.Value, Value.TemperatureMin.Value, Value.TemperatureMax.Value,
                              TemperatureMinName, Properties.Resources.ApplicationInfo_Invalid_TemperatureBetween);
            }

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
                                            WindSpeedMaxName, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMax,
                                            out value);

            if (isValid)
            {
                // Check whether there is an issue with the current minimum
                ValidateRange(value.Value, Value.WindSpeedMin.Value, NoUpperBound,
                              WindSpeedMaxName, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMaxMin);
            }

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
                                            WindSpeedMinName, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMin,
                                            out value);

            if (isValid)
            {
                // Check whether there is an issue with the current minimum
                ValidateRange(value.Value, NoLowerBound, Value.WindSpeedMax.Value,
                              WindSpeedMinName, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMinMax);
            }

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
                                            WindSpeedName, Properties.Resources.ApplicationInfo_Invalid_WindSpeed,
                                            out value);

            if (isValid)
            {
                // Check whether there is an issue with the current minimum
                ValidateRange(value.Value, Value.WindSpeedMin.Value, Value.WindSpeedMax.Value,
                              WindSpeedName, Properties.Resources.ApplicationInfo_Invalid_WindSpeedBetween);
            }

            return isValid;
        }

        #endregion // Specific Validations

        #endregion

        #region IDeepClone Interface

        public ApplicationInfoModel DeepClone()
        {
            return new ApplicationInfoModel(this);
        }

        #endregion IDeepClone Interface

    }
}

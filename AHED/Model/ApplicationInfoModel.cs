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
    public class ApplicationInfoModel : BaseModel
    {
        /// <summary>
        /// The <c>ApplicationInfo</c> being wrapped by this model.
        /// </summary>
        private readonly ApplicationInfo _applicationInfo;

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
            get { return _applicationInfo.EquipmentUsed; }
            set
            {
                if (_applicationInfo.EquipmentUsed != value)
                {
                    ValidateEquipmentUsed(value);
                    _applicationInfo.EquipmentUsed = value;
                }
            }
        }

        public string EquipmentMonitoringMedia
        {
            get { return _applicationInfo.EquipmentMonitoringMedia; }
            set
            {
                if (_applicationInfo.EquipmentMonitoringMedia != value)
                {
                    ValidateEquipmentMonitoringMedia(value);
                    _applicationInfo.EquipmentMonitoringMedia = value;
                }
            }
        }

        public StaticItem Repairs
        {
            get { return _applicationInfo.Repairs; }
            set
            {
                if (_applicationInfo.Repairs != value)
                {
                    ValidateRepairs(value);
                    _applicationInfo.Repairs = value;
                }
            }
        }

        public string ApplicationMakeModel
        {
            get { return _applicationInfo.ApplicationMakeModel; }
            set
            {
                if (_applicationInfo.ApplicationMakeModel != value)
                {
                    ValidateApplicationMakeModel(value);
                    _applicationInfo.ApplicationMakeModel = value;
                }
            }
        }

        public string VehicleMakeModel
        {
            get { return _applicationInfo.VehicleMakeModel; }
            set
            {
                if (_applicationInfo.VehicleMakeModel != value)
                {
                    ValidateVehicleMakeModel(value);
                    _applicationInfo.VehicleMakeModel = value;
                }
            }
        }

        public StaticItem Cleanup
        {
            get { return _applicationInfo.Cleanup; }
            set
            {
                if (_applicationInfo.Cleanup != value)
                {
                    ValidateCleanup(value);
                    _applicationInfo.Cleanup = value;
                }
            }
        }

        public string VehicleDescription
        {
            get { return _applicationInfo.VehicleDescription; }
            set
            {
                if (_applicationInfo.VehicleDescription != value)
                {
                    ValidateVehicleDescription(value);
                    _applicationInfo.VehicleDescription = value;
                }
            }
        }

        public string IncidentalExposure
        {
            get { return _applicationInfo.IncidentalExposure; }
            set
            {
                if (_applicationInfo.IncidentalExposure != value)
                {
                    ValidateIncidentalExposure(value);
                    _applicationInfo.IncidentalExposure = value;
                }
            }
        }

        public string CropTreated
        {
            get { return _applicationInfo.CropTreated; }
            set
            {
                if (_applicationInfo.CropTreated != value)
                {
                    ValidateCropTreated(value);
                    _applicationInfo.CropTreated = value;
                }
            }
        }

        public StaticItem EngineeringControls
        {
            get { return _applicationInfo.EngineeringControls; }
            set
            {
                if (_applicationInfo.EngineeringControls != value)
                {
                    ValidateEngineeringControls(value);
                    _applicationInfo.EngineeringControls = value;
                }
            }
        }

        public string EngineeringControlsComment
        {
            get { return _applicationInfo.EngineeringControlsComment; }
            set
            {
                if (_applicationInfo.EngineeringControlsComment != value)
                {
                    ValidateEngineeringControlsComment(value);
                    _applicationInfo.EngineeringControlsComment = value;
                }
            }
        }

        public string EngineeringMakeModel
        {
            get { return _applicationInfo.EngineeringMakeModel; }
            set
            {
                if (_applicationInfo.EngineeringMakeModel != value)
                {
                    ValidateEngineeringMakeModel(value);
                    _applicationInfo.EngineeringMakeModel = value;
                }
            }
        }

        public string ProcedureAndEquipment
        {
            get { return _applicationInfo.ProcedureAndEquipment; }
            set
            {
                if (_applicationInfo.ProcedureAndEquipment != value)
                {
                    ValidateProcedureAndEquipment(value);
                    _applicationInfo.ProcedureAndEquipment = value;
                }
            }
        }

        private Length.Units _cropHeightUnits;
        public Length.Units HeightUnits
        {
            get { return _cropHeightUnits; }
            set
            {
                if (value != _cropHeightUnits)
                {
                    _cropHeightUnits = value;
                    _cropHeightText =
                        (_applicationInfo.CropHeight != null)
                            ? Length.Convert(_applicationInfo.CropHeight, _cropHeightUnits).ToString()
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
                        _applicationInfo.CropHeight = newHeight;
                        _cropHeightText =
                            (newHeight != null)
                                ? Length.Convert(newHeight, _cropHeightUnits).ToString()
                                : String.Empty;
                    }
                }
            }
        }

        public StaticItem FoliageDensity
        {
            get { return _applicationInfo.FoliageDensity; }
            set
            {
                if (_applicationInfo.FoliageDensity != value)
                {
                    ValidateFoliageDensity(value);
                    _applicationInfo.FoliageDensity = value;
                }
            }
        }

        public StaticItem Diluent
        {
            get { return _applicationInfo.Diluent; }
            set
            {
                if (_applicationInfo.Diluent != value)
                {
                    ValidateDiluent(value);
                    _applicationInfo.Diluent = value;
                }
            }
        }

        public string Additives
        {
            get { return _applicationInfo.Additives; }
            set
            {
                if (_applicationInfo.Additives != value)
                {
                    ValidateAdditives(value);
                    _applicationInfo.Additives = value;
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
                        (_applicationInfo.SpacingBetweenRows != null)
                            ? Length.Convert(_applicationInfo.SpacingBetweenRows, _spacingBetweenRowsUnits).ToString()
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
                        _applicationInfo.SpacingBetweenRows = spacing;
                        _spacingBetweenRowsText =
                            (spacing != null)
                                ? Length.Convert(spacing, _spacingBetweenRowsUnits).ToString()
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
                        (_applicationInfo.SpacingBetweenRows != null)
                            ? Velocity.Convert(_applicationInfo.GroundSpeed, _groundSpeedUnits).ToString()
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
                        _applicationInfo.GroundSpeed = speed;
                        _groundSpeedText =
                            (speed != null)
                                ? Velocity.Convert(speed, _groundSpeedUnits).ToString()
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
                        (_applicationInfo.BoomHeight != null)
                            ? Length.Convert(_applicationInfo.BoomHeight, _boomHeightUnits).ToString()
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
                        _applicationInfo.SpacingBetweenRows = height;
                        _boomHeightText =
                            (height != null)
                                ? Length.Convert(height, _boomHeightUnits).ToString()
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
                        (_applicationInfo.BoomWidth != null)
                            ? Length.Convert(_applicationInfo.BoomWidth, _boomWidthUnits).ToString()
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
                        _applicationInfo.BoomWidth = width;
                        _boomWidthText =
                            (width != null)
                                ? Length.Convert(width, _boomWidthUnits).ToString()
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
                        (_applicationInfo.SwathWidth != null)
                            ? Length.Convert(_applicationInfo.SwathWidth, _swathWidthUnits).ToString()
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
                        _applicationInfo.SwathWidth = width;
                        _swathWidthText =
                            (width != null)
                                ? Length.Convert(width, _swathWidthUnits).ToString()
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
                        (_applicationInfo.BandWidth != null)
                            ? Length.Convert(_applicationInfo.BandWidth, _bandWidthUnits).ToString()
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
                        _applicationInfo.BandWidth = width;
                        _bandWidthText =
                            (width != null)
                                ? Length.Convert(width, _bandWidthUnits).ToString()
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
                        (_applicationInfo.Depth != null)
                            ? Length.Convert(_applicationInfo.Depth, _depthUnits).ToString()
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
                        _applicationInfo.Depth = depth;
                        _bandWidthText =
                            (depth != null)
                                ? Length.Convert(depth, _depthUnits).ToString()
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
                        _applicationInfo.DiskSize = diskSize;
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
                        _applicationInfo.NumberOfNozzles = numberOfNozzles;
                        _numberOfNozzlesText = (numberOfNozzles != null) ? numberOfNozzles.ToString() : String.Empty;
                    }
                }
            }
        }

        public string NozzleType
        {
            get { return _applicationInfo.NozzleType; }
            set
            {
                if (_applicationInfo.NozzleType != value)
                {
                    ValidateNozzleType(value);
                    _applicationInfo.NozzleType = value;
                }
            }
        }

        public string NozzleModel
        {
            get { return _applicationInfo.NozzleModel; }
            set
            {
                if (_applicationInfo.NozzleModel != value)
                {
                    ValidateNozzleModel(value);
                    _applicationInfo.NozzleModel = value;
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
                        (_applicationInfo.NozzlePressure != null)
                            ? Pressure.Convert(_applicationInfo.NozzlePressure, _nozzlePressureUnits).ToString()
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
                        _applicationInfo.NozzlePressure = pressure;
                        _nozzlePressureText =
                            (pressure != null)
                                ? Pressure.Convert(pressure, _nozzlePressureUnits).ToString()
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
                        (_applicationInfo.SprayerTankCapacity != null)
                            ? Volume.Convert(_applicationInfo.SprayerTankCapacity, _sprayerTankCapacityUnits).ToString()
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
                        _applicationInfo.SprayerTankCapacity = capacity;
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
                        (_applicationInfo.HopperCapacity != null)
                            ? Volume.Convert(_applicationInfo.HopperCapacity, _hopperCapacityUnits).ToString()
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
                        _applicationInfo.HopperCapacity = capacity;
                        _hopperCapacityText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _hopperCapacityUnits).ToString()
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
                        _applicationInfo.TotalLoadsApplied = totalLoadsApplied;
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
                        (_applicationInfo.TotalAiApplied != null)
                            ? Mass.Convert(_applicationInfo.TotalAiApplied, _totalAiAppliedUnits).ToString()
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
                        _applicationInfo.TotalAiApplied = totalAiApplied;
                        _totalAiAppliedText =
                            (totalAiApplied != null)
                                ? Mass.Convert(totalAiApplied, _totalAiAppliedUnits).ToString()
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
                        (_applicationInfo.TotalSprayApplied != null)
                            ? Volume.Convert(_applicationInfo.TotalSprayApplied, _totalSprayAppliedUnits).ToString()
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
                        _applicationInfo.TotalSprayApplied = capacity;
                        _totalSprayAppliedText =
                            (capacity != null)
                                ? Volume.Convert(capacity, _totalSprayAppliedUnits).ToString()
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
                        (_applicationInfo.AreaTreated != null)
                            ? Area.Convert(_applicationInfo.AreaTreated, _areaTreatedUnits).ToString()
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
                        _applicationInfo.AreaTreated = area;
                        _areaTreatedText =
                            (area != null)
                                ? Area.Convert(area, _areaTreatedUnits).ToString()
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
                        _applicationInfo.HumidityMax = humidity;
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
                        _applicationInfo.HumidityMin = humidity;
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
                        _applicationInfo.Humidity = humidity;
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
                        (_applicationInfo.TemperatureMax != null)
                            ? Types.Temperature.Convert(_applicationInfo.TemperatureMax, _temperatureMaxUnits).ToString()
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
                        _applicationInfo.TemperatureMax = temperature;
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
                        (_applicationInfo.TemperatureMin != null)
                            ? Types.Temperature.Convert(_applicationInfo.TemperatureMin, _temperatureMinUnits).ToString()
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
                        _applicationInfo.TemperatureMin = temperature;
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
                        (_applicationInfo.Temperature != null)
                            ? Types.Temperature.Convert(_applicationInfo.Temperature, _temperatureUnits).ToString()
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
                        _applicationInfo.Temperature = temperature;
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
                        (_applicationInfo.WindSpeedMax != null)
                            ? Velocity.Convert(_applicationInfo.WindSpeedMax, _windSpeedMaxUnits).ToString()
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
                        _applicationInfo.WindSpeedMax = speed;
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
                        (_applicationInfo.WindSpeedMin != null)
                            ? Velocity.Convert(_applicationInfo.WindSpeedMin, _windSpeedMinUnits).ToString()
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
                        _applicationInfo.WindSpeedMin = speed;
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
                        (_applicationInfo.WindSpeedMin != null)
                            ? Velocity.Convert(_applicationInfo.WindSpeed, _windSpeedUnits).ToString()
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
                        _applicationInfo.WindSpeedMin = speed;
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

        ApplicationInfoModel(ApplicationInfo appInfo)
        {
            _applicationInfo = appInfo;

            // Now set all Model properties, and trigger all validations
            EquipmentUsed = appInfo.EquipmentUsed;
            EquipmentMonitoringMedia = appInfo.EquipmentMonitoringMedia;
            Repairs = appInfo.Repairs;
            ApplicationMakeModel = appInfo.ApplicationMakeModel;
            VehicleMakeModel = appInfo.VehicleMakeModel;
            Cleanup = appInfo.Cleanup;
            VehicleDescription = appInfo.VehicleDescription;
            IncidentalExposure = appInfo.IncidentalExposure;
            CropTreated = appInfo.CropTreated;
            EngineeringControls = appInfo.EngineeringControls;
            EngineeringControlsComment = appInfo.EngineeringControlsComment;
            EngineeringMakeModel = appInfo.EngineeringMakeModel;
            ProcedureAndEquipment = appInfo.ProcedureAndEquipment;
            LengthInOrCmTextAndUnits(appInfo.CropHeight, out _cropHeightText, out _cropHeightUnits);
            FoliageDensity = appInfo.FoliageDensity;
            Diluent = appInfo.Diluent;
            Additives = appInfo.Additives;
            LengthFtOrMTextAndUnits(appInfo.SpacingBetweenRows, out _spacingBetweenRowsText, out _spacingBetweenRowsUnits);
            VelocityMphOrKphTextAndUnits(appInfo.GroundSpeed, out _groundSpeedText, out _groundSpeedUnits);
            LengthInOrCmTextAndUnits(appInfo.BoomHeight, out _boomWidthText, out _boomHeightUnits);
            LengthFtOrMTextAndUnits(appInfo.BoomWidth, out _boomWidthText, out _boomWidthUnits);
            LengthFtOrMTextAndUnits(appInfo.SwathWidth, out _swathWidthText, out _swathWidthUnits);
            LengthInOrCmTextAndUnits(appInfo.BandWidth, out _bandWidthText, out _bandWidthUnits);
            LengthInOrCmTextAndUnits(appInfo.Depth, out _depthText, out _depthUnits);
            DiskSize = appInfo.DiskSize.HasValue ? appInfo.DiskSize.ToString() : String.Empty;
            NumberOfNozzles = appInfo.NumberOfNozzles.HasValue ? appInfo.NumberOfNozzles.ToString() : String.Empty;
            NozzleType = appInfo.NozzleType;
            NozzleModel = appInfo.NozzleModel;
            PressureTextAndUnits(appInfo.NozzlePressure, out _nozzlePressureText, out _nozzlePressureUnits);
            VolumeTextAndUnits(appInfo.SprayerTankCapacity, out _sprayerTankCapacityText, out _sprayerTankCapacityUnits);
            VolumeTextAndUnits(appInfo.HopperCapacity, out _hopperCapacityText, out _hopperCapacityUnits);
            TotalLoadsApplied = appInfo.TotalLoadsApplied.HasValue ? appInfo.TotalLoadsApplied.ToString() : String.Empty;
            MassTextAndUnits(appInfo.TotalAiApplied, out _totalAiAppliedText, out _totalAiAppliedUnits);
            VolumeTextAndUnits(appInfo.TotalSprayApplied, out _totalSprayAppliedText, out _totalSprayAppliedUnits);
            AreaTextAndUnits(appInfo.AreaTreated, out _areaTreatedText, out _areaTreatedUnits);
            HumidityMax = appInfo.HumidityMax.HasValue ? appInfo.HumidityMax.ToString() : String.Empty;
            HumidityMin = appInfo.HumidityMin.HasValue ? appInfo.HumidityMin.ToString() : String.Empty;
            Humidity = appInfo.Humidity.HasValue ? appInfo.Humidity.ToString() : String.Empty;
            TemperatureTextAndUnits(appInfo.TemperatureMax, out _temperatureMaxText, out _temperatureMaxUnits);
            TemperatureTextAndUnits(appInfo.TemperatureMin, out _temperatureMinText, out _temperatureMinUnits);
            TemperatureTextAndUnits(appInfo.Temperature, out _temperatureText, out _temperatureUnits);
            VelocityMphOrMpsTextAndUnits(appInfo.WindSpeedMax, out _windSpeedMaxText, out _windSpeedMaxUnits);
            VelocityMphOrMpsTextAndUnits(appInfo.WindSpeedMin, out _windSpeedMinText, out _windSpeedMinUnits);
            VelocityMphOrMpsTextAndUnits(appInfo.WindSpeed, out _windSpeedText, out _windSpeedUnits);
        }

        #endregion

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string EQUIPMENT_USED = "EquipmentUsed";
        public const string EQUIPMENT_MONITORING_MEDIA = "EquipmentMonitoringMedia";
        public const string REPAIRS = "Repairs";
        public const string APPLICATION_MAKE_MODEL = "ApplicationMakeModel";
        public const string VEHICLE_MAKE_MODEL = "VehicleMakeModel";
        public const string CLEANUP = "Cleanup";
        public const string VEHICLE_DESCRIPTION = "VehicleDescription";
        public const string INCIDENTAL_EXPOSURE = "IncidentalExposure";
        public const string CROP_TREATED = "CropTreated";
        public const string ENGINEERING_CONTROLS = "EngineeringControls";
        public const string ENGINEERING_CONTROLS_COMMENT = "EngineeringControlsComment";
        public const string ENGINEERING_MAKE_MODEL = "EngineeringMakeModel";
        public const string PROCEDURE_AND_EQUIPMENT = "ProcedureAndEquipment";
        public const string CROP_HEIGHT = "CropHeight";
        public const string FOLIAGE_DENSITY = "FoliageDensity";
        public const string DILUENT = "Diluent";
        public const string ADDITIVES = "Additives";
        public const string SPACING_BETWEEN_ROWS = "SpacingBetweenRows";
        public const string GROUND_SPEED = "GroundSpeed";
        public const string BOOM_HEIGHT = "BoomHeight";
        public const string BOOM_WIDTH = "BoomWidth";
        public const string SWATH_WIDTH = "SwathWidth";
        public const string BAND_WIDTH = "BandWidth";
        public const string DEPTH = "Depth";
        public const string DISK_SIZE = "DiskSize";
        public const string NUMBER_OF_NOZZLES = "NumberOfNozzles";
        public const string NOZZLE_TYPE = "NozzleType";
        public const string NOZZLE_MODEL = "NozzleModel";
        public const string NOZZLE_PRESSURE = "NozzlePressure";
        public const string SPRAYER_TANK_CAPACITY = "SprayerTankCapacity";
        public const string HOPPER_CAPACITY = "HopperCapacity";
        public const string TOTAL_LOADS_APPLIED = "TotalLoadsApplied";
        public const string TOTAL_AI_APPLIED = "TotalAIApplied";
        public const string TOTAL_SPRAY_APPLIED = "TotalSprayApplied";
        public const string AREA_TREATED = "AreaTreated";
        public const string HUMIDITY_MAX = "HumidityMax";
        public const string HUMIDITY_MIN = "HumidityMin";
        public const string HUMIDITY = "Humidity";
        public const string TEMPERATURE_MAX = "TemperatureMax";
        public const string TEMPERATURE_MIN = "TemperatureMin";
        public const string TEMPERATURE = "Temperature";
        public const string WIND_SPEED_MAX = "WindSpeedMax";
        public const string WIND_SPEED_MIN = "WindSpeedMin";
        public const string WIND_SPEED = "WindSpeed";

        // Not properties of ApplicationInfo, but properties for this model
        public const string CROP_HEIGHT_UNITS = "CropHeightUnits";
        public const string SPACING_BETWEEN_ROWS_UNITS = "SpacingBetweenRowsUnits";
        public const string GROUND_SPEED_UNITS = "GroundSpeedUnits";
        public const string BOOM_HEIGHT_UNITS = "BoomHeightUnits";
        public const string BOOM_WIDTH_UNITS = "BoomWidthUnits";
        public const string SWATH_WIDTH_UNITS = "SwathWidthUnits";
        public const string BAND_WIDTH_UNITS = "BandWidthUnits";
        public const string DEPTH_UNITS = "DepthUnits";
        public const string SPRAYER_TANK_CAPACITY_UNITS = "SprayerTankCapacityUnits";
        public const string HOPPER_CAPACITY_UNITS = "HopperCapacityUnits";
        public const string TOTAL_AI_APPLIED_UNITS = "TotalAIAppliedUnits";
        public const string TOTAL_SPRAY_APPLIED_UNITS = "TotalSprayAppliedUnits";
        public const string AREA_TREATED_UNITS = "AreaTreatedUnits";
        public const string TEMPERATURE_MAX_UNITS = "TemperatureMaxUnits";
        public const string TEMPERATURE_MIN_UNITS = "TemperatureMinUnits";
        public const string TEMPERATURE_UNITS = "TemperatureUnits";
        public const string WIND_SPEED_MAX_UNITS = "WindSpeedMaxUnits";
        public const string WIND_SPEED_MIN_UNITS = "WindSpeedMinUnits";
        public const string WIND_SPEED_UNITS = "WindSpeedUnits";

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
            bool isValid = true;
            if (ValidEquipmentUseds.Contains(value))
            {
                RemoveError(EQUIPMENT_USED, Properties.Resources.ApplicationInfo_Invalid_Equipment_Used);
            }
            else
            {
                AddError(EQUIPMENT_USED, Properties.Resources.ApplicationInfo_Invalid_Equipment_Used, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EquipmentMonitoringMedia</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EquipmentMonitoringMedia</c>.</returns>
        private bool ValidateEquipmentMonitoringMedia(string value)
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
            bool isValid = true;
            if (ValidReportings.Contains(value))
            {
                RemoveError(REPAIRS, Properties.Resources.ApplicationInfo_Invalid_Repairs);
            }
            else
            {
                AddError(REPAIRS, Properties.Resources.ApplicationInfo_Invalid_Repairs, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ApplicationMakeModel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ApplicationMakeModel</c>.</returns>
        private bool ValidateApplicationMakeModel(string value)
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
        private bool ValidateVehicleMakeModel(string value)
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
            bool isValid = true;
            if (ValidReportings.Contains(value))
            {
                RemoveError(CLEANUP, Properties.Resources.ApplicationInfo_Invalid_Cleanup);
            }
            else
            {
                AddError(CLEANUP, Properties.Resources.ApplicationInfo_Invalid_Cleanup, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>VehicleDescription</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>VehicleDescription</c>.</returns>
        private bool ValidateVehicleDescription(string value)
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
        private bool ValidateIncidentalExposure(string value)
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
        private bool ValidateCropTreated(string value)
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
            bool isValid = true;
            if (ValidEngineeringControls.Contains(value))
            {
                RemoveError(ENGINEERING_CONTROLS, Properties.Resources.ApplicationInfo_Invalid_Engineering_Controls);
            }
            else
            {
                AddError(ENGINEERING_CONTROLS, Properties.Resources.ApplicationInfo_Invalid_Engineering_Controls, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringControlsComment</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringControlsComment</c>.</returns>
        private bool ValidateEngineeringControlsComment(string value)
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
        private bool ValidateEngineeringMakeModel(string value)
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
                                  CROP_HEIGHT, Properties.Resources.ApplicationInfo_Invalid_CropHeight,
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
            bool isValid = true;
            if (ValidFoliageDensities.Contains(value))
            {
                RemoveError(FOLIAGE_DENSITY, Properties.Resources.ApplicationInfo_Invalid_Foliage_Density);
            }
            else
            {
                AddError(FOLIAGE_DENSITY, Properties.Resources.ApplicationInfo_Invalid_Foliage_Density, false);
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
                RemoveError(DILUENT, Properties.Resources.ApplicationInfo_Invalid_Diluent);
            }
            else
            {
                AddError(DILUENT, Properties.Resources.ApplicationInfo_Invalid_Diluent, false);
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
                                  SPACING_BETWEEN_ROWS, Properties.Resources.ApplicationInfo_Invalid_SpacingBetweenRows,
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
                                    GROUND_SPEED, Properties.Resources.ApplicationInfo_Invalid_GroundSpeed,
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
                                  BOOM_HEIGHT, Properties.Resources.ApplicationInfo_Invalid_BoomHeight,
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
                                  BOOM_WIDTH, Properties.Resources.ApplicationInfo_Invalid_BoomWidth,
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
                                  SWATH_WIDTH, Properties.Resources.ApplicationInfo_Invalid_SwathWidth,
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
                                  BAND_WIDTH, Properties.Resources.ApplicationInfo_Invalid_BandWidth,
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
                                  DEPTH, Properties.Resources.ApplicationInfo_Invalid_Depth,
                                  out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>DiskSize</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>DiskSize</c>.</returns>
        private bool ValidateDiskSize(double? value)
        {
            bool isValid = true;
            if (!value.HasValue || value.Value > 0)
                RemoveError(DISK_SIZE, Properties.Resources.ApplicationInfo_Invalid_DiskSize);
            else
            {
                AddError(DISK_SIZE, Properties.Resources.ApplicationInfo_Invalid_DiskSize, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>NumberOfNozzles</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>NumberOfNozzles</c>.</returns>
        private bool ValidateNumberOfNozzles(int? value)
        {
            bool isValid = true;
            if (!value.HasValue || value.Value > 0)
                RemoveError(NUMBER_OF_NOZZLES, Properties.Resources.ApplicationInfo_Invalid_NumberOfNozzles);
            else
            {
                AddError(NUMBER_OF_NOZZLES, Properties.Resources.ApplicationInfo_Invalid_NumberOfNozzles, false);
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>NozzleType</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>NozzleType</c>.</returns>
        private bool ValidateNozzleType(string value)
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
        private bool ValidateNozzleModel(string value)
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
                                    NOZZLE_PRESSURE, Properties.Resources.ApplicationInfo_Invalid_NozzlePressure,
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
                                    SPRAYER_TANK_CAPACITY, Properties.Resources.ApplicationInfo_Invalid_SprayerTankVolume,
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
                                  HOPPER_CAPACITY, Properties.Resources.ApplicationInfo_Invalid_HopperCapacity,
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
                                  TOTAL_LOADS_APPLIED, Properties.Resources.ApplicationInfo_Invalid_TotalLoadsApplied,
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
                                TOTAL_AI_APPLIED, Properties.Resources.ApplicationInfo_Invalid_TotalAiApplied,
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
                                  TOTAL_SPRAY_APPLIED, Properties.Resources.ApplicationInfo_Invalid_TotalSprayApplied,
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
                                  AREA_TREATED, Properties.Resources.ApplicationInfo_Invalid_AreaTreated,
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
                                          HUMIDITY_MAX, Properties.Resources.ApplicationInfo_Invalid_HumidityMax,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HUMIDITY_MAX, Properties.Resources.ApplicationInfo_Invalid_HumidityMax);
            }

            // Check whether there is an issue with the current minimum
            ValidateRange(value, _applicationInfo.HumidityMin, NoUpperBound,
                          HUMIDITY_MAX, Properties.Resources.ApplicationInfo_Invalid_HumidityMaxMin);

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
                                          HUMIDITY_MIN, Properties.Resources.ApplicationInfo_Invalid_HumidityMin,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HUMIDITY_MIN, Properties.Resources.ApplicationInfo_Invalid_HumidityMin);
            }

            // Check whether there is an issue with the current maximum
            ValidateRange(value, NoLowerBound, _applicationInfo.HumidityMax,
                          HUMIDITY_MIN, Properties.Resources.ApplicationInfo_Invalid_HumidityMinMax);

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
                                          HUMIDITY, Properties.Resources.ApplicationInfo_Invalid_Humidity,
                                          out value);

            if (isValid && value.HasValue)
            {
                // Only valid if it is 0-100
                isValid = ValidateRange(value, 0, 100,
                                        HUMIDITY, Properties.Resources.ApplicationInfo_Invalid_Humidity);
            }

            // Check whether there is an issue with the current minimum or maximum
            ValidateRange(value, _applicationInfo.HumidityMin, _applicationInfo.HumidityMax,
                          HUMIDITY, Properties.Resources.ApplicationInfo_Invalid_HumidityBetween);

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
                                               TEMPERATURE_MAX, Properties.Resources.ApplicationInfo_Invalid_TemperatureMax,
                                               out value);

            // Check whether there is an issue with the current maximum
            ValidateRange(value.OriginalValue, _applicationInfo.TemperatureMin.OriginalValue, NoUpperBound,
                          TEMPERATURE_MAX, Properties.Resources.ApplicationInfo_Invalid_TemperatureMaxMin);

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
                                               TEMPERATURE_MIN, Properties.Resources.ApplicationInfo_Invalid_TemperatureMin,
                                               out value);

            // Check whether there is an issue with the current maximum
            ValidateRange(value.OriginalValue, NoLowerBound, _applicationInfo.TemperatureMax.OriginalValue,
                          TEMPERATURE_MIN, Properties.Resources.ApplicationInfo_Invalid_TemperatureMinMax);

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
                                               TEMPERATURE_MIN, Properties.Resources.ApplicationInfo_Invalid_Temperature,
                                               out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, _applicationInfo.TemperatureMin.OriginalValue, _applicationInfo.TemperatureMax.OriginalValue,
                          TEMPERATURE_MIN, Properties.Resources.ApplicationInfo_Invalid_TemperatureBetween);

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
                                            WIND_SPEED_MAX, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMax,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, _applicationInfo.WindSpeedMin.OriginalValue, NoUpperBound,
                          WIND_SPEED_MAX, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMaxMin);

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
                                            WIND_SPEED_MIN, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMin,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, NoLowerBound, _applicationInfo.WindSpeedMax.OriginalValue,
                          WIND_SPEED_MIN, Properties.Resources.ApplicationInfo_Invalid_WindSpeedMinMax);

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
                                            WIND_SPEED, Properties.Resources.ApplicationInfo_Invalid_WindSpeed,
                                            out value);

            // Check whether there is an issue with the current minimum
            ValidateRange(value.OriginalValue, _applicationInfo.WindSpeedMin.OriginalValue, _applicationInfo.WindSpeedMax.OriginalValue,
                          WIND_SPEED, Properties.Resources.ApplicationInfo_Invalid_WindSpeedBetween);

            return isValid;
        }

        #endregion // Specific Validations

        #endregion
    }
}

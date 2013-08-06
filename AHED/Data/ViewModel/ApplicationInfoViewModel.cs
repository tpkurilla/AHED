using System;
using AHED.Data.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class ApplicationInfoViewModel : SimpleViewModel<ApplicationInfoModel, ApplicationInfo>
    {
        #region Fields

        #region Valid Options for StaticItems

        StaticItem[] _equipmentUsedOptions;

        StaticItem[] _engineeringControlsOptions;

        StaticItem[] _reportingOptions;

        StaticItem[] _foliageDensityOptions;

        StaticItem[] _diluentOptions;

        #endregion Valid Options for StaticItems

        #region Valid Units Options for properties

        private Length.Units[] _cropHeightUnitsOptions;

        private Length.Units[] _spacingBetweenRowsUnitsOptions;

        private Velocity.Units[] _groundSpeedUnitsOptions;

        private Length.Units[] _boomHeightUnitsOptions;

        private Length.Units[] _boomWidthUnitsOptions;

        private Length.Units[] _swathWidthUnitsOptions;

        private Length.Units[] _bandWidthUnitsOptions;

        private Length.Units[] _depthUnitsOptions;

        private Pressure.Units[] _nozzlePressureUnitsOptions;

        private Volume.Units[] _capacityUnitsOptions;

        private Mass.Units[] _totalAiAppliedUnitsOptions;

        private Area.Units[] _areaTreatedUnitsOptions;

        private Temperature.Units[] _temperatureUnitsOptions;

        private Velocity.Units[] _windSpeedUnitsOptions;

        #endregion Valid Units Options for properties

        #endregion Fields

        #region Construction

        public ApplicationInfoViewModel(){}

        public ApplicationInfoViewModel(ApplicationInfoModel applicationInfo)
            : base(applicationInfo)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            EquipmentUsed = Model.EquipmentUsed;
            EquipmentMonitoringMedia = Model.EquipmentMonitoringMedia;
            Repairs = Model.Repairs;
            ApplicationMakeModel = Model.ApplicationMakeModel;
            VehicleMakeModel = Model.VehicleMakeModel;
            Cleanup = Model.Cleanup;
            VehicleDescription = Model.VehicleDescription;
            IncidentalExposure = Model.IncidentalExposure;
            CropTreated = Model.CropTreated;
            EngineeringControls = Model.EngineeringControls;
            EngineeringControlsComment = Model.EngineeringControlsComment;
            EngineeringMakeModel = Model.EngineeringMakeModel;
            ProcedureAndEquipment = Model.ProcedureAndEquipment;
            CropHeightUnits = Model.CropHeightUnits;
            CropHeight = Model.CropHeight;
            FoliageDensity = Model.FoliageDensity;
            Diluent = Model.Diluent;
            Additives = Model.Additives;
            SpacingBetweenRowsUnits = Model.SpacingBetweenRowsUnits;
            SpacingBetweenRows = Model.SpacingBetweenRows;
            GroundSpeedUnits = Model.GroundSpeedUnits;
            GroundSpeed = Model.GroundSpeed;
            BoomHeightUnits = Model.BoomHeightUnits;
            BoomHeight = Model.BoomHeight;
            BoomWidthUnits = Model.BoomWidthUnits;
            BoomWidth = Model.BoomWidth;
            SwathWidthUnits = Model.SwathWidthUnits;
            SwathWidth = Model.SwathWidth;
            BandWidthUnits = Model.BandWidthUnits;
            BandWidth = Model.BandWidth;
            DepthUnits = Model.DepthUnits;
            Depth = Model.Depth;
            DiskSize = Model.DiskSize;
            NumberOfNozzles = Model.NumberOfNozzles;
            NozzleType = Model.NozzleType;
            NozzleModel = Model.NozzleModel;
            NozzlePressureUnits = Model.NozzlePressureUnits;
            NozzlePressure = Model.NozzlePressure;
            SprayerTankCapacityUnits = Model.SprayerTankCapacityUnits;
            SprayerTankCapacity = Model.SprayerTankCapacity;
            HopperCapacityUnits = Model.HopperCapacityUnits;
            HopperCapacity = Model.HopperCapacity;
            TotalLoadsApplied = Model.TotalLoadsApplied;
            TotalAiAppliedUnits = Model.TotalAiAppliedUnits;
            TotalAiApplied = Model.TotalAiApplied;
            TotalSprayAppliedUnits = Model.TotalSprayAppliedUnits;
            TotalSprayApplied = Model.TotalSprayApplied;
            AreaTreatedUnits = Model.AreaTreatedUnits;
            AreaTreated = Model.AreaTreated;
            HumidityMax = Model.HumidityMax;
            HumidityMin = Model.HumidityMin;
            Humidity = Model.Humidity;
            TemperatureMaxUnits = Model.TemperatureMaxUnits;
            TemperatureMax = Model.TemperatureMax;
            TemperatureMinUnits = Model.TemperatureMinUnits;
            TemperatureMin = Model.TemperatureMin;
            TemperatureUnits = Model.TemperatureUnits;
            Temperature = Model.Temperature;
            WindSpeedMaxUnits = Model.WindSpeedMaxUnits;
            WindSpeedMax = Model.WindSpeedMax;
            WindSpeedMinUnits = Model.WindSpeedMinUnits;
            WindSpeedUnits = Model.WindSpeedUnits;
            WindSpeed = Model.WindSpeed;
        }

        #endregion Construction

        #region Presentation Properties

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for EquipmentLoaded selector.
        /// </summary>
        public StaticItem[] EquipmentUsedOptions
        {
            get
            {
                return _equipmentUsedOptions
                       ?? (_equipmentUsedOptions = Model.ValidEquipmentUseds.ToArray());
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
        public StaticItem[] FoliageDensityOptionsOptions
        {
            get
            {
                return _foliageDensityOptions
                       ?? (_foliageDensityOptions = Model.ValidFoliageDensities.ToArray());
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

        #region Units Options

        /// <summary>
        /// Returns an array of valid choices for CropHeightUnits selector.
        /// </summary>
        public Length.Units[] CropHeightUnitsOptions
        {
            get
            {
                return _cropHeightUnitsOptions
                       ?? (_cropHeightUnitsOptions = new[] { Length.Units.Inches, Length.Units.Centimeters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for SpacingBetweenRowsUnits selector.
        /// </summary>
        public Length.Units[] SpacingBetweenRowsUnitsOptions
        {
            get
            {
                return _spacingBetweenRowsUnitsOptions
                       ?? (_spacingBetweenRowsUnitsOptions = new[] { Length.Units.Feet, Length.Units.Meters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for GroundSpeedUnits selector.
        /// </summary>
        public Velocity.Units[] GroundSpeedUnitsOptions
        {
            get
            {
                return _groundSpeedUnitsOptions
                       ?? (_groundSpeedUnitsOptions = new[] { Velocity.Units.MilesPerHour, Velocity.Units.KilometersPerHour });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for BoomHeightUnits selector.
        /// </summary>
        public Length.Units[] BoomHeightUnitsOptions
        {
            get
            {
                return _boomHeightUnitsOptions
                       ?? (_boomHeightUnitsOptions = new[] { Length.Units.Inches, Length.Units.Centimeters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for BoomWidthUnits selector.
        /// </summary>
        public Length.Units[] BoomWidthUnitsOptions
        {
            get
            {
                return _boomWidthUnitsOptions
                       ?? (_boomWidthUnitsOptions = new[] { Length.Units.Feet, Length.Units.Meters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for SwathWidthUnits selector.
        /// </summary>
        public Length.Units[] SwathWidthUnitsOptions
        {
            get
            {
                return _swathWidthUnitsOptions
                       ?? (_swathWidthUnitsOptions = new[] { Length.Units.Feet, Length.Units.Meters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for BandWidthUnits selector.
        /// </summary>
        public Length.Units[] BandWidthUnitsOptions
        {
            get
            {
                return _bandWidthUnitsOptions
                       ?? (_bandWidthUnitsOptions = new[] { Length.Units.Inches, Length.Units.Centimeters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for DepthUnits selector.
        /// </summary>
        public Length.Units[] DepthUnitsOptions
        {
            get
            {
                return _depthUnitsOptions
                       ?? (_depthUnitsOptions = new[] { Length.Units.Inches, Length.Units.Centimeters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for NozzlePressureUnits selector.
        /// </summary>
        public Pressure.Units[] NozzlePressureUnitsOptions
        {
            get
            {
                return _nozzlePressureUnitsOptions
                       ?? (_nozzlePressureUnitsOptions = new[] { Pressure.Units.Psi, Pressure.Units.Bar });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for CapacityUnits selector.
        /// </summary>
        public Volume.Units[] CapacityUnitsOptions
        {
            get
            {
                return _capacityUnitsOptions
                       ?? (_capacityUnitsOptions = new[] { Volume.Units.Gallons, Volume.Units.Liters });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for TotalAiAppliedUnits selector.
        /// </summary>
        public Mass.Units[] TotalAiAppliedUnitsOptions
        {
            get
            {
                return _totalAiAppliedUnitsOptions
                       ?? (_totalAiAppliedUnitsOptions = new[] { Mass.Units.Pounds, Mass.Units.Kilograms });
            }
        }

        /// <summary>
        /// Returns an array of valid choices for AreaTreatedUnits selector.
        /// </summary>
        public Area.Units[] AreaTreatedUnitsOptions
        {
            get
            {
                return _areaTreatedUnitsOptions
                       ?? (_areaTreatedUnitsOptions = new[] { Area.Units.Acres, Area.Units.Hectares });
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
                       ?? (_temperatureUnitsOptions = new[] { Types.Temperature.Units.Fahrenheit, Types.Temperature.Units.Celsius });
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
                       ?? (_windSpeedUnitsOptions = new[] { Velocity.Units.MilesPerHour, Velocity.Units.MetersPerSecond });
            }
        }

        #endregion Units Options

        #endregion Presentation Properties

        #region Properties

        private StaticItem _equipmentUsed;
        public StaticItem EquipmentUsed
        {
            get { return _equipmentUsed; }
            set
            {
                if (value == _equipmentUsed)
                    return;

                Model.EquipmentUsed = value;
                _equipmentUsed = Model.EquipmentUsed;
                base.RaisePropertyChanged(ApplicationInfoModel.EquipmentUsedName);
            }
        }

        private string _equipmentMonitoringMedia;
        public string EquipmentMonitoringMedia
        {
            get { return _equipmentMonitoringMedia; }
            set
            {
                if (value == _equipmentMonitoringMedia)
                    return;

                Model.EquipmentMonitoringMedia = value;
                _equipmentMonitoringMedia = Model.EquipmentMonitoringMedia;
                base.RaisePropertyChanged(ApplicationInfoModel.EquipmentMonitoringMediaName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.RepairsName);
            }
        }

        private string _applicationMakeModel;
        public string ApplicationMakeModel
        {
            get { return _applicationMakeModel; }
            set
            {
                if (value == _applicationMakeModel)
                    return;

                Model.ApplicationMakeModel = value;
                _applicationMakeModel = Model.ApplicationMakeModel;
                base.RaisePropertyChanged(ApplicationInfoModel.ApplicationMakeModelName);
            }
        }

        private string _vehicleMakeModel;
        public string VehicleMakeModel
        {
            get { return _vehicleMakeModel; }
            set
            {
                if (value == _vehicleMakeModel)
                    return;

                Model.VehicleMakeModel = value;
                _vehicleMakeModel = Model.VehicleMakeModel;
                base.RaisePropertyChanged(ApplicationInfoModel.VehicleMakeModelName);
            }
        }

        private StaticItem _cleanup;
        public StaticItem Cleanup
        {
            get { return _cleanup; }
            set
            {
                if (value == _cleanup)
                    return;

                Model.Cleanup = value;
                _cleanup = Model.Cleanup;
                base.RaisePropertyChanged(ApplicationInfoModel.CleanupName);
            }
        }

        private string _vehicleDescription;
        public string VehicleDescription
        {
            get { return _vehicleDescription; }
            set
            {
                if (value == _vehicleDescription)
                    return;

                Model.VehicleDescription = value;
                _vehicleDescription = Model.VehicleDescription;
                base.RaisePropertyChanged(ApplicationInfoModel.VehicleDescriptionName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.IncidentalExposureName);
            }
        }

        private string _cropTreated;
        public string CropTreated
        {
            get { return _cropTreated; }
            set
            {
                if (value == _cropTreated)
                    return;

                Model.CropTreated = value;
                _cropTreated = Model.CropTreated;
                base.RaisePropertyChanged(ApplicationInfoModel.CropTreatedName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.EngineeringControlsName);
            }
        }

        private string _engineeringControlsComment;
        public string EngineeringControlsComment
        {
            get { return _engineeringControlsComment; }
            set
            {
                if (value == _engineeringControlsComment)
                    return;

                Model.EngineeringControlsComment = value;
                _engineeringControlsComment = Model.EngineeringControlsComment;
                base.RaisePropertyChanged(ApplicationInfoModel.EngineeringControlsCommentName);
            }
        }

        private string _engineeringMakeModel;
        public string EngineeringMakeModel
        {
            get { return _engineeringMakeModel; }
            set
            {
                if (value == _engineeringMakeModel)
                    return;

                Model.EngineeringMakeModel = value;
                _engineeringMakeModel = Model.EngineeringMakeModel;
                base.RaisePropertyChanged(ApplicationInfoModel.EngineeringMakeModelName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.ProcedureAndEquipmentName);
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
                    Model.CropHeightUnits = value;
                    _cropHeightUnits = Model.CropHeightUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.CropHeightUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.CropHeightName);
                }
            }
        }

        private string _cropHeight;
        public string CropHeight
        {
            get { return _cropHeight; }
            set
            {
                if (value == _cropHeight)
                    return;

                Model.CropHeight = value;
                _cropHeight = Model.CropHeight;
                base.RaisePropertyChanged(ApplicationInfoModel.CropHeightName);
            }
        }

        private StaticItem _foliageDensity;
        public StaticItem FoliageDensity
        {
            get { return _foliageDensity; }
            set
            {
                if (value == _foliageDensity)
                    return;

                Model.FoliageDensity = value;
                _foliageDensity = Model.FoliageDensity;
                base.RaisePropertyChanged(ApplicationInfoModel.FoliageDensityName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.DiluentName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.AdditivesName);
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
                    Model.SpacingBetweenRowsUnits = value;
                    _spacingBetweenRowsUnits = Model.SpacingBetweenRowsUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.SpacingBetweenRowsUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.SpacingBetweenRowsName);
                }
            }
        }

        private string _spacingBetweenRows;
        public string SpacingBetweenRows
        {
            get { return _spacingBetweenRows; }
            set
            {
                if (value == _spacingBetweenRows)
                    return;

                Model.SpacingBetweenRows = value;
                _spacingBetweenRows = Model.SpacingBetweenRows;
                base.RaisePropertyChanged(ApplicationInfoModel.SpacingBetweenRowsName);
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
                    Model.GroundSpeedUnits = value;
                    _groundSpeedUnits = Model.GroundSpeedUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.GroundSpeedUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.GroundSpeedName);
                }
            }
        }

        private string _groundSpeed;
        public string GroundSpeed
        {
            get { return _groundSpeed; }
            set
            {
                if (value == _groundSpeed)
                    return;

                Model.GroundSpeed = value;
                _groundSpeed = Model.GroundSpeed;
                base.RaisePropertyChanged(ApplicationInfoModel.GroundSpeedName);
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
                    Model.BoomHeightUnits = value;
                    _boomHeightUnits = Model.BoomHeightUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.BoomHeightUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.BoomHeightName);
                }
            }
        }

        private string _boomHeight;
        public string BoomHeight
        {
            get { return _boomHeight; }
            set
            {
                if (value == _boomHeight)
                    return;

                Model.BoomHeight = value;
                _boomHeight = Model.BoomHeight;
                base.RaisePropertyChanged(ApplicationInfoModel.BoomHeightName);
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
                    Model.BoomWidthUnits = value;
                    _boomWidthUnits = Model.BoomWidthUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.BoomWidthUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.BoomWidthName);
                }
            }
        }

        private string _boomWidth;
        public string BoomWidth
        {
            get { return _boomWidth; }
            set
            {
                if (value == _boomWidth)
                    return;

                Model.BoomWidth = value;
                _boomWidth = Model.BoomWidth;
                base.RaisePropertyChanged(ApplicationInfoModel.BoomWidthName);
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
                    Model.SwathWidthUnits = value;
                    _swathWidthUnits = Model.SwathWidthUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.SwathWidthUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.SwathWidthName);
                }
            }
        }

        private string _swathWidth;
        public string SwathWidth
        {
            get { return _swathWidth; }
            set
            {
                if (value == _swathWidth)
                    return;

                Model.SwathWidth = value;
                _swathWidth = Model.SwathWidth;
                base.RaisePropertyChanged(ApplicationInfoModel.SwathWidthName);
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
                    Model.BandWidthUnits = value;
                    _bandWidthUnits = Model.BandWidthUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.BandWidthUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.BandWidthName);
                }
            }
        }

        private string _bandWidth;
        public string BandWidth
        {
            get { return _bandWidth; }
            set
            {
                if (value == _bandWidth)
                    return;

                Model.BandWidth = value;
                _bandWidth = Model.BandWidth;
                base.RaisePropertyChanged(ApplicationInfoModel.BandWidthName);
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
                    Model.DepthUnits = value;
                    _depthUnits = Model.DepthUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.DepthUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.DepthName);
                }
            }
        }

        private string _depth;
        public string Depth
        {
            get { return _depth; }
            set
            {
                if (value == _depth)
                    return;

                Model.Depth = value;
                _depth = Model.Depth;
                base.RaisePropertyChanged(ApplicationInfoModel.DepthName);
            }
        }

        private string _diskSize;
        public string DiskSize
        {
            get { return _diskSize; }
            set
            {
                if (value == _diskSize)
                    return;

                Model.DiskSize = value;
                _diskSize = Model.DiskSize;
                base.RaisePropertyChanged(ApplicationInfoModel.DiskSizeName);
            }
        }

        private string _numberOfNozzles;
        public string NumberOfNozzles
        {
            get { return _numberOfNozzles; }
            set
            {
                if (value == _numberOfNozzles)
                    return;

                Model.NumberOfNozzles = value;
                _numberOfNozzles = Model.NumberOfNozzles;
                base.RaisePropertyChanged(ApplicationInfoModel.NumberOfNozzlesName);
            }
        }

        private string _nozzleType;
        public string NozzleType
        {
            get { return _nozzleType; }
            set
            {
                if (value == _nozzleType)
                    return;

                Model.NozzleType = value;
                _nozzleType = Model.NozzleType;
                base.RaisePropertyChanged(ApplicationInfoModel.NozzleTypeName);
            }
        }

        private string _nozzleModel;
        public string NozzleModel
        {
            get { return _nozzleModel; }
            set
            {
                if (value == _nozzleModel)
                    return;

                Model.NozzleModel = value;
                _nozzleModel = Model.NozzleModel;
                base.RaisePropertyChanged(ApplicationInfoModel.NozzleModelName);
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
                    Model.NozzlePressureUnits = value;
                    _nozzlePressureUnits = Model.NozzlePressureUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.NozzlePressureUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.NozzlePressureName);
                }
            }
        }

        private string _nozzlePressure;
        public string NozzlePressure
        {
            get { return _nozzlePressure; }
            set
            {
                if (value == _nozzlePressure)
                    return;

                Model.NozzlePressure = value;
                _nozzlePressure = Model.NozzlePressure;
                base.RaisePropertyChanged(ApplicationInfoModel.NozzlePressureName);
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
                    Model.SprayerTankCapacityUnits = value;
                    _sprayerTankCapacityUnits = Model.SprayerTankCapacityUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.SprayerTankCapacityUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.SprayerTankCapacityName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.SprayerTankCapacityName);
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
                    Model.HopperCapacityUnits = value;
                    _hopperCapacityUnits = Model.HopperCapacityUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.HopperCapacityUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.HopperCapacityName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.HopperCapacityName);
            }
        }

        private string _totalLoadsApplied;
        public string TotalLoadsApplied
        {
            get { return _totalLoadsApplied; }
            set
            {
                if (value == _totalLoadsApplied)
                    return;

                Model.TotalLoadsApplied = value;
                _totalLoadsApplied = Model.TotalLoadsApplied;
                base.RaisePropertyChanged(ApplicationInfoModel.TotalLoadsAppliedName);
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
                    Model.TotalAiAppliedUnits = value;
                    _totalAiAppliedUnits = Model.TotalAiAppliedUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.TotalAiAppliedUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.TotalAiAppliedName);
                }
            }
        }

        private string _totalAiApplied;
        public string TotalAiApplied
        {
            get { return _totalAiApplied; }
            set
            {
                if (value == _totalAiApplied)
                    return;

                Model.TotalAiApplied = value;
                _totalAiApplied = Model.TotalAiApplied;
                base.RaisePropertyChanged(ApplicationInfoModel.TotalAiAppliedName);
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
                    Model.TotalSprayAppliedUnits = value;
                    _totalSprayAppliedUnits = Model.TotalSprayAppliedUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.TotalSprayAppliedUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.TotalSprayAppliedName);
                }
            }
        }

        private string _totalSprayApplied;
        public string TotalSprayApplied
        {
            get { return _totalSprayApplied; }
            set
            {
                if (value == _totalSprayApplied)
                    return;

                Model.TotalSprayApplied = value;
                _totalSprayApplied = Model.TotalSprayApplied;
                base.RaisePropertyChanged(ApplicationInfoModel.TotalSprayAppliedName);
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
                    Model.AreaTreatedUnits = value;
                    _areaTreatedUnits = Model.AreaTreatedUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.AreaTreatedUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.AreaTreatedName);
                }
            }
        }

        private string _areaTreated;
        public string AreaTreated
        {
            get { return _areaTreated; }
            set
            {
                if (value == _areaTreated)
                    return;

                Model.AreaTreated = value;
                _areaTreated = Model.AreaTreated;
                base.RaisePropertyChanged(ApplicationInfoModel.AreaTreatedName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.HumidityMaxName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.HumidityMinName);
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
                base.RaisePropertyChanged(ApplicationInfoModel.HumidityName);
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
                    Model.TemperatureMaxUnits = value;
                    _temperatureMaxUnits = Model.TemperatureMaxUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.TemperatureMaxUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.TemperatureMaxName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.TemperatureMaxName);
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
                    Model.TemperatureMinUnits = value;
                    _temperatureMinUnits = Model.TemperatureMinUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.TemperatureMinUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.TemperatureMinName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.TemperatureMinName);
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
                    Model.TemperatureUnits = value;
                    _temperatureUnits = Model.TemperatureUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.TemperatureUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.TemperatureName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.TemperatureName);
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
                    Model.WindSpeedMaxUnits = value;
                    _windSpeedMaxUnits = Model.WindSpeedMaxUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedMaxUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedMaxName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedMaxName);
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
                    Model.WindSpeedMinUnits = value;
                    _windSpeedMinUnits = Model.WindSpeedMinUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedMinUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedMinName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedMinName);
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
                    Model.WindSpeedUnits = value;
                    _windSpeedUnits = Model.WindSpeedUnits;
                    base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedUnitsName);
                    base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedName);
                }
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
                base.RaisePropertyChanged(ApplicationInfoModel.WindSpeedName);
            }
        }

        #endregion Properties

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

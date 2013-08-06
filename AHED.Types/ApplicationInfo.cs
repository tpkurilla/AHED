using System;

namespace AHED.Types
{
    [Serializable]
    public class ApplicationInfo : IDeepClone<ApplicationInfo>, IPropertyInitializer
    {
        public StaticItem EquipmentUsed { get; set; }
        public string EquipmentMonitoringMedia { get; set; }
        public StaticItem Repairs { get; set; }
        public string ApplicationMakeModel { get; set; }
        public string VehicleMakeModel { get; set; }
        public StaticItem Cleanup { get; set; }
        public string VehicleDescription { get; set; }
        public string IncidentalExposure { get; set; }
        public string CropTreated { get; set; }
        public StaticItem EngineeringControls { get; set; }
        public string EngineeringControlsComment { get; set; }
        public string EngineeringMakeModel { get; set; }
        public string ProcedureAndEquipment { get; set; }
        public Length CropHeight { get; set; }
        public StaticItem FoliageDensity { get; set; }
        public StaticItem Diluent { get; set; }
        public string Additives { get; set; }
        public Length SpacingBetweenRows { get; set; }
        public Velocity GroundSpeed { get; set; }
        public Length BoomHeight { get; set; }
        public Length BoomWidth { get; set; }
        public Length SwathWidth { get; set; }
        public Length BandWidth { get; set; }
        public Length Depth { get; set; }
        public double? DiskSize { get; set; }
        public int? NumberOfNozzles { get; set; }
        public string NozzleType { get; set; }
        public string NozzleModel { get; set; }
        public Pressure NozzlePressure { get; set; }
        public Volume SprayerTankCapacity { get; set; }
        public Volume HopperCapacity { get; set; }
        public double? TotalLoadsApplied { get; set; }
        public Mass TotalAiApplied { get; set; }
        public Volume TotalSprayApplied { get; set; }
        public Area AreaTreated { get; set; }
        public double? DermalSamplingTime { get; set; }
        public double? InhalationSamplingTime { get; set; }
        public double? HumidityMax { get; set; }
        public double? HumidityMin { get; set; }
        public double? Humidity { get; set; }
        public Temperature TemperatureMax { get; set; }
        public Temperature TemperatureMin { get; set; }
        public Temperature Temperature { get; set; }
        public Velocity WindSpeedMax { get; set; }
        public Velocity WindSpeedMin { get; set; }
        public Velocity WindSpeed { get; set; }

        public ApplicationInfo()
        {
        }

        public ApplicationInfo(ApplicationInfo appInfo)
        {
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
            CropHeight = appInfo.CropHeight;
            FoliageDensity = appInfo.FoliageDensity;
            Diluent = appInfo.Diluent;
            Additives = appInfo.Additives;
            SpacingBetweenRows = appInfo.SpacingBetweenRows;
            GroundSpeed = appInfo.GroundSpeed;
            BoomHeight = appInfo.BoomHeight;
            BoomWidth = appInfo.BoomWidth;
            SwathWidth = appInfo.SwathWidth;
            BandWidth = appInfo.BandWidth;
            Depth = appInfo.Depth;
            DiskSize = appInfo.DiskSize;
            NumberOfNozzles = appInfo.NumberOfNozzles;
            NozzleType = appInfo.NozzleType;
            NozzleModel = appInfo.NozzleModel;
            NozzlePressure = appInfo.NozzlePressure;
            SprayerTankCapacity = appInfo.SprayerTankCapacity;
            HopperCapacity = appInfo.HopperCapacity;
            TotalLoadsApplied = appInfo.TotalLoadsApplied;
            TotalAiApplied = appInfo.TotalAiApplied;
            TotalSprayApplied = appInfo.TotalSprayApplied;
            AreaTreated = appInfo.AreaTreated;
            DermalSamplingTime = appInfo.DermalSamplingTime;
            InhalationSamplingTime = appInfo.InhalationSamplingTime;
            HumidityMax = appInfo.HumidityMax;
            HumidityMin = appInfo.HumidityMin;
            Humidity = appInfo.Humidity;
            TemperatureMax = appInfo.TemperatureMax;
            TemperatureMin = appInfo.TemperatureMin;
            Temperature = appInfo.Temperature;
            WindSpeedMax = appInfo.WindSpeedMax;
            WindSpeedMin = appInfo.WindSpeedMin;
            WindSpeed = appInfo.WindSpeed;
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            EquipmentUsed = _template.EquipmentUsed;
            EquipmentMonitoringMedia = _template.EquipmentMonitoringMedia;
            Repairs = _template.Repairs;
            ApplicationMakeModel = _template.ApplicationMakeModel;
            VehicleMakeModel = _template.VehicleMakeModel;
            Cleanup = _template.Cleanup;
            VehicleDescription = _template.VehicleDescription;
            IncidentalExposure = _template.IncidentalExposure;
            CropTreated = _template.CropTreated;
            EngineeringControls = _template.EngineeringControls;
            EngineeringControlsComment = _template.EngineeringControlsComment;
            EngineeringMakeModel = _template.EngineeringMakeModel;
            ProcedureAndEquipment = _template.ProcedureAndEquipment;
            CropHeight = _template.CropHeight;
            FoliageDensity = _template.FoliageDensity;
            Diluent = _template.Diluent;
            Additives = _template.Additives;
            SpacingBetweenRows = _template.SpacingBetweenRows;
            GroundSpeed = _template.GroundSpeed;
            BoomHeight = _template.BoomHeight;
            BoomWidth = _template.BoomWidth;
            SwathWidth = _template.SwathWidth;
            BandWidth = _template.BandWidth;
            Depth = _template.Depth;
            DiskSize = _template.DiskSize;
            NumberOfNozzles = _template.NumberOfNozzles;
            NozzleType = _template.NozzleType;
            NozzleModel = _template.NozzleModel;
            NozzlePressure = _template.NozzlePressure;
            SprayerTankCapacity = _template.SprayerTankCapacity;
            HopperCapacity = _template.HopperCapacity;
            TotalLoadsApplied = _template.TotalLoadsApplied;
            TotalAiApplied = _template.TotalAiApplied;
            TotalSprayApplied = _template.TotalSprayApplied;
            AreaTreated = _template.AreaTreated;
            DermalSamplingTime = _template.DermalSamplingTime;
            InhalationSamplingTime = _template.InhalationSamplingTime;
            HumidityMax = _template.HumidityMax;
            HumidityMin = _template.HumidityMin;
            Humidity = _template.Humidity;
            TemperatureMax = _template.TemperatureMax;
            TemperatureMin = _template.TemperatureMin;
            Temperature = _template.Temperature;
            WindSpeedMax = _template.WindSpeedMax;
            WindSpeedMin = _template.WindSpeedMin;
            WindSpeed = _template.WindSpeed;

            return true;
        }

        /// <summary>
        /// Template initialized once to proper default values;
        /// </summary>
        private static ApplicationInfo _template;

        /// <summary>
        /// Creates a properly-initialized <c>ApplicationInfo</c> instance.  This
        /// is the preferred method for creating a new <c>ApplicationInfo</c>
        /// instance.
        /// </summary>
        /// <returns>A properly initialized <c>ApplicationInfo</c>.</returns>
        public static ApplicationInfo Create()
        {
            if (_template == null)
                CreateTemplate();

            return new ApplicationInfo(_template);
        }

        private static void CreateTemplate()
        {
            _template = new ApplicationInfo()
            {
                EquipmentUsed =
                    StaticValues.Item(StaticValues.Groups.AppEquipment, (int)StaticValues.AppEquipment.NotSet),
                EquipmentMonitoringMedia = null,
                Repairs = StaticValues.Item(StaticValues.Groups.Reporting, (int)StaticValues.Reporting.NotSet),
                ApplicationMakeModel = null,
                VehicleMakeModel = null,
                Cleanup = StaticValues.Item(StaticValues.Groups.Reporting, (int)StaticValues.Reporting.NotSet),
                VehicleDescription = null,
                IncidentalExposure = null,
                CropTreated = null,
                EngineeringControls =
                    StaticValues.Item(StaticValues.Groups.AppEngControls,
                                      (int)StaticValues.AppEngControls.NotSet),
                EngineeringControlsComment = null,
                EngineeringMakeModel = null,
                ProcedureAndEquipment = null,
                CropHeight = null,
                FoliageDensity =
                    StaticValues.Item(StaticValues.Groups.Foliage, (int)StaticValues.Foliage.NotSet),
                Diluent = StaticValues.Item(StaticValues.Groups.Diluent, (int)StaticValues.Diluent.NotSet),
                Additives = null,
                SpacingBetweenRows = null,
                GroundSpeed = null,
                BoomHeight = null,
                BoomWidth = null,
                SwathWidth = null,
                BandWidth = null,
                Depth = null,
                DiskSize = null,
                NumberOfNozzles = null,
                NozzleType = null,
                NozzleModel = null,
                NozzlePressure = null,
                SprayerTankCapacity = null,
                HopperCapacity = null,
                TotalLoadsApplied = null,
                TotalAiApplied = null,
                TotalSprayApplied = null,
                AreaTreated = null,
                DermalSamplingTime = null,
                InhalationSamplingTime = null,
                HumidityMax = null,
                HumidityMin = null,
                Humidity = null,
                TemperatureMax = null,
                TemperatureMin = null,
                Temperature = null,
                WindSpeedMax = null,
                WindSpeedMin = null,
                WindSpeed = null
            };
        }

        #region IDeepClone Interface

        public ApplicationInfo DeepClone()
        {
            return new ApplicationInfo(this);
        }

        #endregion IDeepClone Interface
    }
}

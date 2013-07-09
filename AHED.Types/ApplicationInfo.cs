using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHED.Types
{
    [Serializable]
    public class ApplicationInfo
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

        public ApplicationInfo(ApplicationInfo prod)
        {
            EquipmentUsed = prod.EquipmentUsed;
            Repairs = prod.Repairs;
            ApplicationMakeModel = prod.ApplicationMakeModel;
            VehicleMakeModel = prod.VehicleMakeModel;
            Cleanup = prod.Cleanup;
            VehicleDescription = prod.VehicleDescription;
            IncidentalExposure = prod.IncidentalExposure;
            CropTreated = prod.CropTreated;
            EngineeringControls = prod.EngineeringControls;
            EngineeringMakeModel = prod.EngineeringMakeModel;
            CropHeight = prod.CropHeight;
            FoliageDensity = prod.FoliageDensity;
            Diluent = prod.Diluent;
            Additives = prod.Additives;
            SpacingBetweenRows = prod.SpacingBetweenRows;

            GroundSpeed = prod.GroundSpeed;
            BoomHeight = prod.BoomHeight;
            BoomWidth = prod.BoomWidth;
            SwathWidth = prod.SwathWidth;
            BandWidth = prod.BandWidth;
            Depth = prod.Depth;
            DiskSize = prod.DiskSize;
            NumberOfNozzles = prod.NumberOfNozzles;
            NozzleType = prod.NozzleType;
            NozzleModel = prod.NozzleModel;
            NozzlePressure = prod.NozzlePressure;

            SprayerTankCapacity = prod.SprayerTankCapacity;
            HopperCapacity = prod.HopperCapacity;
            TotalLoadsApplied = prod.TotalLoadsApplied;
            TotalAiApplied = prod.TotalAiApplied;
            TotalSprayApplied = prod.TotalSprayApplied;
            AreaTreated = prod.AreaTreated;
            DermalSamplingTime = prod.DermalSamplingTime;
            InhalationSamplingTime = prod.InhalationSamplingTime;

            HumidityMax = prod.HumidityMax;
            HumidityMin = prod.HumidityMin;
            Humidity = prod.Humidity;
            TemperatureMax = prod.TemperatureMax;
            TemperatureMin = prod.TemperatureMin;
            Temperature = prod.Temperature;
            WindSpeedMax = prod.WindSpeedMax;
            WindSpeedMin = prod.WindSpeedMin;
            WindSpeed = prod.WindSpeed;
        }
    }
}

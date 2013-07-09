using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class MixingInfo
    {
        public StaticItem EquipmentLoaded { get; set; }
        public StaticItem EngineeringControls { get; set; }
        public StaticItem Cleanup { get; set; }
        public StaticItem Repairs { get; set; }
        public string IncidentalExposure { get; set; }
        public string EngineeringControlsMakeModel { get; set; }
        public string ProcedureAndEquipment { get; set; }
        public StaticItem SetupEquipment { get; set; }
        public StaticItem Diluent { get; set; }
        public string Additives { get; set; }
        public Volume PremixTankCapacity { get; set; }
        public Volume SprayerTankCapacity { get; set; }
        public Volume HopperCapacity { get; set; }
        public double? TotalLoadsMixed { get; set; }
        public Mass TotalAiMixed { get; set; }
        public Volume FinalSprayVolumeMixed { get; set; }
        public double? HumidityMax { get; set; }
        public double? HumidityMin { get; set; }
        public double? Humidity { get; set; }
        public Temperature TemperatureMax { get; set; }
        public Temperature TemperatureMin { get; set; }
        public Temperature Temperature { get; set; }
        public Velocity WindSpeedMax { get; set; }
        public Velocity WindSpeedMin { get; set; }
        public Velocity WindSpeed { get; set; }
        public List<StaticItem> ClothingWorn = new List<StaticItem>();

        public MixingInfo()
        {
        }

        public MixingInfo(MixingInfo mix)
        {
            EquipmentLoaded = mix.EquipmentLoaded;
            EngineeringControls = mix.EngineeringControls;
            Cleanup = mix.Cleanup;
            Repairs = mix.Repairs;
            IncidentalExposure = mix.IncidentalExposure;
            EngineeringControlsMakeModel = mix.EngineeringControlsMakeModel;
            SetupEquipment = mix.SetupEquipment;
            Diluent = mix.Diluent;
            Additives = mix.Additives;
            PremixTankCapacity = mix.PremixTankCapacity;
            SprayerTankCapacity = mix.SprayerTankCapacity;
            HopperCapacity = mix.HopperCapacity;
            TotalLoadsMixed = mix.TotalLoadsMixed;
            TotalAiMixed = mix.TotalAiMixed;
            FinalSprayVolumeMixed = mix.FinalSprayVolumeMixed;
            HumidityMax = mix.HumidityMax;
            HumidityMin = mix.HumidityMin;
            Humidity = mix.Humidity;
            TemperatureMax = mix.TemperatureMax;
            TemperatureMin = mix.TemperatureMin;
            Temperature = mix.Temperature;
            WindSpeedMax = mix.WindSpeedMax;
            WindSpeedMin = mix.WindSpeedMin;
            WindSpeed = mix.WindSpeed;
            ClothingWorn = new List<StaticItem>(mix.ClothingWorn);
        }
    }
}

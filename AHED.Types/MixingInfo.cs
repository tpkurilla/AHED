using System;
using System.Collections.Generic;

namespace AHED.Types
{
    [Serializable]
    public class MixingInfo : IDeepClone<MixingInfo>, IPropertyInitializer
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

        /// <summary>
        /// Makes a deep copy of <c>mixInfo</c>.
        /// </summary>
        /// <param name="mixInfo">MixingInfo to copy.</param>
        public MixingInfo(MixingInfo mixInfo)
        {
            EquipmentLoaded = mixInfo.EquipmentLoaded;
            EngineeringControls = mixInfo.EngineeringControls;
            Cleanup = mixInfo.Cleanup;
            Repairs = mixInfo.Repairs;
            IncidentalExposure = mixInfo.IncidentalExposure;
            EngineeringControlsMakeModel = mixInfo.EngineeringControlsMakeModel;
            ProcedureAndEquipment = mixInfo.ProcedureAndEquipment;
            SetupEquipment = mixInfo.SetupEquipment;
            Diluent = mixInfo.Diluent;
            Additives = mixInfo.Additives;
            PremixTankCapacity = new Volume(mixInfo.PremixTankCapacity);
            SprayerTankCapacity = new Volume(mixInfo.SprayerTankCapacity);
            HopperCapacity = new Volume(mixInfo.HopperCapacity);
            TotalLoadsMixed = mixInfo.TotalLoadsMixed;
            TotalAiMixed = new Mass(mixInfo.TotalAiMixed);
            FinalSprayVolumeMixed = new Volume(mixInfo.FinalSprayVolumeMixed);
            HumidityMax = mixInfo.HumidityMax;
            HumidityMin = mixInfo.HumidityMin;
            Humidity = mixInfo.Humidity;
            TemperatureMax = new Temperature(mixInfo.TemperatureMax);
            TemperatureMin = new Temperature(mixInfo.TemperatureMin);
            Temperature = new Temperature(mixInfo.Temperature);
            WindSpeedMax = new Velocity(mixInfo.WindSpeedMax);
            WindSpeedMin = new Velocity(mixInfo.WindSpeedMin);
            WindSpeed = new Velocity(mixInfo.WindSpeed);
            ClothingWorn = new List<StaticItem>(mixInfo.ClothingWorn);  // references to immutable (in practice) objects, so this is good enough
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            EquipmentLoaded = _template.EquipmentLoaded;
            EngineeringControls = _template.EngineeringControls;
            Cleanup = _template.Cleanup;
            Repairs = _template.Repairs;
            IncidentalExposure = _template.IncidentalExposure;
            EngineeringControlsMakeModel = _template.EngineeringControlsMakeModel;
            ProcedureAndEquipment = _template.ProcedureAndEquipment;
            SetupEquipment = _template.SetupEquipment;
            Diluent = _template.Diluent;
            Additives = _template.Additives;
            PremixTankCapacity = new Volume(_template.PremixTankCapacity);
            SprayerTankCapacity = new Volume(_template.SprayerTankCapacity);
            HopperCapacity = new Volume(_template.HopperCapacity);
            TotalLoadsMixed = _template.TotalLoadsMixed;
            TotalAiMixed = new Mass(_template.TotalAiMixed);
            FinalSprayVolumeMixed = new Volume(_template.FinalSprayVolumeMixed);
            HumidityMax = _template.HumidityMax;
            HumidityMin = _template.HumidityMin;
            Humidity = _template.Humidity;
            TemperatureMax = new Temperature(_template.TemperatureMax);
            TemperatureMin = new Temperature(_template.TemperatureMin);
            Temperature = new Temperature(_template.Temperature);
            WindSpeedMax = new Velocity(_template.WindSpeedMax);
            WindSpeedMin = new Velocity(_template.WindSpeedMin);
            WindSpeed = new Velocity(_template.WindSpeed);
            ClothingWorn = new List<StaticItem>(_template.ClothingWorn);  // references to immutable (in practice) objects, so this is good enough

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new MixingInfo()
            {
                EquipmentLoaded = StaticValues.Item(StaticValues.Groups.MixingEquipmentLoaded, (int)StaticValues.MixingEquipmentLoaded.NotSet),
                EngineeringControls = StaticValues.Item(StaticValues.Groups.MixLoadEngControls, (int)StaticValues.MixLoadEngControls.NotSet),
                Cleanup = StaticValues.Item(StaticValues.Groups.Reporting, (int)StaticValues.Reporting.NotSet),
                Repairs = StaticValues.Item(StaticValues.Groups.Reporting, (int)StaticValues.Reporting.NotSet),
                IncidentalExposure = null,
                EngineeringControlsMakeModel = null,
                ProcedureAndEquipment = null,
                SetupEquipment = StaticValues.Item(StaticValues.Groups.MixingSetupEquipment, (int)StaticValues.MixingSetupEquipment.NotSet),
                Diluent = StaticValues.Item(StaticValues.Groups.Diluent, (int)StaticValues.Diluent.NotSet),
                Additives = null,
                PremixTankCapacity = null,
                SprayerTankCapacity = null,
                HopperCapacity = null,
                TotalLoadsMixed = null,
                TotalAiMixed = null,
                FinalSprayVolumeMixed = null,
                HumidityMax = null,
                HumidityMin = null,
                Humidity = null,
                TemperatureMax = null,
                TemperatureMin = null,
                Temperature = null,
                WindSpeedMax = null,
                WindSpeedMin = null,
                WindSpeed = null,
                ClothingWorn = null
            };
        }

        /// <summary>
        /// Template initialized once to proper default values;
        /// </summary>
        private static MixingInfo _template;

        /// <summary>
        /// Creates a properly-initialized <c>MixingInfo</c> instance.  This
        /// is the preferred method for creating a new <c>MixingInfo</c>
        /// instance.
        /// </summary>
        /// <returns>A properly initialized <c>MixingInfo</c>.</returns>
        public static MixingInfo Create()
        {
            if (_template == null)
                CreateTemplate();

            return new MixingInfo(_template);
        }

        public MixingInfo DeepClone()
        {
            return new MixingInfo(this);
        }
    }
}

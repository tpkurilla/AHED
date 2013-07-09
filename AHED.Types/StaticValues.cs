using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AHED.Util;

namespace AHED.Types
{
    /// <summary>
    /// <list type="bullet">
    /// <listheader>Facilitates easy usage of Static Table entries:</listheader>
    /// <item><description>Provides strongly-typed names for Static Table entries for use by other modules.</description></item>
    /// <item><description>Initializes to known base case when static values missing from database.</description></item>
    /// <item><description>Can be used to create initial database at first-time start-up.</description></item>
    /// </list>
    /// <para>
    /// Ideally, whenever a static value is added to the main AHED database, the appropriate changes to
    /// the enumerations will be made here.  This will ensure that emergency generation of the static
    /// table will be up-to-date.
    /// </para>
    /// </summary>
    [Serializable]
    public class StaticValues
    {
        #region Enumerations

        /// <summary>
        /// An enumeration for the current status of a Study in a database.  This is an actual
        /// enumeration, with no <c>StaticItem</c> or <c>StaticValue.Groups</c> values.
        /// </summary>
        public enum QaStatus
        {
            [Description("")]
            NotSet = 0,

            [Description("New")]
            New = 100,

            [Description("QA Pending")]
            QaPending = 200,

            [Description("QA Rejected")]
            QaRejected = 300,

            [Description("Accepted")]
            Accepted = 400,
        }

        /// <summary>
        /// Enumeration for all groups of Static Items.  The description for each value
        /// is simply the enumeration name.  Since the Groups table is not meant to change,
        /// its values can be used anywhere for referencing a specific group.
        /// </summary>
        public enum Groups
        {
            [Description("Group")]
            Group = -1,     // Allows entries for each of the group types, including their description

            [Description("YesOrNo")]
            YesOrNo,

            [Description("Gender")]
            Gender,

            [Description("Country")]
            Country,

            [Description("Site")]
            Site,

            [Description("Season")]
            Season,

            [Description("Task")]
            Task,

            [Description("Employment")]
            Employment,

            [Description("Pesticide")]
            Pesticide,

            [Description("Formulation")]
            Formulation,

            [Description("Package")]
            Package,

            [Description("Foliage")]
            Foliage,

            [Description("Diluent")]
            Diluent,

            [Description("MixingSetupEquipment")]
            MixingSetupEquipment,

            [Description("MixingEquipmentLoaded")]
            MixingEquipmentLoaded,

            [Description("MixLoadEngControls")]
            MixLoadEngControls,

            [Description("AppEquipment")]
            AppEquipment,

            [Description("AppEngControls")]
            AppEngControls,

            [Description("WindDirection")]
            WindDirection,

            [Description("Reporting")]
            Reporting,

            [Description("PpeLayerClothing")]
            PpeLayerClothing,

            [Description("DosimeterGroups")]
            DosimeterGroups,

            [Description("DosimeterDescriptions")]
            DosimeterDescriptions,

            [Description("DosimeterMatrices")]
            DosimeterMatrices,

            [Description("BodyParts")]
            BodyParts,

            [Description("OuterDosimeterClothing")]
            OuterDosimeterClothing
        };

        public enum YesNo
        {
            [Description("")]
            NotSet = 0,

            [Description("No")]
            No,

            [Description("Yes")]
            Yes
        };

        public enum Gender
        {
            [Description("")]
            NotSet = 0,

            [Description("Male")]
            Male,

            [Description("Female")]
            Female
        };

        public enum Country
        {
            [Description("")]
            NotSet = 0,

            [Description("USA")]
            Usa,

            [Description("Canada")]
            Canada,

            [Description("United Kingdom")]
            UnitedKingdom,

            [Description("France")]
            France,

            [Description("Germany")]
            Germany,

            [Description("Spain")]
            Spain,

            [Description("Italy")]
            Italy
        };

        public enum Site
        {
            [Description("")]
            NotSet = 0,

            [Description("Indoor - Greenhouse")]
            IndoorGreenhouse,

            [Description("Indoor - Other")]
            IndoorOther,

            [Description("Outdoor - Bareground")]
            OutdoorBareground,

            [Description("Outdoor - Field Crops")]
            OutdoorFieldCrops,

            [Description("Outdoor - Nursery/shadehouse")]
            OutdoorNurseryShadehouse,

            [Description("Outdoor - Orchard")]
            OutdoorOrchard,

            [Description("Outdoor - Right-of-way")]
            OutdoorRightOfWay,

            [Description("Outdoor - Trellis/vine crop")]
            OutdoorTrellisVineCrop,

            [Description("Outdoor - Other")]
            OutdoorOther
        };

        public enum Season
        {
            [Description("")]
            NotSet = 0,

            [Description("Winter - Dec/Jan/Feb")]
            WinterNorthern,

            [Description("Spring - Mar/Apr/May")]
            SpringNorthern,

            [Description("Summer - Jun/Jul/Aug")]
            SummerNorthern,

            [Description("Summer - Jun/Jul/Aug")]
            FallNorthern,

            [Description("Winter - Jun/Jul/Aug")]
            WinterSouthern,

            [Description("Spring - Sep/Oct/Nov")]
            SpringSouthern,

            [Description("Summer - Dec/Jan/Feb")]
            SummerSouthern,

            [Description("Fall - Mar/Apr/May")]
            FallSouthern
        };

        public enum Task
        {
            [Description("")]
            NotSet = 0,

            [Description("Loader")]
            Loader,

            [Description("Mixer/Loader")]
            MixerLoader,

            [Description("Applicator")]
            Applicator,

            [Description("Mixer/Loader/Applicator")]
            MixerLoaderApplicator
        };

        public enum Employment
        {
            [Description("")]
            NotSet = 0,

            [Description("Commercial Applicator")]
            CommercialApplicator,

            [Description("Commercial Applicator (employee)")]
            CommercialEmployee,

            [Description("Farm (facility) employee")]
            FarmEmployee,

            [Description("Farm (facility) operator")]
            FarmOperator,

            [Description("Farm (facility) owner")]
            FarmOwner,

            [Description("Utility company employee")]
            UtilityEmployee
        };

        public enum Pesticide
        {
            [Description("")]
            NotSet = 0,

            [Description("Biocide")]
            Biocide,

            [Description("Fungicide")]
            Fungicide,

            [Description("Herbicide")]
            Herbicide,

            [Description("Insecticide")]
            Insecticide,

            [Description("Insecticide/Nematicide")]
            InsecticideNematicide,

            [Description("Miticide")]
            Miticide,

            [Description("Nematicide")]
            Nematicide,

            [Description("Plant Grouth Regulator")]
            PlantGrowthRegulator
        };

        public enum Formulation
        {
            [Description("")]
            NotSet = 0,

            [Description("Granule (applied as graule)")]
            Granule,

            [Description("Liquid")]
            Liquid,

            [Description("Water dispersable granule (Dry Flowable)")]
            WaterDisperableGranule,

            [Description("Wettable powder")]
            WettablePowder
        };

        public enum Package
        {
            [Description("")]
            NotSet = 0,

            [Description("Bag")]
            Bag,

            [Description("Plastic Jug")]
            PlasticJug,

            [Description("Can")]
            Can,

            [Description("Drum (nonreturnable)")]
            DrumNonreturnable,

            [Description("Drum (returnable)")]
            DrumReturnable,

            [Description("Mini - bulk")]
            MiniBulk,

            [Description("Bulk Tank")]
            BulkTank,

            [Description("Water soluable package")]
            WaterSolublePackage,

            [Description("Lock and Load")]
            LockAndLoad
        };

        public enum Foliage
        {
            [Description("")]
            NotSet = 0,

            [Description("None - Not Applicable")]
            NoneNotApplicable,

            [Description("None - Bare Ground")]
            NoneBareGround,

            [Description("None - Bare Branches")]
            NoneBareBranches,

            [Description("< 25%")]
            LessThan25,

            [Description("25-50%")]
            _25to50,

            [Description("51-75%")]
            _51to75,

            [Description("> 75%")]
            Greater75
        };

        public enum Diluent
        {
            [Description("")]
            NotSet = 0,

            [Description("None")]
            None,

            [Description("Water")]
            Water,

            [Description("Other")]
            Other
        };

        public enum MixingSetupEquipment
        {
            [Description("")]
            NotSet = 0,

            [Description("Diluent directly in spray tank")]
            DiluentDirectly,

            [Description("Diluent in premix tank")]
            DiluentPremixTank,

            [Description("Diluent in premix tank and transfer to spray tank")]
            DiluentPremixTransferSpray,

            [Description("Mix using indicator system")]
            MixUsingIndicator
        };

        public enum MixingEquipmentLoaded
        {
            [Description("")]
            NotSet = 0,

            [Description("Backpack")]
            Backpack,

            [Description("Backpack with hack and squirt bottle")]
            BackpackHackAndSquirt,

            [Description("Hand wand tank")]
            HandWandTank,

            [Description("Groundboom")]
            Groundboom,

            [Description("Airblast")]
            Airblast,

            [Description("Aerial - fixed wing")]
            AerialFixedWing,

            [Description("Aerial - rotor craft")]
            AerialRotor,

            [Description("Chemigation")]
            Chemigation,

            [Description("Not Applicable")]
            NotApplicable
        };

        public enum MixLoadEngControls
        {
            [Description("")]
            NotSet = 0,

            [Description("None - open pour")]
            NoneOpenPour,

            [Description("Water soluble package")]
            WaterSolublePackage,

            [Description("Closed system - container breech")]
            ClosedContainerBreech,

            [Description("Closed system - granule gravity feed")]
            ClosedGranuleGravity,

            [Description("Closed system - gravity feed")]
            ClosedGravityFeed,

            [Description("Closed system - suction extraction")]
            ClosedSuction,

            [Description("Closed system - manual probe")]
            ClosedManualProbe
        };

        public enum AppEquipment
        {
            [Description("")]
            NotSet = 0,

            [Description("Backpack - liquid, manual pump")]
            BackpackLiquid,

            [Description("Backpack - granule, gravity")]
            BackpackGranuleGravity,

            [Description("Backpack - granule")]
            BackpackGranule,

            [Description("Hack and Squirt")]
            HackAndSquirt,

            [Description("Handgun sprayer")]
            HandgunSprayer,

            [Description("Groundboom - ATV or golf cart")]
            GroundboomAtv,

            [Description("Groundboom - Small tractor (Lawn & garden-sized)")]
            GroundboomSmallTractor,

            [Description("Groundboom - Tractor / truck mounted")]
            GroundboomTractorMounted,

            [Description("Granular - Banded or in-furrow")]
            GranularBanded,

            [Description("Granular - Broadcast")]
            GranularBroadcast,

            [Description("Airblast - Tractor-drawn")]
            AirblastTractor,

            [Description("Airblast - Truck-mounted")]
            AirblastTruck,

            [Description("Aerial - Fixed wing")]
            AerialFixed,

            [Description("Aerial - Rotor craft")]
            AerialRotor,

            [Description("Chemigation")]
            Chemigation
        };

        public enum AppEngControls
        {
            [Description("")]
            NotSet = 0,

            [Description("Open cab")]
            OpenCab,

            [Description("Closed cab - window(s) or door(s) open")]
            ClosedCabOpen,

            [Description("Closed cab - windows and doors closed")]
            ClosedCabClosed
        };

        public enum WindDirection
        {
            [Description("")]
            NotSet = 0,

            [Description("Not reported")]
            NotReported,

            [Description("Upwind")]
            Upwind,

            [Description("Dowdwind")]
            Downwind,

            [Description("Various")]
            Various
        };

        public enum Reporting
        {
            [Description("")]
            NotSet = 0,

            [Description("None done or reported")]
            NoneReported,

            [Description("Monitored as part of task")]
            MonitoredPartOfTask,

            [Description("Monitored separately")]
            MonitoredSeparately
        };

        public enum Clothing
        {
            [Description("")]
            NotSet = 0,

            // Whole body
            [Description("Cloth coveralls")]
            ClothCoveralls = 100,

            [Description("Tyvek coveralls - without hood")]
            TyvekCoverallsNoHood,

            [Description("Tyvek coveralls - with hood")]
            TyvekCoverallsHood,

            // Upper body
            [Description("Reflective safety vest")]
            ReflectiveVest = 200,

            [Description("Cloth long sleeved shirt")]
            LongSleevedShirt,

            [Description("Cloth short sleeved shirt")]
            ShortSleevedShirt,

            [Description("Cloth jacket")]
            ClothJacket,

            [Description("CR apron")]
            CrApron,

            [Description("CR apron worn for back protection")]
            CrApronBack,

            [Description("Tyvek Jacket (with hood)")]
            TyvekJacketHood,

            [Description("Tyvek Jacket (without hood)")]
            TyvekJacketNoHood,

            [Description("CR Jacket (rainsuit) (without hood)")]
            CrJacketRainsuitNoHood,

            [Description("CR Jacket (rainsuit) (with hood)")]
            CrJacketRainsuitHood,

            // Lower body
            [Description("Chaps or snake leggings")]
            ChapsOrSnakeLeggings = 300,

            [Description("Cloth pants - long")]
            LongPants,

            [Description("Cloth pants - short")]
            ShortPants,

            [Description("Tyvek pants")]
            TyvekPants,

            [Description("CR (rainsuit) pants")]
            CrRainsuitPants,

            // Head
            [Description("Hat or Cap")]
            HatOrCap = 400,

            [Description("Cloth Bandana (head scarf)")]
            ClothBandanaHeadScarf,

            [Description("Cloth Bandana (neck scarf)")]
            ClothBandanaNeckScarf,

            [Description("CR hat ('rain hat')")]
            CrHatRainHat,

            [Description("CR hood")]
            CrHood,

            // Face/Neck
            [Description("Dust/mist mask")]
            DustMistMask = 500,

            [Description("Half face - mask respirator")]
            HalfFaceRespirator,

            [Description("Full face - respirator")]
            FullFaceRespirator,

            [Description("Eyeglasses or sunglasses")]
            Glasses,

            [Description("Protective eyewear")]
            ProtectiveEyewear,

            [Description("Goggles")]
            Goggles,

            [Description("Face Shield")]
            FaceShield,

            // Hands
            [Description("Non-CR Gloves")]
            NonCrGloves = 600,

            [Description("CR Gloves")]
            CrGloves,

            // Feet
            [Description("Shoes/boots over socks")]
            ShoesBootsOverSocks = 700,

            [Description("CR boots over socks")]
            CrBootsOverSocks,

            [Description("CR boots over shoes/boots over socks")]
            CrBootsOverShoesBootsOverSocks

            // Inhalation -- NONE

            // Field Fortification -- NONE
        };

        public enum DosimeterGroups
        {
            [Description("")]
            NotSet = 0,

            [Description("Whole Body Dosimeter - 1 Piece")]
            WholeBodyDosimeter1Piece,

            [Description("Whole Body Dosimeter - 2 Piece")]
            WholeBodyDosimeter2Piece,

            [Description("Whole Body Dosimeter - 3 Piece")]
            WholeBodyDosimeter3Piece,

            [Description("Whole Body Dosimeter - 4 Piece 2 Torso")]
            WholeBodyDosimeter4Piece2Torso,

            [Description("Whole Body Dosimeter - 4 Piece 2 Legs")]
            WholeBodyDosimeter4Piece2Legs,

            [Description("Whole Body Dosimeter - 6 Piece")]
            WholeBodyDosimeter6Piece,

            [Description("Face and neck wipes")]
            FaceNeckWipe,

            [Description("Head patches")]
            Head,

            [Description("Hand Dosimeters")]
            Hands,

            [Description("Feet Dosimeters")]
            Feet,

            [Description("Inhalation Dosimeters")]
            Inhalation,

            [Description("Field Fortification Dosimeters")]
            FieldFortification
        }

        public enum DosimeterDescriptions
        {
            [Description("")]
            NotSet = 0,

            [Description("1 piece ID - whole body")]
            Body1WholeBody,

            [Description("2 piece ID - lower body")]
            Body2LowerBody,

            [Description("2 piece ID - upper body")]
            Body2UpperBody,

            [Description("3 piece ID - arms")]
            Body3Arms,

            [Description("3 piece ID - torso")]
            Body3Torso,

            [Description("3 piece ID - legs")]
            Body3Legs,

            [Description("4 piece ID (legs) - arms")]
            Body4LegsArms,

            [Description("4 piece ID (legs) - whole torso")]
            Body4LegsTorso,

            [Description("4 piece ID (legs) - lower legs")]
            Body4LegsLowerLegs,

            [Description("4 piece ID (legs) - upper legs")]
            Body4LegsUpperLegs,

            [Description("4 piece ID (torso) - arms")]
            Body4TorsoArms,

            [Description("4 piece ID (torso) - front torso")]
            Body4TorsoFrontTorso,

            [Description("4 piece ID (torso) - rear torso")]
            Body4TorsoRearTorso,

            [Description("4 piece ID (torso) - legs")]
            Body4TorsoLegs,

            [Description("6 piece ID - lower arms")]
            Body6LowerArms,

            [Description("6 piece ID - upper arms")]
            Body6UpperArms,

            [Description("6 piece ID - front torso")]
            Body6FrontTorso,

            [Description("6 piece ID - rear torso")]
            Body6RearTorso,

            [Description("6 piece ID - lower legs")]
            Body6LowerLegs,

            [Description("6 piece ID - upper legs")]
            Body6UpperLegs,

            [Description("Swab - detergent water")]
            FaceNeckWipeDetergent,

            [Description("Swab - organic solvent")]
            FaceNeckWipeOrganic,

            [Description("Swab - water")]
            FaceNeckWipeWater,

            [Description("Patch (inner) on hat")]
            PatchInnerOnHat,

            [Description("Patch (outer) on hat")]
            PatchOuterOnHat,

            [Description("Hand wash - detergent water")]
            HandWashDetergent,

            [Description("Hand wash - organic solvent")]
            HandWashOrganic,

            [Description("Hand wash - water")]
            HandWashWater,

            [Description("Socks")]
            Socks,

            [Description("OVS front section")]
            OvsFront,

            [Description("OVS back section")]
            OvsBack,

            [Description("OVS whole matrix")]
            OvsWhole,

            [Description("Glass fiber filter front section")]
            GlassFiberFilterFront,

            [Description("Glass fiber filter back section")]
            GlassFiberFilterBack,

            [Description("Glass fiber filter whole matrix")]
            GlassFiberFilterWhole,

            [Description("Inner dosimeter (FF)")]
            InnerDosimeterFF,

            [Description("Outer dosimeter (FF)")]
            OuterDosimeterFF,

            [Description("Patch (outer) on hat (FF)")]
            PatchOuterOnHatFF,

            [Description("Patch (inner) on hat (FF)")]
            PatchInnerOnHatFF,

            [Description("Face/neck swab - detergent water (FF)")]
            FaceNeckWipeDetergentFF,

            [Description("Face/neck swab - organic solvent (FF)")]
            FaceNeckWipeOrganicFF,

            [Description("Face/neck swab - water (FF)")]
            FaceNeckWipeWaterFF,

            [Description("Socks (FF)")]
            SocksFF,

            [Description("Hand wash - detergent water (FF)")]
            HandWashDetergentFF,

            [Description("Hand wash - organic solvent (FF)")]
            HandWashOrganicFF,

            [Description("Hand wash - water (FF)")]
            HandWashWaterFF,

            [Description("Inhalation - OVS (FF)")]
            InhalationOvsFF,

            [Description("Inhalation - glass fiber filter (FF)")]
            InhalationGlassFF
        }

        public enum DosimeterMatrices
        {
            [Description("")]
            NotSet = 0,

            [Description("100% cotton")]
            Cotton,

            [Description("Cotton / polyester blend")]
            CottonPolyesterBlend,

            [Description("100% cotton gauze and 4 mL of 0.01% v/v AOT solution")]
            CottonGauzeAotSolution,

            [Description("100% cotton gauze")]
            CottonGauze,

            [Description("0.01% v/v AOT solution")]
            AotSolution,

            [Description("100% cotton patch")]
            PatchCotton,

            [Description("Patch - other")]
            PatchOther,

            [Description("85% cotton, 15% nylon")]
            Cotton85Nylon15,

            [Description("Glass fiber filter")]
            GlassFiberFilter,

            [Description("XAD2")]
            Xad2,

            [Description("Chromosorb")]
            Chromosorb,

            [Description("4 mL 0.01% v/v AOT solution")]
            AotSolution4mL,

        }

        public enum BodyParts
        {
            [Description("")]
            NotSet = 0,

            [Description("Upper body")]
            UpperBody,

            [Description("Lower body")]
            LowerBody,

            [Description("Whole body")]
            WholeBody,

            [Description("Face/Neck")]
            FaceNeck,

            [Description("Head")]
            Head,

            [Description("Hands")]
            Hands,

            [Description("Feet")]
            Feet,

            [Description("Inhalation")]
            Inhalation
        }

        #endregion

        #region Group mapping tables

        #region key -> CachedStaticItem maps for all enumerations

        /// <summary>
        /// Holds all Cached Static Items in a single dictionary for rapid generic look-up.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> All { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Group" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> GroupMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "YesOrNo" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> YesOrNoMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Gender" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> GenderMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Site" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> SiteMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Season" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> SeasonMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Task" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> TaskMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Employment" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> EmploymentMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Pesticide" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> PesticideMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Formulation" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> FormulationMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Package" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> PackageMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Foliage" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> FoliageMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Diluent" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> DiluentMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "MixingSetupEquipment" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> MixingSetupEquipmentMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "MixingEquipmentLoaded" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> MixingEquipmentLoadedMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "MixLoadEngControls" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> MixLoadEngControlsMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "AppEquipment" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> AppEquipmentMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "AppEngControls" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> AppEngControlsMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "WindDirection" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> WindDirectionMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Reporting" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> ReportingMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "PpeLayerClothing" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> ClothingMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "DosimeterGroups" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> DosimeterGroupMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the <c>DosimeterLocations</c> group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> DosimeterLocationMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the <c>DosimeterMatrices</c> group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> DosimeterMatrixMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "BodyParts" group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> BodyPartMap { get; protected set; }

        #endregion key -> CachedStaticItem maps for all enumerations

        #region string -> CachedStaticItem maps for all enumerations

        /// <summary>
        /// Holds the Cached Static Items for the "Group" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> GroupDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "YesOrNo" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> YesOrNoDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Gender" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> GenderDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Site" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> SiteDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Season" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> SeasonDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Task" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> TaskDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Employment" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> EmploymentDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Pesticide" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> PesticideDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Formulation" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> FormulationDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Package" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> PackageDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Foliage" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> FoliageDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Diluent" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> DiluentDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "MixingSetupEquipment" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> MixingSetupEquipmentDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "MixingEquipmentLoaded" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> MixingEquipmentLoadedDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "MixLoadEngControls" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> MixLoadEngControlsDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "AppEquipment" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> AppEquipmentDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "AppEngControls" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> AppEngControlsDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "WindDirection" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> WindDirectionDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "Reporting" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> ReportingDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "PpeLayerClothing" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> ClothingDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "DosimeterGroups" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> DosimeterGroupDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the <c>DosimeterLocations</c> group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> DosimeterLocationDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the <c>DosimeterMatrices</c> group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> DosimeterMatrixDescMap { get; protected set; }

        /// <summary>
        /// Holds the Cached Static Items for the "BodyParts" group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> BodyPartDescMap { get; protected set; }

        #endregion string -> CachedStaticItem maps for all enumerations

        #region Other maps

        /// <summary>
        /// Holds the Enum types for each Groups entry.
        /// </summary>
        static public Dictionary<Groups, Type> GroupEnums { get; protected set; }

        /// <summary>
        /// Maps groupName -> Cached Static Items for that group.
        /// </summary>
        static public Dictionary<Groups, Dictionary<int, CachedStaticItem>> GroupTables { get; protected set; }

        /// <summary>
        /// Maps groupName -> Cached Static Item Descriptions for that group.
        /// </summary>
        static public Dictionary<Groups, Dictionary<string, CachedStaticItem>> GroupDescTables { get; protected set; }

        /// <summary>
        /// Maps a <c>DosimeterGroups</c> id to a list of associated <c>DosimeterLocations</c> in that group.
        /// </summary>
        static public Dictionary<DosimeterGroups, List<CachedStaticItem>> DosimeterGroupLocations { get; protected set; }

        /// <summary>
        /// Maps a <c>DosimeterGroups</c> id to a list of associated <c>DosimeterMatrices</c> in that group.
        /// </summary>
        static public Dictionary<DosimeterGroups, List<CachedStaticItem>> DosimeterGroupMatrices { get; protected set; }

        /// <summary>
        /// Maps a <c>DosimeterGroups</c> id to a list of associated <c>DosimeterGroupBodyParts</c> in that group.
        /// </summary>
        static public Dictionary<DosimeterGroups, List<CachedStaticItem>> DosimeterGroupBodyParts { get; protected set; }

        /// <summary>
        /// Maps a Body Part to a list of associated PpeLayerClothing that can be layered.
        /// </summary>
        static public Dictionary<BodyParts, List<CachedStaticItem>> PpeLayerClothingMap { get; protected set; }

        /// <summary>
        /// Maps an Outer PpeLayerClothing Body Part to a list of associated Outer Dosimeters.
        /// </summary>
        static public Dictionary<BodyParts, List<CachedStaticItem>> OuterDosimeterClothingMap { get; protected set; }

        #endregion Other maps

        #endregion

        #region Cache Management

        public static CachedStaticItem Lookup(Groups groupId, int itemId)
        {
            int key = StaticItem.GetKey(groupId, itemId);
            return All[key];
        }

        public static CachedStaticItem Lookup(Groups groupId, string itemDesc)
        {
            var groupDescTable = GroupDescTables[groupId];
            if (groupDescTable == null)
                return null;

            return groupDescTable[itemDesc];
        }

        private static int SortStaticItemsByItemId(StaticItem lhs, StaticItem rhs)
        {
            if (lhs == null)
            {
                if (rhs == null)
                {
                    // Both are 'null', so they are equal
                    return 0;
                }

                // lhs is null, but rhs has a value, so rhs sorts before lhs
                return -1;
            }

            if (rhs == null)
            {
                // lhs is not 'null', and rhs is, so lhs sorts before rhs
                return 1;
            }

            // at this point we know neither is 'null', so do a straight comparison
            int diff = lhs.ItemId - rhs.ItemId;
            if (diff < 0)
                return -1;

            if (diff > 0)
                return 1;

            // Item Ids are equal, so lhs == rhs
            return 0;
        }

        public static List<StaticItem> GroupOptions(Groups groupId)
        {
            var csiList = GroupDescTables[groupId].Values.ToList();
            var optionList = csiList.Select(cachedStaticItem => cachedStaticItem.Item).ToList();
            optionList.Sort(SortStaticItemsByItemId);
            return optionList;
        }

        /// <summary>
        /// Adds the values in <c>table</c> to the in-memory cache of Static Items.
        /// <para>
        /// If a collision occurs within a group table by ItemId, then a new ItemId is provided.
        /// If a collision occurs within a group table by Desc, then the Static Item is not added.
        /// </para>
        /// </summary>
        /// <param name="dbName">The name of the database containing <c>table</c>.</param>
        /// <param name="table">The <c>StaticTable</c> whose members are to be added to the cache.</param>
        public static void AddTable(string dbName, StaticTable table)
        {
            List<KeyValuePair<Int32, StaticItem>> collisions = new List<KeyValuePair<int, StaticItem>>();
            foreach (KeyValuePair<Int32, StaticItem> item in table)
            {
                if (All.ContainsKey(item.Key))
                {
                    // Collision, so remember it for de-confliction later.
                    collisions.Add(item);
                }
                else
                {
                    // Double check enumeration values
                    Groups grp = (Groups)item.Value.GroupId;
                    if (!Enum.IsDefined(grp.GetType(), grp))
                    {
                        // This is a bad group Id, so log it
                        Log.Error("Invalid GroupId for " + item.Value.ToString());
                        continue;
                    }

                    Type enumType = GroupEnums[grp];
                    if (!Enum.IsDefined(enumType.GetType(), item.Value.ItemId))
                    {
                    }

                    CachedStaticItem csi = new CachedStaticItem(dbName, item.Value);
                    All.Add(item.Key, csi);

                    Dictionary<int, CachedStaticItem> groupTable = GroupTables[grp];
                    groupTable.Add(item.Key, csi);

                    Dictionary<string, CachedStaticItem> groupDescTable = GroupDescTables[grp];
                    groupDescTable.Add(item.Value.Desc, csi);
                }
            }

            // Address any duplications here
            foreach (KeyValuePair<Int32, StaticItem> item in collisions)
            {
                // @todo: if Desc duplicate, do nothing, otherwise get the next integer available for the given enumeration
                Log.Warning("Static Item collision; later entry ignored.  " + item.Value.ToString());
            }
        }

        /// <summary>
        /// Removes all entries for <c>db</c> from cache.
        /// </summary>
        /// <param name="dbName">Database for which to remove it members</param>
        /// <returns>Number of entries purged from all tables.</returns>
        public static int Purge(string dbName)
        {
            int totalPurged = 0;

            // @todo: LINQ Voodoo for removals
            // @todo: These comparisions *should* be good using db instead of db.FullName.

            // Add items to remove to list to avoid modifying dictionary during foreach loop.
            List<KeyValuePair<int, CachedStaticItem>> itemsToRemove = new List<KeyValuePair<int, CachedStaticItem>>();
            foreach (KeyValuePair<int, CachedStaticItem> item in All)
                if (item.Value.DbName == dbName)
                    itemsToRemove.Add(item);

            totalPurged += itemsToRemove.Count;
            foreach (KeyValuePair<int, CachedStaticItem> item in itemsToRemove)
                All.Remove(item.Key);

            // Now do all of the specific group tables
            foreach (KeyValuePair<Groups, Dictionary<int, CachedStaticItem>> groupTable in GroupTables)
            {
                itemsToRemove.Clear();
                foreach (KeyValuePair<int, CachedStaticItem> item in groupTable.Value)
                    if (item.Value.DbName == dbName)
                        itemsToRemove.Add(item);

                totalPurged += itemsToRemove.Count;
                foreach (KeyValuePair<int, CachedStaticItem> item in itemsToRemove)
                    groupTable.Value.Remove(item.Key);
            }

            return totalPurged;
        }

        #endregion

        #region Static initializations

        static StaticValues()
        {
            #region GroupTables

            All = new Dictionary<int, CachedStaticItem>();
            GroupTables = new Dictionary<Groups, Dictionary<int, CachedStaticItem>>();
            GroupMap = new Dictionary<int, CachedStaticItem>();
            YesOrNoMap = new Dictionary<int, CachedStaticItem>();
            GenderMap = new Dictionary<int, CachedStaticItem>();
            SiteMap = new Dictionary<int, CachedStaticItem>();
            SeasonMap = new Dictionary<int, CachedStaticItem>();
            TaskMap = new Dictionary<int, CachedStaticItem>();
            EmploymentMap = new Dictionary<int, CachedStaticItem>();
            PesticideMap = new Dictionary<int, CachedStaticItem>();
            FormulationMap = new Dictionary<int, CachedStaticItem>();
            PackageMap = new Dictionary<int, CachedStaticItem>();
            FoliageMap = new Dictionary<int, CachedStaticItem>();
            DiluentMap = new Dictionary<int, CachedStaticItem>();
            MixingSetupEquipmentMap = new Dictionary<int, CachedStaticItem>();
            MixingEquipmentLoadedMap = new Dictionary<int, CachedStaticItem>();
            MixLoadEngControlsMap = new Dictionary<int, CachedStaticItem>();
            AppEquipmentMap = new Dictionary<int, CachedStaticItem>();
            AppEngControlsMap = new Dictionary<int, CachedStaticItem>();
            WindDirectionMap = new Dictionary<int, CachedStaticItem>();
            ReportingMap = new Dictionary<int, CachedStaticItem>();
            ClothingMap = new Dictionary<int, CachedStaticItem>();
            DosimeterGroupMap = new Dictionary<int, CachedStaticItem>();
            DosimeterLocationMap = new Dictionary<int, CachedStaticItem>();
            DosimeterGroupLocations = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
            DosimeterMatrixMap = new Dictionary<int, CachedStaticItem>();
            DosimeterGroupMatrices = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
            BodyPartMap = new Dictionary<int, CachedStaticItem>();
            PpeLayerClothingMap = new Dictionary<BodyParts, List<CachedStaticItem>>();
            OuterDosimeterClothingMap = new Dictionary<BodyParts, List<CachedStaticItem>>();

            GroupTables.Add(Groups.Group, GroupMap);
            GroupTables.Add(Groups.YesOrNo, YesOrNoMap);
            GroupTables.Add(Groups.Gender, GenderMap);
            GroupTables.Add(Groups.Site, SiteMap);
            GroupTables.Add(Groups.Season, SeasonMap);
            GroupTables.Add(Groups.Task, TaskMap);
            GroupTables.Add(Groups.Employment, EmploymentMap);
            GroupTables.Add(Groups.Pesticide, PesticideMap);
            GroupTables.Add(Groups.Formulation, FormulationMap);
            GroupTables.Add(Groups.Package, PackageMap);
            GroupTables.Add(Groups.Foliage, FoliageMap);
            GroupTables.Add(Groups.Diluent, DiluentMap);
            GroupTables.Add(Groups.MixingSetupEquipment, MixingSetupEquipmentMap);
            GroupTables.Add(Groups.MixingEquipmentLoaded, MixingEquipmentLoadedMap);
            GroupTables.Add(Groups.MixLoadEngControls, MixLoadEngControlsMap);
            GroupTables.Add(Groups.AppEquipment, AppEquipmentMap);
            GroupTables.Add(Groups.AppEngControls, AppEngControlsMap);
            GroupTables.Add(Groups.WindDirection, WindDirectionMap);
            GroupTables.Add(Groups.Reporting, ReportingMap);
            GroupTables.Add(Groups.PpeLayerClothing, ClothingMap);
            GroupTables.Add(Groups.DosimeterGroups, DosimeterGroupMap);
            GroupTables.Add(Groups.DosimeterMatrices, DosimeterMatrixMap);
            GroupTables.Add(Groups.DosimeterDescriptions, DosimeterLocationMap);
            GroupTables.Add(Groups.BodyParts, BodyPartMap);

            #endregion GroupTables

            #region GroupDescTables

            GroupDescTables = new Dictionary<Groups, Dictionary<string, CachedStaticItem>>();
            GroupDescMap = new Dictionary<string, CachedStaticItem>();
            YesOrNoDescMap = new Dictionary<string, CachedStaticItem>();
            GenderDescMap = new Dictionary<string, CachedStaticItem>();
            SiteDescMap = new Dictionary<string, CachedStaticItem>();
            SeasonDescMap = new Dictionary<string, CachedStaticItem>();
            TaskDescMap = new Dictionary<string, CachedStaticItem>();
            EmploymentDescMap = new Dictionary<string, CachedStaticItem>();
            PesticideDescMap = new Dictionary<string, CachedStaticItem>();
            FormulationDescMap = new Dictionary<string, CachedStaticItem>();
            PackageDescMap = new Dictionary<string, CachedStaticItem>();
            FoliageDescMap = new Dictionary<string, CachedStaticItem>();
            DiluentDescMap = new Dictionary<string, CachedStaticItem>();
            MixingSetupEquipmentDescMap = new Dictionary<string, CachedStaticItem>();
            MixingEquipmentLoadedDescMap = new Dictionary<string, CachedStaticItem>();
            MixLoadEngControlsDescMap = new Dictionary<string, CachedStaticItem>();
            AppEquipmentDescMap = new Dictionary<string, CachedStaticItem>();
            AppEngControlsDescMap = new Dictionary<string, CachedStaticItem>();
            WindDirectionDescMap = new Dictionary<string, CachedStaticItem>();
            ReportingDescMap = new Dictionary<string, CachedStaticItem>();
            ClothingDescMap = new Dictionary<string, CachedStaticItem>();
            DosimeterGroupDescMap = new Dictionary<string, CachedStaticItem>();
            DosimeterLocationDescMap = new Dictionary<string, CachedStaticItem>();
            DosimeterGroupLocations = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
            DosimeterMatrixDescMap = new Dictionary<string, CachedStaticItem>();
            DosimeterGroupMatrices = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
            BodyPartDescMap = new Dictionary<string, CachedStaticItem>();

            GroupDescTables.Add(Groups.Group, GroupDescMap);
            GroupDescTables.Add(Groups.YesOrNo, YesOrNoDescMap);
            GroupDescTables.Add(Groups.Gender, GenderDescMap);
            GroupDescTables.Add(Groups.Site, SiteDescMap);
            GroupDescTables.Add(Groups.Season, SeasonDescMap);
            GroupDescTables.Add(Groups.Task, TaskDescMap);
            GroupDescTables.Add(Groups.Employment, EmploymentDescMap);
            GroupDescTables.Add(Groups.Pesticide, PesticideDescMap);
            GroupDescTables.Add(Groups.Formulation, FormulationDescMap);
            GroupDescTables.Add(Groups.Package, PackageDescMap);
            GroupDescTables.Add(Groups.Foliage, FoliageDescMap);
            GroupDescTables.Add(Groups.Diluent, DiluentDescMap);
            GroupDescTables.Add(Groups.MixingSetupEquipment, MixingSetupEquipmentDescMap);
            GroupDescTables.Add(Groups.MixingEquipmentLoaded, MixingEquipmentLoadedDescMap);
            GroupDescTables.Add(Groups.MixLoadEngControls, MixLoadEngControlsDescMap);
            GroupDescTables.Add(Groups.AppEquipment, AppEquipmentDescMap);
            GroupDescTables.Add(Groups.AppEngControls, AppEngControlsDescMap);
            GroupDescTables.Add(Groups.WindDirection, WindDirectionDescMap);
            GroupDescTables.Add(Groups.Reporting, ReportingDescMap);
            GroupDescTables.Add(Groups.PpeLayerClothing, ClothingDescMap);
            GroupDescTables.Add(Groups.DosimeterGroups, DosimeterGroupDescMap);
            GroupDescTables.Add(Groups.DosimeterMatrices, DosimeterMatrixDescMap);
            GroupDescTables.Add(Groups.DosimeterDescriptions, DosimeterLocationDescMap);
            GroupDescTables.Add(Groups.BodyParts, BodyPartDescMap);

            #endregion GroupDescTables

            #region GroupEnums

            GroupEnums.Add(Groups.Group, Groups.Group.GetType());
            GroupEnums.Add(Groups.YesOrNo, YesNo.NotSet.GetType());
            GroupEnums.Add(Groups.Gender, Gender.NotSet.GetType());
            GroupEnums.Add(Groups.Site, Site.NotSet.GetType());
            GroupEnums.Add(Groups.Season, Season.NotSet.GetType());
            GroupEnums.Add(Groups.Task, Task.NotSet.GetType());
            GroupEnums.Add(Groups.Employment, Employment.NotSet.GetType());
            GroupEnums.Add(Groups.Pesticide, Pesticide.NotSet.GetType());
            GroupEnums.Add(Groups.Formulation, Formulation.NotSet.GetType());
            GroupEnums.Add(Groups.Package, Package.NotSet.GetType());
            GroupEnums.Add(Groups.Foliage, Foliage.NotSet.GetType());
            GroupEnums.Add(Groups.Diluent, Diluent.NotSet.GetType());
            GroupEnums.Add(Groups.MixingSetupEquipment, MixingSetupEquipment.NotSet.GetType());
            GroupEnums.Add(Groups.MixingEquipmentLoaded, MixingEquipmentLoaded.NotSet.GetType());
            GroupEnums.Add(Groups.MixLoadEngControls, MixLoadEngControls.NotSet.GetType());
            GroupEnums.Add(Groups.AppEquipment, AppEquipment.NotSet.GetType());
            GroupEnums.Add(Groups.AppEngControls, AppEngControls.NotSet.GetType());
            GroupEnums.Add(Groups.WindDirection, WindDirection.NotSet.GetType());
            GroupEnums.Add(Groups.Reporting, Reporting.NotSet.GetType());
            GroupEnums.Add(Groups.PpeLayerClothing, Clothing.HatOrCap.GetType());
            GroupEnums.Add(Groups.DosimeterGroups, DosimeterGroups.NotSet.GetType());
            GroupEnums.Add(Groups.DosimeterDescriptions, DosimeterDescriptions.NotSet.GetType());
            GroupEnums.Add(Groups.BodyParts, BodyParts.NotSet.GetType());

            #endregion
        }

        public static void InitializeDefaults()
        {
            foreach (KeyValuePair<Groups, Type> kvPair in GroupEnums)
            {
                Type typ = kvPair.Value;
                Dictionary<int, CachedStaticItem> table = GroupTables[kvPair.Key];
                string[] names = Enum.GetNames(kvPair.Value.GetType());
                Dictionary<string, CachedStaticItem> groupDescTable = GroupDescTables[kvPair.Key];
                Array.Sort(names);
                foreach (var name in names)
                {
                    int val = (int)Enum.Parse(kvPair.Value.GetType(), name);
                    string desc = EnumEx.GetDescription(kvPair.Value.GetType(), name);
                    StaticItem si = new StaticItem() { GroupId = kvPair.Key, ItemId = val, Desc = desc };

                    // Alright, we've got a specific StaticItem now.  Add it to "All" as well as its specific table.
                    CachedStaticItem csi = new CachedStaticItem("StaticDefaults", si);
                    All.Add(si.Key, csi);
                    table.Add(si.Key, csi);
                    groupDescTable.Add(desc, csi);
                }
            }

            // All base enumeration tables entered as CachedStaticItems.

            // Map dosimeter groups to lists of dosimeter locations
            Type dosGroupType = Enum.GetUnderlyingType(DosimeterGroups.NotSet.GetType());
            int first;
            int last;
            EnumEx.Range(dosGroupType, out first, out last);
            for (int g = first; g <= last; g++)
            {
                DosimeterGroupLocations[(DosimeterGroups)g] = new List<CachedStaticItem>();
            }

            //DosimeterGroupLocations[DosimeterGroups.NotSet] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter1Piece] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter2Piece] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter3Piece] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter4Piece2Torso] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter4Piece2Legs] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter6Piece] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.FaceNeckWipe] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.Head] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.Hands] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.Feet] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.Inhalation] = new List<CachedStaticItem>();
            //DosimeterGroupLocations[DosimeterGroups.FieldFortification] = new List<CachedStaticItem>();

            List<CachedStaticItem> csiList = DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter1Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body1WholeBody));

            csiList = DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter2Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body2LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body2UpperBody));

            csiList = DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter3Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body3Arms));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body3Torso));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body3Legs));

            csiList = DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter4Piece2Legs];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsArms));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsTorso));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsUpperLegs));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsLowerLegs));

            csiList = DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter4Piece2Torso];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoArms));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoFrontTorso));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoRearTorso));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoLegs));

            csiList = DosimeterGroupLocations[DosimeterGroups.WholeBodyDosimeter6Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6UpperArms));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6LowerArms));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6FrontTorso));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6RearTorso));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6UpperLegs));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6LowerLegs));

            csiList = DosimeterGroupLocations[DosimeterGroups.FaceNeckWipe];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeDetergent));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeOrganic));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeWater));

            csiList = DosimeterGroupLocations[DosimeterGroups.Head];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchInnerOnHat));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchOuterOnHat));

            csiList = DosimeterGroupLocations[DosimeterGroups.Hands];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashDetergent));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashOrganic));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashWater));

            csiList = DosimeterGroupLocations[DosimeterGroups.Feet];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Socks));

            csiList = DosimeterGroupLocations[DosimeterGroups.Inhalation];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OvsFront));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OvsBack));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OvsWhole));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.GlassFiberFilterFront));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.GlassFiberFilterBack));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.GlassFiberFilterWhole));

            csiList = DosimeterGroupLocations[DosimeterGroups.FieldFortification];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.InnerDosimeterFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OuterDosimeterFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchInnerOnHatFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchOuterOnHat));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeDetergentFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeOrganicFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeWaterFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashDetergentFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashOrganicFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashWaterFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.SocksFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.InhalationOvsFF));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterDescriptions, (int)DosimeterDescriptions.InhalationGlassFF));

            // Map dosimeter groups to dosimeter matrices
            DosimeterGroupMatrices[DosimeterGroups.NotSet] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter1Piece] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter2Piece] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter3Piece] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter4Piece2Torso] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter4Piece2Legs] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter6Piece] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.FaceNeckWipe] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.Head] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.Hands] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.Feet] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.Inhalation] = new List<CachedStaticItem>();
            DosimeterGroupMatrices[DosimeterGroups.FieldFortification] = new List<CachedStaticItem>();

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter1Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter2Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter3Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter4Piece2Legs];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter4Piece2Torso];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter6Piece];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.FaceNeckWipe];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonGauzeAotSolution));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Head];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchCotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchOther));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Hands];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.AotSolution));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Feet];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton85Nylon15));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Inhalation];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.GlassFiberFilter));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Xad2));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Chromosorb));

            csiList = DosimeterGroupMatrices[DosimeterGroups.FieldFortification];
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonGauze));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.AotSolution4mL));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchCotton));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchOther));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton85Nylon15));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.GlassFiberFilter));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Xad2));
            csiList.Add(Lookup(StaticValues.Groups.DosimeterMatrices, (int)DosimeterMatrices.Chromosorb));

            // Map dosimeter groups to body parts
            DosimeterGroupBodyParts[DosimeterGroups.NotSet] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter1Piece] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter2Piece] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter3Piece] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter4Piece2Torso] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter4Piece2Legs] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter6Piece] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.FaceNeckWipe] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.Head] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.Hands] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.Feet] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.Inhalation] = new List<CachedStaticItem>();
            DosimeterGroupBodyParts[DosimeterGroups.FieldFortification] = new List<CachedStaticItem>();

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter1Piece];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter2Piece];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter3Piece];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter4Piece2Torso];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter4Piece2Legs];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter6Piece];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.FaceNeckWipe];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.FaceNeck));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Head];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.Head));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Hands];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.Hands));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Feet];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.Feet));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Inhalation];
            csiList.Add(Lookup(StaticValues.Groups.BodyParts, (int)BodyParts.Inhalation));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.FieldFortification];  // No Field Fortification Body Parts

            // Map body parts to list of clothing choices for Layers
            PpeLayerClothingMap[BodyParts.NotSet] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.UpperBody] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.LowerBody] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.WholeBody] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.FaceNeck] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.Head] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.Hands] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.Feet] = new List<CachedStaticItem>();
            PpeLayerClothingMap[BodyParts.Inhalation] = new List<CachedStaticItem>();

            csiList = PpeLayerClothingMap[BodyParts.UpperBody];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ReflectiveVest));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.LongSleevedShirt));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ShortSleevedShirt));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothJacket));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrApron));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrApronBack));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekJacketHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekJacketNoHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitNoHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitHood));

            csiList = PpeLayerClothingMap[BodyParts.LowerBody];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ChapsOrSnakeLeggings));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.LongPants));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ShortPants));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekPants));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrRainsuitPants));

            csiList = PpeLayerClothingMap[BodyParts.WholeBody];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothCoveralls));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsNoHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsHood));

            csiList = PpeLayerClothingMap[BodyParts.FaceNeck];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.DustMistMask));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.HalfFaceRespirator));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.FullFaceRespirator));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.Glasses));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ProtectiveEyewear));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.Goggles));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.FaceShield));

            csiList = PpeLayerClothingMap[BodyParts.Head];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.HatOrCap));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothBandanaHeadScarf));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothBandanaNeckScarf));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrHatRainHat));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrHood));

            csiList = PpeLayerClothingMap[BodyParts.Hands];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrGloves));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.NonCrGloves));

            csiList = PpeLayerClothingMap[BodyParts.Feet];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ShoesBootsOverSocks));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrBootsOverSocks));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrBootsOverShoesBootsOverSocks));

            csiList = PpeLayerClothingMap[BodyParts.Inhalation];   // No PPE layers for Inhalation

            // Map body parts to list of clothing choices for PPE
            OuterDosimeterClothingMap[BodyParts.NotSet] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.UpperBody] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.LowerBody] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.WholeBody] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.FaceNeck] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.Head] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.Hands] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.Feet] = new List<CachedStaticItem>();
            OuterDosimeterClothingMap[BodyParts.Inhalation] = new List<CachedStaticItem>();

            csiList = OuterDosimeterClothingMap[BodyParts.UpperBody];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.LongSleevedShirt));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ShortSleevedShirt));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothJacket));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekJacketHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekJacketNoHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitNoHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitHood));

            csiList = OuterDosimeterClothingMap[BodyParts.LowerBody];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.LongPants));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ShortPants));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekPants));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrRainsuitPants));

            csiList = OuterDosimeterClothingMap[BodyParts.WholeBody];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothCoveralls));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsNoHood));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsHood));

            csiList = OuterDosimeterClothingMap[BodyParts.FaceNeck];       // no Outer Dosimeter Layer Clothing for Face/Neck

            csiList = OuterDosimeterClothingMap[BodyParts.Head];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.HatOrCap));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothBandanaHeadScarf));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.ClothBandanaNeckScarf));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrHatRainHat));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrHood));

            csiList = OuterDosimeterClothingMap[BodyParts.Hands];
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.CrGloves));
            csiList.Add(Lookup(StaticValues.Groups.PpeLayerClothing, (int)Clothing.NonCrGloves));

            csiList = OuterDosimeterClothingMap[BodyParts.Feet];           // no Outer Dosimeter Layer Clothing for Feet

            csiList = OuterDosimeterClothingMap[BodyParts.Inhalation];     // no Outer Dosimeter Layer Clothing for Inhalation

            // No Inhalation Outer Dosimeter Layer Clothing

            #region LONG way to initialize!

            //#region Groups

            //StaticValues.Groups grp = Groups.Group;
            //var item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Group, Desc = "Group" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.YesOrNo, Desc = "YesOrNo" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Gender, Desc = "Gender" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Country, Desc = "Country" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Site, Desc = "Site" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Season, Desc = "Season" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Task, Desc = "Task" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Employment, Desc = "Employment" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Pesticide, Desc = "Pesticide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Formulation, Desc = "Formulation" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Package, Desc = "Package" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Foliage, Desc = "Foliage" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Diluent, Desc = "Diluent" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.MixingSetupEquipment, Desc = "MixingSetupEquipment" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.MixingEquipmentLoaded, Desc = "MixingEquipmentLoaded" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.MixLoadEngControls, Desc = "MixLoadEngControls" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.AppEquipment, Desc = "AppEquipment" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.AppEngControls, Desc = "AppEngControls" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.WindDirection, Desc = "WindDirection" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.Reporting, Desc = "Reporting" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.PpeLayerClothing, Desc = "PpeLayerClothing" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.MeasurementLocation, Desc = "MeasurementLocation" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Groups.MeasurementMedia, Desc = "MeasurementMedia" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Yes or No

            //grp = StaticValues.Groups.YesOrNo;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.YesNo.No, Desc = "No" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.YesNo.Yes, Desc = "Yes" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Gender

            //grp = StaticValues.Groups.Gender;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Gender.Male, Desc = "Male" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Gender.Female, Desc = "Female" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Country

            //grp = Groups.Country;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.Usa, Desc = "USA" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.Canada, Desc = "Canada" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.UnitedKingdom, Desc = "United Kingdom" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.France, Desc = "France" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.Germany, Desc = "Germany" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.Spain, Desc = "Spain" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Country.Italy, Desc = "Italy" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Site

            //grp = Groups.Site;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.IndoorGreenhouse, Desc = "Indoor - Greenhouse" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.IndoorOther, Desc = "Indoor - Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorBareground, Desc = "Outdoor - Bareground" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorFieldCrops, Desc = "Outdoor - Field Crops" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorNurseryShadehouse, Desc = "Outdoor - Nursery/shadehouse" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorOrchard, Desc = "Outdoor - Orchard" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorRightOfWay, Desc = "Outdoor - Right-of-way" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorTrellisVineCrop, Desc = "Outdoor - Trellis/vine crop" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Site.OutdoorOther, Desc = "Outdoor - Other" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Season

            //grp = StaticValues.Groups.Season;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.WinterNorthern, Desc = "Winter - Dec/Jan/Feb" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.SpringNorthern, Desc = "Spring - Mar/Apr/May" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.SummerNorthern, Desc = "Summer - Jun/Jul/Aug" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.FallNorthern, Desc = "Fall - Sep/Oct/Nov" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.WinterSouthern, Desc = "Winter - Jun/Jul/Aug" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.SpringSouthern, Desc = "Spring - Sep/Oct/Nov" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.SummerSouthern, Desc = "Summer - Dec/Jan/Feb" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Season.FallSouthern, Desc = "Fall - Mar/Apr/May" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Task

            //grp = StaticValues.Groups.Task;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Task.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Task.Loader, Desc = "Loader" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Task.MixerLoader, Desc = "Mixer/Loader" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Task.Applicator, Desc = "Applicator" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Task.MixerLoaderApplicator, Desc = "Mixer/Loader/Applicator" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Employment

            //grp = StaticValues.Groups.Employment;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.CommercialApplicator, Desc = "Commercial Applicator" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.CommercialEmployee, Desc = "Commercial Applicator (employee)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.FarmEmployee, Desc = "Farm (facility) employee" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.FarmOperator, Desc = "Farm (facility) operator" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.FarmOwner, Desc = "Farm (facility) owner" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Employment.UtilityEmployee, Desc = "Utility company employee" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Pesticide

            //grp = StaticValues.Groups.Pesticide;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.Biocide, Desc = "Biocide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.Fungicide, Desc = "Fungicide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.Herbicide, Desc = "Herbicide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.Insecticide, Desc = "Insecticide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.InsecticideNematicide, Desc = "Insecticide/Nematicide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.Miticide, Desc = "Miticide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.Nematicide, Desc = "Nematicide" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Pesticide.PlantGrowthRegulator, Desc = "Plant Grouth Regulator" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Formulation

            //grp = StaticValues.Groups.Formulation;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Formulation.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Formulation.Granule, Desc = "Granule (applied as graule)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Formulation.Liquid, Desc = "Liquid" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Formulation.WaterDisperableGranule, Desc = "Water dispersable granule (Dry Flowable)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Formulation.WettablePowder, Desc = "Wettable powder" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Package

            //grp = StaticValues.Groups.Package;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.Bag, Desc = "Bag" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.PlasticJug, Desc = "Plastic Jug" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.Can, Desc = "Can" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.DrumNonreturnable, Desc = "Drum (nonreturnable)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.DrumReturnable, Desc = "Drum (returnable)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.MiniBulk, Desc = "Mini - bulk" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.BulkTank, Desc = "Bulk Tank" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.WaterSolublePackage, Desc = "Water soluable package" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Package.LockAndLoad, Desc = "Lock and Load" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Foliage

            //grp = StaticValues.Groups.Foliage;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage.NoneNotApplicable, Desc = "None - Not Applicable" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage.NoneBareGround, Desc = "None - Bare Ground" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage.NoneBareBranches, Desc = "None - Bare Branches" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage.LessThan25, Desc = "< 25%" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage._25to50, Desc = "25-50%" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage._51to75, Desc = "51-75%" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Foliage.Greater75, Desc = "> 75%" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Diluent

            //grp = StaticValues.Groups.Diluent;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Diluent.Other, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Diluent.None, Desc = "None" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Diluent.Water, Desc = "Water" };
            //table.AddStaticItem(item);

            //#endregion

            //#region MixingSetupEquipment

            //grp = StaticValues.Groups.MixingSetupEquipment;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingSetupEquipment.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingSetupEquipment.DiluentDirectly, Desc = "Diluent directly in spray tank" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingSetupEquipment.DiluentPremixTank, Desc = "Diluent in premix tank" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingSetupEquipment.DiluentPremixTransferSpray, Desc = "Diluent in premix tank and transfer to spray tank" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingSetupEquipment.MixUsingIndicator, Desc = "Mix using indicator system" };
            //table.AddStaticItem(item);

            //#endregion

            //#region MixingEquipmentLoaded

            //grp = StaticValues.Groups.MixingEquipmentLoaded;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.Backpack, Desc = "Backpack" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.BackpackHackAndSquirt, Desc = "Backpack with hack and squirt bottle" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.HandWandTank, Desc = "Hand wand tank" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.Groundboom, Desc = "Groundboom" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.Airblast, Desc = "Airblast" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.AerialFixedWing, Desc = "Aerial - fixed wing" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.AerialRotor, Desc = "Aerial - rotor craft" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.Chemigation, Desc = "Chemigation" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixingEquipmentLoaded.NotApplicable, Desc = "Not Applicable" };
            //table.AddStaticItem(item);

            //#endregion

            //#region MixLoadEngControls

            //grp = StaticValues.Groups.MixLoadEngControls;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.NoneOpenPour, Desc = "None - open pour" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.WaterSolublePackage, Desc = "Water soluble package" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.ClosedContainerBreech, Desc = "Closed system - container breech" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.ClosedGranuleGravity, Desc = "Closed system - granule gravity feed" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.ClosedGravityFeed, Desc = "Closed system - gravity feed" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.ClosedSuction, Desc = "Closed system - suction extraction" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.MixLoadEngControls.ClosedManualProbe, Desc = "Closed system - manual probe" };
            //table.AddStaticItem(item);

            //#endregion

            //#region AppEquipment

            //grp = StaticValues.Groups.AppEquipment;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.BackpackLiquid, Desc = "Backpack - liquid, manual pump" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.BackpackGranuleGravity, Desc = "Backpack - granule, gravity" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.BackpackGranule, Desc = "Backpack - granule" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.HackAndSquirt, Desc = "Hack and Squirt" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.HandgunSprayer, Desc = "Handgun sprayer" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.GroundboomAtv, Desc = "Groundboom - ATV or golf cart" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.GroundboomSmallTractor, Desc = "Groundboom - Small tractor (Lawn & garden-sized)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.GroundboomTractorMounted, Desc = "Groundboom - Tractor / truck mounted" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.GranularBanded, Desc = "Granular - Banded or in-furrow" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.GranularBroadcast, Desc = "Granular - Broadcast" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.AirblastTractor, Desc = "Airblast - Tractor-drawn" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.AirblastTruck, Desc = "Airblast - Truck-mounted" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.AerialFixed, Desc = "Aerial - Fixed wing" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.AerialRotor, Desc = "Aerial - Rotor craft" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEquipment.Chemigation, Desc = "Chemigation" };
            //table.AddStaticItem(item);

            //#endregion

            //#region AppEngControls

            //grp = StaticValues.Groups.AppEngControls;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEngControls.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEngControls.OpenCab, Desc = "Open cab" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEngControls.ClosedCabOpen, Desc = "Closed cab - window(s) or door(s) open" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.AppEngControls.ClosedCabClosed, Desc = "Closed cab - windows and doors closed" };
            //table.AddStaticItem(item);

            //#endregion

            //#region WindDirection

            //grp = StaticValues.Groups.WindDirection;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.WindDirection.NotSet, Desc = "Other" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.WindDirection.NotReported, Desc = "Not reported" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.WindDirection.Upwind, Desc = "Upwind" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.WindDirection.Downwind, Desc = "Dowdwind" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.WindDirection.Various, Desc = "Various" };
            //table.AddStaticItem(item);

            //#endregion

            //#region Report

            //grp = StaticValues.Groups.Reporting;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Reporting.NoneReported, Desc = "None done or reported" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Reporting.MonitoredPartOfTask, Desc = "Monitored as part of task" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.Reporting.MonitoredSeparately, Desc = "Monitored separately" };
            //table.AddStaticItem(item);

            //#endregion

            //#region PpeLayerClothing

            //grp = StaticValues.Groups.PpeLayerClothing;
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.HatOrCap, Desc = "Hat or Cap" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ClothBandanaHeadScarf, Desc = "Cloth Bandana (head scarf)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ClothBandanaNeckScarf, Desc = "Cloth Bandana (neck scarf)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrHatRainHat, Desc = "CR hat ('rain hat')" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrHood, Desc = "CR hood" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.Eyeglasses, Desc = "Eyeglasses" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ProtectiveEyewear, Desc = "Protective eyewear" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.Goggles, Desc = "Goggles" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.FaceShield, Desc = "Face Shield" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.NonCrGloves, Desc = "Non-CR Gloves" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrGloves, Desc = "CR Gloves" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.DustMistMask, Desc = "Dust/mist mask" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.QuarterFaceRespirator, Desc = "Quarter face - mask respirator" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.FullFaceRespirator, Desc = "Full face - respirator" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.LongSleevedShirt, Desc = "Cloth long sleeved shirt" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ShortSleevedShirt, Desc = "Cloth short sleeved shirt" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ReflectiveVest, Desc = "Reflective saftey vest" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ClothJacket, Desc = "Cloth jacket" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrApron, Desc = "CR apron" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrApronBack, Desc = "CR apron worn for back protection" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.TyvekJacketHood, Desc = "Tyvek Jacket (with hood)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.TyvekCoverallsNoHood, Desc = "Tyvek Jacket (without hood)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrJacketRainsuitNoHood, Desc = "CR Jacket (rainsuit) (without hood)" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrJacketRainsuitHood, Desc = "CR Jacket (rainsuit) (with hood)" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.LongPants, Desc = "Cloth pants - long" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ShortPants, Desc = "Cloth pants - short" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ChapsOrSnakeLeggings, Desc = "Chaps or snake leggings" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.TyvekPants, Desc = "Tyvek pants" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrRainsuitPants, Desc = "CR (rainsuit) pants" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ClothCoveralls, Desc = "Cloth coveralls" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.TyvekCoverallsNoHood, Desc = "Tyvek coveralls - without hood" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.TyvekCoverallsHood, Desc = "Tyvek coveralls - with hood" };
            //table.AddStaticItem(item);

            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.ShoesBootsOverSocks, Desc = "Shoes/boots over socks" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrBootsOverSocks, Desc = "CR boots over socks" };
            //table.AddStaticItem(item);
            //item = new StaticItem() { GroupId = grp, ItemId = (int)StaticValues.PpeLayerClothing.CrBootsOverShoesBootsOverSocks, Desc = "CR boots over shoes/boots over socks" };
            //table.AddStaticItem(item);

            //#endregion

            #endregion
        }

        public static List<CachedStaticItem> DosimeterLocationChoices(DosimeterGroups dosimeterGroup)
        {
            return DosimeterGroupLocations[dosimeterGroup];
        }

        public static List<CachedStaticItem> BodyPartChoices(DosimeterGroups dosimeterGroup)
        {
            return DosimeterGroupBodyParts[dosimeterGroup];
        }

        public static List<CachedStaticItem> LayerChoices(BodyParts bodyPart)
        {
            return PpeLayerClothingMap[bodyPart];
        }

        public static List<CachedStaticItem> PpeLayerChoices(BodyParts bodyPart)
        {
            return OuterDosimeterClothingMap[bodyPart];
        }

        #endregion
    }
}

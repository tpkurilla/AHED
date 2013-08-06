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

            [Description("Mixing Setup Equipment")]
            MixingSetupEquipment,

            [Description("Mixing Equipment Loaded")]
            MixingEquipmentLoaded,

            [Description("Mixing/Loading Engineering Controls")]
            MixLoadEngControls,

            [Description("Application Equipment")]
            AppEquipment,

            [Description("Application Engineering Controls")]
            AppEngControls,

            [Description("Wind Direction")]
            WindDirection,

            [Description("Reporting")]
            Reporting,

            [Description("PPE Layer Clothing")]
            PpeLayerClothing,

            [Description("Dosimeter Groups")]
            DosimeterGroups,

            [Description("Dosimeter Descriptions")]
            DosimeterDescriptions,

            [Description("Dosimeter Matrices")]
            DosimeterMatrices,

            [Description("Body Parts")]
            BodyParts,

            [Description("Outer Dosimeter Clothing")]
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

            [Description("Fall - Sep/Oct/Nov")]
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
            From25To50,

            [Description("51-75%")]
            From51To75,

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
            InnerDosimeterFf,

            [Description("Outer dosimeter (FF)")]
            OuterDosimeterFf,

            [Description("Patch (outer) on hat (FF)")]
            PatchOuterOnHatFf,

            [Description("Patch (inner) on hat (FF)")]
            PatchInnerOnHatFf,

            [Description("Face/neck swab - detergent water (FF)")]
            FaceNeckWipeDetergentFf,

            [Description("Face/neck swab - organic solvent (FF)")]
            FaceNeckWipeOrganicFf,

            [Description("Face/neck swab - water (FF)")]
            FaceNeckWipeWaterFf,

            [Description("Socks (FF)")]
            SocksFf,

            [Description("Hand wash - detergent water (FF)")]
            HandWashDetergentFf,

            [Description("Hand wash - organic solvent (FF)")]
            HandWashOrganicFf,

            [Description("Hand wash - water (FF)")]
            HandWashWaterFf,

            [Description("Inhalation - OVS (FF)")]
            InhalationOvsFf,

            [Description("Inhalation - glass fiber filter (FF)")]
            InhalationGlassFf
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
        /// Holds the Cached Static Items for the <c>DosimeterDescriptions</c> group.
        /// </summary>
        static public Dictionary<int, CachedStaticItem> DosimeterDescriptionsMap { get; protected set; }

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
        /// Holds the Cached Static Items for the <c>DosimeterDescriptions</c> group.
        /// </summary>
        static public Dictionary<string, CachedStaticItem> DosimeterDescriptionsDescMap { get; protected set; }

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
        /// Maps a <c>DosimeterGroups</c> id to a list of associated <c>DosimeterDescriptions</c> in that group.
        /// </summary>
        static public Dictionary<DosimeterGroups, List<CachedStaticItem>> DosimeterGroupDescriptions { get; protected set; }

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

        public static StaticItem Item(Groups groupId, int itemId)
        {
            int key = StaticItem.GetKey(groupId, itemId);
            CachedStaticItem csi = All[key];
            return (csi == null) ? null : csi.Item;
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
        /// If a collision occurs within a group table by Description, then the Static Item is not added.
        /// </para>
        /// </summary>
        /// <param name="dbName">The name of the database containing <c>table</c>.</param>
        /// <param name="table">The <c>StaticTable</c> whose members are to be added to the cache.</param>
        public static void AddTable(string dbName, StaticTable table)
        {
            var collisions = new List<KeyValuePair<int, StaticItem>>();
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
                    var grp = item.Value.GroupId;
                    if (!Enum.IsDefined(grp.GetType(), grp))
                    {
                        // This is a bad group Id, so log it
                        Log.Error("Invalid GroupId for " + item.Value);
                        continue;
                    }

                    Type enumType = GroupEnums[grp];
                    if (!Enum.IsDefined(enumType, item.Value.ItemId))
                    {
                    }

                    var csi = new CachedStaticItem(dbName, item.Value);
                    All.Add(item.Key, csi);

                    Dictionary<int, CachedStaticItem> groupTable = GroupTables[grp];
                    groupTable.Add(item.Key, csi);

                    Dictionary<string, CachedStaticItem> groupDescTable = GroupDescTables[grp];
                    groupDescTable.Add(item.Value.Description, csi);
                }
            }

            // Address any duplications here
            foreach (KeyValuePair<Int32, StaticItem> item in collisions)
            {
                // @todo: if Description duplicate, do nothing, otherwise get the next integer available for the given enumeration
                Log.Warning("Static Item collision; later entry ignored.  " + item.Value);
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
            var itemsToRemove = All.Where(item => item.Value.DbName == dbName).ToList();

            totalPurged += itemsToRemove.Count;
            foreach (KeyValuePair<int, CachedStaticItem> item in itemsToRemove)
                All.Remove(item.Key);

            // Now do all of the specific group tables
            foreach (KeyValuePair<Groups, Dictionary<int, CachedStaticItem>> groupTable in GroupTables)
            {
                itemsToRemove.Clear();
                itemsToRemove.AddRange(groupTable.Value.Where(item => item.Value.DbName == dbName));

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
            DosimeterDescriptionsMap = new Dictionary<int, CachedStaticItem>();
            DosimeterGroupDescriptions = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
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
            GroupTables.Add(Groups.DosimeterDescriptions, DosimeterDescriptionsMap);
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
            DosimeterDescriptionsDescMap = new Dictionary<string, CachedStaticItem>();
            DosimeterGroupDescriptions = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
            DosimeterGroupBodyParts = new Dictionary<DosimeterGroups, List<CachedStaticItem>>();
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
            GroupDescTables.Add(Groups.DosimeterDescriptions, DosimeterDescriptionsDescMap);
            GroupDescTables.Add(Groups.BodyParts, BodyPartDescMap);

            #endregion GroupDescTables

            #region GroupEnums

            GroupEnums = new Dictionary<Groups, Type>
                {
                    {Groups.Group, Groups.Group.GetType()},
                    {Groups.YesOrNo, YesNo.NotSet.GetType()},
                    {Groups.Gender, Gender.NotSet.GetType()},
                    {Groups.Site, Site.NotSet.GetType()},
                    {Groups.Season, Season.NotSet.GetType()},
                    {Groups.Task, Task.NotSet.GetType()},
                    {Groups.Employment, Employment.NotSet.GetType()},
                    {Groups.Pesticide, Pesticide.NotSet.GetType()},
                    {Groups.Formulation, Formulation.NotSet.GetType()},
                    {Groups.Package, Package.NotSet.GetType()},
                    {Groups.Foliage, Foliage.NotSet.GetType()},
                    {Groups.Diluent, Diluent.NotSet.GetType()},
                    {Groups.MixingSetupEquipment, MixingSetupEquipment.NotSet.GetType()},
                    {Groups.MixingEquipmentLoaded, MixingEquipmentLoaded.NotSet.GetType()},
                    {Groups.MixLoadEngControls, MixLoadEngControls.NotSet.GetType()},
                    {Groups.AppEquipment, AppEquipment.NotSet.GetType()},
                    {Groups.AppEngControls, AppEngControls.NotSet.GetType()},
                    {Groups.WindDirection, WindDirection.NotSet.GetType()},
                    {Groups.Reporting, Reporting.NotSet.GetType()},
                    {Groups.PpeLayerClothing, Clothing.HatOrCap.GetType()},
                    {Groups.DosimeterGroups, DosimeterGroups.NotSet.GetType()},
                    {Groups.DosimeterMatrices, DosimeterMatrices.NotSet.GetType()},
                    {Groups.DosimeterDescriptions, DosimeterDescriptions.NotSet.GetType()},
                    {Groups.BodyParts, BodyParts.NotSet.GetType()}
                };

            #endregion
        }

        public static void InitializeDefaults()
        {
            if (GroupTables[Groups.Group].Count > 0)
            {
                // Tables already have values...don't write over them
                return;
            }

            foreach (KeyValuePair<Groups, Type> kvPair in GroupEnums)
            {
                Dictionary<int, CachedStaticItem> table = GroupTables[kvPair.Key];
                string[] names = Enum.GetNames(kvPair.Value);
                Dictionary<string, CachedStaticItem> groupDescTable = GroupDescTables[kvPair.Key];
                Array.Sort(names);
                foreach (var name in names)
                {
                    var val = (int)Enum.Parse(kvPair.Value, name);
                    string desc = EnumEx.GetDescription(kvPair.Value, name);
                    var si = new StaticItem { GroupId = kvPair.Key, ItemId = val, Description = desc };

                    // Alright, we've got a specific StaticItem now.  Add it to "All" as well as its specific table.
                    var csi = new CachedStaticItem("StaticDefaults", si);
                    All.Add(si.Key, csi);
                    table.Add(si.Key, csi);
                    groupDescTable.Add(desc, csi);
                }
            }

            // All base enumeration tables entered as CachedStaticItems.

            // Map dosimeter groups to lists of dosimeter locations
            Type dosGroupType = DosimeterGroups.NotSet.GetType(); //Enum.GetUnderlyingType(DosimeterGroups.NotSet.GetType());
            int first;
            int last;
            EnumEx.Range(dosGroupType, out first, out last);
            for (int g = first; g <= last; g++)
            {
                DosimeterGroupDescriptions[(DosimeterGroups)g] = new List<CachedStaticItem>();
            }

            //DosimeterGroupDescriptions[DosimeterGroups.NotSet] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter1Piece] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter2Piece] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter3Piece] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter4Piece2Torso] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter4Piece2Legs] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter6Piece] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.FaceNeckWipe] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.Head] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.Hands] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.Feet] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.Inhalation] = new List<CachedStaticItem>();
            //DosimeterGroupDescriptions[DosimeterGroups.FieldFortification] = new List<CachedStaticItem>();

            List<CachedStaticItem> csiList = DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter1Piece];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body1WholeBody));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter2Piece];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body2LowerBody));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body2UpperBody));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter3Piece];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body3Arms));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body3Torso));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body3Legs));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter4Piece2Legs];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsArms));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsTorso));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsUpperLegs));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4LegsLowerLegs));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter4Piece2Torso];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoArms));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoFrontTorso));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoRearTorso));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body4TorsoLegs));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.WholeBodyDosimeter6Piece];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6UpperArms));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6LowerArms));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6FrontTorso));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6RearTorso));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6UpperLegs));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Body6LowerLegs));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.FaceNeckWipe];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeDetergent));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeOrganic));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeWater));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.Head];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchInnerOnHat));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchOuterOnHat));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.Hands];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashDetergent));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashOrganic));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashWater));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.Feet];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.Socks));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.Inhalation];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OvsFront));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OvsBack));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OvsWhole));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.GlassFiberFilterFront));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.GlassFiberFilterBack));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.GlassFiberFilterWhole));

            csiList = DosimeterGroupDescriptions[DosimeterGroups.FieldFortification];
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.InnerDosimeterFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.OuterDosimeterFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchInnerOnHatFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.PatchOuterOnHat));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeDetergentFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeOrganicFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.FaceNeckWipeWaterFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashDetergentFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashOrganicFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.HandWashWaterFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.SocksFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.InhalationOvsFf));
            csiList.Add(Lookup(Groups.DosimeterDescriptions, (int)DosimeterDescriptions.InhalationGlassFf));

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
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter2Piece];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter3Piece];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter4Piece2Legs];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter4Piece2Torso];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.WholeBodyDosimeter6Piece];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));

            csiList = DosimeterGroupMatrices[DosimeterGroups.FaceNeckWipe];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonGauzeAotSolution));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Head];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchCotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchOther));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Hands];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.AotSolution));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Feet];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton85Nylon15));

            csiList = DosimeterGroupMatrices[DosimeterGroups.Inhalation];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.GlassFiberFilter));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Xad2));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Chromosorb));

            csiList = DosimeterGroupMatrices[DosimeterGroups.FieldFortification];
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonPolyesterBlend));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.CottonGauze));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.AotSolution4mL));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchCotton));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.PatchOther));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Cotton85Nylon15));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.GlassFiberFilter));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Xad2));
            csiList.Add(Lookup(Groups.DosimeterMatrices, (int)DosimeterMatrices.Chromosorb));

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
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter2Piece];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter3Piece];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter4Piece2Torso];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter4Piece2Legs];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.WholeBodyDosimeter6Piece];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.UpperBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.LowerBody));
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.WholeBody));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.FaceNeckWipe];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.FaceNeck));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Head];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.Head));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Hands];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.Hands));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Feet];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.Feet));

            csiList = DosimeterGroupBodyParts[DosimeterGroups.Inhalation];
            csiList.Add(Lookup(Groups.BodyParts, (int)BodyParts.Inhalation));

            //csiList = DosimeterGroupBodyParts[DosimeterGroups.FieldFortification];  // No Field Fortification Body Parts

            // Map body parts to list of clothing choices for PpeLayers
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
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ReflectiveVest));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.LongSleevedShirt));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ShortSleevedShirt));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothJacket));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrApron));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrApronBack));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekJacketHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekJacketNoHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitNoHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitHood));

            csiList = PpeLayerClothingMap[BodyParts.LowerBody];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ChapsOrSnakeLeggings));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.LongPants));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ShortPants));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekPants));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrRainsuitPants));

            csiList = PpeLayerClothingMap[BodyParts.WholeBody];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothCoveralls));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsNoHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsHood));

            csiList = PpeLayerClothingMap[BodyParts.FaceNeck];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.DustMistMask));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.HalfFaceRespirator));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.FullFaceRespirator));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.Glasses));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ProtectiveEyewear));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.Goggles));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.FaceShield));

            csiList = PpeLayerClothingMap[BodyParts.Head];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.HatOrCap));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothBandanaHeadScarf));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothBandanaNeckScarf));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrHatRainHat));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrHood));

            csiList = PpeLayerClothingMap[BodyParts.Hands];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrGloves));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.NonCrGloves));

            csiList = PpeLayerClothingMap[BodyParts.Feet];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ShoesBootsOverSocks));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrBootsOverSocks));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrBootsOverShoesBootsOverSocks));

            //csiList = PpeLayerClothingMap[BodyParts.Inhalation];   // No PPE layers for Inhalation

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
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.LongSleevedShirt));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ShortSleevedShirt));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothJacket));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekJacketHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekJacketNoHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitNoHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrJacketRainsuitHood));

            csiList = OuterDosimeterClothingMap[BodyParts.LowerBody];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.LongPants));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ShortPants));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekPants));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrRainsuitPants));

            csiList = OuterDosimeterClothingMap[BodyParts.WholeBody];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothCoveralls));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsNoHood));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.TyvekCoverallsHood));

            //csiList = OuterDosimeterClothingMap[BodyParts.FaceNeck];       // no Outer Dosimeter Layer Clothing for Face/Neck

            csiList = OuterDosimeterClothingMap[BodyParts.Head];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.HatOrCap));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothBandanaHeadScarf));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.ClothBandanaNeckScarf));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrHatRainHat));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrHood));

            csiList = OuterDosimeterClothingMap[BodyParts.Hands];
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.CrGloves));
            csiList.Add(Lookup(Groups.PpeLayerClothing, (int)Clothing.NonCrGloves));

            //csiList = OuterDosimeterClothingMap[BodyParts.Feet];           // no Outer Dosimeter Layer Clothing for Feet

            //csiList = OuterDosimeterClothingMap[BodyParts.Inhalation];     // no Outer Dosimeter Layer Clothing for Inhalation

            // No Inhalation Outer Dosimeter Layer Clothing

        }

        public static List<CachedStaticItem> DosimeterDescriptionChoices(DosimeterGroups dosimeterGroup)
        {
            return DosimeterGroupDescriptions[dosimeterGroup];
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

using System;
using System.Collections.Generic;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>MixingInfo</c> for editable viewing such as in DataEntry.
    /// <br/>
    /// NOTE: Changes to Units enumerated values are assumed correct.  All other
    /// error checking *should* be in place.
    /// </summary>
    public class DosimeterMeasurementModel : Model<DosimeterMeasurement>, IDeepClone<DosimeterMeasurementModel>
    {
        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidDosimeterGroups = StaticValues.GroupOptions(StaticValues.Groups.DosimeterGroups);

        #endregion Valid Options for StaticItems

        #region Properties

        public StaticItem Group
        {
            get { return Value.Group; }
            protected set 
            {
                if (value != Value.Group)
                {
                    if (ValidateGroup(value))
                    {
                        Value.Group = value;

                        // Update the list of valid Dosimeter Descriptions
                        _validDosimeterDescriptions.Clear();
                        var group = (StaticValues.DosimeterGroups)Value.Group.ItemId;
                        List<CachedStaticItem> csiList = StaticValues.DosimeterGroupDescriptions[group];
                        foreach (var cachedStaticItem in csiList)
                        {
                            _validDosimeterDescriptions.Add(cachedStaticItem.Item);
                        }

                        // Update the list of valid Body Parts 
                        csiList = StaticValues.DosimeterGroupBodyParts[group];
                        foreach (var cachedStaticItem in csiList)
                        {
                            _validGroupBodyParts.Add(cachedStaticItem.Item);
                        }

                        // Now re-validate everything based upon this change
                        Validate();
                    }
                }
            }
        }

        private readonly List<StaticItem> _validDosimeterDescriptions; 
        public List<StaticItem> ValidDosimeterDescriptions
        {
            get { return _validDosimeterDescriptions; }
        }

        public StaticItem DosimeterDescription
        {
            get { return Value.Description; }
            set
            {
                if (Value.Description != value)
                {
                    if (ValidateDescription(value))
                    {
                        Value.Description = value;

                        // Update the list of valid Dosimeter Matrices
                        _validDosimeterDescriptions.Clear();
                        var group = (StaticValues.DosimeterGroups)Value.Group.ItemId;
                        List<CachedStaticItem> csi = StaticValues.DosimeterGroupMatrices[group];
                        foreach (var cachedStaticItem in csi)
                        {
                            _validDosimeterMatrices.Add(cachedStaticItem.Item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Holds the InputDosimeterMatices that are valid choices, base upon the Group.
        /// </summary>
        private readonly List<StaticItem> _validDosimeterMatrices;
        public List<StaticItem> ValidDosimeterMatrices
        {
            get { return _validDosimeterMatrices; }
        }

        public MeasurementModel Measurement { get; private set; }

        /// <summary>
        /// Holds the BodyPart that are valid choices, based upon the Group.
        /// </summary>
        private readonly List<StaticItem> _validGroupBodyParts;

        public List<StaticItem> ValidGroupBodyParts
        {
            get { return _validGroupBodyParts; }
        }

        public ModelCache<PpeLayerModel,PpeLayer> PpeLayers { get; private set; }

        public ModelCache<OuterMeasurementModel,OuterMeasurement> OuterMeasurements { get; private set; }

        public new bool IsValid
        {
            get
            {
                return base.IsValid
                       && Measurement.IsValid
                       && PpeLayers.IsValid
                       && OuterMeasurements.IsValid;
            }
        }

        #endregion

        #region Creation

        public DosimeterMeasurementModel(){}

        public DosimeterMeasurementModel(DosimeterMeasurement dosimeterMeasurement)
            : base(dosimeterMeasurement)
        {
            _validDosimeterDescriptions = new List<StaticItem>();
            _validDosimeterMatrices = new List<StaticItem>();
            _validGroupBodyParts = new List<StaticItem>();

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public DosimeterMeasurementModel(DosimeterMeasurementModel dosimeterMeasurementModel)
            : base(dosimeterMeasurementModel)
        {
            _validDosimeterDescriptions = new List<StaticItem>(dosimeterMeasurementModel._validDosimeterDescriptions);
            _validDosimeterMatrices = new List<StaticItem>(dosimeterMeasurementModel._validDosimeterMatrices);
            _validGroupBodyParts = new List<StaticItem>(dosimeterMeasurementModel._validGroupBodyParts);

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
            Group = Value.Group;
            DosimeterDescription = Value.Description;
            Measurement = new MeasurementModel(Value.Measurement, this);

            PpeLayers = new ModelCache<PpeLayerModel, PpeLayer>(
                (from layer in Value.PpeLayers
                 select new PpeLayerModel(layer, this)
                ).ToList());

            OuterMeasurements = new ModelCache<OuterMeasurementModel,OuterMeasurement>(
                (from outerMeasurement in Value.OuterMeasurements
                 select new OuterMeasurementModel(outerMeasurement, this)
                ).ToList());
        }

        public static DosimeterMeasurementModel Create(StaticValues.DosimeterGroups dosimeterGroup)
        {
            StaticItem groupItem = StaticValues.Item(StaticValues.Groups.DosimeterGroups, (int)dosimeterGroup);

            return new DosimeterMeasurementModel(new DosimeterMeasurement(groupItem));
        }

        #endregion Creation

        #region Public Methods

        public override bool Validate()
        {
            ValidateGroup(Value.Group);
            ValidateDescription(Value.Description);
            Measurement.Validate();
            foreach (var ppeLayer in PpeLayers.GetAll())
            {
                ppeLayer.Validate();
            }

            foreach (var outerMeasurement in OuterMeasurements.GetAll())
            {
                outerMeasurement.Validate();
            }

            return IsValid;
        }

        #endregion Public Methods

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string GroupName = "Group";
        public const string DosimeterDescriptionName = "DosimeterDescription";
        public const string ValidDosimeterDescriptionsName = "ValidDosimeterDescriptions";
        public const string ValidGroupBodyPartsName = "ValidGroupBodyParts";
        public const string InputDosimeterMatrixName = "InputDosimeterMatrix";
        public const string InputResidueName = "InputResidue";
        public const string InputLoqName = "InputLoq";
        public const string InputLodName = "InputLod";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>MixingEquipmentLoaded</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[MixingEquipmentLoaded] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>MixingEquipmentLoaded</c>.</returns>
        private bool ValidateGroup(StaticItem value)
        {
            if (value == null || ValidDosimeterGroups.Contains(value))
            {
                RemoveError(GroupName, Properties.Resources.DosimeterMeasurement_Invalid_Group);
                return true;
            }

            AddError(GroupName, Properties.Resources.DosimeterMeasurement_Invalid_Group, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>EngineeringControls</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[MixLoadEngControls] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>EngineeringControls</c>.</returns>
        private bool ValidateDescription(StaticItem value)
        {
            if (value == null || ValidDosimeterDescriptions.Contains(value))
            {
                RemoveError(DosimeterDescriptionName, Properties.Resources.DosimeterMeasurement_Invalid_Dosimeter_Description);
                return true;
            }

            AddError(DosimeterDescriptionName, Properties.Resources.DosimeterMeasurement_Invalid_Dosimeter_Description, false);
            return false;
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        DosimeterMeasurementModel IDeepClone<DosimeterMeasurementModel>.DeepClone()
        {
            return new DosimeterMeasurementModel(this);
        }

        #endregion IDeepClone Interface
    }
}

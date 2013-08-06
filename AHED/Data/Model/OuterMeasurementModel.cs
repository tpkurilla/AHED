using System;
using System.Collections.Generic;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class OuterMeasurementModel : Model<OuterMeasurement>, IDeepClone<OuterMeasurementModel>
    {
        private readonly DosimeterMeasurementModel _parentDosimeterMeasurement;

        #region Properties

        public List<StaticItem> ValidBodyParts { get { return _parentDosimeterMeasurement.ValidGroupBodyParts; } } 

        public StaticItem BodyPart
        {
            get { return Value.BodyPart; }
            set
            {
                if (value != Value.BodyPart)
                {
                    if (ValidateBodyPart(value))
                    {
                        Value.BodyPart = value;

                        // Update the list of valid Clothing
                        _validClothing.Clear();
                        var bodyPart = (StaticValues.BodyParts)Value.BodyPart.ItemId;
                        List<CachedStaticItem> csi = StaticValues.OuterDosimeterClothingMap[bodyPart];
                        foreach (var cachedStaticItem in csi)
                        {
                            _validClothing.Add(cachedStaticItem.Item);
                        }

                        ValidateClothing(Clothing);
                    }
                }
            }
        }

        private readonly List<StaticItem> _validClothing;
        public List<StaticItem> ValidClothing { get { return _validClothing; } } 
 
        public StaticItem Clothing
        {
            get { return Value.Clothing; }
            set
            {
                if (value != Value.Clothing)
                {
                    if (ValidateClothing(value))
                    {
                        Value.Clothing = value;
                    }
                }
            }
        }

        public List<StaticItem> ValidDosimeterMatrices
        {
            get { return _parentDosimeterMeasurement.ValidDosimeterMatrices; }
        }

        public MeasurementModel Measurement { get; private set; }

        #endregion

        #region Creation

        public OuterMeasurementModel(){}

        public OuterMeasurementModel(OuterMeasurement outerMeasurement,
                                     DosimeterMeasurementModel parentDosimeterMeasurement)
            : base(outerMeasurement)
        {
            if (parentDosimeterMeasurement == null)
                throw new ArgumentNullException("parentDosimeterMeasurement");

            _parentDosimeterMeasurement = parentDosimeterMeasurement;
            _validClothing = new List<StaticItem>();
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public OuterMeasurementModel(OuterMeasurementModel outerMeasurementModel)
            : base(outerMeasurementModel)
        {
            // Not a deep copy since it is just a reference to the parent
            _parentDosimeterMeasurement = outerMeasurementModel._parentDosimeterMeasurement;

            // Not a deep copy since it is just a list of references
            _validClothing = new List<StaticItem>(outerMeasurementModel._validClothing);

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
            BodyPart = Value.BodyPart;
            Clothing = Value.Clothing;
            Measurement = new MeasurementModel(Value.Measurement, _parentDosimeterMeasurement);
        }

        #endregion Creation

        #region Public Methods

        public override bool Validate()
        {
            ValidateBodyPart(Value.BodyPart);
            ValidateClothing(Value.Clothing);
            Measurement.Validate();

            return true;
        }

        #endregion Public Methods

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string BodyPartName = "BodyPart";
        public const string ClothingName = "Clothing";
        public const string MeasurementName = "Measurement";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Task</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Task] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Task</c>.</returns>
        private bool ValidateBodyPart(StaticItem value)
        {
            if (_parentDosimeterMeasurement.ValidGroupBodyParts.Contains(value))
            {
                RemoveError(BodyPartName, Properties.Resources.StaticItem_Invalid_BodyPart);
                return true;
            }

            AddError(BodyPartName, Properties.Resources.StaticItem_Invalid_BodyPart, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Gender</c>.
        /// </summary>
        /// <remarks>
        /// Accepts members of <c>StaticValues.GroupOptions[Groups.Gender]</c>.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Gender</c>.</returns>
        private bool ValidateClothing(StaticItem value)
        {
            if (_validClothing.Contains(value))
            {
                RemoveError(ClothingName, Properties.Resources.StaticItem_Invalid_Clothing);
                return true;
            }

            AddError(ClothingName, Properties.Resources.StaticItem_Invalid_Clothing, false);
            return false;
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        OuterMeasurementModel IDeepClone<OuterMeasurementModel>.DeepClone()
        {
            return new OuterMeasurementModel(this);
        }

        #endregion IDeepClone Interface
    }
}

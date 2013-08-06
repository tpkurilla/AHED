using System;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class MeasurementModel : Model<Measurement>, IDeepClone<MeasurementModel>
    {
        private readonly DosimeterMeasurementModel _parentDosimeterMeasurement;

        #region Properties

        public StaticItem InputDosimeterMatrix
        {
            get { return Value.InputDosimeterMatrix; }
            set
            {
                if (value != Value.InputDosimeterMatrix)
                {
                    if (ValidateInputDosimeterMatrix(value))
                        Value.InputDosimeterMatrix = value;
                }
            }
        }

        private Mass.Units _inputResidueUnits;
        public Mass.Units InputResidueUnits
        {
            get { return _inputResidueUnits; }
            set
            {
                if (value != _inputResidueUnits)
                {
                    _inputResidueUnits = value;
                    _inputResidueText =
                        (Value.InputResidue != null)
                            ? Mass.Convert(Value.InputResidue, _inputResidueUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _inputResidueText;
        public string InputResidue
        {
            get { return _inputResidueText; }
            set
            {
                if (value != _inputResidueText)
                {
                    Mass residue;
                    if (!ValidateInputResidue(value, out residue))
                    {
                        _inputResidueText = value;
                    }
                    else
                    {
                        Value.InputResidue = residue;
                        _inputResidueText =
                            (residue != null)
                                ? Mass.Convert(residue, _inputResidueUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Mass.Units _inputLoqUnits;
        public Mass.Units InputLoqUnits
        {
            get { return _inputLoqUnits; }
            set
            {
                if (value != _inputLoqUnits)
                {
                    _inputLoqUnits = value;
                    _inputLoqText =
                        (Value.InputLoq != null)
                            ? Mass.Convert(Value.InputLoq, _inputLoqUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _inputLoqText;
        public string InputLoq
        {
            get { return _inputLoqText; }
            set
            {
                if (value != _inputLoqText)
                {
                    Mass loq;
                    if (!ValidateInputLoq(value, out loq))
                    {
                        _inputLoqText = value;
                    }
                    else
                    {
                        Value.InputLoq = loq;
                        _inputLoqText =
                            (loq != null)
                                ? Mass.Convert(loq, _inputLoqUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        private Mass.Units _inputLodUnits;
        public Mass.Units InputLodUnits
        {
            get { return _inputLodUnits; }
            set
            {
                if (value != _inputLodUnits)
                {
                    _inputLodUnits = value;
                    _inputLodText =
                        (Value.InputLod != null)
                            ? Mass.Convert(Value.InputLod, _inputLodUnits).ToString(Culture.Info)
                            : String.Empty;
                }
            }
        }

        private string _inputLodText;
        public string InputLod
        {
            get { return _inputLodText; }
            set
            {
                if (value != _inputLodText)
                {
                    Mass lod;
                    if (!ValidateInputLod(value, out lod))
                    {
                        _inputLodText = value;
                    }
                    else
                    {
                        Value.InputLod = lod;
                        _inputLodText =
                            (lod != null)
                                ? Mass.Convert(lod, _inputLodUnits).ToString(Culture.Info)
                                : String.Empty;
                    }
                }
            }
        }

        public bool HasSize { get { return Value.HasSize; } }

        private string _sizeText;
        public string Size
        {
            get { return _sizeText; }
            set
            {
                if (value != _sizeText)
                {
                    double? size;
                    if (!ValidateSize(value, out size))
                    {
                        _sizeText = value;
                    }
                    else
                    {
                        Value.Size = size;
                        _sizeText = (size != null) ? size.ToString() : String.Empty;
                    }
                }
            }
        }


        #endregion

        #region Creation

        public MeasurementModel(){}

        public MeasurementModel(Measurement measurement, DosimeterMeasurementModel parentDosimeterMeasurement)
            : base(measurement)
        {
            if (parentDosimeterMeasurement == null)
                throw new ArgumentNullException("parentDosimeterMeasurement");

            _parentDosimeterMeasurement = parentDosimeterMeasurement;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public MeasurementModel(MeasurementModel measurementModel)
            : base(measurementModel)
        {
            if (measurementModel == null)
                throw new ArgumentNullException("measurementModel");

            _parentDosimeterMeasurement = measurementModel._parentDosimeterMeasurement;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            // dummy variables for simulating properties being set
            string dummyText;
            Mass.Units dummyMassUnits;

            // Now set all Model properties, and trigger all validations
            InputDosimeterMatrix = Value.InputDosimeterMatrix;

            Mass.TextAndUnits(Value.InputResidue, out dummyText, out dummyMassUnits);
            InputResidueUnits = dummyMassUnits;
            InputResidue = dummyText;

            Mass.TextAndUnits(Value.InputLoq, out dummyText, out dummyMassUnits);
            InputLoqUnits = dummyMassUnits;
            InputLoq = dummyText;

            Mass.TextAndUnits(Value.InputLod, out dummyText, out dummyMassUnits);
            InputLodUnits = dummyMassUnits;
            InputLod = dummyText;

            _sizeText = Value.HasSize ? Value.Size.ToString() : String.Empty;
        }

        public static MeasurementModel Create(DosimeterMeasurementModel parentDosimeterMeasurement)
        {
            if (parentDosimeterMeasurement == null)
                throw new ArgumentNullException("parentDosimeterMeasurement");

            bool hasSize = parentDosimeterMeasurement.Group.ItemId == (int)StaticValues.DosimeterGroups.Head;
            return new MeasurementModel(Measurement.Create(hasSize), parentDosimeterMeasurement);
        }

        #endregion Creation

        #region Public Methods

        public override bool Validate()
        {
            ValidateInputDosimeterMatrix(Value.InputDosimeterMatrix);

            Mass dummyMass;
            string dummyText = String.IsNullOrEmpty(InputResidue)
                                   ? ((Value.InputResidue == null) ? null : Value.InputResidue.ToString())
                                   : InputResidue;
            ValidateInputResidue(dummyText, out dummyMass);

            dummyText = String.IsNullOrEmpty(InputLoq)
                            ? ((Value.InputLoq == null) ? null : Value.InputLoq.ToString())
                            : InputLoq;
            ValidateInputLoq(dummyText, out dummyMass);

            dummyText = String.IsNullOrEmpty(InputLod)
                            ? ((Value.InputLod == null) ? null : Value.InputLod.ToString())
                            : InputLod;
            ValidateInputLod(dummyText, out dummyMass);

            return IsValid;
        }

        #endregion Public Methods

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string InputDosimeterMatrixName = "InputDosimeterMatrix";
        public const string InputResidueName = "InputResidue";
        public const string InputResidueUnitsName = "InputResidueUnits";
        public const string InputLoqName = "InputLoq";
        public const string InputLoqUnitsName = "InputLoqUnits";
        public const string InputLodName = "InputLod";
        public const string InputLodUnitsName = "InputLodUnits";
        public const string HasSizeName = "HasSize";
        public const string SizeName = "Size";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Cleanup</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[Reporting] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Cleanup</c>.</returns>
        private bool ValidateInputDosimeterMatrix(StaticItem value)
        {
            if (value == null || _parentDosimeterMeasurement.ValidDosimeterMatrices.Contains(value))
            {
                RemoveError(InputDosimeterMatrixName, Properties.Resources.Measurement_Invalid_Input_Dosimeter_Matrix);
                return true;
            }

            AddError(InputDosimeterMatrixName, Properties.Resources.Measurement_Invalid_Input_Dosimeter_Matrix, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>TotalAIMixed</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a mass.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>TotalAIMixed</c>.</returns>
        private bool ValidateInputResidue(string str, out Mass value)
        {
            return ValidateMass(str, _inputResidueUnits, InputResidueName,
                                Properties.Resources.Measurement_Invalid_Input_Residue, out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>InputLoq</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a InputLoq.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>InputLoq</c>.</returns>
        private bool ValidateInputLoq(string str, out Mass value)
        {
            return ValidateMass(str, _inputLoqUnits, InputLoqName,
                                Properties.Resources.Measurement_Invalid_Input_Loq, out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>InputLod</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null, and any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a InputLod.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>InputLod</c>.</returns>
        private bool ValidateInputLod(string str, out Mass value)
        {
            return ValidateMass(str, _inputLodUnits, InputLodName,
                                Properties.Resources.Measurement_Invalid_Input_Lod, out value);
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Size</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts null or any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a quantity.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Size</c>.</returns>
        private bool ValidateSize(string str, out double? value)
        {
            if (!HasSize)
            {
                value = null;
                return true;
            }

            return ValidateDouble(str, PositiveOnly,
                                  SizeName, Properties.Resources.Measurement_Invalid_Size,
                                  out value);
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        MeasurementModel IDeepClone<MeasurementModel>.DeepClone()
        {
            return new MeasurementModel(this);
        }

        #endregion
    }
}

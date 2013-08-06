using System;
using AHED.Data.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class MeasurementViewModel : SimpleViewModel<MeasurementModel,Measurement>
    {
        #region Creation

        public MeasurementViewModel(){}

        public MeasurementViewModel(MeasurementModel model)
            : base(model)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        void SetProperties()
        {
            InputDosimeterMatrix = Model.InputDosimeterMatrix;
            InputResidue = Model.InputResidue;
            InputResidueUnits = Model.InputResidueUnits;
            InputLoq = Model.InputLoq;
            InputLoqUnits = Model.InputLoqUnits;
            InputLod = Model.InputLod;
            InputLodUnits = Model.InputLodUnits;
            Size = Model.Size;
        }

        #endregion Creation

        #region Properties

        private StaticItem _inputDosimeterMatrix;
        public StaticItem InputDosimeterMatrix
        {
            get { return _inputDosimeterMatrix; }
            set
            {
                if (value == _inputDosimeterMatrix)
                    return;

                Model.InputDosimeterMatrix = value;
                _inputDosimeterMatrix = Model.InputDosimeterMatrix;
                base.RaisePropertyChanged(MeasurementModel.InputDosimeterMatrixName);
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
                    Model.InputResidueUnits = value;
                    _inputResidueUnits = Model.InputResidueUnits;
                    base.RaisePropertyChanged(MeasurementModel.InputResidueUnitsName);
                    base.RaisePropertyChanged(MeasurementModel.InputResidueName);
                }
            }
        }

        private string _inputResidue;
        public string InputResidue
        {
            get { return _inputResidue; }
            set
            {
                if (value == _inputResidue)
                    return;

                Model.InputResidue = value;
                _inputResidue = Model.InputResidue;
                base.RaisePropertyChanged(MeasurementModel.InputResidueName);
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
                    Model.InputLoqUnits = value;
                    _inputLoqUnits = Model.InputLoqUnits;
                    base.RaisePropertyChanged(MeasurementModel.InputLoqUnitsName);
                    base.RaisePropertyChanged(MeasurementModel.InputLoqName);
                }
            }
        }

        private string _inputLoq;
        public string InputLoq
        {
            get { return _inputLoq; }
            set
            {
                if (value == _inputLoq)
                    return;

                Model.InputLoq = value;
                _inputLoq = Model.InputLoq;
                base.RaisePropertyChanged(MeasurementModel.InputLoqName);
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
                    Model.InputLodUnits = value;
                    _inputLodUnits = Model.InputLodUnits;
                    base.RaisePropertyChanged(MeasurementModel.InputLodUnitsName);
                    base.RaisePropertyChanged(MeasurementModel.InputLodName);
                }
            }
        }

        private string _inputLod;
        public string InputLod
        {
            get { return _inputLod; }
            set
            {
                if (value == _inputLod)
                    return;

                Model.InputLod = value;
                _inputLod = Model.InputLod;
                base.RaisePropertyChanged(MeasurementModel.InputLodName);
            }
        }

        public bool HasSize { get { return Model.HasSize; } }

        private string _size;
        public string Size
        {
            get { return Model.HasSize ? _size : String.Empty; }
            set
            {
                if (value == _size || !Model.HasSize)
                    return;

                Model.Size = value;
                _size = Model.Size;
                base.RaisePropertyChanged(MeasurementModel.SizeName);
                
            }
        }

        #endregion Properties

        #region Property Names

        public const string InputDosimeterMatrixName = "InputDosimeterMatrix";
        public const string InputResidueName = "InputResidue";
        public const string InputLoqName = "InputLoq";
        public const string InputLodName = "InputLod";
        public const string HasSizeName = "HasSize";
        public const string SizeName = "Size";

        #endregion Property Names

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

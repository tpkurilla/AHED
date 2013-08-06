using System;
using System.Collections.Generic;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    /// <summary>
    /// A UI-friendly wrapper for a Field Fortification.
    /// </summary>
    public class OuterMeasurementViewModel : SelectableViewModel<OuterMeasurementModel, OuterMeasurement>
    {
        #region Creation

        public OuterMeasurementViewModel(){}

        public OuterMeasurementViewModel(OuterMeasurementModel model,
                                         ModelCache<OuterMeasurementModel,OuterMeasurement> cache)
            : base(model, cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            ResetMeasurementVm();

            SetProperties();
        }

        void SetProperties()
        {
            BodyPart = Model.BodyPart;
            Clothing = Model.Clothing;

            if (MeasurementVm == null)
            {
                MeasurementVm = new MeasurementViewModel(Model.Measurement);
                Workspaces.ViewModels.Add(MeasurementVm);
            }

            Workspaces.SetActiveWorkspace(MeasurementVm);
        }

        private void ResetMeasurementVm()
        {
            if (MeasurementVm == null)
                return;

            Workspaces.ViewModels.Remove(MeasurementVm);
            MeasurementVm.Dispose();
            MeasurementVm = null;
        }

        #endregion Creation

        #region Properties

        private WorkspaceCollection _workspaces;
        public WorkspaceCollection Workspaces
        {
            get
            {
                return _workspaces
                       ?? (_workspaces = new WorkspaceCollection());
            }
        }

        public List<StaticItem> ValidBodyParts { get { return Model.ValidBodyParts; } }

        private StaticItem _bodyPart;
        public StaticItem BodyPart
        {
            get { return _bodyPart; }
            set
            {
                if (value == _bodyPart)
                    return;

                Model.BodyPart = value;
                _bodyPart = Model.BodyPart;
                base.RaisePropertyChanged(OuterMeasurementModel.BodyPartName);
            }
        }

        public List<StaticItem> ValidClothing { get { return Model.ValidClothing; } }

        private StaticItem _clothing;
        public StaticItem Clothing
        {
            get { return _clothing; }
            set
            {
                if (value == _clothing)
                    return;

                Model.Clothing = value;
                _clothing = Model.Clothing;
                base.RaisePropertyChanged(OuterMeasurementModel.ClothingName);
            }
        }

        public MeasurementViewModel MeasurementVm { get; private set; }

        public bool IsValid { get { return Model.IsValid; } }

        #endregion Properties

        #region Property Names

        public const string BodyPartName = "BodyPart";
        public const string ClothingName = "Clothing";
        public const string MeasurementVmName = "MeasurementVm";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            MeasurementVm.Dispose();
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

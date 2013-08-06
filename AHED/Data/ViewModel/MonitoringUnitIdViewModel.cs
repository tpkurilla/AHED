using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class MonitoringUnitIdViewModel : SelectableViewModel<MonitoringUnitIdModel,FieldFortification.MonitoringUnitId>
    {
        #region Creation

        public MonitoringUnitIdViewModel(){}

        public MonitoringUnitIdViewModel(MonitoringUnitIdModel muIdModel,
                                         ModelCache<MonitoringUnitIdModel, FieldFortification.MonitoringUnitId> modelCache)
            : base(muIdModel,modelCache)
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
            WorkerId = Model.WorkerId;
            ReplicateId = Model.ReplicateId;
        }

        #endregion Creation

        #region Properties

        private string _workerId;
        public string WorkerId
        {
            get { return _workerId; }
            set
            {
                if (value == _workerId)
                    return;

                Model.WorkerId = value;
                _workerId = Model.WorkerId;
                base.RaisePropertyChanged(MonitoringUnitIdModel.WorkerIdName);
            }
        }

        private string _replicateId;
        public string ReplicateId
        {
            get { return _replicateId; }
            set
            {
                if (value == _replicateId)
                    return;

                Model.ReplicateId = value;
                _replicateId = Model.ReplicateId;
                base.RaisePropertyChanged(MonitoringUnitIdModel.ReplicateIdName);
            }
        }

        #endregion Properties

        #region Property Names

        public const string WorkerIdName = "WorkerId";
        public const string ReplicateIdName = "ReplicateId";

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

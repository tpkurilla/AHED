using System;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class MonitoringUnitIdModel : Model<FieldFortification.MonitoringUnitId>, IDeepClone<MonitoringUnitIdModel>
    {
        #region Properties

        public string WorkerId
        {
            get { return Value.WorkerId; }
            set
            {
                if (value != Value.WorkerId)
                {
                    if (ValidateWorkerId(value))
                        Value.WorkerId = value;
                }
            }
        }

        public string ReplicateId
        {
            get { return Value.ReplicateId; }
            set
            {
                if (value != Value.ReplicateId)
                {
                    if (ValidateReplicateId(value))
                        Value.ReplicateId = value;
                }
            }
        }

        #endregion Properties

        #region Creation

        public MonitoringUnitIdModel(){}

        public MonitoringUnitIdModel(FieldFortification.MonitoringUnitId muId)
            : base(muId)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public MonitoringUnitIdModel(MonitoringUnitIdModel muIdModel)
            : base(muIdModel)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            // Set all Model properties, and trigger all validations
            WorkerId = Value.WorkerId;
            ReplicateId = Value.ReplicateId;
        }

        public static MonitoringUnitIdModel Create()
        {
            FieldFortification.MonitoringUnitId muId = FieldFortification.MonitoringUnitId.Create();
            muId.InitializeProperties();

            return new MonitoringUnitIdModel(muId);
        }

        #endregion // Creation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string WorkerIdName = "WorkerId";
        public const string ReplicateIdName = "ReplicateId";

        #endregion

        #region Validation

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Description</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field.  Uniqueness is checked by the containing
        /// AllFieldFortEntriesViewModel.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Description</c>.</returns>
        private bool ValidateWorkerId(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(WorkerIdName, Properties.Resources.FieldFortEntry_Description);
                return true;
            }

            AddError(WorkerIdName, Properties.Resources.FieldFortEntry_Description, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ReplicateId</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ReplicateId</c>.</returns>
        private bool ValidateReplicateId(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(ReplicateIdName, Properties.Resources.FieldFortEntry_Description);
                return true;
            }

            AddError(ReplicateIdName, Properties.Resources.FieldFortEntry_Description, false);
            return false;
        }

        #endregion // Validation

        #region IDeepClone Interface

        MonitoringUnitIdModel IDeepClone<MonitoringUnitIdModel>.DeepClone()
        {
            return new MonitoringUnitIdModel(this);
        }
        #endregion IDeepClone Interface

    }
}

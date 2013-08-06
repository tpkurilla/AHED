using System;
using System.Collections.Generic;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class StudyModel : Model<Study>, IDeepClone<StudyModel>
    {
        #region Properties

        public string StudyNumber
        {
            get { return Value.StudyNumber; }
            set
            {
                if (value != Value.StudyNumber)
                {
                    if (ValidateStudyNumber(value))
                        Value.StudyNumber = value;
                }
            }
        }

        public string ReviewerId
        {
            get { return Value.ReviewerId; }
            set
            {
                if (value != Value.ReviewerId)
                {
                    if (ValidateReviewerId(value))
                        Value.ReviewerId = value;
                }
            }
        }

        public bool Metric
        {
            get { return Value.Metric; }
            set { Value.Metric = value; }
        }

        public StaticValues.QaStatus QaStatus
        {
            get { return Value.QaStatus; }
            set { Value.QaStatus = value; }
        }

        public ModelCache<MonitoringUnitModel,MonitoringUnit> MonitoringUnits { get; set; }
        public ModelCache<FieldFortificationModel,FieldFortification> FieldFortifications { get; set; }

        public List<string> MuIds { get; protected set; }

        #endregion Properties

        #region Creation

        public StudyModel(){}

        public StudyModel(Study study)
            : base(study)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public StudyModel(StudyModel model)
            : base(model)
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
            StudyNumber = String.IsNullOrEmpty(Value.StudyNumber) ? String.Empty : Value.StudyNumber;
            ReviewerId = String.IsNullOrEmpty(Value.ReviewerId) ? String.Empty : Value.ReviewerId;
            Metric = Value.Metric;
            QaStatus = Value.QaStatus;

            MonitoringUnits = new ModelCache<MonitoringUnitModel,MonitoringUnit>(
                (from mu in Value.MonitoringUnits
                 select new MonitoringUnitModel(mu, MonitoringUnits, this)
                ).ToList());
            
            FieldFortifications = new ModelCache<FieldFortificationModel,FieldFortification>(
                (from ff in Value.FieldFortifications
                 select new FieldFortificationModel(ff, FieldFortifications, this)
                ).ToList());
            
            MuIds = (from mu in MonitoringUnits.GetAll()
                      select mu.Id
                     ).ToList();
        }

        #endregion Creation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string StudyNumberName = "StudyNumber";
        public const string ReviewerIdName = "ReviewerId";
        public const string MetricName = "Metric";
        public const string QaStatusName = "QaStatus";
        public const string MonitoringUnitsName = "MonitoringUnits";
        public const string FieldFortificationsName = "FieldFortifications";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>StudyNumber</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field, and must be unique.  Uniqueness is tested elsewhere.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>StudyNumber</c>.</returns>
        private bool ValidateStudyNumber(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(StudyNumberName, Properties.Resources.Study_Study_Number);
                return true;
            }

            AddError(StudyNumberName, Properties.Resources.Study_Study_Number, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ReviewerId</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ReviewerId</c>.</returns>
        private bool ValidateReviewerId(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(ReviewerIdName, Properties.Resources.Study_Reviewer_Id);
                return true;
            }

            AddError(ReviewerIdName, Properties.Resources.Study_Reviewer_Id, false);
            return false;
        }

        #endregion


        public StudyModel DeepClone()
        {
            return new StudyModel(this);
        }
    }
}

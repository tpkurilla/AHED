using System;
using System.Collections.Generic;
using System.ComponentModel;
using AHED.Types;

namespace AHED.Model
{
    [Serializable]
    public class StudyModel : IDataErrorInfo
    {
        private string _studyNumber;
        public string StudyNumber
        {
            get { return _studyNumber; }
            set { if (IsValidStudyNumber(value) && _studyNumber != value) _studyNumber = value; }
        }

        private string _reviewerId;
        public string ReviewerId
        {
            get { return _reviewerId; }
            set { if (IsValidReviewerId(value) && _reviewerId != value) _reviewerId = value; }
        }

        private bool _metric;
        public bool Metric
        {
            get { return _metric; }
            set { if (_metric != value) _metric = value; }
        }

        private QaStatus _qaStatus;
        public QaStatus QaStatus
        {
            get { return _qaStatus; }
            set { if (IsValidQaStatus(value) && _qaStatus != value) _qaStatus = value; }
        }

        public List<MonitoringUnit> MonitoringUnits { get; set; }
        public List<FieldFortification> FieldFortifications { get; set; }

        public StudyModel()
        {
            StudyNumber = string.Empty;
            ReviewerId = string.Empty;
            Metric = false;
            QaStatus = QaStatus.NewStudy;
            MonitoringUnits = new List<MonitoringUnit>();
            FieldFortifications = new List<FieldFortification>();
        }

        #region IDataErrorInfo methods

        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}

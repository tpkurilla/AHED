using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class ChangeLogEntryViewModel : SelectableViewModel<ChangeLogEntryModel, ChangeLogEntry>
    {
        #region Creation

        public ChangeLogEntryViewModel(){}

        public ChangeLogEntryViewModel(ChangeLogEntryModel model, ModelCache<ChangeLogEntryModel, ChangeLogEntry> cache)
            : base(model, cache)
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
            DateChanged = Model.DateChanged;
            QaStatus = Model.Status;
            Identity = Model.Identity;
            VersionMajor = Model.VersionMajor;
            VersionMinor = Model.VersionMinor;

            if (CommentVm != null)
                CommentVm.Dispose();

            CommentVm = new CommentViewModel(Model.CommentModel);
        }

        #endregion Creation

        #region Properties

        private string _dateChanged;
        public string DateChanged
        {
            get { return _dateChanged; }
            set
            {
                if (value == _dateChanged)
                    return;

                Model.DateChanged = value;
                _dateChanged = Model.DateChanged;
                base.RaisePropertyChanged(DateChangedName);
            }
        }

        private StaticValues.QaStatus _qaStatus;
        public StaticValues.QaStatus QaStatus
        {
            get { return _qaStatus; }
            set
            {
                if (value == _qaStatus)
                    return;

                Model.Status = value;
                _qaStatus = Model.Status;
                base.RaisePropertyChanged(QaStatusName);
            }
        }

        private string _identity;
        public string Identity
        {
            get { return _identity; }
            set
            {
                if (value == _identity)
                    return;

                Model.Identity = value;
                _identity = Model.Identity;
                base.RaisePropertyChanged(IdentityName);
            }
        }

        private string _versionMajor;
        public string VersionMajor
        {
            get { return _versionMajor; }
            set
            {
                if (value == _versionMajor)
                    return;

                Model.VersionMajor = value;
                _versionMajor = Model.VersionMajor;
                base.RaisePropertyChanged(VersionMajorName);
            }
        }

        private string _versionMinor;
        public string VersionMinor
        {
            get { return _versionMinor; }
            set
            {
                if (value == _versionMinor)
                    return;

                Model.VersionMinor = value;
                _versionMinor = Model.VersionMinor;
                base.RaisePropertyChanged(VersionMinorName);
            }
        }

        public CommentViewModel CommentVm { get; private set; }

        #endregion Properties

        #region Property Names

        public const string DateChangedName = "DateChanged";
        public const string QaStatusName = "QaStatus";
        public const string IdentityName = "Identity";
        public const string VersionMajorName = "VersionMajor";
        public const string VersionMinorName = "VersionMinor";
        public const string CommentVmName = "CommentVm";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            CommentVm.Dispose();
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

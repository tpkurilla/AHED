using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class AccessEntryViewModel : SelectableViewModel<AccessEntryModel, AccessEntry>
    {
        #region Creation

        public AccessEntryViewModel(){}

        public AccessEntryViewModel(AccessEntryModel model, ModelCache<AccessEntryModel, AccessEntry> cache)
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
            Identity = Model.Identity;
            HasReadAccess = Model.HasReadAccess;
            HasWriteAccess = Model.HasWriteAccess;
        }

        #endregion Creation

        #region Properties

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

        private bool _hasReadAccess;
        public bool HasReadAccess
        {
            get { return _hasReadAccess; }
            set
            {
                if (value == _hasReadAccess)
                    return;

                Model.HasReadAccess = value;
                _hasReadAccess = Model.HasReadAccess;
                base.RaisePropertyChanged(HasReadAccessName);
            }
        }

        private bool _hasWriteAccess;
        public bool HasWriteAccess
        {
            get { return _hasWriteAccess; }
            set
            {
                if (value == _hasWriteAccess)
                    return;

                Model.HasWriteAccess = value;
                _hasWriteAccess = Model.HasWriteAccess;
                base.RaisePropertyChanged(HasWriteAccessName);
            }
        }

        #endregion Properties

        #region Property Names

        public const string IdentityName = "Identity";
        public const string HasReadAccessName = "HasReadAccess";
        public const string HasWriteAccessName = "HasWriteAccess";

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

using System;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class AccessEntryModel : Model<AccessEntry>, IDeepClone<AccessEntryModel>
    {
        private readonly ModelCache<AccessEntryModel, AccessEntry> _cache;

        #region Properties

        private string _identity;
        public string Identity
        {
            get { return _identity; }
            set
            {
                if (value != _identity)
                {
                    _identity = value;
                    if (ValidateIdentity(value))
                        Value.Identity = value;
                }
            }
        }

        public bool HasReadAccess
        {
            get { return Value.HasReadAccess; }
            set { Value.HasReadAccess = value; }
        }

        public bool HasWriteAccess
        {
            get { return Value.HasWriteAccess; }
            set { Value.HasWriteAccess = value; }
        }

        #endregion

        #region Creation

        public AccessEntryModel() { }

        public AccessEntryModel(AccessEntry accessEntry,
                                ModelCache<AccessEntryModel, AccessEntry> cache)
            : base(accessEntry)
        {
            if (cache == null)
                throw new ArgumentNullException("cache");

            _cache = cache;

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public AccessEntryModel(AccessEntryModel accessEntryModel)
            : base(accessEntryModel)
        {
            _cache = accessEntryModel._cache;

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            Identity = Value.Identity;
        }

        #endregion Creation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string DateChangedName = "DateChanged";
        public const string StatusName = "Status";
        public const string IdentityName = "Identity";
        public const string VersionMajorName = "VersionMajor";
        public const string VersionMinorName = "VersionMinor";
        public const string CommentName = "Comment";

        #endregion

        #region Validation

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Identity</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field, and must be either match the value of
        /// <c>Crendential.LocalUser</c>, or be a Authenticated identity from
        /// the AHED server.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Identity</c>.</returns>
        private bool ValidateIdentity(string value)
        {
            if (Credential.Validate(value))
            {
                RemoveError(IdentityName, Properties.Resources.Study_Study_Number);
                return true;
            }

            AddError(IdentityName, Properties.Resources.Study_Study_Number, false);
            return false;
        }

        #endregion Validation

        #region IDeepClone Interface

        AccessEntryModel IDeepClone<AccessEntryModel>.DeepClone()
        {
            return new AccessEntryModel(this);
        }

        #endregion IDeepClone Interface
    }
}

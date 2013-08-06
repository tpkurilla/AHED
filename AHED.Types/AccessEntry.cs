using System;

namespace AHED.Types
{
    /// <summary>
    /// An entry within an <c>AccessEntries</c>.  Determines access rights for a user
    /// for a <c>LocalDatabase</c>.
    /// </summary>
    [Serializable]
    public class AccessEntry : IDeepClone<AccessEntry>, IPropertyInitializer
    {
        public string Identity { get; set; }
        public bool HasReadAccess { get; set; }
        public bool HasWriteAccess { get; set; }

        public AccessEntry()
        {
        }

        public AccessEntry(AccessEntry accessEntry)
        {
            Identity = accessEntry.Identity;
            HasReadAccess = accessEntry.HasReadAccess;
            HasWriteAccess = accessEntry.HasWriteAccess;
        }

        /// <summary>
        /// Constructor to use when <c>identity</c> will have full access.
        /// </summary>
        /// <param name="identity">The name of the user or group this <c>AccessEntry</c> corresponds to.</param>
        public AccessEntry(string identity)
        {
            Identity = identity;
            HasReadAccess = true;
            HasWriteAccess = true;
        }


        public bool InitializeProperties()
        {
            Identity = Credential.UserIdentity;
            HasReadAccess = true;
            HasWriteAccess = true;

            return true;
        }

        public AccessEntry DeepClone()
        {
            return new AccessEntry(this);
        }
    }
}

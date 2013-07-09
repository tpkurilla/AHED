using System;

namespace AHED.Types
{
    /// <summary>
    /// An entry within an <c>AccessList</c>.  Determines access rights for a user
    /// for a <c>LocalDatabase</c>.
    /// </summary>
    [Serializable]
    public class AccessEntry
    {
        public string NameOrGroup { get; set; }
        public bool HasCreateAccess { get; set; }
        public bool HasReadAccess { get; set; }
        public bool HasUpdateAccess { get; set; }
        public bool HasDeleteAccess { get; set; }

        public AccessEntry()
        {
        }

        /// <summary>
        /// Constructor to use when <c>nameOrGroup</c> will have full access.
        /// </summary>
        /// <param name="nameOrGroup">The name of the user or group this <c>AccessEntry</c> corresponds to.</param>
        public AccessEntry(string nameOrGroup)
        {
            NameOrGroup = nameOrGroup;
            HasCreateAccess = true;
            HasReadAccess = true;
            HasUpdateAccess = true;
            HasDeleteAccess = true;
        }
    }
}

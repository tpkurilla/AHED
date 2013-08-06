using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Security.Permissions;

namespace AHED.Types
{
    [Serializable]
    public class Credential
    {
        public enum Groups
        {
            [Description("AHED User")]
            AhedUser,

            [Description("AHED Data Entry")]
            AhedDataEntry,

            [Description("AHED Quality Assurance")]
            AhedQualityAssurance,

            [Description("AHED Administrator")]
            AhedAdministrator,
        }

        private static ClaimsIdentity _identity;

        /// <summary>
        /// The key in the AHED Server Authentication database.
        /// </summary>
        public static ClaimsIdentity Identity
        {
            get
            {
                if (_identity == null)
                    Authenticate();

                return _identity;
            }
        }

        /// <summary>
        /// The groups within the AHED Server Authentication database
        /// that <c>Identity</c> belongs to.
        /// </summary>
        public List<string> BelongsTo { get; set; }

        public static string UserIdentity { get; protected set; }

        public static string LocalUserIdentity { get; protected set; }

        public static bool Authenticated { get; protected set; }

        static Credential()
        {
            Authenticated = false;

            // @todo: Change this to actually get an identity from the server
            UserIdentity = Environment.UserName;

            LocalUserIdentity = Environment.UserName;
        }

        private static void Authenticate()
        {
            // @todo: insert code to Authenticate user and set _identity
        }

        public static bool Validate(string value)
        {
            if (String.IsNullOrEmpty(value))
                return false;

            if (value == LocalUserIdentity)
                return true;

            // @todo: Perform lookup on AHED server to verify valid Identity
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    [Serializable]
    public class ChangeLogEntry
    {
        /// <summary>
        /// Date of status change.
        /// </summary>
        public DateTime DateChanged { get; set; }

        /// <summary>
        /// Status changed to.
        /// </summary>
        public StaticValues.QaStatus Status { get; set; }

        /// <summary>
        /// The identity of the person or entity authorizing the change.
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Major version number after change.
        /// </summary>
        public int VersionMajor { get; set; }

        /// <summary>
        /// Minor version number after change.
        /// </summary>
        public int VersionMinor { get; set; }

        /// <summary>
        /// Reason for the status change.
        /// </summary>
        public string Comment { get; set; }

        public ChangeLogEntry()
        {
        }

        public static ChangeLogEntry InitialEntry
        {
            get
            {
                return new ChangeLogEntry()
                    {
                        DateChanged = DateTime.Now,
                        Status = StaticValues.QaStatus.New,
                        Identity = Environment.UserName,
                        VersionMajor = 1,
                        VersionMinor = 0,
                        VersionBuild = 1,
                        Comment = "Initial Creation"
                    };
            }
        }
    }
}

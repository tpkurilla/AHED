using System;

namespace AHED.Types
{
    [Serializable]
    public class ChangeLogEntry : IDeepClone<ChangeLogEntry>, IPropertyInitializer
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
        public Comment Comment { get; set; }

        public ChangeLogEntry()
        {
        }

        public ChangeLogEntry(ChangeLogEntry entry)
        {
            DateChanged = entry.DateChanged;
            Status = entry.Status;
            Identity = entry.Identity;
            VersionMajor = entry.VersionMajor;
            VersionMinor = entry.VersionMinor;
            Comment = entry.Comment;
        }

        private static ChangeLogEntry _template;

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            if (_template != null)
            {
                DateChanged = _template.DateChanged;
                Status = _template.Status;
                Identity = _template.Identity;
                VersionMajor = _template.VersionMajor;
                VersionMinor = _template.VersionMinor;
                Comment = _template.Comment;
            }

            return true;
        }

        private static void CreateTemplate()
        {
            if (_template != null)
                return;

            _template = new ChangeLogEntry
            {
                DateChanged = DateTime.Now,
                Status = StaticValues.QaStatus.New,
                Identity = Environment.UserName,
                VersionMajor = 1,
                VersionMinor = 0,
                Comment = new Comment("Initial Creation")
            };
        }

        public static ChangeLogEntry InitialEntry
        {
            get
            {
                if (_template == null)
                    CreateTemplate();

                return new ChangeLogEntry(_template);
            }
        }

        public ChangeLogEntry DeepClone()
        {
            return new ChangeLogEntry(this);
        }
    }
}

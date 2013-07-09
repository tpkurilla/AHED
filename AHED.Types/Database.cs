using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using AHED.Util;

namespace AHED.Types
{
    /// <summary>
    /// Represents a specific database containing an access list, a <c>StaticTable</c> and
    /// a list of <c>Study</c> entries.
    /// <para>
    /// When instantiated, the entire database will be ingested and available.
    /// This will generally be held within the <c>LocalDataCache</c>.
    /// </para>
    /// <para>
    /// Actual physical access to the underlying RaveDb database should
    /// be completely encapulated.  No <c>Database</c> should ever be
    /// left in an open state.  Using is in a <c>using</c> statement so that
    /// automatic disposal occurs is preferred.
    /// </para>
    /// </summary>
    [Serializable]
    public class Database
    {
        /// <summary>
        /// Current version of the database.
        /// </summary>
        public const int SerializationVersion = 1;

        /// <summary>
        /// Full description of the database.  e.g., "Main database for AHETF".
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The major version of this database.  e.g., the '2' in "2.0.1".
        /// </summary>
        public int VersionMajor { get; set; }

        /// <summary>
        /// The minor version of this database.  e.g., the '0' in "2.0.1".
        /// </summary>
        public int VersionMinor { get; set; }

        /// <summary>
        /// The build number of this database.  e.g., the '1' in "2.0.1".
        /// </summary>
        public int VersionBuild { get; set; }

        /// <summary>
        /// When this database was original created.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// When this database was last modified.
        /// </summary>
        public DateTime DateLastModified { get; set; }

        /// <summary>
        /// Used to cache the entire <c>StaticTable</c> for this database.
        /// </summary>
        public StaticTable StaticTable { get; set; }

        /// <summary>
        /// List of all <c>Study</c> entries for this database.
        /// </summary>
        public List<Study> Studies { get; set; }

        /// <summary>
        /// Current status of this database.
        /// </summary>
        public StaticValues.QaStatus Status { get; set; }

        /// <summary>
        /// List of changes made 
        /// </summary>
        public List<ChangeLogEntry> Changes { get; set; }
 
        /// <summary>
        /// Access control list for this database.
        /// </summary>
        public List<AccessEntry> AccessList { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Database()
        {
        }

        /// <summary>
        /// Creates a new, empty <c>Database</c>.
        /// </summary>
        public static Database New
        {
            get
            {
                var newDb = new Database()
                    {
                        Description = String.Empty,
                        DateCreated = DateTime.Now,
                        VersionMajor = SerializationVersion,
                        VersionMinor = 0,
                        Status = StaticValues.QaStatus.New,
                        StaticTable = new StaticTable(),
                        Studies = new List<Study>(),
                        Changes = new List<ChangeLogEntry>(),
                        AccessList = new List<AccessEntry>(),
                    };

                newDb.DateLastModified = newDb.DateCreated;

                var initialEntry = ChangeLogEntry.InitialEntry;
                initialEntry.VersionMajor = newDb.VersionMajor;
                initialEntry.VersionMinor = newDb.VersionMinor;
                newDb.Changes.Add(initialEntry);

                // @todo: add AccessList entries here if needed.

                return newDb;
            }
        }

        public override string ToString()
        {
            return Serialize(this).ToString();
        }

        /// <summary>
        /// Converts this database to <c>Database</c>.
        /// <br/>
        /// If the database Serialization Version changes, then a new
        /// Database class will be created for the new version.  <c>Database</c>
        /// will always implement the latest version of the database, while
        /// the previous <c>Database</c> class should be renamed and have
        /// attributes added to its members to correctly map elements to
        /// members on the parse.  The renamed class will still appear
        /// in <c>_databaseTypes</c> for the same key, and the new
        /// <c>Database</c> type should be added with the next version
        /// number.
        /// </summary>
        /// <returns>this database converted to <c>Database</c>.</returns>
        public Database ToDatabase()
        {
            return this;
        }

        #region Static Members

        private static Dictionary<int, Type> _databaseTypes;
 
        /// <summary>
        /// Maps version number to <c>XmlSerializer</c> to use for
        /// serialization and deserialization.  MSDN documentation
        /// recommends only creating one XmlSerializer for any
        /// class.
        /// </summary>
        private static Dictionary<int, XmlSerializer> _serializers;

        private static void Initialize()
        {
            _databaseTypes = new Dictionary<int, Type>();
            _databaseTypes[1] = typeof (Database);

            _serializers = new Dictionary<int, XmlSerializer>();

            foreach (KeyValuePair<int, Type> pair in _databaseTypes)
            {
                _serializers[pair.Key] = new XmlSerializer(pair.Value);
            }
        }

        /// <summary>
        /// Serializes a <c>Database</c> object using an XmlSerializer.  An <c>XDocument</c> is
        /// created with a <c>Version</c> element and a <c>Data</c> element.  The version is
        /// used to determine which which version of a <c>Database</c> is contained within
        /// the data element.  This allows particular de-serialization to occurs for each
        /// version of the database.
        /// </summary>
        /// <param name="db">The <c>Database</c> to serialize.</param>
        /// <returns></returns>
        public static XDocument Serialize(Database db)
        {
            if (_serializers == null)
            {
                Initialize();
            }

            // First, convert the database to a string
            var serializer = _serializers[db.VersionMajor];
            var writer = new StringWriter();
            serializer.Serialize(writer, db);
            writer.Close();

            var doc = new XDocument(
                new XComment("Database for the Agricultural Handler Exposure Task Force (AHETF)"),
                new XElement("AHED-Database",
                    new XElement("Version", db.VersionMajor)),
                    new XElement("Data", new XCData(writer.ToString())));

            return doc;
        }

        public static Database Deserialize(string dbString)
        {
            Database db = null;
            try
            {
                XDocument doc = XDocument.Parse(dbString);
                XElement versionElement = doc.Elements().First(e => e.Name == "Version");
                int version = Int32.Parse(versionElement.Value);
                var serializer = _serializers[version];

                XElement dataElement = doc.Elements().First(e => e.Name == "Data");
                StringReader reader = new StringReader(dataElement.Value);
                object dbObject = serializer.Deserialize(reader);
                db = dbObject.GetType().GetMethod("ToDatabase").Invoke(dbObject, parameters: null) as Database;
            }
            catch (Exception)
            {
                Log.Error("Malformed database:\n" + dbString);
            }

            return db;
        }

        #endregion Static Members
    }
}

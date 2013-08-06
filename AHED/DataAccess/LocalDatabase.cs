using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHED.Types;
using AHED.Util;

namespace AHED.Model
{
    /// <summary>
    /// Represents a specific local database containing a <c>StaticTable</c> and
    /// a <c>StudyTable</c>.
    /// <para>
    /// When instantiated, the entire database will be ingested and available.
    /// This will generally be held within the <c>LocalDataCache</c>.
    /// </para>
    /// <para>
    /// Actual physical access to the underlying RaveDb database should
    /// be completely encapulated.  No <c>LocalDatabase</c> should ever be
    /// left in an open state.  Using is in a <c>using</c> statement so that
    /// automatic disposal occurs is preferred.
    /// </para>
    /// </summary>
    [Serializable]
    public class LocalDatabase
    {
        public static string DefaultPath { get; set; }

        /// <summary>
        /// Directory path of the directory holding this database.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Name of the database.  This will actually be a folder in <c>Path</c>
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// The full name of the database, including path.
        /// </summary>
        public string FullName { get; protected set; }

        /// <summary>
        /// Full description of the database.  e.g., "Main database for AHETF; v2.0.1".
        /// </summary>
        public string Description { get; protected set; }

        public Database Database { get; protected set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocalDatabase()
        {
            Path = DefaultPath;
            Name = String.Empty;    /// @todo Generate a LocalDb name
            FullName = String.Empty;    /// @todo set once LocalDb name generated
            Database = new Database();
        }

        public LocalDatabase(string name)
        {
            Path = DefaultPath;
            Name = name;
            FullName = Path + Name; /// @todo stitch these together for the general case
        }

        public void IngestData()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Error("Error ingesting data for '" + FullName + "'\n" + ex.Message);
            }
        }

        #region Static initialization

        static LocalDatabase()
        {
            DefaultPath = AHED.Properties.Resources.Local_Database_Path;
        }

        #endregion

    }
}

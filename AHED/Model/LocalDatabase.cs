using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHED.Types;

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

        /// <summary>
        /// Used to cache the entire <c>StaticTable</c> for this database.
        /// </summary>
        public StaticTable staticTable;

        /// <summary>
        /// Access control list for this database.
        /// </summary>
        public AccessTable Access { get; set; }

        /// <summary>
        /// Current status of this database.
        /// </summary>
        public QaStatus Status { get; set; }

        /// <summary>
        /// Used to cache the entire <c>StudyTable</c> for this database.
        /// </summary>
        public StudyTable studyTable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocalDatabase()
        {
            Path = DefaultPath;
            Name = String.Empty;    /// @todo Generate a LocalDb name
            FullName = String.Empty;    /// @todo set once LocalDb name generated
            Access = new AccessTable();
            Access.Add(new AccessEntry("LOCAL"));
            Status = QaStatus.NewStudy;
            staticTable = new StaticTable();
            studyTable = new StudyTable();
        }

        public LocalDatabase(string name)
        {
            Path = DefaultPath;
            Name = name;
            FullName = Path + Name; /// @todo stitch these together for the general case
            Status = QaStatus.NewStudy;
        }

        public void IngestData()
        {
            try
            {
                using (EmbeddableDocumentStore db = new EmbeddableDocumentStore { DataDirectory = FullName })
                {
                    db.Initialize();
                    new RavenDocumentsByEntityName().Execute(db); // create the default index
                    IngestStaticTable(db);
                    IngestStudyTable(db);

                    // @todo: Ingest other tables
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error ingesting data for '" + FullName + "'\n" + ex.Message);
            }
        }

        public void IngestStaticTable(EmbeddableDocumentStore db)
        {
            using (IDocumentSession session = db.OpenSession())
            {
                const int ElementTakeCount = 128;
                int position = 0;
                Dictionary<Int32, StaticItem> theStaticItems = new Dictionary<Int32, StaticItem>();
                Dictionary<Int32, StaticItem> results = new Dictionary<Int32, StaticItem>();

                // RavenDb by default only returns 128 elements at a time.  Even by changing
                // defaults, it will still not return more than 1024 at a time.  Thus, we need
                // to loop and grab chunks of data to get all of it.
                do
                {
                    results =
                        (
                            from item in session.Query<KeyValuePair<Int32, StaticItem>>()
                            .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite())
                            .Skip(position)
                            .Take(ElementTakeCount)
                            select item
                        ).ToDictionary(item => item.Key, item => item.Value);

                    // concatenate the results to the main list
                    results.ToList().ForEach(x => theStaticItems.Add(x.Key, x.Value));

                    position += ElementTakeCount;
                } while (results.Count == ElementTakeCount);


                staticTable = new StaticTable(theStaticItems);
            }
        }

        public void IngestStudyTable(EmbeddableDocumentStore db)
        {
            using (IDocumentSession session = db.OpenSession())
            {
                const int ElementTakeCount = 128;
                int position = 0;
                List<StudyModel> theStudyList = new List<StudyModel>();
                List<StudyModel> results = new List<StudyModel>();


                // RavenDb by default only returns 128 elements at a time.  Even by changing
                // defaults, it will still not return more than 1024 at a time.  Thus, we need
                // to loop and grab chunks of data to get all of it.
                do
                {
                    results =
                        (
                            from item in session.Query<Study>()
                            .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite())
                            .Skip(position)
                            .Take(ElementTakeCount)
                            select item
                       ).ToList<Study>();

                    // concatenate the results to the main list
                    results.ToList().ForEach(x => theStudyList.Add(x));

                    position += ElementTakeCount;

                } while (results.Count == ElementTakeCount);

                studyTable = new StudyTable(theStudyList);
            }
        }

        public void SaveStaticTable()
        {
            /// @todo Make a backup of this database before changing it

            try
            {
                Dictionary<Int32, StaticItem> dictionary = staticTable.GetAll();

                using (EmbeddableDocumentStore db = new EmbeddableDocumentStore { DataDirectory = FullName })
                {
                    db.Initialize();
                    new RavenDocumentsByEntityName().Execute(db); // create the default index
                    using (IDocumentSession session = db.OpenSession())
                    {
                        // NOTE: This method will clear out the RavenDB database
                        // for Static Items and then save what we have in memory
                        session.Advanced.DatabaseCommands.DeleteByIndex("Raven/DocumentsByEntityName",
                            new IndexQuery { Query = "Tag:KeyValuePairsOfInt32sOfStaticItems" }, allowStale: true);


                        // Operations against session
                        foreach (KeyValuePair<Int32, StaticItem> item in dictionary)
                        {
                            session.Store(item);
                        }

                        // Flush those changes
                        session.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error saving Static Table for '" + FullName + "'\n" + ex.Message);
            }
        }

        public void DeleteStaticTable()
        {
            /// @todo Make a backup of this database before changing it

            staticTable.Clear();
            SaveStaticTable();
        }

        public void SaveStudyTable()
        {
            /// @todo Make a backup of this database before changing it

            try
            {
                using (EmbeddableDocumentStore db = new EmbeddableDocumentStore { DataDirectory = FullName })
                {
                    db.Initialize();
                    new RavenDocumentsByEntityName().Execute(db); // create the default index
                    using (IDocumentSession session = db.OpenSession())
                    {
                        // NOTE: This method will clear out the RavenDB database
                        // for Study Items and then save what we have in memory
                        session.Advanced.DatabaseCommands.DeleteByIndex("Raven/DocumentsByEntityName",
                            new IndexQuery { Query = "Tag:Studies" }, allowStale: true);


                        // Operations against session
                        foreach (StudyModel item in studyTable.studyList)
                        {
                            session.Store(item);
                        }

                        // Flush those changes
                        session.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error saving Study Table for '" + FullName + "'\n" + ex.Message);
            }
        }

        public void DeleteStudyTable()
        {
            /// @todo Make a backup of this database before changing it

            studyTable.Clear();
            SaveStudyTable();
        }

        #region Static initialization

        static LocalDatabase()
        {
            DefaultPath = AHED.Properties.Resources.Local_Database_Path;
        }

        #endregion

    }
}

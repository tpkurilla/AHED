using System;
using System.Collections.Generic;
using System.Linq;
using AHED.Types;

namespace AHED.Model
{
    /// <summary>
    /// Models the active data used for AHED queries and reports.
    /// </summary>
    public class DataSetModel
    {
        private readonly List<LocalDatabase> _localDatabases;

        #region Properties

        public List<string> DatabasesLoaded
        {
            get
            {
                return (from db in _localDatabases
                        select db.Description
                       ).ToList();
            }
        }

        private readonly List<Predicate<MonitoringUnit>> _filters;

        /// <summary>
        /// Ordered list of filters to apply to 
        /// </summary>
        public List<Predicate<MonitoringUnit>> Filters
        {
            get { return new List<Predicate<MonitoringUnit>>(_filters); }
        }

        /// <summary>
        /// Current list of results matching Filters.
        /// <br/>
        /// NOTE: Property currently returns a reference to the actual internal
        /// list.  This can be abused by changing the list.  If abuse
        /// occurs, then change the property to return a new copy of the list.
        /// </summary>
        private readonly List<MonitoringUnit> _results; 
        public List<MonitoringUnit> Results { get { return _results; }}

        public int ResultsCount { get { return _results.Count; } }

        #endregion Properties

        #region Creation

        public DataSetModel()
        {
            _localDatabases = new List<LocalDatabase>();
            _filters = new List<Predicate<MonitoringUnit>>();
            _results = new List<MonitoringUnit>();
        }

        #endregion Creation

        #region Public Methods

        public void Add(LocalDatabase database)
        {
            if (!_localDatabases.Contains(database))
            {
                _localDatabases.Add(database);
                AddMonitoringUnits(database);

                ApplyFilters();
            }
        }

        public bool Remove(LocalDatabase database)
        {
            bool result = _localDatabases.Remove(database);
            _results.Clear();
            foreach (var localDatabase in _localDatabases)
            {
                AddMonitoringUnits(localDatabase);
            }

            ApplyFilters();
            return result;
        }

        public void Add(Predicate<MonitoringUnit> predicate)
        {
            _filters.Add(predicate);
            ApplyFilters();
        }

        public void ClearFilters()
        {
            _filters.Clear();
        }

        public bool Remove(Predicate<MonitoringUnit> predicate)
        {
            return _filters.Remove(predicate);
        }

        #endregion Public Methods

        #region Private Helpers

        private void AddMonitoringUnits(LocalDatabase database)
        {
            foreach (var study in database.Database.Studies)
            {
                foreach (var monitoringUnit in study.MonitoringUnits)
                {
                    _results.Add(monitoringUnit);
                }
            }
        }

        private void ApplyFilters()
        {
            // LINQ voodoo applying Filters to Monitoring Units in _results
        }

        #endregion Private Helpers
    }
}

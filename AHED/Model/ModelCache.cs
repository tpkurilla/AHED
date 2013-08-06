using System;
using System.Collections.Generic;
using System.Linq;
using AHED.Types;
using AHED.Util;

namespace AHED.Model
{
    /// <summary>
    /// Represents a source of a specific sub-class of <c>BaseModel</c>.
    /// Supports Add/Modify/Delete events.
    /// </summary>
    public class ModelCache<TModel, TBase>
        where TModel : Model<TBase>, IDeepClone<TModel>, new ()
        where TBase : class, IDeepClone<TBase>, IPropertyInitializer, new ()
    {
        #region Fields

        private readonly List<TModel> _entries;

        #endregion // Fields

        #region Constructor

        public ModelCache()
        {
            _entries = new List<TModel>();
        }

        /// <summary>
        /// Creates a new cache of entries.
        /// </summary>
        /// <param name="entries">
        /// The enumerable collection whose entries we will CRUD.
        /// </param>
        public ModelCache(List<TModel> entries)
        {
            _entries = (from entry in entries
                        select entry.DeepClone()
                       ).ToList();
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary>
        /// Raised when an entry is placed into the collection.
        /// </summary>
        public event EventHandler<ModelCacheEventArgs<TModel>> EntryAdded;

        /// <summary>
        /// Raised when an entry is changed in the collection.
        /// </summary>
        public event EventHandler<ModelCacheEventArgs<TModel>> EntryUpdated;

        /// <summary>
        /// Raised when an entry is deleted from the collection.
        /// </summary>
        public event EventHandler<ModelCacheEventArgs<TModel>> EntryDeleted;

        public void Add(List<TModel> entries)
        {
            foreach (var entry in entries)
            {
                _entries.Add(entry);
            }
        }

        /// <summary>
        /// Places the specified entry into the cache.
        /// If the entry is already in the cache, an
        /// exception is not thrown.
        /// </summary>
        public void AddEntry(TModel entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            _entries.Add(entry);
            RaiseEntryAdded(new ModelCacheEventArgs<TModel>(entry));
        }

        /// <summary>
        /// Places the specified entry into the cache.
        /// If the entry is already in the cache, an
        /// exception is not thrown.
        /// </summary>
        public void UpdateEntry(TModel entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            if (ContainsEntry(entry))
            {
                RaiseEntryUpdated(new ModelCacheEventArgs<TModel>(entry));
            }
            else
            {
                RaiseEntryAdded(new ModelCacheEventArgs<TModel>(entry));
            }
        }

        /// <summary>
        /// Places the specified entry into the cache.
        /// If the entry is already in the cache, an
        /// exception is not thrown.
        /// </summary>
        public void DeleteEntry(TModel entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            try
            {
                _entries.Remove(entry);
            }
            catch (Exception ex)
            {
                Log.Error("Error removing FieldFortEntry:\n" + ex.Message);
            }

            RaiseEntryDeleted(new ModelCacheEventArgs<TModel>(entry));
        }

        public void Clear()
        {
            if (EntryDeleted == null)
            {
                // No subscribers, so do it quick and easy
                _entries.RemoveAll(entry => true);
                return;
            }

            // Cannot use _entries.RemoveAll because we need to notify subscribers
            var toDelete = new List<TModel>(_entries);
            foreach (var entry in toDelete)
            {
                DeleteEntry(entry);
            }
        }

        /// <summary>
        /// Returns true if the specified entry exists in the
        /// cache, or false if it is not.
        /// </summary>
        public bool ContainsEntry(TModel entry)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            return _entries.Contains(entry);
        }

        /// <summary>
        /// Returns a shallow-copied list of all models in the cache.
        /// </summary>
        public List<TModel> GetAll()
        {
            return new List<TModel>(_entries);
        }

        public bool IsValid
        {
            get
            {
                if (_entries.Any(entry => entry.IsValid == false))
                {
                    return false;
                }

                return true;
            }
        }

        #endregion // Public Interface

        #region Events

        protected virtual void RaiseEntryAdded(ModelCacheEventArgs<TModel> modelCacheEventArgs)
        {
            EventHandler<ModelCacheEventArgs<TModel>> handler = EntryAdded;
            if (handler != null)
            {
                handler(this, modelCacheEventArgs);
            }
        }

        protected virtual void RaiseEntryUpdated(ModelCacheEventArgs<TModel> modelCacheEventArgs)
        {
            EventHandler<ModelCacheEventArgs<TModel>> handler = EntryUpdated;
            if (handler != null)
            {
                handler(this, modelCacheEventArgs);
            }
        }

        protected virtual void RaiseEntryDeleted(ModelCacheEventArgs<TModel> modelCacheEventArgs)
        {
            EventHandler<ModelCacheEventArgs<TModel>> handler = EntryDeleted;
            if (handler != null)
            {
                handler(this, modelCacheEventArgs);
            }
        }

        #endregion Events
    }

    public class ModelCacheEventArgs<T> : EventArgs
        where T : class 
    {
        public ModelCacheEventArgs(T entry)
        {
            Entry = entry;
        }

        public T Entry { get; private set; }
    }

}

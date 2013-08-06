using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using AHED.Model;
using AHED.Properties;
using AHED.Types;

namespace AHED.ViewModel
{
    /// <summary>
    /// Represents a container of ViewModel objects
    /// that has support for staying synchronized with the
    /// ModelCache holding then.  This class also provides information
    /// related to multiple selected cache entries.
    /// </summary>
    public class AllViewModel<TViewModel, TModel, TBase> : WorkspaceViewModel
        where TViewModel : SelectableViewModel<TModel,TBase>, new()
        where TModel : Model<TBase>, IDeepClone<TModel>, new()
        where TBase : class, IDeepClone<TBase>, IPropertyInitializer, new()
    {
        #region Fields

        protected readonly ModelCache<TModel,TBase> Cache;

        #endregion // Fields

        #region Constructor

        public AllViewModel(ModelCache<TModel, TBase> cache)
        {
            if (cache == null)
                throw new ArgumentNullException("cache");

            base.DisplayName = Resources.AllViewModel_Display_Name;

            Cache = cache;

            // Subscribe for notifications of changes to the cache.
            Cache.EntryAdded += OnEntryAddedToCache;
            Cache.EntryDeleted += OnEntryDeletedFromCache;

            // Populate the Entries collection with CustomerViewModels.
            var all = new List<TViewModel>();
            foreach (TModel model in Cache.GetAll())
            {
                var vm = new TViewModel();
                vm.Initialize(model, cache);
                all.Add(vm);
            }

            foreach (TViewModel cvm in all)
                cvm.PropertyChanged += OnTViewModelPropertyChanged;

            Entries = new ObservableCollection<TViewModel>(all);
            Entries.CollectionChanged += OnCollectionChanged;
        }

        #endregion // Constructor

        #region Public Interface

        /// <summary>
        /// Returns a collection of all the TViewModel objects.
        /// </summary>
        public ObservableCollection<TViewModel> Entries { get; private set; }

        /// <summary>
        /// Returns the total sales sum of all selected Monitoring Unit Ids.
        /// </summary>
        public int TotalNumberSelectedEntries
        {
            get
            {
                return Entries.Sum(viewModel => viewModel.IsSelected ? 1 : 0);
            }
        }

        public const string AllEntriesName = "Entries";
        public const string TotalNumberSelectedEntriesName = "TotalNumberSelectedEntries";

        #endregion // Public Interface

        #region  Base Class Overrides

        protected new void Dispose()
        {
            foreach (TViewModel vm in Entries)
                vm.Dispose();

            Entries.Clear();
            Entries.CollectionChanged -= OnCollectionChanged;

            Cache.EntryAdded -= OnEntryAddedToCache;
            Cache.EntryDeleted -= OnEntryDeletedFromCache;

            base.Dispose();
        }

        #endregion // Base Class Overrides

        #region Event Handling Methods

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (TViewModel vm in e.NewItems)
                    vm.PropertyChanged += OnTViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (TViewModel vm in e.OldItems)
                    vm.PropertyChanged -= OnTViewModelPropertyChanged;
        }

        void OnTViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            // Make sure that the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            var vm = (sender as TViewModel);
            if (vm != null)
                vm.VerifyPropertyName(e.PropertyName);

            // When an entry is selected or unselected, we must let the
            // world know that the TotalSelectedComments property has changed,
            // so that it will be queried again for a new value.
            if (e.PropertyName == SelectableViewModel<TModel, TBase>.IsSelectedName)
                RaisePropertyChanged(TotalNumberSelectedEntriesName);
        }

        void OnEntryAddedToCache(object sender, ModelCacheEventArgs<TModel> e)
        {
            var viewModel = new TViewModel();
            viewModel.Initialize(e.Entry, Cache);
            Entries.Add(viewModel);
        }

        private void OnEntryDeletedFromCache(object sender, ModelCacheEventArgs<TModel> e)
        {
            TViewModel muIdViewModel = Entries.First(vm => vm.Model == e.Entry);
            if (muIdViewModel != null)
                Entries.Remove(muIdViewModel);
        }

        #endregion // Event Handling Methods
    }
}

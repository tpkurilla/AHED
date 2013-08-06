using System;
using System.Windows.Input;
using AHED.Model;
using AHED.Types;

namespace AHED.ViewModel
{
    public class SelectableViewModel<TModel,TBase> : SimpleViewModel<TModel,TBase>
        where TModel : Model<TBase>, IDeepClone<TModel>, new()
        where TBase : class, IDeepClone<TBase>, IPropertyInitializer, new()
    {
        #region Fields

        private ModelCache<TModel, TBase> _cache;

        private bool _isSelected;

        private RelayCommand _deleteCommand;

        #endregion Fields

        #region Creation

        public SelectableViewModel(){}

        public SelectableViewModel(TModel model, ModelCache<TModel, TBase> cache)
            : base(model)
        {
            if (cache == null)
                throw new ArgumentNullException("cache");

            _cache = cache;
        }

        public virtual void Initialize(TModel model, ModelCache<TModel, TBase> cache)
        {
            base.Initialize(model);
            if (cache == null)
                throw new ArgumentNullException("cache");

            _cache = cache;
            RaiseModelReset();
        }
        
        #endregion Creation

        #region Properties

        public ModelCache<TModel, TBase> Cache { get { return _cache; } } 

        #endregion Properties

        #region Property Names

        public const string CacheName = "Cache";
        public const string IsSelectedName = "IsSelected";

        #endregion Property Names

        #region Presentation Properties

        /// <summary>
        /// Gets/sets whether this entry is selected in the UI.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected)
                    return;

                _isSelected = value;

                base.RaisePropertyChanged(IsSelectedName);
            }
        }

        /// <summary>
        /// Returns a command that saves the entry.
        /// </summary>
        public virtual ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand
                       ?? (_deleteCommand = new RelayCommand(
                                                param => Delete(),
                                                param => CanDelete
                                                ));
            }
        }

        #endregion Presentation Properties

        #region Public Methods

        /// <summary>
        /// Saves the working entry into the original.  This method is invoked by the SaveCommand.
        /// </summary>
        public override void Save()
        {
            if (!Model.IsValid)
            {
                string msg = String.Format(Properties.Resources.SelectableViewModel_Exception_Cannot_Save, DisplayName);
                throw new InvalidOperationException(msg);
            }

            Model.Save();
            if (_cache.ContainsEntry(Model))
            {
                _cache.UpdateEntry(Model);
            }
            else
            {
                _cache.AddEntry(Model);
            }
        }

        /// <summary>
        /// Saves the working entry into the original.  This method is invoked by the SaveCommand.
        /// </summary>
        public virtual void Delete()
        {
            if (_cache.ContainsEntry(Model))
                _cache.DeleteEntry(Model);
        }

        #endregion // Public Methods

        #region Private Helpers

        bool CanDelete
        {
            get { return _cache.ContainsEntry(Model) /*(_model.OriginalEntry != null)*/; }
        }

        #endregion // Private Helpers
    }
}

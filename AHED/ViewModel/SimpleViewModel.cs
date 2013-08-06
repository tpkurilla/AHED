using System;
using System.Windows.Input;
using AHED.Model;
using AHED.Types;

namespace AHED.ViewModel
{
    public class SimpleViewModel<TModel,TBase> : WorkspaceViewModel
        where TModel : Model<TBase>, IDeepClone<TModel>, new()
        where TBase : class, IDeepClone<TBase>, IPropertyInitializer, new()
    {
        #region Fields

        private TModel _model;

        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;

        public event EventHandler ModelReset;

        #endregion Fields

        #region Creation

        public SimpleViewModel(){}

        public SimpleViewModel(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            _model = model.DeepClone();
        }

        public virtual void Initialize(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            _model = model.DeepClone();
            RaiseModelReset();
        }

        protected virtual void RaiseModelReset()
        {
            EventHandler handler = ModelReset;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion Creation

        #region Properties

        public TModel Model { get { return _model; } }

        #endregion Properties

        #region Property Names

        public const string ModelName = "Model";

        #endregion Property Names

        #region Presentation Properties

        /// <summary>
        /// Returns a command that saves the entry.
        /// </summary>
        public virtual ICommand SaveCommand
        {
            get
            {
                return _saveCommand
                       ?? (_saveCommand = new RelayCommand(
                                              param => Save(),
                                              param => CanSave
                                              ));
            }
        }

        /// <summary>
        /// Returns a command that saves the entry.
        /// </summary>
        public virtual ICommand CancelCommand
        {
            get
            {
                return _cancelCommand
                       ?? (_cancelCommand = new RelayCommand(
                                                param => Cancel(),
                                                param => CanCancel
                                                ));
            }
        }

        #endregion Presentation Properties

        #region Public Methods

        /// <summary>
        /// Saves the working entry into the original.  This method is invoked by the SaveCommand.
        /// </summary>
        public virtual void Save()
        {
            if (!_model.IsValid)
            {
                string msg = String.Format(Properties.Resources.SelectableViewModel_Exception_Cannot_Save, DisplayName);
                throw new InvalidOperationException(msg);
            }

            _model.Save();
        }

        /// <summary>
        /// Cancels the working entry, returning all models to their last-saved state.
        /// This method is invoked by the CancelCommand.
        /// </summary>
        public virtual void Cancel()
        {
            _model.Cancel();
            RaiseModelReset();
        }

        #endregion // Public Methods

        #region Private Helpers

        /// <summary>
        /// Returns true if the entry is valid and can be saved.
        /// </summary>
        protected virtual bool CanSave
        {
            get { return _model.IsValid; }
        }

        /// <summary>
        /// Reports whether this current ViewModel can be reset to its last-saved state.
        /// Currently, always reports <c>true</c>.  If this need to only report <c>true</c>
        /// if changes have been made, then more logic is required.
        /// </summary>
        protected virtual bool CanCancel
        {
            get { return true; }
        }

        #endregion // Private Helpers
    }
}

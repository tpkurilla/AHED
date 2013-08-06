using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class FieldFortEntryViewModel : SelectableViewModel<FieldFortEntryModel,FieldFortification.Entry>
    {
        #region Creation

        public FieldFortEntryViewModel(){}

        public FieldFortEntryViewModel(FieldFortEntryModel model, ModelCache<FieldFortEntryModel, FieldFortification.Entry> cache)
            : base(model,cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        void SetProperties()
        {
            Description = Model.Description;
            FortificationLevel = Model.FortificationLevel;
            FortificationAdjustment = Model.FortificationAdjustment;
        }

        #endregion Creation

        #region Properties

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;

                Model.Description = value;
                _description = Model.Description;
                base.RaisePropertyChanged(FieldFortEntryModel.DescriptionName);
            }
        }

        private string _fortificationLevel;
        public string FortificationLevel
        {
            get { return _fortificationLevel; }
            set
            {
                if (value == _fortificationLevel)
                    return;

                Model.FortificationLevel = value;
                _fortificationLevel = Model.FortificationLevel;
                base.RaisePropertyChanged(FieldFortEntryModel.FortificationLevelName);
            }
        }

        private string _fortificationAdjustment;
        public string FortificationAdjustment
        {
            get { return _fortificationAdjustment; }
            set
            {
                if (value == _fortificationAdjustment)
                    return;

                Model.FortificationAdjustment = value;
                _fortificationAdjustment = Model.FortificationAdjustment;
                base.RaisePropertyChanged(FieldFortEntryModel.FortificationAdjustmentName);
            }
        }

        #endregion Properties

        #region Property Names

        public const string DescriptionName = "Description";
        public const string FortificationLevelName = "FortificationLevel";
        public const string FortificationAdjustmentName = "FortificationAdjustment";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members

    }
}

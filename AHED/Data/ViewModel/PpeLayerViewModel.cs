using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class PpeLayerViewModel : SelectableViewModel<PpeLayerModel, PpeLayer>
    {
        #region Creation

        public PpeLayerViewModel(){}

        public PpeLayerViewModel(PpeLayerModel model, ModelCache<PpeLayerModel,PpeLayer> cache)
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
            BodyPart = Model.BodyPart;
            Clothing = Model.Clothing;
        }

        #endregion Creation

        #region Properties

        private StaticItem _bodyPart;
        public StaticItem BodyPart
        {
            get { return _bodyPart; }
            set
            {
                if (value == _bodyPart)
                    return;

                Model.BodyPart = value;
                _bodyPart = Model.BodyPart;
                base.RaisePropertyChanged(PpeLayerModel.BodyPartName);
            }
        }

        private StaticItem _clothing;
        public StaticItem Clothing
        {
            get { return _clothing; }
            set
            {
                if (value == _clothing)
                    return;

                Model.Clothing = value;
                _clothing = Model.Clothing;
                base.RaisePropertyChanged(PpeLayerModel.ClothingName);
            }
        }

        #endregion Properties

        #region Property Names

        public const string BodyPartName = "BodyPart";
        public const string ClothingName = "Clothing";

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

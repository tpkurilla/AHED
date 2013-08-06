using System;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class StaticItemViewModel : SelectableViewModel<StaticItemModel, StaticItem>
    {
        #region Creation

        public StaticItemViewModel(){}

        public StaticItemViewModel(StaticItemModel model, ModelCache<StaticItemModel, StaticItem> cache)
            : base(model, cache)
        {
            base.DisplayName = Properties.Resources.CommentViewModel_Display_Name;
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            GroupId = Model.GroupId;
            ItemId = Model.ItemId;
            Description = Model.Description;
        }

        #endregion Creation

        #region Properties

        private StaticValues.Groups _groupId;
        public StaticValues.Groups GroupId
        {
            get { return _groupId; }
            set
            {
                if (value == _groupId)
                    return;

                Model.GroupId = value;
                _groupId = Model.GroupId;
                base.RaisePropertyChanged(GroupIdName);
            }
        }

        private string _itemId;
        public string ItemId
        {
            get { return _itemId; }
            set
            {
                if (value == _itemId)
                    return;

                Model.ItemId = value;
                _itemId = Model.ItemId;
                base.RaisePropertyChanged(ItemIdName);
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == Description)
                    return;

                Model.Description = value;
                _description = Model.Description;
                base.RaisePropertyChanged(DescriptionName);
            }
        }

        #endregion Properties

        #region Property Names

        public const string GroupIdName = "GroupId";
        public const string ItemIdName = "ItemId";
        public const string DescriptionName = "Description";

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

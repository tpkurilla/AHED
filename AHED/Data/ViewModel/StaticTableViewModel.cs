using System;
using AHED.Data.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class StaticTableViewModel : SimpleViewModel<StaticTableModel, StaticTable>
    {
        #region Valid Options for StaticItems

        private static StaticItem[] _groupOptions;

        #endregion Valid Options for StaticItems

        #region Constructor

        public StaticTableViewModel(StaticTableModel model)
            : base(model)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        private void SetProperties()
        {
            Group = Model.Group;
            if (ItemsVm != null)
                ItemsVm.Dispose();

            ItemsVm = new AllViewModel<StaticItemViewModel, StaticItemModel, StaticItem>(Model.Items);
        }

        #endregion // Constructor

        #region Presentation Properties

        #region StaticItem Choices

        /// <summary>
        /// Returns an array of valid choices for Task selector.
        /// </summary>
        public StaticItem[] GroupOptions
        {
            get
            {
                return _groupOptions
                       ?? (_groupOptions = Model.ValidGroups);
            }
        }

        #endregion StaticItem Choices

        #endregion Presentation Properties

        #region StaticTable Properties

        private StaticItem _group;
        public StaticItem Group
        {
            get { return _group; }
            set
            {
                if (value == _group)
                    return;

                Model.Group = value;
                _group = Model.Group;
                base.RaisePropertyChanged(GroupName);
            }
        }

        public AllViewModel<StaticItemViewModel, StaticItemModel, StaticItem> ItemsVm { get; private set; } 

        #endregion

        #region Property Names

        public const string GroupName = "Group";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            ItemsVm.Dispose();
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

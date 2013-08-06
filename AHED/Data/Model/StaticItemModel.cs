using System;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class StaticItemModel : Model<StaticItem>, IDeepClone<StaticItemModel>
    {
        private readonly StaticTableModel _parentTable;

        #region Properties

        public StaticValues.Groups GroupId
        {
            get { return Value.GroupId; }
            set
            {
                if (value != Value.GroupId)
                {
                    if (ValidateGroupId(value))
                        Value.GroupId = value;
                }
            }
        }

        private string _itemIdText;
        public string ItemId
        {
            get { return _itemIdText; }
            set
            {
                if (value != _itemIdText)
                {
                    int itemId = 0;
                    if (!ValidateItemId(value, ref itemId))
                    {
                        _itemIdText = value;
                    }
                    else
                    {
                        _itemIdText = itemId.ToString(Culture.Info);
                        Value.ItemId = itemId;
                    }
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    if (!ValidateDescription(value))
                    {
                        _description = value;
                    }
                    else
                    {
                        Value.Description = value;
                        _description = Value.Description;
                    }
                }
            }
        }

        #endregion Properties

        #region Creation

        public StaticItemModel() { }

        public StaticItemModel(StaticItem item, StaticTableModel parentTable)
            : base(item)
        {
            if (parentTable == null)
                throw new ArgumentNullException("parentTable");

            _parentTable = parentTable;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public StaticItemModel(StaticItemModel item)
            : base(item)
        {
            _parentTable = item._parentTable;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            // Set all Model properties, and trigger all validations
            GroupId = (StaticValues.Groups) _parentTable.Group.ItemId;
            ItemId = Value.ItemId.ToString(Culture.Info);
            Description = Value.Description;
        }

        #endregion // Creation

        #region Property Names

        // String constants matching Properties that are to be validated

        public const string GroupIdName = "GroupId";
        public const string ItemIdName = "ItemId";
        public const string DescriptionName = "Description";

        #endregion

        #region Validation

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>Description</c>.
        /// </summary>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>Description</c>.</returns>
        private bool ValidateGroupId(StaticValues.Groups value)
        {
            if (!Enum.IsDefined(typeof(StaticValues.Groups), value))
            {
                AddError(GroupIdName, Properties.Resources.StaticItemModel_Invalid_GroupId, false);
                return false;
            }

            RemoveError(GroupIdName, Properties.Resources.StaticItemModel_Invalid_GroupId);
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>FortificationLevel</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any positive value.
        /// </remarks>
        /// <param name="str">The raw string to validate as a fortification level.</param>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>FortificationLevel</c>.</returns>
        private bool ValidateItemId(string str, ref int value)
        {
            if (String.IsNullOrEmpty(str))
            {
                AddError(ItemIdName, Properties.Resources.StaticItemModel_Invalid_ItemId, false);
                return false;
            }

            int itemId;
            if (!Int32.TryParse(str, out itemId))
            {
                AddError(ItemIdName, Properties.Resources.StaticItemModel_Invalid_ItemId, false);
                return false;
            }

            if (_parentTable.Items.GetAll().Any(model => itemId == model.Value.ItemId))
            {
                AddError(ItemIdName, Properties.Resources.StaticItemModel_Invalid_ItemId, false);
                return false;
            }

            RemoveError(ItemIdName, Properties.Resources.StaticItemModel_Invalid_ItemId);
            value = itemId;
            return true;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>ValidateDescription</c>.
        /// </summary>
        /// <remarks>
        /// Currently accepts any positive value.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>ValidateDescription</c>.</returns>
        private bool ValidateDescription(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                AddError(DescriptionName, Properties.Resources.StaticItemModel_Invalid_Description, false);
                return false;
            }

            if (_parentTable.Items.GetAll().Any(item => value == item.Value.Description))
            {
                AddError(DescriptionName, Properties.Resources.StaticItemModel_Invalid_Description, false);
                return false;
            }

            RemoveError(DescriptionName, Properties.Resources.StaticItemModel_Invalid_Description);
            return true;
        }

        #endregion // Validation

        #region IDeepClone Interface

        StaticItemModel IDeepClone<StaticItemModel>.DeepClone()
        {
            return new StaticItemModel(this);
        }

        #endregion IDeepClone Interface

    }
}

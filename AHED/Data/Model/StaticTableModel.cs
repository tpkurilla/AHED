using System;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class StaticTableModel : Model<StaticTable>, IDeepClone<StaticTableModel>
    {
        #region Valid Options for StaticItems

        public StaticItem[] ValidGroups;

        #endregion Valid Options for StaticItems

        #region Properties

        private StaticItem _group;
        public StaticItem Group
        {
            get { return _group; }
            set 
            {
                if (value != _group)
                {
                    if (ValidateGroup(value))
                    {
                        _group = value;

                        // Update the list of valid Dosimeter Descriptions
                        Items.Clear();
                        Items.Add(
                            (from keyValuePair in Value.GetAll().Where(item => (int) item.Value.GroupId == Group.ItemId)
                             select new StaticItemModel(keyValuePair.Value, this)
                            ).ToList());
                    }
                }
            }
        }

        public ModelCache<StaticItemModel,StaticItem> Items { get; private set; }

        public new bool IsValid
        {
            get
            {
                return base.IsValid && Items.IsValid;
            }
        }

        #endregion

        #region Creation

        public StaticTableModel(){}

        public StaticTableModel(StaticTable table)
            : base(table)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public StaticTableModel(StaticTableModel table)
            : base(table)
        {
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            Items = new ModelCache<StaticItemModel, StaticItem>();
            var itemList = (from keyValuePair in Value.GetAll().Where(item => (int)item.Value.GroupId == Group.ItemId)
                            select new StaticItemModel(keyValuePair.Value, this)
                           ).ToList();
            Items.Add(itemList);

            var allGroups = StaticValues.GroupOptions(StaticValues.Groups.Group).Where(item => item.ItemId >= 0).ToList();
            allGroups.Sort((item1, item2) => (item1.ItemId - item2.ItemId));
            ValidGroups = allGroups.ToArray();
        }

        #endregion Creation

        #region Validation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string GroupName = "Group";
        public const string DosimeterDescriptionName = "DosimeterDescription";
        public const string ValidDosimeterDescriptionsName = "ValidDosimeterDescriptions";
        public const string ValidGroupBodyPartsName = "ValidGroupBodyParts";
        public const string InputDosimeterMatrixName = "InputDosimeterMatrix";
        public const string InputResidueName = "InputResidue";
        public const string InputLoqName = "InputLoq";
        public const string InputLodName = "InputLod";

        #endregion

        #region Specific Validations

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>MixingEquipmentLoaded</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from GroupOptions[MixingEquipmentLoaded] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>MixingEquipmentLoaded</c>.</returns>
        private bool ValidateGroup(StaticItem value)
        {
            if (value == null || ValidGroups.Contains(value))
            {
                RemoveError(GroupName, Properties.Resources.StaticTableModel_Invalid_Group);
                return true;
            }

            AddError(GroupName, Properties.Resources.StaticTableModel_Invalid_Group, false);
            return false;
        }

        #endregion

        #endregion

        #region IDeepClone Interface

        StaticTableModel IDeepClone<StaticTableModel>.DeepClone()
        {
            return new StaticTableModel(this);
        }

        #endregion IDeepClone Interface
    }
}

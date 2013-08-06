using System;
using System.Globalization;

namespace AHED.Types
{
    [Serializable]
    public class StaticItem : IDeepClone<StaticItem>, IPropertyInitializer
    {
        public StaticValues.Groups GroupId { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }

        private int _key;

        public int Key
        {
            get
            {
                if (_key == 0)
                    _key = GetKey(GroupId, ItemId);

                return _key;
            }
        }

        public StaticItem(){}

        public StaticItem(StaticItem item)
        {
            GroupId = item.GroupId;
            ItemId = item.ItemId;
            Description = item.Description;
        }

        public bool InitializeProperties()
        {
            GroupId = default(StaticValues.Groups);
            ItemId = default(int);
            Description = String.Empty;

            return true;
        }

        override public string ToString()
        {
            return "\"StaticItem\": {"
                + "\"GroupId\": " + GroupId.ToString() + ", "
                + "\"ItemId\": " + ItemId.ToString(CultureInfo.InvariantCulture) + ", "
                + "\"Description\": \"" + Description + "\"}";
        }

        public static int GetKey(StaticValues.Groups groupId, int itemId)
        {
            int key;
            if (groupId == StaticValues.Groups.Group)
                key = (int)groupId * 1000 - itemId;
            else
                key = (int)groupId * 1000 + itemId;

            return key;
        }

        /// <summary>
        /// Makes a "deep" copy of this <c>StaticItem</c>.  Since
        /// all Static Items are supposed to be Singletons, a
        /// reference to this Static Item is simply returned.
        /// </summary>
        /// <returns>Reference to this Static Item.</returns>
        public StaticItem DeepClone()
        {
            return this;
        }
    }
}

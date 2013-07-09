using System;

namespace AHED.Types
{
    [Serializable]
    public class StaticItem
    {
        public StaticValues.Groups GroupId { get; set; }
        public int ItemId { get; set; }
        public string Desc { get; set; }

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

        override public string ToString()
        {
            return "\"StaticItem\": {"
                + "\"GroupId\": " + GroupId.ToString() + ", "
                + "\"ItemId\": " + ItemId.ToString() + ", "
                + "\"Desc\": \"" + Desc + "\"}";
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AHED.Types
{
    public class StaticTable : IEnumerable<KeyValuePair<int,StaticItem>>
    {
        /// <summary>
        /// The actual key -> <c>StaticItem</c> map used to hold all values for this table.
        /// <br/>
        /// We could keep <c>StaticItems</c> hidden, and implement <c>IEnumerable</c>
        /// to allows for "protected" iteration.  But this adds unnecessary overhead.
        /// So users of <c>StaticTable</c> are encouraged to only modify <c>StaticItems</c>
        /// using the methods and indexers provided by <c>StaticTable</c>.
        /// </summary>
        private Dictionary<int, StaticItem> StaticItems { get; set; }

        /// <summary>
        /// Indexer to allow easy indexing references for this <c>StaticTable</c>.
        /// </summary>
        /// <param name="key">The key to use for finding the associated <c>StaticItem</c></param>
        /// <returns>The <c>StaticItem</c> associated with <c>key</c>.</returns>
        public StaticItem this[int key]
        {
            get { return StaticItems[key]; }
            set { StaticItems[key] = value; }
        }

        public StaticTable()
        {
            StaticItems = new Dictionary<int, StaticItem>();
        }

        public StaticTable(Dictionary<int, StaticItem> newDict)
        {
            StaticItems = new Dictionary<int, StaticItem>(newDict);
        }

        public void Add(StaticItem item)
        {
            StaticItems.Add(item.Key, item);
        }

        public Dictionary<int, StaticItem> GetGroup(StaticValues.Groups groupId)
        {
            //var results = staticItems.Where(kvp => kvp.Value.staticGroup.CompareTo(groupName) == 0)
            //                         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var results = StaticItems.Where(kvp => kvp.Value.GroupId == groupId)
                                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return results;
        }

        public Dictionary<int, string> GetSimpleGroup(StaticValues.Groups groupId)
        {
            //var results = staticItems.Where(kvp => kvp.Value.staticGroup.CompareTo(groupName) == 0)
            //                         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.item);
            var results = StaticItems.Where(kvp => kvp.Value.GroupId == groupId)
                                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Desc);

            return results;
        }

        public StaticItem GetItem(int key)
        {
            return StaticItems[key];
        }

        public List<string> GetGroupNames()
        {
            var groups = StaticItems.Where(kvp => kvp.Value.GroupId == StaticValues.Groups.Group)
                .ToDictionary(kvp => kvp.Key, kvp => ((StaticValues.Groups)kvp.Value.ItemId).ToString());

            var result = groups.Values.Distinct().ToList();

            return result;
        }

        public Dictionary<int, StaticItem> GetAll()
        {
            return new Dictionary<int, StaticItem>(StaticItems);
        }

        public void Clear()
        {
            StaticItems.Clear();
        }

        #region IEnumerator implementation

        public IEnumerator<KeyValuePair<int, StaticItem>> GetEnumerator()
        {
            foreach (KeyValuePair<int, StaticItem> item in StaticItems)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (KeyValuePair<int, StaticItem> item in StaticItems)
            {
                yield return item;
            }
        }

        #endregion IEnumerator
    }
}

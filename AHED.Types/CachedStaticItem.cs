using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    /// <summary>
    /// Adds a <c>LocalDatabase</c> reference to <c>StaticItem</c> so
    /// <c>CachedStaticItem</c>s can be differentiated by database when
    /// required.
    /// </summary>
    [Serializable]
    public class CachedStaticItem
    {
        public string DbName { get; protected set; }
        public StaticItem Item { get; protected set; }

        public CachedStaticItem(string db, StaticItem item)
        {
            DbName = db;
            Item = item;
        }
    }
}

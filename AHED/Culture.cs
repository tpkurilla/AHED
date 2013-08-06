using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED
{
    public static class Culture
    {
        private static CultureInfo _cultureInfo;
        public static CultureInfo Info { get { return _cultureInfo; } }

        static Culture()
        {
            try
            {
                _cultureInfo = new CultureInfo(Properties.Resources.CultureName, false);
            }
            catch (Exception)
            {
                _cultureInfo = CultureInfo.InvariantCulture;
            }
        }
    }
}

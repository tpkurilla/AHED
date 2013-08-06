using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    public interface IPropertyInitializer
    {
        /// <summary>
        /// Insures that all properties are correctly initialized.
        /// </summary>
        /// <returns><c>true</c> if initialization was successful; <c>false</c> otherwise.</returns>
        bool InitializeProperties();
    }
}

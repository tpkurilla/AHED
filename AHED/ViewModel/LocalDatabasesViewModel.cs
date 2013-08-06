using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.ViewModel
{
    public class LocalDatabasesViewModel : WorkspaceViewModel
    {
        private Model.DataSetModel _dataSet;

        public LocalDatabasesViewModel(Model.DataSetModel dataSet)
        {
            _dataSet = dataSet;
        }
    }
}

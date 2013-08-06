using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHED.Model;

namespace AHED.ViewModel
{
    public class AnalyticToolsViewModel : WorkspaceViewModel
    {
        private DataSetModel _dataSet;

        public AnalyticToolsViewModel(DataSetModel dataSet)
        {
            _dataSet = dataSet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHED.Model;
using AHED.ViewModel;

namespace AHED.Reports.ViewModel
{
    public class WorkerInfoReportViewModel : WorkspaceViewModel
    {
        private DataSetModel _dataSet;

        public WorkerInfoReportViewModel(DataSetModel dataSet)
        {
            _dataSet = dataSet;
        }
    }
}

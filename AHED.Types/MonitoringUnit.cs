using System;
using System.Collections.Generic;
using System.Linq;

namespace AHED.Types
{
    [Serializable]
    public class MonitoringUnit : IDeepClone<MonitoringUnit>, IPropertyInitializer
    {
        public WorkerInfo WorkerInfo { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public MixingInfo MixingInfo { get; set; }
        public ApplicationInfo ApplicationInfo { get; set; }
        public List<DosimeterMeasurement> DosimeterMeasurements { get; set; }
        public List<string> Comments { get; set; }

        public MonitoringUnit()
        {
        }

        public MonitoringUnit(MonitoringUnit unit)
        {
            WorkerInfo = new WorkerInfo(unit.WorkerInfo);
            ProductInfo = new ProductInfo(unit.ProductInfo);
            MixingInfo = new MixingInfo(unit.MixingInfo);
            ApplicationInfo = new ApplicationInfo(unit.ApplicationInfo);
            DosimeterMeasurements = (from meas in unit.DosimeterMeasurements
                            select new DosimeterMeasurement(meas)
                           ).ToList();

            Comments = (from comment in unit.Comments
                        select comment
                       ).ToList();
        }

        public bool InitializeProperties()
        {
            WorkerInfo = WorkerInfo.Create();
            ProductInfo = ProductInfo.Create();
            MixingInfo = MixingInfo.Create();
            ApplicationInfo = ApplicationInfo.Create();
            DosimeterMeasurements = new List<DosimeterMeasurement>();
            Comments = new List<string>();

            return true;
        }

        public static MonitoringUnit Create()
        {
            var result = new MonitoringUnit();
            result.InitializeProperties();

            return result;
        }

        public MonitoringUnit DeepClone()
        {
            return new MonitoringUnit(this);
        }
    }
}

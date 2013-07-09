using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AHED.Types
{
    [Serializable]
    public class MonitoringUnit
    {
        public WorkerInfo Worker { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public MixingInfo MixingInfo { get; set; }
        public ApplicationInfo ApplicationInfo { get; set; }
        public List<DosimeterMeasurement> Measurements { get; set; }
        public List<string> Comments { get; set; }

        public MonitoringUnit()
        {
            Worker = new WorkerInfo();
            ProductInfo = new ProductInfo();
            MixingInfo = new MixingInfo();
            ApplicationInfo = new ApplicationInfo();
            Measurements = new List<DosimeterMeasurement>();
            Comments = new List<string>();
        }

        public MonitoringUnit(MonitoringUnit unit)
        {
            Worker = new WorkerInfo(unit.Worker);
            ProductInfo = new ProductInfo(unit.ProductInfo);
            MixingInfo = new MixingInfo(unit.MixingInfo);
            ApplicationInfo = new ApplicationInfo(unit.ApplicationInfo);
            Measurements = DeepClone(unit.Measurements);

            Comments = DeepClone(unit.Comments);
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

    }
}

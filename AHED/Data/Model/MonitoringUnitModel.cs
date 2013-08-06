using System;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    public class MonitoringUnitModel : Model<MonitoringUnit>, IDeepClone<MonitoringUnitModel>
    {
        private readonly ModelCache<MonitoringUnitModel, MonitoringUnit> _muCache;

        private readonly StudyModel _study;

        #region Properties

        public WorkerInfoModel WorkerInfo { get; protected set; }
        public ProductInfoModel ProductInfo { get; protected set; }
        public MixingInfoModel MixingInfo { get; protected set; }
        public ApplicationInfoModel ApplicationInfo { get; protected set; }
        public ModelCache<DosimeterMeasurementModel, DosimeterMeasurement> DosimeterMeasurements { get; protected set; }
        public ModelCache<CommentModel, Comment> Comments { get; protected set; }

        public string Id
        {
            get
            {
                return ((_study == null) ? "?" : _study.StudyNumber)
                       + Properties.Resources.MonitoringUnit_Id_Separator
                       + WorkerInfo.Id;
            }
        }

        #endregion Properties

        #region Creation

        public MonitoringUnitModel(){}

        public MonitoringUnitModel(MonitoringUnit monitoringUnit, ModelCache<MonitoringUnitModel, MonitoringUnit> muCache, StudyModel study)
            : base(monitoringUnit)
        {
            if (muCache == null)
                throw new ArgumentNullException("muCache");

            if (study == null)
                throw new ArgumentNullException("study");

            _study = study;
            _muCache = muCache;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public MonitoringUnitModel(MonitoringUnitModel monitoringUnitModel)
            : base(monitoringUnitModel)
        {
            _study = monitoringUnitModel._study;
            _muCache = monitoringUnitModel._muCache;
            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            WorkerInfo = new WorkerInfoModel(Value.WorkerInfo, _study);
            ProductInfo = new ProductInfoModel(Value.ProductInfo);
            MixingInfo = new MixingInfoModel(Value.MixingInfo);
            ApplicationInfo = new ApplicationInfoModel(Value.ApplicationInfo);

            DosimeterMeasurements = new ModelCache<DosimeterMeasurementModel, DosimeterMeasurement>(
                (from measurement in Value.DosimeterMeasurements
                 select new DosimeterMeasurementModel(measurement)
                ).ToList());

            Comments = new ModelCache<CommentModel, Comment>(
                (from comment in Value.Comments
                 select new CommentModel(new Comment(comment))
                ).ToList());
        }

        #endregion Creation

        #region Property Names

        public const string WorkerInfoName = "WorkerInfo";
        public const string ProductInfoName = "ProductInfo";
        public const string MixingInfoName = "MixingInfo";
        public const string ApplicationInfoName = "ApplicationInfo";
        public const string DosimeterMeasurementsName = "DosimeterMeasurements";
        public const string CommentsName = "Comments";

        #endregion Property Names

        #region IDeepClone Interface

        public MonitoringUnitModel DeepClone()
        {
            return new MonitoringUnitModel(this);
        }

        #endregion IDeepClone Interface
    }
}

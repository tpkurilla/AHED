using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    /// <summary>
    /// A UI-friendly wrapper for a MonitoringUnit.
    /// </summary>
    public class MonitoringUnitViewModel : SelectableViewModel<MonitoringUnitModel, MonitoringUnit>
    {
        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;

        #endregion Fields

        #region Creation

        public MonitoringUnitViewModel(){}

        public MonitoringUnitViewModel(MonitoringUnitModel model,
                                       ModelCache<MonitoringUnitModel,MonitoringUnit> cache)
            : base(model, cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            ResetWorkerInfoVm();
            ResetProductInfoVm();
            ResetMixingInfoVm();
            ResetApplicationInfoVm();
            ResetMeasurementsVm();
            ResetCommentsVm();

            SetProperties();
        }

        void SetProperties()
        {
            // These ViewModels are always shown when this MonitoringUnitViewModel is created
            ShowWorkerInfo();
            ShowProductInfo();
            ShowMixingInfo();
            ShowApplicationInfo();
            ShowDosimeterMeasurements();
            ShowComments();

            Workspaces.SetActiveWorkspace(WorkerInfoVm);
        }

        private void ResetWorkerInfoVm()
        {
            if (WorkerInfoVm == null)
                return;

            Workspaces.ViewModels.Remove(WorkerInfoVm);
            WorkerInfoVm.Dispose();
            WorkerInfoVm = null;
        }

        private void ResetProductInfoVm()
        {
            if (ProductInfoVm == null)
                return;

            Workspaces.ViewModels.Remove(ProductInfoVm);
            ProductInfoVm.Dispose();
            ProductInfoVm = null;
        }

        private void ResetMixingInfoVm()
        {
            if (MixingInfoVm == null)
                return;

            Workspaces.ViewModels.Remove(MixingInfoVm);
            MixingInfoVm.Dispose();
            MixingInfoVm = null;
        }

        private void ResetApplicationInfoVm()
        {
            if (ApplicationInfoVm == null)
                return;

            Workspaces.ViewModels.Remove(ApplicationInfoVm);
            ApplicationInfoVm.Dispose();
            ApplicationInfoVm = null;
        }

        private void ResetMeasurementsVm()
        {
            if (MeasurementsVm == null)
                return;

            Workspaces.ViewModels.Remove(MeasurementsVm);
            MeasurementsVm.Dispose();
            MeasurementsVm = null;
        }

        private void ResetCommentsVm()
        {
            if (CommentsVm == null)
                return;

            Workspaces.ViewModels.Remove(CommentsVm);
            CommentsVm.Dispose();
            CommentsVm = null;
        }

        #endregion Creation

        #region Commands

        /// <summary>
        /// Returns a read-only list of commands 
        /// that the UI can display and execute.
        /// </summary>
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    List<CommandViewModel> cmds = CreateCommands();
                    _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }

                return _commands;
            }
        }

        List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    Properties.Resources.MonitoringUnitViewModel_Command_CreateNewComment,
                    new RelayCommand(param => CreateNewComment())),

                new CommandViewModel(
                    Properties.Resources.MonitoringUnitViewModel_Command_DeleteSelectedComments,
                    new RelayCommand(param => DeleteSelectedComments()))
            };
        }

        private void CreateNewComment()
        {
            var newMuId = new CommentModel(new Comment(String.Empty));
            var workspace = new CommentsViewModel(newMuId, Model.Comments);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedComments()
        {
            var muIdViewModels = CommentsVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in muIdViewModels)
            {
                Model.Comments.DeleteEntry(vm.Model);
            }
        }

        private void ShowWorkerInfo()
        {
            if (WorkerInfoVm == null)
            {
                WorkerInfoVm = new WorkerInfoViewModel(Model.WorkerInfo);
                Workspaces.ViewModels.Add(WorkerInfoVm);
            }

            Workspaces.SetActiveWorkspace(WorkerInfoVm);
        }

        private void ShowProductInfo()
        {
            if (ProductInfoVm == null)
            {
                ProductInfoVm = new ProductInfoViewModel(Model.ProductInfo);
                Workspaces.ViewModels.Add(ProductInfoVm);
            }

            Workspaces.SetActiveWorkspace(ProductInfoVm);
        }

        private void ShowMixingInfo()
        {
            if (MixingInfoVm == null)
            {
                MixingInfoVm = new MixingInfoViewModel(Model.MixingInfo);
                Workspaces.ViewModels.Add(MixingInfoVm);
            }

            Workspaces.SetActiveWorkspace(MixingInfoVm);
        }

        private void ShowApplicationInfo()
        {
            if (ApplicationInfoVm == null)
            {
                ApplicationInfoVm = new ApplicationInfoViewModel(Model.ApplicationInfo);
                Workspaces.ViewModels.Add(ApplicationInfoVm);
            }

            Workspaces.SetActiveWorkspace(ApplicationInfoVm);
        }

        private void ShowDosimeterMeasurements()
        {
            if (MeasurementsVm == null)
            {
                MeasurementsVm = new MonitoringUnitMeasurementsViewModel(Model.DosimeterMeasurements);
                Workspaces.ViewModels.Add(MeasurementsVm);
            }

            Workspaces.SetActiveWorkspace(MeasurementsVm);
        }
        
        private void ShowComments()
        {
            if (CommentsVm == null)
            {
                CommentsVm = new AllViewModel<CommentsViewModel, CommentModel, Comment>(Model.Comments);
                Workspaces.ViewModels.Add(CommentsVm);
            }

            Workspaces.SetActiveWorkspace(CommentsVm);
        }

        #endregion // Commands

        #region Properties

        private WorkspaceCollection _workspaces;
        public WorkspaceCollection Workspaces
        {
            get
            {
                return _workspaces
                       ?? (_workspaces = new WorkspaceCollection());
            }
        }

        public WorkerInfoViewModel WorkerInfoVm { get; private set; }

        public ProductInfoViewModel ProductInfoVm { get; private set; }

        public MixingInfoViewModel MixingInfoVm { get; private set; }

        public ApplicationInfoViewModel ApplicationInfoVm { get; private set; }

        public MonitoringUnitMeasurementsViewModel MeasurementsVm { get; private set; }

        public AllViewModel<CommentsViewModel,CommentModel,Comment> CommentsVm { get; set; }

        public override string DisplayName
        {
            get { return Model.Id; }
        }

        #endregion Properties

        #region Property Names

        public const string WorkerInfoVmName = "WorkerInfoVm";
        public const string ProductInfoVmName = "ProductInfoVm";
        public const string MixingInfoVmName = "MixingInfoVm";
        public const string ApplicationInfoVmName = "ApplicationInfoVm";
        public const string MeasurementsVmName = "MeasurementsVm";
        public const string CommentsVmName = "CommentsVm";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            WorkerInfoVm.Dispose();
            ProductInfoVm.Dispose();
            MixingInfoVm.Dispose();
            ApplicationInfoVm.Dispose();
            MeasurementsVm.Dispose();
            CommentsVm.Dispose();
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

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
    public class StudyViewModel : SelectableViewModel<StudyModel, Study>
    {
        #region Fields

        private ReadOnlyCollection<CommandViewModel> _commands;

        #endregion Fields

        #region Creation

        public StudyViewModel()
        {
        }

        public StudyViewModel(StudyModel model,
                              ModelCache<StudyModel, Study> cache)
            : base(model, cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            ResetMonitoringUnitsVm();
            ResetFieldFortificationsVm();

            SetProperties();
        }

        private void SetProperties()
        {
            StudyNumber = Model.StudyNumber;
            ReviewerId = Model.ReviewerId;
            Metric = Model.Metric;
            QaStatus = Model.QaStatus;

            // These ViewModels are always shown when this StudyViewModel is created
            ShowAllMonitoringUnits();
            ShowAllFieldFortifications();
        }

        private void ResetMonitoringUnitsVm()
        {
            if (MonitoringUnitsVm == null)
                return;

            Workspaces.ViewModels.Remove(MonitoringUnitsVm);
            MonitoringUnitsVm.Dispose();
            MonitoringUnitsVm = null;
        }

        private void ResetFieldFortificationsVm()
        {
            if (FieldFortificationsVm == null)
                return;

            Workspaces.ViewModels.Remove(FieldFortificationsVm);
            FieldFortificationsVm.Dispose();
            FieldFortificationsVm = null;
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

        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
                {
                    new CommandViewModel(
                        Properties.Resources.StudyViewModel_Command_Create_MonitoringUnit,
                        new RelayCommand(param => CreateNewMonitoringUnit())),

                    new CommandViewModel(
                        Properties.Resources.StudyViewModel_Command_Create_FieldFortification,
                        new RelayCommand(param => CreateNewFieldFortification())),

                    new CommandViewModel(
                        Properties.Resources.StudyViewModel_Command_Delete_Selected_MonitoringUnits,
                        new RelayCommand(param => DeleteSelectedMonitoringUnits())),

                    new CommandViewModel(
                        Properties.Resources.StudyViewModel_Command_Delete_Selected_FieldFortifications,
                        new RelayCommand(param => DeleteSelectedFieldFortifications())),

                };
        }

        private void CreateNewMonitoringUnit()
        {
            var newModel = new MonitoringUnitModel(MonitoringUnit.Create(), Model.MonitoringUnits, Model);
            var workspace = new MonitoringUnitViewModel(newModel, Model.MonitoringUnits);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void CreateNewFieldFortification()
        {
            var newModel = new FieldFortificationModel(FieldFortification.Create(), Model.FieldFortifications, Model);
            var workspace = new FieldFortificationViewModel(newModel, Model.FieldFortifications);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedMonitoringUnits()
        {
            var muIdViewModels = MonitoringUnitsVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in muIdViewModels)
            {
                Model.MonitoringUnits.DeleteEntry(vm.Model);
            }
        }

        private void DeleteSelectedFieldFortifications()
        {
            var entriesToDelete = FieldFortificationsVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var entryViewModel in entriesToDelete)
            {
                Model.FieldFortifications.DeleteEntry(entryViewModel.Model);
            }
        }

        private void ShowAllMonitoringUnits()
        {
            if (MonitoringUnitsVm == null)
            {
                MonitoringUnitsVm = new AllViewModel<MonitoringUnitViewModel, MonitoringUnitModel, MonitoringUnit>(Model.MonitoringUnits);
                Workspaces.ViewModels.Add(MonitoringUnitsVm);
            }

            Workspaces.SetActiveWorkspace(MonitoringUnitsVm);
        }

        private void ShowAllFieldFortifications()
        {
            if (FieldFortificationsVm == null)
            {
                FieldFortificationsVm =
                    new AllViewModel<FieldFortificationViewModel, FieldFortificationModel, FieldFortification>(Model.FieldFortifications);
                Workspaces.ViewModels.Add(FieldFortificationsVm);
            }

            Workspaces.SetActiveWorkspace(FieldFortificationsVm);
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

        private string _studyNumber;

        public string StudyNumber
        {
            get { return _studyNumber; }
            set
            {
                if (value == _studyNumber)
                    return;

                Model.StudyNumber = value;
                _studyNumber = Model.StudyNumber;
                base.RaisePropertyChanged(StudyNumberName);
            }
        }

        private string _reviewerId;

        public string ReviewerId
        {
            get { return _reviewerId; }
            set
            {
                if (value == _reviewerId)
                    return;

                Model.ReviewerId = value;
                _reviewerId = Model.ReviewerId;
                base.RaisePropertyChanged(ReviewerIdName);
            }
        }

        public bool Metric
        {
            get { return Model.Metric; }
            set { Model.Metric = value; }
        }

        public StaticValues.QaStatus QaStatus
        {
            get { return Model.QaStatus; }
            set { Model.QaStatus = value; }
        }

        public AllViewModel<MonitoringUnitViewModel, MonitoringUnitModel, MonitoringUnit> MonitoringUnitsVm { get; set; }

        public AllViewModel<FieldFortificationViewModel, FieldFortificationModel, FieldFortification> FieldFortificationsVm { get; set; }

        public bool IsValid
        {
            get { return Model.IsValid; }
        }

        #endregion Properties

        #region Property Names

        public const string StudyNumberName = "StudyNumber";
        public const string ReviewerIdName = "ReviewerId";
        public const string MetricName = "Metric";
        public const string QaStatusName = "QaStatus";
        public const string MonitoringUnitsVmName = "MonitoringUnitsVm";
        public const string FieldFortificationsVmName = "FieldFortificationsVm";

        #endregion Property Names

        #region IDisposable Interface

        public new void Dispose()
        {
            MonitoringUnitsVm.Dispose();
            FieldFortificationsVm.Dispose();
            base.Dispose();
        }

        #endregion IDisposable Interface
    }
}

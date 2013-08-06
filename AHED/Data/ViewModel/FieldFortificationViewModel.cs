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
    /// A UI-friendly wrapper for a Field Fortification.
    /// </summary>
    public class FieldFortificationViewModel : SelectableViewModel<FieldFortificationModel,FieldFortification>
    {
        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;

        #endregion Fields

        #region Creation

        public FieldFortificationViewModel(){}

        public FieldFortificationViewModel(FieldFortificationModel model,
                                           ModelCache<FieldFortificationModel,FieldFortification> cache)
            : base(model, cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            // Insure that all old View Models are properly disposed of
            ResetMonitoringUnitIds();
            ResetEntries();

            SetProperties();
        }

        void SetProperties()
        {
            EventId = Model.EventId;
            DosimeterDescription = Model.DosimeterDescription;

            // These ViewModels are always shown when this FieldFortificationViewModel is created
            ShowAllMonitoringUnitIds();
            ShowAllEntries();
        }

        private void ResetMonitoringUnitIds()
        {
            if (MonitoringUnitIdsVm == null)
                return;

            Workspaces.ViewModels.Remove(MonitoringUnitIdsVm);
            MonitoringUnitIdsVm.Dispose();
            MonitoringUnitIdsVm = null;
        }

        private void ResetEntries()
        {
            if (FieldFortEntriesVm == null)
                return;

            Workspaces.ViewModels.Remove(FieldFortEntriesVm);
            FieldFortEntriesVm.Dispose();
            FieldFortEntriesVm = null;
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
                    Properties.Resources.FieldFortificationViewModel_Command_CreateNewMonitoringUnitId,
                    new RelayCommand(param => CreateNewMonitoringUnitId())),

                new CommandViewModel(
                    Properties.Resources.FieldFortificationViewModel_Command_CreateNewEntry,
                    new RelayCommand(param => CreateNewEntry())),

                new CommandViewModel(
                    Properties.Resources.FieldFortificationViewModel_Command_Delete_Selected_Entries,
                    new RelayCommand(param => DeleteSelectedEntries())),

                new CommandViewModel(
                    Properties.Resources.FieldFortificationViewModel_Command_Delete_Selected_MonitoringUnitIds,
                    new RelayCommand(param => DeleteSelectedMonitoringUnitIds()))
            };
        }

        private void CreateNewEntry()
        {
            FieldFortEntryModel newEntry = FieldFortEntryModel.Create();
            var workspace = new FieldFortEntryViewModel(newEntry, Model.Entries);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void CreateNewMonitoringUnitId()
        {
            MonitoringUnitIdModel newMuId = MonitoringUnitIdModel.Create();
            var workspace = new MonitoringUnitIdViewModel(newMuId, Model.MonitoringUnitIds);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedEntries()
        {
            var entriesToDelete = FieldFortEntriesVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var entryViewModel in entriesToDelete)
            {
                Model.Entries.DeleteEntry(entryViewModel.Model);
            }
        }

        private void DeleteSelectedMonitoringUnitIds()
        {
            var muIdViewModels = MonitoringUnitIdsVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in muIdViewModels)
            {
                Model.MonitoringUnitIds.DeleteEntry(vm.Model);
            }
        }

        private void ShowAllEntries()
        {
            if (FieldFortEntriesVm == null)
            {
                FieldFortEntriesVm = new AllViewModel<FieldFortEntryViewModel, FieldFortEntryModel, FieldFortification.Entry>(Model.Entries);
                Workspaces.ViewModels.Add(FieldFortEntriesVm);
            }

            Workspaces.SetActiveWorkspace(FieldFortEntriesVm);
        }

        private void ShowAllMonitoringUnitIds()
        {
            if (MonitoringUnitIdsVm == null)
            {
                MonitoringUnitIdsVm =
                    new AllViewModel<MonitoringUnitIdViewModel, MonitoringUnitIdModel, FieldFortification.MonitoringUnitId>(Model.MonitoringUnitIds);
                Workspaces.ViewModels.Add(MonitoringUnitIdsVm);
            }

            Workspaces.SetActiveWorkspace(MonitoringUnitIdsVm);
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

        private string _eventId;
        public string EventId
        {
            get { return _eventId; }
            set
            {
                if (value == _eventId)
                    return;

                Model.EventId = value;
                _eventId = Model.EventId;
                base.RaisePropertyChanged(FieldFortificationModel.EventIdName);
            }
        }

        public List<StaticItem> ValidDosimeterDescriptions
        {
            get { return Model.ValidFieldFortDosimeters; }
        }

        private StaticItem _dosimeterDescription;
        public StaticItem DosimeterDescription
        {
            get { return _dosimeterDescription; }
            set
            {
                if (value == _dosimeterDescription)
                    return;

                Model.DosimeterDescription = value;
                _dosimeterDescription = Model.DosimeterDescription;
                base.RaisePropertyChanged(FieldFortificationModel.DosimeterDescriptionName);
            }
        }

        public AllViewModel<FieldFortEntryViewModel, FieldFortEntryModel, FieldFortification.Entry> FieldFortEntriesVm { get; set; }

        public AllViewModel<MonitoringUnitIdViewModel, MonitoringUnitIdModel, FieldFortification.MonitoringUnitId> MonitoringUnitIdsVm { get; set; }

        public bool IsValid { get { return Model.IsValid; } }

        #endregion Properties

        #region Property Names

        public const string EventIdName = "EventId";
        public const string ValidDosimeterDescriptionsName = "ValidDosimeterDescriptions";
        public const string DosimeterDescriptionName = "DosimeterDescription";
        public const string FieldFortEntriesVmName = "FieldFortEntriesVm";
        public const string MonitoringUnitIdsVmName = "MonitoringUnitIdsVm";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            FieldFortEntriesVm.Dispose();
            MonitoringUnitIdsVm.Dispose();
            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

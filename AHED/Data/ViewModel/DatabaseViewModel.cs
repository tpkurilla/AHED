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
    public class DatabaseViewModel : SelectableViewModel<DatabaseModel, Database>
    {
        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;

        #endregion Fields

        #region Creation

        public DatabaseViewModel(){}

        public DatabaseViewModel(DatabaseModel model, ModelCache<DatabaseModel,Database> cache)
            : base(model, cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            // Insure that all old View Models are properly disposed of
            ResetChangeLogEntries();
            ResetAccessEntries();
            ResetStaticTableVm();
            ResetStudies();

            SetProperties();
        }

        void SetProperties()
        {
            Description = Model.Description;
            VersionMajor = Model.VersionMajor;
            VersionMinor = Model.VersionMinor;
            DateCreated = Model.DateCreated;
            DateLastModified = Model.DateLastModified;
            QaStatus = Model.QaStatus;

            // These ViewModels are always shown when this DatabaseViewModel is created
            ShowAllStudies();
        }

        private void ResetChangeLogEntries()
        {
            if (ChangeLogEntriesVm == null)
                return;

            Workspaces.ViewModels.Remove(ChangeLogEntriesVm);
            ChangeLogEntriesVm.Dispose();
            ChangeLogEntriesVm = null;
        }

        private void ResetAccessEntries()
        {
            if (AccessEntriesVm == null)
                return;

            Workspaces.ViewModels.Remove(AccessEntriesVm);
            AccessEntriesVm.Dispose();
            AccessEntriesVm = null;
        }

        private void ResetStaticTableVm()
        {
            if (StaticTableVm == null)
                return;

            Workspaces.ViewModels.Remove(StaticTableVm);
            StaticTableVm.Dispose();
            StaticTableVm = null;
        }

        private void ResetStudies()
        {
            if (StudiesVm == null)
                return;

            Workspaces.ViewModels.Remove(StudiesVm);
            StudiesVm.Dispose();
            StudiesVm = null;
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
                        Properties.Resources.DatabaseViewModel_Command_Show_StaticTable,
                        new RelayCommand(param => ShowStaticTable())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_ShowAllChangeLogEntries,
                        new RelayCommand(param => ShowAllChangeLogEntries())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_ShowAllAccessEntries,
                        new RelayCommand(param => ShowAllAccessEntries())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_CreateNewAccessEntry,
                        new RelayCommand(param => CreateNewAccessEntry())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_Delete_Selected_AccessEntries,
                        new RelayCommand(param => DeleteSelectedAccessEntries())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_ShowAllStudies,
                        new RelayCommand(param => ShowAllStudies())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_CreateNewStudy,
                        new RelayCommand(param => CreateNewStudy())),

                    new CommandViewModel(
                        Properties.Resources.DatabaseViewModel_Command_Delete_Selected_Studies,
                        new RelayCommand(param => DeleteSelectedStudies())),

                };
        }

        private void ShowStaticTable()
        {
            if (StaticTableVm == null)
            {
                StaticTableVm = new StaticTableViewModel(Model.StaticTable);
                Workspaces.ViewModels.Add(StaticTableVm);
            }

            Workspaces.SetActiveWorkspace(StaticTableVm);
        }

        private void ShowAllChangeLogEntries()
        {
            if (ChangeLogEntriesVm == null)
            {
                ChangeLogEntriesVm = new AllViewModel<ChangeLogEntryViewModel, ChangeLogEntryModel, ChangeLogEntry>(Model.Changes);
                Workspaces.ViewModels.Add(ChangeLogEntriesVm);
            }

            Workspaces.SetActiveWorkspace(ChangeLogEntriesVm);
        }

        private void ShowAllAccessEntries()
        {
            if (AccessEntriesVm == null)
            {
                AccessEntriesVm = new AllViewModel<AccessEntryViewModel, AccessEntryModel, AccessEntry>(Model.AccessEntries);
                Workspaces.ViewModels.Add(AccessEntriesVm);
            }

            Workspaces.SetActiveWorkspace(AccessEntriesVm);
        }

        private void CreateNewAccessEntry()
        {
            var newAccessEntry = new AccessEntry();
            newAccessEntry.InitializeProperties();
            var newModel = new AccessEntryModel(newAccessEntry, Model.AccessEntries);
            var workspace = new AccessEntryViewModel(newModel, Model.AccessEntries);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedAccessEntries()
        {
            var entriesToDelete = AccessEntriesVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var entryViewModel in entriesToDelete)
            {
                Model.AccessEntries.DeleteEntry(entryViewModel.Model);
            }
        }

        private void ShowAllStudies()
        {
            if (StudiesVm == null)
            {
                StudiesVm = new AllViewModel<StudyViewModel, StudyModel, Study>(Model.Studies);
                Workspaces.ViewModels.Add(StudiesVm);
            }

            Workspaces.SetActiveWorkspace(StudiesVm);
        }

        private void CreateNewStudy()
        {
            var newStudy = new Study();
            newStudy.InitializeProperties();
            var newModel = new StudyModel(newStudy);
            var workspace = new StudyViewModel(newModel, Model.Studies);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedStudies()
        {
            var studyViewModels = StudiesVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in studyViewModels)
            {
                Model.Studies.DeleteEntry(vm.Model);
            }
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;

                Model.Description = value;
                _description = Model.Description;
                base.RaisePropertyChanged(DescriptionName);
            }
        }

        private string _versionMajor;
        public string VersionMajor
        {
            get { return _versionMajor; }
            set
            {
                if (value == _versionMajor)
                    return;

                Model.VersionMajor = value;
                _versionMajor = Model.VersionMajor;
                base.RaisePropertyChanged(VersionMajorName);
            }
        }

        private string _versionMinor;
        public string VersionMinor
        {
            get { return _versionMinor; }
            set
            {
                if (value == _versionMinor)
                    return;

                Model.VersionMinor = value;
                _versionMinor = Model.VersionMinor;
                base.RaisePropertyChanged(VersionMinorName);
            }
        }

        private string _dateCreated;
        public string DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (value == _dateCreated)
                    return;

                Model.DateCreated = value;
                _dateCreated = Model.DateCreated;
                base.RaisePropertyChanged(DateCreatedName);
            }
        }

        private string _dateLastModified;
        public string DateLastModified
        {
            get { return _dateLastModified; }
            set
            {
                if (value == _dateLastModified)
                    return;

                Model.DateLastModified = value;
                _dateLastModified = Model.DateLastModified;
                base.RaisePropertyChanged(DateLastModifiedName);
            }
        }

        private StaticValues.QaStatus _qaQaStatus;
        public StaticValues.QaStatus QaStatus
        {
            get { return _qaQaStatus; }
            set
            {
                if (value == _qaQaStatus)
                    return;

                Model.QaStatus = value;
                _qaQaStatus = Model.QaStatus;
                base.RaisePropertyChanged(QaStatusName);
            }
        }

        public AllViewModel<ChangeLogEntryViewModel, ChangeLogEntryModel, ChangeLogEntry> ChangeLogEntriesVm { get; private set; }

        public AllViewModel<AccessEntryViewModel, AccessEntryModel, AccessEntry> AccessEntriesVm { get; private set; }

        public StaticTableViewModel StaticTableVm { get; private set; }

        public AllViewModel<StudyViewModel, StudyModel, Study> StudiesVm { get; set; }

        public bool IsValid { get { return Model.IsValid; } }

        public override string DisplayName
        {
            get { return Model.Description; }
        }

        #endregion Properties

        #region Property Names

        public const string DescriptionName = "Description";
        public const string VersionMajorName = "VersionMajor";
        public const string VersionMinorName = "VersionMinor";
        public const string DateCreatedName = "DateCreated";
        public const string DateLastModifiedName = "DateLastModified";
        public const string QaStatusName = "QaStatus";
        public const string ChangeLogEntrieVmName = "ChangeLogEntriesVm";
        public const string AccessEntriesVmName = "AccessEntriesVm";
        public const string StaticTableVmName = "StaticTableVm";
        public const string StudiesVmName = "StudiesVm";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            ChangeLogEntriesVm.Dispose();
            AccessEntriesVm.Dispose();
            StaticTableVm.Dispose();
            StudiesVm.Dispose();

            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members
    }
}

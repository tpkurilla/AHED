using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using AHED.Model;
using AHED.Properties;

namespace AHED.ViewModel
{
    public class AhedViewModel : WorkspaceViewModel
    {
        #region Fields
                
        ReadOnlyCollection<CommandViewModel> _commands;

        readonly DataSetModel _dataSet;

        #endregion // Fields

        #region Properties

        WorkspaceCollection _workspaces;
        public WorkspaceCollection Workspaces
        {
            get
            {
                return _workspaces
                       ?? (_workspaces = new WorkspaceCollection());
            }
        }

        public List<string> DatabasesLoaded { get { return _dataSet.DatabasesLoaded; } }
 
        #endregion Properties

        #region Constructor

        public AhedViewModel()
        {
            base.DisplayName = Resources.AhedViewModel_DisplayName;

            // If the default folder is not yet set, set it now
            // Currently, My Documents\AHED Data is the default.
            if (String.IsNullOrEmpty(Settings.Default.AhedDataFolderPath))
            {
                Settings.Default.AhedDataFolderPath =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                 Settings.Default.AhedDataFolderName);
                Settings.Default.Save();
            }

            _dataSet = new DataSetModel();

            // Create all of the workspaces in the collection
            Workspaces.ViewModels.Add(new AnalyticToolsViewModel(_dataSet));
            Workspaces.ViewModels.Add(new LocalDatabasesViewModel(_dataSet));
            Workspaces.ViewModels.Add(new ServerDatabasesViewModel(_dataSet));
            Workspaces.ViewModels.Add(new DataReportsViewModel(_dataSet));
            ShowAnalyticTools();
        }

        #endregion // Constructor

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
                    Resources.AhedViewModel_Command_AnalyticTools,
                    new RelayCommand(param => ShowAnalyticTools())),

                new CommandViewModel(
                    Resources.AhedViewModel_Command_LocalDatabases,
                    new RelayCommand(param => ShowLocalDatabases())),

                new CommandViewModel(
                    Resources.AhedViewModel_Command_ServerDatabases,
                    new RelayCommand(param => ShowServerDatabases())),
 
                new CommandViewModel(
                    Resources.AhedViewModel_Command_DataReports,
                    new RelayCommand(param => ShowDataReports())),
           };
        }

        #endregion // Commands

        #region Private Helpers

        private void ShowAnalyticTools()
        {
            var workspace =
                Workspaces.ViewModels.FirstOrDefault(vm => vm is AnalyticToolsViewModel) as AnalyticToolsViewModel;
            if (workspace == null)
            {
                workspace = new AnalyticToolsViewModel(_dataSet);
                Workspaces.ViewModels.Add(workspace);
            }

            Workspaces.SetActiveWorkspace(workspace);
        }

        private void ShowLocalDatabases()
        {
            var workspace =
                Workspaces.ViewModels.FirstOrDefault(vm => vm is LocalDatabasesViewModel) as LocalDatabasesViewModel;
            if (workspace == null)
            {
                workspace = new LocalDatabasesViewModel(_dataSet);
                Workspaces.ViewModels.Add(workspace);
            }

            Workspaces.SetActiveWorkspace(workspace);
        }

        private void ShowServerDatabases()
        {
            var workspace =
                Workspaces.ViewModels.FirstOrDefault(vm => vm is ServerDatabasesViewModel) as ServerDatabasesViewModel;
            if (workspace == null)
            {
                workspace = new ServerDatabasesViewModel(_dataSet);
                Workspaces.ViewModels.Add(workspace);
            }

            Workspaces.SetActiveWorkspace(workspace);
        }

        private void ShowDataReports()
        {
            var workspace =
                Workspaces.ViewModels.FirstOrDefault(vm => vm is DataReportsViewModel) as DataReportsViewModel;
            if (workspace == null)
            {
                workspace = new DataReportsViewModel(_dataSet);
                Workspaces.ViewModels.Add(workspace);
            }

            Workspaces.SetActiveWorkspace(workspace);
        }

        #endregion // Private Helpers
    }
}

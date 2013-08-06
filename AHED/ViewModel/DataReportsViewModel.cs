using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using AHED.Model;
using AHED.Properties;
using AHED.Reports.ViewModel;

namespace AHED.ViewModel
{
    /// <summary>
    /// Exposes each of the tables in the working DataSetModel.  e.g.,
    /// <c>WorderInfo</c>, <c>ProductInfo</c>, etc.
    /// </summary>
    public class DataReportsViewModel : WorkspaceViewModel
    {
        private readonly DataSetModel _dataSet;

        public DataReportsViewModel(DataSetModel dataSet)
        {
            _dataSet = dataSet;
        }

        #region Commands

        ReadOnlyCollection<CommandViewModel> _commands;

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
                    Resources.DataViewModel_Command_WorkerInfo,
                    new RelayCommand(param => ShowWorkerInfo())),

                new CommandViewModel(
                    Resources.DataViewModel_Command_ProductInfo,
                    new RelayCommand(param => ShowProductInfo())),
                new CommandViewModel(
                    Resources.DataViewModel_Command_WorkerInfo,
                    new RelayCommand(param => ShowMixingInfo())),

                new CommandViewModel(
                    Resources.DataViewModel_Command_WorkerInfo,
                    new RelayCommand(param => ShowApplicationInfo())),

                new CommandViewModel(
                    Resources.DataViewModel_Command_WorkerInfo,
                    new RelayCommand(param => ShowMeasurements())),

                new CommandViewModel(
                    Resources.DataViewModel_Command_WorkerInfo,
                    new RelayCommand(param => ShowFieldFortifications())),

            };
        }

        private void ShowWorkerInfo()
        {
            var workspace = Workspaces.FirstOrDefault(vm => vm is WorkerInfoReportViewModel) as WorkerInfoReportViewModel;
            if (workspace == null)
            {
                workspace = new WorkerInfoReportViewModel(_dataSet);
                Workspaces.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void ShowProductInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowMixingInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowApplicationInfo()
        {
            throw new NotImplementedException();
        }

        private void ShowMeasurements()
        {
            throw new NotImplementedException();
        }

        private void ShowFieldFortifications()
        {
            throw new NotImplementedException();
        }

        #endregion // Commands

        #endregion Commands

        #region Workspaces

        ObservableCollection<WorkspaceViewModel> _workspaces;

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            var workspace = sender as WorkspaceViewModel;
            if (workspace != null)
            {
                workspace.Dispose();
                Workspaces.Remove(workspace);
            }
        }

        void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion // Workspaces

    }
}

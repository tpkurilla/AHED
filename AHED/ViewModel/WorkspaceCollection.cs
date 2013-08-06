using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;

namespace AHED.ViewModel
{
    public class WorkspaceCollection
    {
        ObservableCollection<WorkspaceViewModel> _viewModels;

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<WorkspaceViewModel>();
                    _viewModels.CollectionChanged += OnViewModelsChanged;
                }
                return _viewModels;
            }
        }

        void OnViewModelsChanged(object sender, NotifyCollectionChangedEventArgs e)
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
                ViewModels.Remove(workspace);
            }
        }

        public void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(ViewModels.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(ViewModels);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

    }
}

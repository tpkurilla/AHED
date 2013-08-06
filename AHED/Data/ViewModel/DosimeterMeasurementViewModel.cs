using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    /// <summary>
    /// A UI-friendly wrapper for a Field Fortification.
    /// </summary>
    public class DosimeterMeasurementViewModel : SelectableViewModel<DosimeterMeasurementModel, DosimeterMeasurement>
    {
        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;

        #endregion Fields

        #region Creation

        public DosimeterMeasurementViewModel(){}

        public DosimeterMeasurementViewModel(DosimeterMeasurementModel model,
                                             ModelCache<DosimeterMeasurementModel, DosimeterMeasurement> cache)
            : base(model, cache)
        {
            ModelReset += OnModelReset;
            SetProperties();
        }

        private void OnModelReset(object sender, EventArgs e)
        {
            // Insure all View Models are properly disposed off
            ResetMeasurement();
            ResetPpeLayers();
            ResetOutMeasurements();

            SetProperties();
        }

        void SetProperties()
        {
            DosimeterDescription = Model.DosimeterDescription;
            
            // These ViewModels are always shown when this DosimeterMeasurementViewModel is created
            ShowMeasurement();
            ShowAllPpeLayers();
            ShowAllOuterMeasurements();
        }

        private void ResetMeasurement()
        {
            if (MeasurementVm == null)
                return;

            Workspaces.ViewModels.Remove(MeasurementVm);
            MeasurementVm.Dispose();
            MeasurementVm = null;
        }

        private void ResetPpeLayers()
        {
            if (PpeLayersVm == null)
                return;

            Workspaces.ViewModels.Remove(PpeLayersVm);
            PpeLayersVm.Dispose();
            PpeLayersVm = null;
        }

        private void ResetOutMeasurements()
        {
            if (OuterMeasurementsVm == null)
                return;

            Workspaces.ViewModels.Remove(OuterMeasurementsVm);
            OuterMeasurementsVm.Dispose();
            OuterMeasurementsVm = null;
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
                    Properties.Resources.DosimeterMeasurementViewModel_Command_CreateNewOuterMeasurement,
                    new RelayCommand(param => CreateNewOuterMeasurement())),

                new CommandViewModel(
                    Properties.Resources.DosimeterMeasurementViewModel_Command_CreateNewPpeLayer,
                    new RelayCommand(param => CreateNewPpeLayer())),

                new CommandViewModel(
                    Properties.Resources.DosimeterMeasurementViewModel_Command_Delete_Selected_PpeLayers,
                    new RelayCommand(param => DeleteSelectedPpeLayers())),

                new CommandViewModel(
                    Properties.Resources.DosimeterMeasurementViewModel_Command_Delete_Selected_OuterMeasurements,
                    new RelayCommand(param => DeleteSelectedOuterMeasurements()))
            };
        }

        private void CreateNewPpeLayer()
        {
            var newModel = new PpeLayerModel(PpeLayer.Create(), Model);
            var workspace = new PpeLayerViewModel(newModel, Model.PpeLayers);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void CreateNewOuterMeasurement()
        {
            var newMuId = new OuterMeasurementModel(OuterMeasurement.Create(Model.Measurement.HasSize), Model);
            var workspace = new OuterMeasurementViewModel(newMuId, Model.OuterMeasurements);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedPpeLayers()
        {
            var ppeLayersToDelete = PpeLayersVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in ppeLayersToDelete)
            {
                Model.PpeLayers.DeleteEntry(vm.Model);
            }
        }

        private void DeleteSelectedOuterMeasurements()
        {
            var outerMeasurementViewModels = OuterMeasurementsVm.Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in outerMeasurementViewModels)
            {
                Model.OuterMeasurements.DeleteEntry(vm.Model);
            }
        }

        private void ShowMeasurement()
        {
            if (MeasurementVm == null)
            {
                MeasurementVm = new MeasurementViewModel(Model.Measurement);
                Workspaces.ViewModels.Add(MeasurementVm);
            }

            Workspaces.SetActiveWorkspace(MeasurementVm);
        }

        private void ShowAllPpeLayers()
        {
            if (PpeLayersVm == null)
            {
                PpeLayersVm = new AllViewModel<PpeLayerViewModel, PpeLayerModel, PpeLayer>(Model.PpeLayers);
                Workspaces.ViewModels.Add(PpeLayersVm);
            }

            Workspaces.SetActiveWorkspace(PpeLayersVm);
        }

        private void ShowAllOuterMeasurements()
        {
            if (OuterMeasurementsVm == null)
            {
                OuterMeasurementsVm = new AllViewModel<OuterMeasurementViewModel, OuterMeasurementModel, OuterMeasurement>(Model.OuterMeasurements);
                Workspaces.ViewModels.Add(OuterMeasurementsVm);
            }

            Workspaces.SetActiveWorkspace(OuterMeasurementsVm);
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

        public StaticItem Group { get { return Model.Group; } }

        public List<StaticItem> ValidDosimeterDescriptions
        {
            get { return Model.ValidDosimeterDescriptions; }
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
                base.RaisePropertyChanged(DosimeterDescriptionName);
            }
        }

        public List<StaticItem> ValidDosimeterMatrices
        {
            get { return Model.ValidDosimeterMatrices; }
        }

        public MeasurementViewModel MeasurementVm { get; private set; }

        private AllViewModel<PpeLayerViewModel,PpeLayerModel,PpeLayer> PpeLayersVm { get; set; }

        private AllViewModel<OuterMeasurementViewModel,OuterMeasurementModel,OuterMeasurement> OuterMeasurementsVm { get; set; }

        public bool IsValid { get { return Model.IsValid; } }

        #endregion Properties

        #region Property Names

        public const string GroupName = "Group";
        public const string ValidDosimeterDescriptionsName = "ValidDosimeterDescriptions";
        public const string DosimeterDescriptionName = "DosimeterDescription";
        public const string ValidDosimeterMatricesName = "ValidDosimeterMatrices";
        public const string MeasurementViewModelName = "MeasurementVm";
        public const string PpeLayersVmName = "PpeLayersVm";
        public const string OuterMeasurementsVmName = "OuterMeasurementsVm";

        #endregion Property Names

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public new void Dispose()
        {
            MeasurementVm.Dispose();
            PpeLayersVm.Dispose();
            OuterMeasurementsVm.Dispose();

            ModelReset -= OnModelReset;
            base.Dispose();
        }

        #endregion // IDisposable Members

    }
}

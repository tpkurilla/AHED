using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using AHED.Data.Model;
using AHED.Model;
using AHED.Types;
using AHED.ViewModel;

namespace AHED.Data.ViewModel
{
    public class MonitoringUnitMeasurementsViewModel : AllViewModel<DosimeterMeasurementViewModel,DosimeterMeasurementModel, DosimeterMeasurement>
    {
        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;

        #endregion Fields

        #region Creation

        public MonitoringUnitMeasurementsViewModel(ModelCache<DosimeterMeasurementModel,DosimeterMeasurement> cache)
            : base(cache)
        {
            SetProperties();
        }

        void SetProperties()
        {
            DosimeterGroup = StaticValues.DosimeterGroups.WholeBodyDosimeter1Piece;
        }

        #endregion Creation

        #region Commands

        /// <summary>
        /// Returns a read-only list of commands that the UI can display and execute.
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
                    Properties.Resources.MonitoringUnitMeasurementViewModel_Command_CreateNewMeasurement,
                    new RelayCommand(param => CreateNewMeasurement())),

                new CommandViewModel(
                    Properties.Resources.MonitoringUnitMeasurementViewModel_Command_DeleteMeasurements,
                    new RelayCommand(param => DeleteSelectedMeasurements()))
            };
        }

        private void CreateNewMeasurement()
        {
            if (DosimeterGroup == StaticValues.DosimeterGroups.NotSet)
                throw new InvalidDataException("DosimeterGroup must be selected before creation can occur.\n"
                                               + "Command should be disabled until a selection has been made.");

            var newMuId = DosimeterMeasurementModel.Create(DosimeterGroup);
            var workspace = new DosimeterMeasurementViewModel(newMuId, Cache);
            Workspaces.ViewModels.Add(workspace);
            Workspaces.SetActiveWorkspace(workspace);
        }

        private void DeleteSelectedMeasurements()
        {
            var selectedMeasurements = Entries.Where(vm => vm.IsSelected).ToList();
            foreach (var vm in selectedMeasurements)
            {
                Cache.DeleteEntry(vm.Model);
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

        private StaticValues.DosimeterGroups[] _validDosimeterGroups;
        public StaticValues.DosimeterGroups[] ValidDosimeterGroups
        {
            get
            {
                return _validDosimeterGroups
                       ?? (_validDosimeterGroups = new []
                           {
                               StaticValues.DosimeterGroups.WholeBodyDosimeter1Piece,
                               StaticValues.DosimeterGroups.WholeBodyDosimeter2Piece,
                               StaticValues.DosimeterGroups.WholeBodyDosimeter3Piece,
                               StaticValues.DosimeterGroups.WholeBodyDosimeter4Piece2Legs,
                               StaticValues.DosimeterGroups.WholeBodyDosimeter4Piece2Torso,
                               StaticValues.DosimeterGroups.WholeBodyDosimeter6Piece,
                               StaticValues.DosimeterGroups.Head,
                               StaticValues.DosimeterGroups.Hands,
                               StaticValues.DosimeterGroups.Feet,
                               StaticValues.DosimeterGroups.Inhalation
                           });
            }
        }

        public StaticValues.DosimeterGroups DosimeterGroup { get; set; }

        #endregion Properties

        #region Property Names

        public const string DosimeterGroupName = "DosimeterGroup";

        #endregion Property Names

    }
}

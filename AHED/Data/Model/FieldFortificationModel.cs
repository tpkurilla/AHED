using System;
using System.Collections.Generic;
using System.Linq;
using AHED.Model;
using AHED.Types;

namespace AHED.Data.Model
{
    /// <summary>
    /// Wraps <c>FieldFortification</c> for editable viewing such as in DataEntry.
    /// <br/>
    /// NOTE: Changes to Units enumerated values are assumed correct.  All other
    /// error checking *should* be in place.
    /// </summary>
    public class FieldFortificationModel : Model<FieldFortification>, IDeepClone<FieldFortificationModel>
    {
        private readonly StudyModel _parentStudy;
        private readonly ModelCache<FieldFortificationModel,FieldFortification> _ffCache;

        #region Valid Options for StaticItems

        public readonly List<StaticItem> ValidFieldFortDosimeters =
            (from item in StaticValues.DosimeterGroupDescriptions[StaticValues.DosimeterGroups.FieldFortification]
             select item.Item
            ).ToList();

        #endregion Valid Options for StaticItems

        #region Properties

        public string EventId
        {
            get { return Value.EventId; }
            set
            {
                if (value != Value.EventId)
                {
                    if (ValidateEventId(value))
                        Value.EventId = value;
                }
            }
        }

        public StaticItem DosimeterDescription
        {
            get { return Value.DosimeterDescription; }
            set
            {
                if (value != Value.DosimeterDescription)
                {
                    if (ValidateDosimeterDescription(value))
                        Value.DosimeterDescription = value;
                }
            }
        }

        public ModelCache<MonitoringUnitIdModel,FieldFortification.MonitoringUnitId> MonitoringUnitIds { get; private set; }

        public ModelCache<FieldFortEntryModel,FieldFortification.Entry> Entries { get; private set; }

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public new bool IsValid
        {
            get
            {
                // If the properties here are not valid, no need to go further
                if (!base.IsValid)
                    return false;

                return MonitoringUnitIds.IsValid && Entries.IsValid;
            }
        }

        #endregion

        #region Creation

        public FieldFortificationModel() { }

        public FieldFortificationModel(FieldFortification fieldFortification,
            ModelCache<FieldFortificationModel,FieldFortification> ffCache, StudyModel parentStudy)
            : base(fieldFortification)
        {
            if (ffCache == null)
                throw new ArgumentNullException("ffCache");

            if (parentStudy == null)
                throw new ArgumentNullException("parentStudy");

            _parentStudy = parentStudy;
            _ffCache = ffCache;

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        public FieldFortificationModel(FieldFortificationModel fieldFortificationModel)
            : base(fieldFortificationModel)
        {
            _parentStudy = fieldFortificationModel._parentStudy;
            _ffCache = fieldFortificationModel._ffCache;

            ValueReset += OnModelValueReset;
            SetProperties();
        }

        private void OnModelValueReset(object sender, EventArgs e)
        {
            SetProperties();
        }

        public void SetProperties()
        {
            EventId = Value.EventId;
            DosimeterDescription = Value.DosimeterDescription;

            MonitoringUnitIds = new ModelCache<MonitoringUnitIdModel,FieldFortification.MonitoringUnitId>(
                (from muId in Value.MonitoringUnitIds
                 select new MonitoringUnitIdModel(muId)
                ).ToList());

            Entries = new ModelCache<FieldFortEntryModel,FieldFortification.Entry>(
                (from entry in Value.Entries
                 select new FieldFortEntryModel(entry)
                ).ToList());
        }

        #endregion Creation

        #region Property Names

        // String constants matching Properties that are to be validated
        public const string EventIdName = "EventId";
        public const string DosimeterDescriptionName = "DosimeterDescription";
        public const string MonitoringUnitIdsName = "MonitoringUnitIds";
        public const string EntriesName = "Entries";

        #endregion

        #region Validation

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>BodyPart</c>.
        /// </summary>
        /// <remarks>
        /// This is a required field, and must be unique.  Uniqueness is tested elsewhere.
        /// </remarks>
        /// <param name="value">Value to validate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>BodyPart</c>.</returns>
        private bool ValidateEventId(string value)
        {
            if (!IsStringMissing(value))
            {
                RemoveError(EventIdName, Properties.Resources.FieldFortification_Event_Id);
                return true;
            }

            AddError(EventIdName, Properties.Resources.FieldFortification_Event_Id, false);
            return false;
        }

        /// <summary>
        /// Check whether <c>value</c> is a valid <c>DosimeterDescription</c>.
        /// </summary>
        /// <remarks>
        /// Valid values are set at object creation from StaticValues.DosimeterGroupDescriptions[FieldFortification] table.
        /// </remarks>
        /// <param name="value">Value to validiate.</param>
        /// <returns>Whether <c>value</c> is a valid <c>DosimeterDescription</c>.</returns>
        private bool ValidateDosimeterDescription(StaticItem value)
        {
            bool isValid = true;
            if (ValidFieldFortDosimeters.Contains(value))
            {
                RemoveError(DosimeterDescriptionName, Properties.Resources.FieldFortification_Dosimeter_Description);
            }
            else
            {
                AddError(DosimeterDescriptionName, Properties.Resources.FieldFortification_Dosimeter_Description, false);
                isValid = false;
            }

            return isValid;
        }

        #endregion Validation

        #region Public Methods

        public override void Cancel()
        {
            // We can't just SetProperties because the two ModelCaches likely
            // already have suscribers.  So we'll delete the cache entries, and
            // repopulate.
            Value = new FieldFortification(OriginalValue);

            EventId = Value.EventId;
            DosimeterDescription = Value.DosimeterDescription;

            MonitoringUnitIds.Clear();
            MonitoringUnitIds.Add((from muId in Value.MonitoringUnitIds
                                   select new MonitoringUnitIdModel(muId)
                                  ).ToList());

            Entries.Clear();
            Entries.Add((from entry in Value.Entries
                         select new FieldFortEntryModel(entry)
                        ).ToList());

            Value.EventId = OriginalValue.EventId;
            Value.DosimeterDescription = OriginalValue.DosimeterDescription;
            foreach (var muId in MonitoringUnitIds.GetAll())
            {
                muId.Cancel();
            }
            {
                
            }
        }

        public void Update()
        {
            if (!IsValid)
                throw new InvalidOperationException(Properties.Resources.WorkerInfo_Exception_Cannot_Update);

            OriginalValue = new FieldFortification(Value);
        }

        #endregion Public Methods

        #region IDeepClone Interface

        FieldFortificationModel IDeepClone<FieldFortificationModel>.DeepClone()
        {
            return new FieldFortificationModel(this);
        }

        #endregion IDeepClone Interface
    }
}

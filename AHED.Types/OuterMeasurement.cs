using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    [Serializable]
    public class OuterMeasurement : IDeepClone<OuterMeasurement>, IPropertyInitializer
    {
        /// <summary>
        /// Must be a <c>StaticValues.PpeBodyParts</c> enumeration/entry.
        /// </summary>
        public StaticItem BodyPart { get; set; }

        public StaticItem Clothing { get; set; }

        public Measurement Measurement { get; set; }

        public OuterMeasurement(){}

        /// <summary>
        /// Makes a deep copy of <c>outerMeasurement</c>.
        /// </summary>
        /// <param name="outerMeasurement">OuterMeasurement to copy.</param>
        public OuterMeasurement(OuterMeasurement outerMeasurement)
        {
            BodyPart = outerMeasurement.BodyPart;
            Clothing = outerMeasurement.Clothing;
            Measurement = new Measurement(outerMeasurement.Measurement);
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            BodyPart = _template.BodyPart;
            Clothing = _template.Clothing;
            Measurement = new Measurement(_template.Measurement);

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new OuterMeasurement()
            {
                BodyPart = StaticValues.Item(StaticValues.Groups.BodyParts, (int)StaticValues.BodyParts.NotSet),
                Clothing = StaticValues.Item(StaticValues.Groups.OuterDosimeterClothing, (int)StaticValues.Clothing.NotSet),
                Measurement = Measurement.Create()
            };
        }

        private static OuterMeasurement _template;

        public static OuterMeasurement Create(bool hasSize)
        {
            if (_template == null)
                CreateTemplate();

            var result = new OuterMeasurement(_template);
            result.Measurement.HasSize = hasSize;

            return result;
        }

        #region IDeepClone Interface

        public OuterMeasurement DeepClone()
        {
            return new OuterMeasurement(this);
        }

        #endregion IDeepClone Interface
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHED.Types
{
    [Serializable]
    public class PpeLayer : IDeepClone<PpeLayer>, IPropertyInitializer
    {
        /// <summary>
        /// Must be a <c>StaticValues.PpeBodyParts</c> enumeration/entry.
        /// </summary>
        public StaticItem BodyPart { get; set; }

        public StaticItem Clothing { get; set; }

        public PpeLayer(){}

        /// <summary>
        /// Makes a deep copy of <c>ppeLayer</c>.
        /// </summary>
        /// <param name="ppeLayer">PpeLayer to copy.</param>
        public PpeLayer(PpeLayer ppeLayer)
        {
            BodyPart = ppeLayer.BodyPart;
            Clothing = ppeLayer.Clothing;
        }

        public bool InitializeProperties()
        {
            if (_template == null)
                CreateTemplate();

            BodyPart = _template.BodyPart;
            Clothing = _template.Clothing;

            return true;
        }

        private static void CreateTemplate()
        {
            _template = new PpeLayer()
            {
                BodyPart = StaticValues.Item(StaticValues.Groups.BodyParts, (int)StaticValues.BodyParts.NotSet),
                Clothing = StaticValues.Item(StaticValues.Groups.OuterDosimeterClothing, (int)StaticValues.Clothing.NotSet)
            };
        }

        private static PpeLayer _template;

        public static PpeLayer Create()
        {
            if (_template == null)
                CreateTemplate();

            return new PpeLayer(_template);
        }

        #region IDeepClone Interface

        public PpeLayer DeepClone()
        {
            return new PpeLayer(this);
        }

        #endregion IDeepClone Interface
    }
}

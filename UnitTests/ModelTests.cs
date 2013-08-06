using Microsoft.VisualStudio.TestTools.UnitTesting;
using AHED.Data.Model;
using AHED.Types;

namespace UnitTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void TestSetProperties()
        {
            StaticValues.InitializeDefaults();
            var fieldFortEntry = new FieldFortification.Entry();
            fieldFortEntry.InitializeProperties();
            fieldFortEntry.Description = "Event name";
            var model = new FieldFortEntryModel(fieldFortEntry);
            //DummyFieldFortEntryModel model = new DummyFieldFortEntryModel(fieldFortEntry);
            Assert.AreEqual(fieldFortEntry.Description, model.Value.Description);

            var model2 = new FieldFortEntryModel(fieldFortEntry);
            Assert.AreEqual(fieldFortEntry.Description, model2.Value.Description);
        }
    }
}

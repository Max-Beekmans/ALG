using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alg1_Practicum;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System.Linq;
using System.Diagnostics;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils;


namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class NawHashTableTest : ContextBoundObject
    {
        private NAW naw0 = new NAW("Koen", "Kerkstraat", "Veldhoven");
        private NAW naw1 = new NAW("Paul", "De Remise", "Eindhoven");

        #region Setup and Teardown
        [TestInitialize]
        public void NawArrayOrdered_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void NawArrayOrdered_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }
        #endregion

        #region Add
        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS6 - HashTable - Add" )]
        [PrintCode("NawHashTable", "Add")]
        [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er een NAW aan toe. Deze moet worden toegevoegd in de array op plek abs(hashcode % 10).")]
        public void NawHashTable_Add_ShouldAddToArray()
        {
            NawHashTable hashtable = new NawHashTable(10);
            
            hashtable.Add(naw0);

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET);
            Assert.AreEqual(1, setters.Count(), "\n\nNawHashTable.Add(): Er zijn geen of teveel schrijf operaties geweest in de array");
            Assert.AreEqual(8, setters.First().Index1, "\n\nNawHashTable.Add(): De GetHashCode van de NAW is -953963338. De absolute waarde hiervan modulo 10 is 8. Dit is de index waarop de waarde moet worden gezet.");

        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS6 - HashTable - Add" )]
        [PrintCode("NawHashTable", "Add")]
        [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er twee NAW's aan toe met dezelfde hashcode. De tweede zou een plek verder moeten komen te staan")]
        public void NawHashTable_Add_Twice_ShouldDoLinearProbing()
        {
            NawHashTable hashtable = new NawHashTable(10);

            hashtable.Add(naw0);
            hashtable.Add(naw0);

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
            Assert.AreEqual(2, setters.Count(), "\n\nNawHashTable.Add(): Er zouden twee elementen toegevoegd moeten zijn aan de array");
            Assert.AreEqual(9, setters[1].Index1, "\n\nNawHashTable.Add(): De eerste NAW wordt op plek 8 gezet, de tweede zou op plek 9 moeten komen");
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS6 - HashTable - Add" )]
        [PrintCode("NawHashTable", "Add")]
        [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er drie NAW's aan toe met dezelfde hashcode. De derde zou via linear probing aan het begin van de array moeten komen te staan.")]
        public void NawHashTable_Add_Thrice_LinearProbingShouldWrap()
        {
            NawHashTable hashtable = new NawHashTable(10);

            hashtable.Add(naw0);
            hashtable.Add(naw0);
            hashtable.Add(naw0);

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
            Assert.AreEqual(3, setters.Count(), "\n\nNawHashTable.Add(): Er zouden twee elementen toegevoegd moeten zijn aan de array");
            Assert.AreEqual(0, setters[2].Index1, "\n\nNawHashTable.Add(): De eerste NAW wordt op plek 8 gezet, op 9. De derde moet op plek 0 komen te staan.");
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS6 - HashTable - Add" )]
        [PrintCode("NawHashTable", "Add")]
        [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er tien NAW's aan toe. Deze zouden allemaal een plekje in de array moeten krijgen.")]
        public void NawHashTable_Add_TenTimes_ShouldFillArray()
        {
            NawHashTable hashtable = new NawHashTable(10);

            bool result = true;
            for (int i = 0; i < 10; i++)
            {
                result = result && hashtable.Add(i % 2 == 0 ? naw0 : naw1);
            }
            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
            Assert.AreEqual(10, setters.Count(), "\n\nNawHashTable.Add(): Er zouden precies 10 elementen gevuld moeten zijn");
            Assert.IsTrue(result, "\n\nNawHashTable.Add(): Er wordt niet geretourneerd dat de operatie succesvol was.");
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS6 - HashTable - Add" )]
        [PrintCode("NawHashTable", "Add")]
        [TestSummary(@"We maken een NawHashTable met een capaciteit van 10 en voegen er elf toe. De elfde zou genegeerd moeten worden.")]
        public void NawHashTable_Add_ElevenTimes_ShouldIgnoreLast()
        {
            NawHashTable hashtable = new NawHashTable(10);

            for (int i = 0; i < 10; i++)
            {
                hashtable.Add(i % 2 == 0 ? naw0 : naw1);
            }
            Logger.Instance.ClearLog();

            // Elfde keer
            bool result = hashtable.Add(naw0);

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).ToArray();
            Assert.AreEqual(0, setters.Count(), "\n\nNawHashTable.Add(): Er wordt een element in de array gezet terwijl deze al vol is.");
            Assert.IsFalse(result, "\n\nNawHashTable.Add(): Er wordt niet geretourneerd dat de operatie niet succesvol was.");
        }
        #endregion
    }

}

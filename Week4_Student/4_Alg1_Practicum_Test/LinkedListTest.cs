using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class LinkedListTest : ContextBoundObject
    {
        private NawLinkedList lijst { get; set; }

        private NAW naw0 = new NAW("Koen", "Kerkstraat", "Veldhoven");
        private NAW naw1 = new NAW("Paul", "De Remise", "Eindhoven");
        private NAW naw2 = new NAW("Martijn", "Dorpstraat", "Oss");

        private NAW new_naw = new NAW("Bart", "Parklaan", "Tilburg");

        [TestInitialize]
        public void LinkedList_Initialize()
        {
            lijst = new NawLinkedList();
            lijst.InsertHead(naw2);
            lijst.InsertHead(naw1);
            lijst.InsertHead(naw0);
        }

        #region Count
        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountCalculated")]
        [TestSummary(@"")]

        public void LinkedList_CountCalculated_EmptyList_Returns0()
        {
            NawLinkedList legeLijst = new NawLinkedList();
            Assert.AreEqual(0, legeLijst.CountCalculated(), "Bij een lege lijst retourneert CountCalculated geen 0.");
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountCalculated")]
        [TestSummary(@"")]
        public void LinkedList_CountCalculated_FilledList_Returns2()
        {
            lijst.RemoveHead();
            Assert.AreEqual(2, lijst.CountCalculated(), "CountCalculated retourneert {0}, dit is niet het juiste aantal elementen {1}.", lijst.CountCalculated(), 2);
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountStored")]
        [TestSummary(@"")]

        public void LinkedList_CountStored_EmptyList_Returns0()
        {
            NawLinkedList legeLijst = new NawLinkedList();
            Assert.AreEqual(0, legeLijst.CountStored(), "Bij een lege lijst retourneert CountStored geen 0.");
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountStored")]
        [TestSummary(@"")]
        public void LinkedList_CountStored_FilledList_Returns2()
        {
            lijst.RemoveHead();
            Assert.AreEqual(2, lijst.CountStored(), "CountStored retourneert {0}, dit is niet het juiste aantal elementen {1}.", lijst.CountStored(), 2);
        }

        #endregion

        #region InsertHead
        [TestMethod]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_FilledList_ChangesList()
        {
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.Head().Naw, "Het nieuwe element is nu niet het eerste element geworden.");
            Assert.AreEqual(4, lijst.CountStored(), "Na toevoegen van het element geeft CountStored() niet het juiste aantal elementen. Zorg dat _length up to date blijft.");
        }

        [TestMethod]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_EmptyList_ChangesList()
        {
            NawLinkedList lijst = new NawLinkedList();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.Head().Naw, "Het nieuwe element is nu niet het eerste element geworden.");
            Assert.AreEqual(1, lijst.CountStored(), "Na toevoegen van het element geeft CountStored() niet het juiste aantal elementen. Zorg dat _length up to date blijft.");
        }


        [TestMethod]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_EmptyList_LastUpdatedCorrectly()
        {
            NawLinkedList lijst = new NawLinkedList();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.Tail().Naw, "Na invoegen van 1 nieuwe element in de lege lijst, wijst _last niet naar dit nieuwe element.");
        }

        [TestMethod]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_FilledList_LastUpdatedCorrectly()
        {
            Link oldTail = lijst.Tail();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(oldTail, lijst.Tail(), "Door het invoegen van het nieuwe element aan het begin van de lijst is de waarde van _last onterecht gewijzigd.");
        }

        #endregion

        #region RemoveHead
        [TestMethod]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_FilledList_ChangesList()
        {
            Link secondLink = lijst.Head().Next;
            Link oldLast = lijst.Tail();
            lijst.RemoveHead();

            Assert.AreEqual(secondLink, lijst.Head(), "Het tweede element in de oorspronkelijke lijst is na het verwijderen niet het eerste element geworden. Werk je _first wel bij ?");
            Assert.AreEqual(oldLast, lijst.Tail(), "Bij het verwijderen van het eerste element is de waarde van _last onterecht gewijzigd.");
            Assert.AreEqual(2, lijst.CountStored(), "Na verwijderen van het element geeft CountStored() niet het juiste aantal elementen. Zorg dat _length up to date blijft.");
        }

        [TestMethod]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_EmptyList_DoesNothing()
        {
            NawLinkedList lijst = new NawLinkedList();
            lijst.RemoveHead();

            Assert.AreEqual(0, lijst.CountStored(), "Bij verwijderen uit een lege lijst krijgt _length onterecht de waarde {0}", lijst.CountStored());
            Assert.AreEqual(null, lijst.Head(), "Bij verwijderen uit een lege lijst krijgt _first onterecht de waarde {0}", lijst.Head());
            Assert.AreEqual(null, lijst.Tail(), "Bij verwijderen uit een lege lijst krijgt _last onterecht de waarde {0}", lijst.Tail());
        }


        [TestMethod]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_OneItemList_LastUpdatedCorrectly()
        {
            NawLinkedList lijst = new NawLinkedList();
            lijst.InsertHead(new_naw);
            lijst.RemoveHead();

            Assert.AreEqual(null, lijst.Tail(), "Na verwijderen van laatste element in de lijst wijst _last niet naar null.");
        }

        [TestMethod]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_FilledList_LastRetainedCorrectly()
        {
            Link oldTail = lijst.Tail();
            lijst.RemoveHead();

            Assert.AreEqual(oldTail, lijst.Tail(), "Na verwijderen van element in de lijst wijst _last niet meer naar juiste Link.");
        }

        #endregion

        #region Show

        [TestMethod]
        [TestCategory("WS4 - Linked List - Show")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "Show")]
        [TestSummary(@"")]
        public void LinkedList_Show_ShouldBeImplemented()
        {
            lijst.Show();
        }
        #endregion
 
        #region FindNaw
        [TestMethod]
        [TestCategory("WS4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_IsInList_ReturnsIndex()
        {
            Assert.AreEqual(0, lijst.FindNaw(naw0),"Het eerste item in de lijst wordt niet gevonden.");
            Assert.AreEqual(1, lijst.FindNaw(naw1),"Een item in de lijst wordt niet gevonden.");
            Assert.AreEqual(2, lijst.FindNaw(naw2),"Het laatste item in de lijst wordt niet gevonden.");
        }

        [TestMethod]
        [TestCategory("WS4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_NotInList_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, lijst.FindNaw(new_naw),"Bij zoeken naar een niet bestaand element is de return-waarde {0} ipv -1.",lijst.FindNaw(new_naw));
        }

        [TestMethod]
        [TestCategory("WS4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_EmptyList_ReturnsMinusOne()
        {
            NawLinkedList lijst = new NawLinkedList();
            Assert.AreEqual(-1, lijst.FindNaw(new_naw), "Bij zoeken in een lege lijst is de return-waarde {0} ipv -1.", lijst.FindNaw(new_naw));
        }
        #endregion
 
    }
}

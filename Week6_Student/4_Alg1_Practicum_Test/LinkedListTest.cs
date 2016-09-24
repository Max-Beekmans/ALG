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
            Assert.AreEqual(0, legeLijst.CountCalculated());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountCalculated")]
        [TestSummary(@"")]
        public void LinkedList_CountCalculated_FilledList_Returns2()
        {
            lijst.RemoveHead();
            Assert.AreEqual(2, lijst.CountCalculated());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountStored")]
        [TestSummary(@"")]

        public void LinkedList_CountStored_EmptyList_Returns0()
        {
            NawLinkedList legeLijst = new NawLinkedList();
            Assert.AreEqual(0, legeLijst.CountStored());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountStored")]
        [TestSummary(@"")]
        public void LinkedList_CountStored_FilledList_Returns2()
        {
            lijst.RemoveHead();
            Assert.AreEqual(2, lijst.CountStored());
        }
        
        #endregion

        #region GetNawAt
        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW4 - Linked List - GetAt")]
        [PrintCode("NawLinkedList", "GetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_GetNawAt_CorrectIndex_ReturnsNAW()
        {
            Assert.AreSame(naw0, lijst.GetNawAt(0));
            Assert.AreSame(naw1, lijst.GetNawAt(1));
            Assert.AreSame(naw2, lijst.GetNawAt(2));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW4 - Linked List - GetAt")]
        [PrintCode("NawLinkedList", "GetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_GetNawAt_NegativeIndex_ReturnsNull()
        {
            Assert.IsNull(lijst.GetNawAt(-1));
            Assert.IsNull(lijst.GetNawAt(-100));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW4 - Linked List - GetAt")]
        [PrintCode("NawLinkedList", "GetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_GetNawAt_TooLargeIndex_ReturnsNull()
        {
            Assert.IsNull(lijst.GetNawAt(3));
            Assert.IsNull(lijst.GetNawAt(100));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW4 - Linked List - GetAt")]
        [PrintCode("NawLinkedList", "GetNawAt")]
        [TestSummary(@"")]

        public void LinkedList_GetNawAt_EmptyList_ReturnsNull()
        {
            NawLinkedList lijst = new NawLinkedList();
            Assert.IsNull(lijst.GetNawAt(0));
        }

        #endregion

        #region SetNawAt
        [TestMethod]
        [TestCategory("HW4 - Linked List - SetAt")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "SetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_SetNawAt_CorrectIndex_ChangesList()
        {
            lijst.SetNawAt(1, new_naw);

            Assert.AreNotSame(new_naw, lijst.GetNawAt(0));
            Assert.AreSame(new_naw, lijst.GetNawAt(1));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(2));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - SetAt")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "SetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_SetNawAt_NegativeIndex_DoesNothing()
        {
            lijst.SetNawAt(-1, new_naw);

            Assert.AreNotSame(new_naw, lijst.GetNawAt(0));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(1));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(2));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - SetAt")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "SetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_SetNawAt_TooLargeIndex_DoesNothing()
        {
            lijst.SetNawAt(3, new_naw);

            Assert.AreNotSame(new_naw, lijst.GetNawAt(0));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(1));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(2));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - SetAt")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "SetNawAt")]
        [TestSummary(@"")]
        public void LinkedList_SetNawAt_EmptyList_DoesNothing()
        {
            NawLinkedList lijst = new NawLinkedList();
            lijst.SetNawAt(0, new_naw);

            Assert.AreNotSame(new_naw, lijst.GetNawAt(0));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(1));
            Assert.AreNotSame(new_naw, lijst.GetNawAt(2));
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

            Assert.AreSame(new_naw, lijst.GetNawAt(0));
            Assert.AreEqual(4, lijst.CountCalculated());
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

            Assert.AreSame(new_naw, lijst.GetNawAt(0));
            Assert.AreEqual(1, lijst.CountCalculated());
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

            Assert.AreSame(new_naw, lijst.GetNawAt(0));
            Assert.AreEqual(1, lijst.CountCalculated());
            Assert.AreEqual(lijst.Head(), lijst.Tail());
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
            
            Assert.AreSame(new_naw, lijst.GetNawAt(0));
            Assert.AreEqual(1, lijst.CountCalculated());
            Assert.AreEqual(oldTail, lijst.Tail());
        }

        #endregion

        #region FindNaw
        [TestMethod]
        [TestCategory("HW4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_IsInList_ReturnsIndex()
        {
            Assert.AreEqual(0, lijst.FindNaw(naw0));
            Assert.AreEqual(1, lijst.FindNaw(naw1));
            Assert.AreEqual(2, lijst.FindNaw(naw2));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_NotInList_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, lijst.FindNaw(new_naw));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_EmptyList_ReturnsMinusOne()
        {
           NawLinkedList lijst = new NawLinkedList();
            Assert.AreEqual(-1, lijst.FindNaw(new_naw));
        }
        #endregion

        #region RemoveAllNaw

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_RemoveFirst_UpdatesCount()
        {
            lijst.RemoveAllNaw(naw0);
            Assert.AreEqual(2, lijst.CountCalculated());
            Assert.AreEqual(2, lijst.CountStored());
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_RemoveFirst_ChangesList()
        {
            lijst.RemoveAllNaw(naw0);

            Assert.AreEqual(2, lijst.CountCalculated());
            Assert.AreSame(naw1, lijst.GetNawAt(0));
            Assert.AreSame(naw2, lijst.GetNawAt(1));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_RemoveMiddle_ChangesList()
        {
            lijst.RemoveAllNaw(naw1);

            Assert.AreEqual(2, lijst.CountCalculated());
            Assert.AreSame(naw0, lijst.GetNawAt(0));
            Assert.AreSame(naw2, lijst.GetNawAt(1));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_RemoveLast_ChangesList()
        {
            lijst.RemoveAllNaw(naw2);

            Assert.AreEqual(2, lijst.CountCalculated());
            Assert.AreSame(naw0, lijst.GetNawAt(0));
            Assert.AreSame(naw1, lijst.GetNawAt(1));
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_RemoveNotInList_DoesNothing()
        {
            lijst.RemoveAllNaw(new_naw);

            Assert.AreEqual(3, lijst.CountCalculated());
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_EmptyList_DoesNothing()
        {
            NawLinkedList lijst = new NawLinkedList();

            lijst.RemoveAllNaw(new_naw);

            Assert.AreEqual(0, lijst.CountCalculated());
        }

        [TestMethod]
        [TestCategory("HW4 - Linked List - RemoveAllNaw")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("NawLinkedList", "RemoveAllNaw")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAllNaw_RemoveDuplicate_RemovesFirst()
        {
            NawLinkedList lijst = new NawLinkedList();
            lijst.InsertHead(naw0);
            lijst.InsertHead(naw0);
            lijst.InsertHead(naw0);
            lijst.InsertHead(naw0);
            Assert.AreEqual(4, lijst.CountCalculated());

            lijst.RemoveAllNaw(naw0);
            Assert.AreEqual(3, lijst.CountCalculated());
        }
        #endregion
    }
}

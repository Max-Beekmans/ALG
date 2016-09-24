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
    public class UndoableNawArrayTest
    {
        private NAW naw0 = new NAW("Paul", "De Remise", "Eindhoven");
        private NAW naw1 = new NAW("Martijn", "Dorpstraat", "Oss");
        private NAW naw2 = new NAW("Koen", "Kerkstraat", "Veldhoven");

        #region Add

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - Add")]
        [AantalPuntenAlsSlaagt(0.0)]
        [PrintCode("UndoableNawArray", "Add")]
        public void Add_SingleItem()
        {
            UndoableNawArray list = new UndoableNawArray(10);
            Assert.AreEqual(0, list.Count);

            list.Add(naw1);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list.Find(naw1));
            Assert.AreEqual(-1, list.Find(naw0));
        }

        #endregion Add

        #region remove

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - Remove")]
        [AantalPuntenAlsSlaagt(0.0)]
        [PrintCode("UndoableNawArray", "Remove")]
        public void Remove_SingleItem()
        {
            UndoableNawArray list = new UndoableNawArray(10);
            Assert.AreEqual(0, list.Count);

            list.Add(naw1);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list.Find(naw1));
            Assert.AreEqual(-1, list.Find(naw0));
        }

        #endregion remove

        #region AddOperation

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_LinkContainsOperation()
        {
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw1);

            Assert.AreEqual(list.First.Operation, Operation.ADD, "De Link die aan de Undo-lijst is toegevoegd geeft niet aan dat er een Add operatie heeft plaatsgevonden.");
            Assert.AreEqual(list.First.Naw, naw1, "De Link die aan de Undo-lijst is toegevoegd geeft niet het juiste Naw-object aan waarop een Add operatie heeft plaatsgevonden.");
        }

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Remove_AddOperation_LinkContainsOperation()
        {
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw1);
            list.Remove(naw1);

            Assert.AreEqual(list.First.Next.Operation, Operation.REMOVE, "De Link die aan de Undo-lijst is toegevoegd geeft niet aan dat er een Remove operatie heeft plaatsgevonden.");
            Assert.AreEqual(list.First.Next.Naw, naw1, "De Link die aan de Undo-lijst is toegevoegd geeft niet het juiste Naw-object aan waarop een Remove operatie heeft plaatsgevonden.");
        }

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_BothNextAndPreviousSet()
        {
            UndoableNawArray list = new UndoableNawArray(10);
            list.Add(naw0);

            // Act
            list.Add(naw1);

            Assert.AreEqual(list.First.Next.Naw, naw1, "Er wordt geen juiste referentie naar de Link die aan de Undo-lijst is toegevoegd gelegd vanuit de voorgaande link.");
            Assert.AreEqual(list.First.Next.Previous.Naw, naw0, "Er wordt geen juiste referentie van de Link die aan de Undo-lijst is toegevoegd gelegd naar de voorgaande link.");
        }

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_CurrentIsUpdated()
        {
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw1);
            list.Remove(naw1);

            Assert.AreEqual(list.First.Next.Operation, Operation.REMOVE, "De Link die aan de Undo-lijst is toegevoegd geeft niet aan dat er een Remove operatie heeft plaatsgevonden.");
            Assert.AreEqual(list.First.Next.Naw, naw1, "De Link die aan de Undo-lijst is toegevoegd geeft niet het juiste Naw-object aan waarop een Remove operatie heeft plaatsgevonden.");
        }

        [TestMethod]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_EmptyList_ListIsCorrect()
        {
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw0);

            Assert.AreEqual(list.First.Naw, naw0, "In het geval dat een eerste Undo-Link aan een lege lijst wordt toegevoegd wordt de First niet goed bijgewerkt.");
            Assert.AreEqual(list.Current.Naw, naw0, "In het geval dat een eerste Undo-Link aan een lege lijst wordt toegevoegd wordt deze niet de currentUndoLink gemaakt.");
        }

        #endregion AddOperation

     }
}

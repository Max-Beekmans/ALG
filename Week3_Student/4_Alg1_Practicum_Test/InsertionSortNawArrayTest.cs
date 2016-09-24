using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Utils.Models;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum;


namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class InsertionSortNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void InsertionSortNawArray_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void InsertionSortNawArray_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }
        #endregion

        #region InsertionSort

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_EmptyArray_ShouldNotSort()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(10), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(0, Logger.Instance.LogItems.Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_SortedArray_ShouldNotSetAnyNewIndexes()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET &&
                                                                    li.NewNaw1 != li.OldNaw1).Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_SortedArrayDescending_ShouldSetAllItemsButOne()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderDescending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(expectedLength.SumAllSmallerIncSelf() - 1, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_AllTheSameWoonplaats_IsInOrder()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            foreach (var item in testSet)
            {
                item.Woonplaats = "Allemaal dezelfde woonplaats";
            }

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_AllTheSameWoonplaatsAndNaam_IsInOrder()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            foreach (var item in testSet)
            {
                item.Woonplaats = "Allemaal dezelfde woonplaats";
                item.Naam = "Allemaal dezelfde naam";
            }

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_EightAndFourSwapped_ShouldHaveRightBounds()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "0";
            testSet[1].Woonplaats = "1";
            testSet[2].Woonplaats = "2";
            testSet[3].Woonplaats = "3";
            testSet[4].Woonplaats = "8";
            testSet[5].Woonplaats = "5";
            testSet[6].Woonplaats = "6";
            testSet[7].Woonplaats = "7";
            testSet[8].Woonplaats = "4";
            testSet[9].Woonplaats = "9";

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");
     
            // Logger.Instance.Print();

            Assert.IsTrue(array.CheckIsGesorteerd());

            int lowerBound = 4, upperBound = 8;

            NAW toMoveUp = testSet[lowerBound];
            var toMoveUpSetters = (from li in Logger.Instance.LogItems
                                   where li.NewNaw1 == toMoveUp && li.ArrayAction == ArrayAction.SET
                                    && li.NewNaw1 != li.OldNaw1 // This will be checked in another test
                                   orderby li.Index1
                                   select li).ToArray();
            // This one bubbles up slowly.
            for (int i = lowerBound + 1; i <= upperBound; i++)
            {
                Assert.IsTrue(toMoveUpSetters[i - lowerBound - 1].Index1 == i);
            }

            NAW toBeInsertedDown = testSet[upperBound];
            var toBeInsertedDownSetters = (from li in Logger.Instance.LogItems
                                           where li.NewNaw1 == toBeInsertedDown && li.ArrayAction == ArrayAction.SET
                                            && li.NewNaw1 != li.OldNaw1 // This will be checked in another test
                                           orderby li.Index1
                                           select li).ToArray();
            // This one moves down in an insertion way.
            Assert.AreEqual(1, toBeInsertedDownSetters.Count());
            Assert.AreEqual(lowerBound, toBeInsertedDownSetters.First().Index1);


            // All setters must be in between the bounds.
            Assert.IsTrue(Logger.Instance.LogItems
                    .Where(li => li.ArrayAction == ArrayAction.SET && li.NewNaw1 != li.OldNaw1)
                    .All(li => li.Index1 >= lowerBound && li.Index1 <= upperBound));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_EightAndFourSwapped_ShouldNotSetWhenNotSwapped()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "0";
            testSet[1].Woonplaats = "1";
            testSet[2].Woonplaats = "2";
            testSet[3].Woonplaats = "3";
            testSet[4].Woonplaats = "8";
            testSet[5].Woonplaats = "5";
            testSet[6].Woonplaats = "6";
            testSet[7].Woonplaats = "7";
            testSet[8].Woonplaats = "4";
            testSet[9].Woonplaats = "9";

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());

            int lowerBound = 4, upperBound = 8;

            NAW toMoveUp = testSet[lowerBound];
            var toMoveUpSetters = (from li in Logger.Instance.LogItems
                                   where li.NewNaw1 == toMoveUp && li.ArrayAction == ArrayAction.SET
                                   orderby li.Index1
                                   select li).ToArray();
            
            // This one bubbles up slowly.
            for (int i = lowerBound + 1; i <= upperBound; i++)
            {
                Assert.IsTrue(toMoveUpSetters[i - lowerBound - 1].Index1 == i);
            }

            NAW toBeInsertedDown = testSet[upperBound];
            var toBeInsertedDownSetters = (from li in Logger.Instance.LogItems
                                           where li.NewNaw1 == toBeInsertedDown && li.ArrayAction == ArrayAction.SET
                                           orderby li.Index1
                                           select li).ToArray();
            // This one moves down in an insertion way.
            Assert.AreEqual(1, toBeInsertedDownSetters.Count());
            Assert.AreEqual(lowerBound, toBeInsertedDownSetters.First().Index1);


            // All setters must be in between the bounds.
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).All(li => li.Index1 >= lowerBound && li.Index1 <= upperBound));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("WS3 - Array - InsertionSort")]
        public void InsertionSortNawArray_InsertionSort_ShouldStartWithFirst()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "4";
            testSet[1].Woonplaats = "1";
            testSet[2].Woonplaats = "2";
            testSet[3].Woonplaats = "3";
            testSet[4].Woonplaats = "0";
            testSet[5].Woonplaats = "5";
            testSet[6].Woonplaats = "6";
            testSet[7].Woonplaats = "7";
            testSet[8].Woonplaats = "8";
            testSet[9].Woonplaats = "9";

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSort();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET && li.OldNaw1 != li.NewNaw1).ToList();
            // We moeten eerst alles naar achteren schuiven voordat er voor de 0 plaats is.
            setters.Last().AssertAreEqual(0, "0");
        }

        #endregion

        #region InsertionSortGeinverteerd

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_EmptyArray_ShouldNotSort()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(10), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(0, Logger.Instance.LogItems.Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_SortedArray_ShouldNotSetAnyNewIndexes()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET &&
                                                                    li.NewNaw1 != li.OldNaw1).Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_SortedArrayDescending_ShouldSetAllItemsButOne()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderDescending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(expectedLength.SumAllSmallerIncSelf() - 1, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET).Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_AllTheSameWoonplaats_IsInOrder()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            foreach (var item in testSet)
            {
                item.Woonplaats = "Allemaal dezelfde woonplaats";
            }

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(0.5)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_AllTheSameWoonplaatsAndNaam_IsInOrder()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            foreach (var item in testSet)
            {
                item.Woonplaats = "Allemaal dezelfde woonplaats";
                item.Naam = "Allemaal dezelfde naam";
            }

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_EightAndFourSwapped_ShouldHaveRightBounds()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "0";
            testSet[1].Woonplaats = "1";
            testSet[2].Woonplaats = "2";
            testSet[3].Woonplaats = "3";
            testSet[4].Woonplaats = "8";
            testSet[5].Woonplaats = "5";
            testSet[6].Woonplaats = "6";
            testSet[7].Woonplaats = "7";
            testSet[8].Woonplaats = "4";
            testSet[9].Woonplaats = "9";

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            Logger.Instance.Print();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());

            int lowerBound = 4, upperBound = 8;

            NAW toMoveDown = testSet[upperBound];
            var toMoveDownSetters = (from li in Logger.Instance.LogItems
                                     where li.NewNaw1 == toMoveDown && li.ArrayAction == ArrayAction.SET
                                      && li.NewNaw1 != li.OldNaw1 // This will be checked in another test
                                     orderby li.Index1 descending
                                     select li).ToArray();
            // This one bubbles Down slowly.
            for (int i = upperBound - 1; i >= lowerBound; i--)
            {
                Assert.IsTrue(toMoveDownSetters[upperBound - i - 1].Index1 == i);
            }

            NAW toBeInsertedUp = testSet[lowerBound];
            var toBeInsertedUpSetters = (from li in Logger.Instance.LogItems
                                         where li.NewNaw1 == toBeInsertedUp && li.ArrayAction == ArrayAction.SET
                                          && li.NewNaw1 != li.OldNaw1 // This will be checked in another test
                                         orderby li.Index1
                                         select li).ToArray();
            // This one moves Up in an insertion way.
            Assert.AreEqual(1, toBeInsertedUpSetters.Count());
            Assert.AreEqual(upperBound, toBeInsertedUpSetters.First().Index1);

            // All setters must be in between the bounds.
            Assert.IsTrue(Logger.Instance.LogItems
                    .Where(li => li.ArrayAction == ArrayAction.SET && li.NewNaw1 != li.OldNaw1)
                    .All(li => li.Index1 >= lowerBound && li.Index1 <= upperBound));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_EightAndFourSwapped_ShouldNotSetWhenNotSwapped()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "0";
            testSet[1].Woonplaats = "1";
            testSet[2].Woonplaats = "2";
            testSet[3].Woonplaats = "3";
            testSet[4].Woonplaats = "8";
            testSet[5].Woonplaats = "5";
            testSet[6].Woonplaats = "6";
            testSet[7].Woonplaats = "7";
            testSet[8].Woonplaats = "4";
            testSet[9].Woonplaats = "9";

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            Logger.Instance.Print();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());

            int lowerBound = 4, upperBound = 8;

            NAW toMoveDown = testSet[upperBound];
            var toMoveDownSetters = (from li in Logger.Instance.LogItems
                                     where li.NewNaw1 == toMoveDown && li.ArrayAction == ArrayAction.SET
                                     orderby li.Index1 descending
                                     select li).ToArray();
            // This one bubbles Down slowly.
            for (int i = upperBound - 1; i >= lowerBound; i--)
            {
                Assert.IsTrue(toMoveDownSetters[upperBound - i - 1].Index1 == i);
            }

            NAW toBeInsertedUp = testSet[lowerBound];
            var toBeInsertedUpSetters = (from li in Logger.Instance.LogItems
                                         where li.NewNaw1 == toBeInsertedUp && li.ArrayAction == ArrayAction.SET
                                          && li.NewNaw1 != li.OldNaw1 // This will be checked in another test
                                         orderby li.Index1
                                         select li).ToArray();
            // This one moves Up in an insertion way.
            Assert.AreEqual(1, toBeInsertedUpSetters.Count());
            Assert.AreEqual(upperBound, toBeInsertedUpSetters.First().Index1);

            // All setters must be in between the bounds.
            Assert.IsTrue(Logger.Instance.LogItems
                    .Where(li => li.ArrayAction == ArrayAction.SET && li.NewNaw1 != li.OldNaw1)
                    .All(li => li.Index1 >= lowerBound && li.Index1 <= upperBound));
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.5)]
        [TestCategory("HW3 - Array - InsertionSortInverted")]
        public void InsertionSortNawArray_InsertionSortGeinverteerd_ShouldStartWithLast()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "0";
            testSet[1].Woonplaats = "1";
            testSet[2].Woonplaats = "2";
            testSet[3].Woonplaats = "3";
            testSet[4].Woonplaats = "9";
            testSet[5].Woonplaats = "5";
            testSet[6].Woonplaats = "6";
            testSet[7].Woonplaats = "7";
            testSet[8].Woonplaats = "8";
            testSet[9].Woonplaats = "4";

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.InsertionSortInverted();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(array.CheckIsGesorteerd());

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET && li.OldNaw1 != li.NewNaw1).ToList();
            // We moeten eerst alles naar voren schuiven voordat er voor de 9 plaats is.
            setters.Last().AssertAreEqual(9, "9");
        }

        #endregion
    }
}

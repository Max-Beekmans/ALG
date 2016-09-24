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
    public class BubbleSortNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void NawArrayUnordered_TestInitialize()
        {
            Logger.Instance.ClearLog();
        }
        #endregion

        #region BubbleSort

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_EmptyArray_ShouldNotSort()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(10), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.BubbleSort();

            // Assert
            Assert.AreEqual(0, Logger.Instance.LogItems.Count());
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_SortedArray_ShouldNotSetAnyNewIndexes()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.BubbleSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SWAP &&
                                                                    li.NewNaw1 != li.OldNaw1).Count());
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_SortedArrayDescending_ShouldSetAllItemsButOne()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderDescending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.BubbleSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            var swaps = Logger.Instance.RealSwaps;
            Assert.AreEqual(expectedLength.SumAllSmallerIncSelf() - expectedLength, swaps.Count());
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_AllTheSameWoonplaats_IsInOrder()
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
            array.BubbleSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_AllTheSameWoonplaatsAndNaam_IsInOrder()
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
            array.BubbleSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_EightAndFourSwapped_ShouldHaveRightBounds()
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
            array.BubbleSort();

            Logger.Instance.Print();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(7, Logger.Instance.RealSwaps.Count());
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_EightAndFourSwapped_ShouldNotSetWhenNotSwapped()
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
            array.BubbleSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(7, Logger.Instance.RealSwaps.Count());
            Assert.AreEqual(0, Logger.Instance.LogItems.Count(li => li.ArrayAction == ArrayAction.SWAP && li.Index1 == li.Index2));
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Bubble Sort")]
        [AantalPuntenAlsSlaagt(0.5)]

        public void NawArrayUnordered_BubbleSort_ShouldStartWithFirst()
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
            array.BubbleSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());

            var swaps = Logger.Instance.RealSwaps.ToList();
            // We moeten eerst alles naar achteren schuiven voordat er voor de 0 plaats is.
            Assert.AreEqual(7, swaps.Count);
            Assert.AreEqual("0", swaps[6].NewNaw1.Woonplaats);
        }

        #endregion

    }
}

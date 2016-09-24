using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum_Utils.Logging;
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
    public class SelectionSortNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void SelectionSortNawArray_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void SelectionSortNawArray_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }

        #endregion

        #region SelectionSort

        [TestMethod]        
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_EmptyArray_ShouldNotSort()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(10), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSort();

            // Assert
            Assert.AreEqual(0, Logger.Instance.LogItems.Count());
        }

        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_SortedArray_ShouldNotSwapDifferentIndexes()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.RealSwaps.Count());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_SortedArray_ShouldNotSwapAtAll()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SWAP).Count());
        }
        
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_SortedArrayDescending_ShouldSwapAllItems()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderDescending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            // We expect half the length of the array to be swapped.
            // This occurs because when ordered descending when we swap we coincidentally set two items right.
            Assert.AreEqual(expectedLength / 2, Logger.Instance.RealSwaps.Count());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_NineOnFront_WholeArrayShifted()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "9";
            testSet[1].Woonplaats = "0";
            testSet[2].Woonplaats = "1";
            testSet[3].Woonplaats = "2";
            testSet[4].Woonplaats = "3";
            testSet[5].Woonplaats = "4";
            testSet[6].Woonplaats = "5";
            testSet[7].Woonplaats = "6";
            testSet[8].Woonplaats = "7";
            testSet[9].Woonplaats = "8";

            // Act
            array.SelectionSort();

            // Assert
            var realSwaps = Logger.Instance.RealSwaps.ToList();
            var logItems = Logger.Instance.LogItems.ToList();
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(expectedLength - 1, realSwaps.Count);

            for (int i = 0; i < expectedLength - 1; i++)
            {
                Assert.AreEqual(i, realSwaps[i].Index1);
                Assert.AreEqual(i + 1, realSwaps[i].Index2);

                var indexOfSwap = logItems.IndexOf(realSwaps[i]);

                // We assert to not touch previous touched items.
                Assert.IsFalse(logItems.Skip(indexOfSwap + 1).Any(li => li.Index1 <= realSwaps[i].Index1));
            }
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_AllTheSameWoonplaats_IsInOrder()
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
            array.SelectionSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_AllTheSameWoonplaatsAndNaam_IsInOrder()
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
            array.SelectionSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_SortedArrayDescending_ShouldHaveRightBounds()
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
            array.SelectionSort();

            // Assert
            var realSwaps = Logger.Instance.RealSwaps.ToList();
            var logItems = Logger.Instance.LogItems.ToList();
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(1, realSwaps.Count);

            // We assert to not touch previous touched items.
            var indexOfSwap = logItems.IndexOf(realSwaps[0]);
            Assert.IsFalse(logItems.Skip(indexOfSwap + 1).Any(li => li.Index1 <= realSwaps[0].Index1));
        }
               
        [TestMethod]         
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("WS3 - Array - SelectionSort")]
        public void SelectionSortNawArray_SelectionSort_ShouldStartWithFirst()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "9";
            testSet[1].Woonplaats = "0";
            testSet[2].Woonplaats = "1";
            testSet[3].Woonplaats = "2";
            testSet[4].Woonplaats = "3";
            testSet[5].Woonplaats = "4";
            testSet[6].Woonplaats = "5";
            testSet[7].Woonplaats = "6";
            testSet[8].Woonplaats = "7";
            testSet[9].Woonplaats = "8";

            // Act
            array.SelectionSort();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());

            var logItems = Logger.Instance.LogItems.ToList();
            var realSwaps = Logger.Instance.RealSwaps.ToList();

            Assert.AreEqual(expectedLength - 1, realSwaps.Count);
            for (int i = 0; i < realSwaps.Count; i++)
            {
                var indexOf = logItems.IndexOf(realSwaps[i]);
                var range = logItems.Take(indexOf);
                Assert.AreEqual(i, range.Min(li => li.Index1));
                Assert.AreEqual(expectedLength - 1, range.Max(li => li.Index1));

                logItems = logItems.Skip(indexOf + 1).ToList();
            }
        }

        #endregion

        #region SelectionSortGeinverteerd

        [TestMethod]         
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_EmptyArray_ShouldNotSort()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(10), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSortInverted();

            // Assert
            Assert.AreEqual(0, Logger.Instance.LogItems.Count());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_SortedArray_ShouldNotSwapDifferentIndexes()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSortInverted();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.RealSwaps.Count());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_SortedArray_ShouldNotSwapAtAll()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderAscending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSortInverted();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            Assert.AreEqual(0, Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SWAP).Count());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_SortedArrayDescending_ShouldSwapAllItems()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet, orderDescending: true);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.SelectionSortInverted();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.IsTrue(Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count() >= expectedLength);
            // We expect half the length of the array to be swapped.
            // This occurs because when ordered descending when we swap we coincidentally set two items right.
            Assert.AreEqual(expectedLength / 2, Logger.Instance.RealSwaps.Count());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_NineOnFront_WholeArrayShifted()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "9";
            testSet[1].Woonplaats = "0";
            testSet[2].Woonplaats = "1";
            testSet[3].Woonplaats = "2";
            testSet[4].Woonplaats = "3";
            testSet[5].Woonplaats = "4";
            testSet[6].Woonplaats = "5";
            testSet[7].Woonplaats = "6";
            testSet[8].Woonplaats = "7";
            testSet[9].Woonplaats = "8";

            // Act
            array.SelectionSortInverted();

            // Assert
            var realSwaps = Logger.Instance.RealSwaps.ToList();
            var logItems = Logger.Instance.LogItems.ToList();
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(expectedLength - 1, realSwaps.Count);

            for (int i = 0; i < expectedLength - 1; i++)
            {
                Assert.AreEqual(0, realSwaps[i].Index1);
                // Last index minus where we are at the moment.
                Assert.AreEqual(expectedLength - 1 - i, realSwaps[i].Index2);

                var indexOfSwap = logItems.IndexOf(realSwaps[i]);

                // We assert to not touch previous touched items.
                Assert.IsFalse(logItems.Skip(indexOfSwap + 1).Any(li => li.Index2 >= realSwaps[i].Index2));
            }
        }
        
        [TestMethod]         
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_AllTheSameWoonplaats_IsInOrder()
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
            array.SelectionSortInverted();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(0.5)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_AllTheSameWoonplaatsAndNaam_IsInOrder()
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
            array.SelectionSortInverted();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.0)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_SortedArrayDescending_ShouldHaveRightBounds()
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
            array.SelectionSortInverted();

            // Assert
            var realSwaps = Logger.Instance.RealSwaps.ToList();
            var logItems = Logger.Instance.LogItems.ToList();
            Assert.IsTrue(array.CheckIsGesorteerd());
            Assert.AreEqual(1, realSwaps.Count);

            // We assert to not touch previous touched items.
            var indexOfSwap = logItems.IndexOf(realSwaps[0]);
            Assert.IsFalse(logItems.Skip(indexOfSwap + 1).Any(li => li.Index1 >= realSwaps[0].Index2));
        }
                
        [TestMethod]         
        [AantalPuntenAlsSlaagt(1.5)]         
        [TestCategory("HW3 - Array - SelectionSortInverted")]
        public void SelectionSortNawArray_SelectionSortGeinverteerd_ShouldStartWithLast()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            testSet[0].Woonplaats = "9";
            testSet[1].Woonplaats = "0";
            testSet[2].Woonplaats = "1";
            testSet[3].Woonplaats = "2";
            testSet[4].Woonplaats = "3";
            testSet[5].Woonplaats = "4";
            testSet[6].Woonplaats = "5";
            testSet[7].Woonplaats = "6";
            testSet[8].Woonplaats = "7";
            testSet[9].Woonplaats = "8";

            // Act
            array.SelectionSortInverted();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());

            var logItems = Logger.Instance.LogItems.ToList();
            var realSwaps = Logger.Instance.RealSwaps.ToList();

            Assert.AreEqual(expectedLength - 1, realSwaps.Count);
            for (int i = 0; i < realSwaps.Count; i++)
            {
                var indexOf = logItems.IndexOf(realSwaps[i]);
                var range = logItems.Take(indexOf);
                Assert.AreEqual(0, range.Min(li => li.Index1));
                Assert.AreEqual(expectedLength - 1 - i, range.Max(li => li.Index1));

                logItems = logItems.Skip(indexOf).ToList();
            }
        }

        #endregion
    }
}

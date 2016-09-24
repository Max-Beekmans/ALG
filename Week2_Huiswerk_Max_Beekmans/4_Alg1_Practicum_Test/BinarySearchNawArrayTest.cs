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
using Alg1_Practicum_Utils.Exceptions;


namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class BinarySearchNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void BinarySearchNawArray_TestInitialize()
        {
            Logger.Instance.ClearLog();
        }
        #endregion

        #region BinarySearch

        [TestMethod]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(1.0)]

        public void NawArrayOrdered_FindBinary_EmptyArray_ShouldHaveNoSteps()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(10), expectedLength, out testSet);

            // Act
            array.FindBinary(new NAW("Naam", "Adres", "Woonplaats"));

            // Assert
            Assert.AreEqual(0, Logger.Instance.LogItems.Count(), "\n\nNawArrayOrdered.FindBinary(): Er wordt onnodig gezocht in een lege array.\n");
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(1.0)]

        public void NawArrayOrdered_FindBinary_LastItem_ShouldNotTakeMoreThanLogN()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var expectedSearches = Math.Ceiling(Math.Log(expectedLength));
            var expectedIndex = 99;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            // Act
            var actualIndex = array.FindBinary(testSet[expectedIndex]);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
            var actualSearches = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count();
            Assert.IsTrue(actualSearches <= expectedSearches + 2, "\n\nNawArrayOrdered.FindBinary(): De implementatie gebruikt teveel stappen om het laatste element te vinden middels binair zoeken.\n");
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(1.0)]

        public void NawArrayOrdered_FindBinary_FirstItem_ShouldNotTakeMoreThanLogN()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var expectedSearches = Math.Ceiling(Math.Log(expectedLength));
            var expectedIndex = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            // Act
            var actualIndex = array.FindBinary(testSet[expectedIndex]);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
            var actualSearches = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count();
            Assert.IsTrue(actualSearches <= expectedSearches + 2, "\n\nNawArrayOrdered.FindBinary(): De implementatie gebruikt teveel stappen om het eerste element te vinden middels binair zoeken.\n");
        }

        [TestMethod]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(1.0)]

        public void NawArrayOrdered_FindBinary_MiddleItem_ShouldNotTakeMoreThanLogN()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var expectedSearches = Math.Ceiling(Math.Log(expectedLength));
            var expectedIndex = 50;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            // Act
            var actualIndex = array.FindBinary(testSet[expectedIndex]);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
            var actualSearches = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count();
            Assert.IsTrue(actualSearches <= expectedSearches + 2, "\n\nNawArrayOrdered.FindBinary(): De implementatie gebruikt teveel stappen om het middelste element te vinden middels binair zoeken.\n");
        }

        #endregion BinarySearch

    }
    
}

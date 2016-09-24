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
    public class NawArrayUnorderedTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void NawArrayUnordered_TestInitialize()
        {
            Logger.Instance.ClearLog();
        }
        #endregion

        #region Constructor
        [TestMethod]
        public void NawArrayUnordered_Constructor_Size0_ThrowsException()
        {
            try
            {
                INawArrayUnordered array = new NawArrayUnordered(0);
                Assert.Fail("\n\nNawArrayUnordered: De constructor accepteert ten onrechte een initialSize van 0. \nTIP: De minimale grootte waarop de NawArrayUnordered geinitialiseerd mag worden zou 1 moeten zijn.\n");
            }
            catch (NawArrayUnorderedInvalidSizeException) { }
        }

        [TestMethod]
        public void NawArrayUnordered_Constructor_Size1000001_ThrowsException()
        {
            try
            {
                INawArrayUnordered array = new NawArrayUnordered(1000001);
                Assert.Fail("\n\nNawArrayUnordered: De constructor accepteert ten onrechte een te grote initialSize.\nTIP: De maximale grootte waarop de NawArrayUnordered geinitialiseerd mag worden zou 1.000.000 moeten zijn.\n");
            }
            catch (NawArrayUnorderedInvalidSizeException) { }
        }
        #endregion

        #region Add
        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        public void NawArrayUnordered_Add_FillWholeArray_ShouldFit()
        {
            // Arrange
            var expectedSize = 10;
            var expectedNaws = RandomNawGenerator.NewArray(expectedSize);

            var array = new NawArrayUnordered(expectedSize);

            // Act
            for (int i = 0; i < expectedSize; i++)
            {
                try
                {
                    array.Add(expectedNaws[i]);
                    Assert.AreEqual(i + 1, array.Count, "\n\nNawArrayUnordered.Add(): Het aantal elementen in de array komt niet overeen met het aantal toegevoegde items.");
                }
                catch (NawArrayUnorderedOutOfBoundsException)
                {
                    // Assert
                    Assert.Fail("\n\nNawArrayUnordered.Add(): Er konden maar {0} NAW-objecten aan een array die met omvang {1} is geinitialiseerd worden toegevoegd", i, expectedSize);
                }
            }
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        public void NawArrayUnordered_Add_OneTooMany_ShouldThrowException()
        {
            // Arrange
            NAW[] testSet;
            var array = InitializeTestsubject(3, 3, out testSet);
            var oneTooMany = RandomNawGenerator.New();

            // Act
            try
            {
                array.Add(oneTooMany);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(NawArrayUnorderedOutOfBoundsException),
                    "\n\nNawArrayUnordered.Add(): Toevoegen van 11e element aan array met omvang van 10 geeft geen exceptie.");
            }
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        public void NawArrayUnordered_Add_Valid_ShouldAddAtTheEnd()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 5;
            var array = InitializeTestsubject(10, expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            array.Add(newNaw);

            // Assert
            Assert.AreEqual(expectedLength + 1, array.Count);

            // Niets is overschreven
            for (var i = 0; i < testSet.Length; i++)
            {
                Assert.AreEqual(testSet[i], array.Array[i], "\n\nNawArrayUnordered.Add(): Bij het toevoegen aan de array is item {0} onterecht overschreven.", i);
            }
            // Aan het einde toegevoegd
            Assert.AreEqual(newNaw, array.Array[expectedLength], "\n\nNawArrayUnordered.Add(): Bij het toevoegen aan de array is de nieuwe item niet aan het einde ingevoegd.");
        }

        #endregion

        #region FindNaam
        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        public void NawArrayUnordered_FindNaam_NaamNotInArray_ReturnsMin1()
        {
            // Arrange
            var expectedNaam = "ExpectedNaam";
            NAW[] testSet;
            var array = InitializeTestsubject(5, 5, out testSet, maxStringLenght: 5);

            // Act
            var result = array.FindNaam(expectedNaam);

            // Assert
            Assert.AreEqual(-1, result, "\n\nNawArrayUnordered.FindNaam(): Naam \"{0}\" zit niet in de array dus moet bij FindNaam -1 teruggeven", expectedNaam);
            Assert.AreEqual(array.Count, Logger.Instance.LogItems.Count());
        }

        [TestMethod]
        [AantalPuntenAlsSlaagt(1.0)]
        public void NawArrayUnordered_FindNaam_NaamTwiceInArray_ReturnsFirstIndex()
        {
            // Arrange
            var expectedNaam = "ExpectedNaam";
            var expectedIndex = 2;
            NAW[] testSet;
            var array = InitializeTestsubject(5, 5, out testSet, maxStringLenght: 5);

            testSet[expectedIndex].Naam = expectedNaam;
            testSet[testSet.Length - 1].Naam = expectedNaam;

            // Act
            var result = array.FindNaam(expectedNaam);

            // Assert
            Assert.AreEqual(expectedIndex, result, "NawArrayUnordered.FindNaam(): Naam \"{0}\" zit op index {1} in de array dus moet bij FindNaam {1} teruggeven", expectedNaam, expectedIndex);
            Assert.AreEqual(expectedIndex + 1 /* + 1 because arrays are zero based */, Logger.Instance.LogItems.Count());
        }

        #endregion

        private static INawArrayUnordered InitializeTestsubject(int maxSize, int initialFilledSize, out NAW[] testSet, int? maxStringLenght = null)
        {
            testSet = RandomNawGenerator.NewArray(initialFilledSize);
            var array = new NawArrayUnordered(maxSize);

            Array.ForEach(testSet, naw => array.Add(naw));

            // We have to clear the log because adding to the array will cause the logger to log as well.
            Logger.Instance.ClearLog();
            return array;
        }
    }
}

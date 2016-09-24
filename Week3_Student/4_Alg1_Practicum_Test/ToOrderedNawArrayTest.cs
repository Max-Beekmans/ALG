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
    public class ToOrderedNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void ToOrderedNawArray_TestInitialize()
        {
            Logger.Instance.ClearLog();
        }
        #endregion

        #region ToNawArrayOrdered

        [TestMethod]
        [TestCategory("WS2 - Array - ToNawArrayOrdered")]
        [AantalPuntenAlsSlaagt(1.0)]

        public void NawArrayOrdered_ToNawOrdered_OrderedArray_ShouldHaveSameItems()
        {
            // Arrange
            NAW[] testSet;

            var expectedLength = 10;
            var itemsRemoved = 0;

            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);

            // Act
            var orderedArray = array.ToNawArrayOrdered();
            for (var i = 0; i < orderedArray.ItemCount(); i++ )
            {
                var indexToRemove = FindNaw(array, orderedArray.Array[i], expectedLength-itemsRemoved );
                array.RemoveAtIndex(indexToRemove);
                itemsRemoved++;
            }

            // Assert
            Assert.IsTrue(orderedArray.ItemCount() == expectedLength, "\n\nNawArrayUnordered.ToNawArrayOrdered(): De geordende array die wordt teruggegeven heeft een andere itemCount ({0}) dan de oorspronkelijke ongesorteerde array ({1}.\n", orderedArray.ItemCount(), expectedLength);
            Assert.IsTrue(array.ItemCount() == 0, "\n\nNawArrayUnordered.ToNawArrayOrdered(): De geordende array die wordt teruggegeven bevat niet alle elementen van de oorspronkelijke ongesorteerde array.\n");
        }

        int FindNaw(NawArrayUnordered array, NAW item, int maxIndex)
        {
            for (int i=0; i<maxIndex; i++)
            {
                if (array.Array[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        [TestMethod]
        [TestCategory("WS2 - Array - ToNawArrayOrdered")]
        [AantalPuntenAlsSlaagt(1.0)]
        public void NawArrayOrdered_ToNawOrdered_OrderedArray_ShouldBeOrdered()
        {
            // Arrange
            NAW[] testSet;

            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);

            // Act
            var orderedArray = array.ToNawArrayOrdered();

            // Assert
            Assert.IsTrue(orderedArray.CheckIsGesorteerd(), "\n\nNawArrayUnordered.ToNawArrayOrdered(): De geordende array die wordt teruggegeven is niet correct geordend.\n");
        }

        #endregion ToNawOrdered
    }
    
}

﻿using Alg1_Practicum;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Alg1_Practicum_PerformanceTests
{
    [TestClass]
    public class SelectionSortPerformanceTest
    {
        #region Initialize

        [TestInitialize]
        public void TestInitialize()
        {
            Logger.Instance.Enabled = false;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Logger.Instance.Enabled = true;
        }

        #endregion Initialize

        [TestMethod]
        public void SelectionSortNawArray_100Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var array = ArrayExtensions.InitializeTestSubject(new SelectionSortNawArray(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            array.SelectionSort();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        [TestMethod]
        public void SelectionSortNawArray_1000Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 1000;
            var array = ArrayExtensions.InitializeTestSubject(new SelectionSortNawArray(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            array.SelectionSort();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        [TestMethod]
        public void SelectionSortNawArray_10000Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10000;
            var array = ArrayExtensions.InitializeTestSubject(new SelectionSortNawArray(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            array.SelectionSort();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        [TestMethod]
        [Ignore]
        public void SelectionSortNawArray_100000Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100000;
            var array = ArrayExtensions.InitializeTestSubject(new SelectionSortNawArray(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            array.SelectionSort();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(array.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        private static void PrintOutput(int expectedLength, Stopwatch stopwatch)
        {
            Console.WriteLine("Elapsed time with {0} items: {1:ss\\.fffffff} seconds", expectedLength, stopwatch.Elapsed);
        }
    }
}

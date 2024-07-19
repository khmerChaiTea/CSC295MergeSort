using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSC295MergeSort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC295MergeSort.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void BubbleSort_UnSortedArray_ArrayShouldToBeSorted()
        {
            // AAA - Arrange, Act, Assert // Arrange - setting the test up
            int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            // Act - This is where you call the code you are wanting to test
            Program.BubbleSort(arr1);

            // Assert - is the outcome what you expected
            Assert.AreEqual(0, arr1[0]);
            Assert.AreEqual(100, arr1[arr1.Length - 1]);
            Assert.AreEqual(56, arr1[7]);
        }

        [TestMethod()]
        public void BubbleSort_EmptyArray_ShouldReturnEmptyArray()
        {
            // AAA - Arrange, Act, Assert // Arrange - setting the test up
            int[] arr1 = [];
            // Act - This is where you call the code you are wanting to test
            Program.BubbleSort(arr1);

            // Assert - is the outcome what you expected
            Assert.AreEqual(arr1, []);
        }

        [TestMethod()]
        public void BubbleSort_SortedArray_ArrayShouldToBeSorted()
        {
            // AAA - Arrange, Act, Assert // Arrange - setting the test up
            int[] arr1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act - This is where you call the code you are wanting to test
            int Iteration = Program.BubbleSort(arr1);

            // Assert - is the outcome what you expected
            Assert.AreEqual(arr1[0], 0);
            Assert.AreEqual(arr1[arr1.Length - 1], 10);
            Assert.AreEqual(arr1[7], 7);
            Assert.AreEqual(Iteration, 1);
        }

        [TestMethod()]
        public void SelectionSort_UnSortedArray_ArrayShouldBeSortedAsc()
        {
            int[] arrToTest = { 434, 2, 121, 43, 32, 1, 0, 78, 65, 56, 10, 8, 500, 6 };
            Program.SelectionSort(arrToTest);
            Assert.AreEqual(0, arrToTest[0]);
            Assert.AreEqual(500, arrToTest[arrToTest.Length - 1]);
            Assert.AreEqual(10, arrToTest[5]);
        }

        [TestMethod()]
        public void SelectionSort_EmptyArray_ShouldReturnEmptyArray()
        {
            // AAA - Arrange, Act, Assert // Arrange - setting the test up
            int[] arr1 = [];
            // Act - This is where you call the code you are wanting to test
            Program.SelectionSort(arr1);

            // Assert - is the outcome what you expected
            Assert.AreEqual([], arr1);
        }
    }
}
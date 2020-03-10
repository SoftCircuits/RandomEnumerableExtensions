// Copyright (c) 2019-2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftCircuits.RandomEnumerableExtensions;
using System.Collections.Generic;
using System.Linq;

namespace RandomEnumerableExtensions.Tests
{
    [TestClass]
    public class Tests
    {
        private const int MinValue = 1;
        private const int MaxValue = 100;

        [TestMethod]
        public void TestIEnumerable()
        {
            IEnumerable<int> list = Enumerable.Range(MinValue, MaxValue);

            // Get random values
            for (int i = 0; i < 100; i++)
            {
                int value = list.Random();
                Assert.IsTrue(value >= MinValue);
                Assert.IsTrue(value <= MaxValue);
            }

            // Shuffle list
            var list2 = list.Shuffle();
            Assert.AreNotEqual(list, list2);                            // IEnumerables are copied
            Assert.AreEqual(list.Count(), list2.Count());               // Same size
            Assert.AreEqual(list.Count(), list2.Distinct().Count());    // No duplicates
            Assert.IsFalse(list.SequenceEqual(list2));                  // Different order

            // Returns default on empty collection
            list = Enumerable.Empty<int>();
            Assert.IsTrue(list.Random() == default);

            // Returns default on null collection
            list = null;
            Assert.IsTrue(list.Random() == default);
        }

        [TestMethod]
        public void TestIList()
        {
            List<int> list = Enumerable.Range(MinValue, MaxValue).ToList();

            // Get random values
            for (int i = 0; i < 100; i++)
            {
                int value = list.Random();
                Assert.IsTrue(value >= MinValue);
                Assert.IsTrue(value <= MaxValue);
            }

            // Copy list
            var list2 = new List<int>(list);
            // Shuffle copy in place
            list2.Shuffle();
            Assert.AreEqual(list.Count(), list2.Count());               // Same size
            Assert.AreEqual(list.Count(), list2.Distinct().Count());    // No duplicates
            Assert.IsFalse(list.SequenceEqual(list2));                  // Different order

            // Returns default on empty collection
            list.Clear();
            Assert.IsTrue(list.Random() == default);

            // Returns default on null collection
            list = null;
            Assert.IsTrue(list.Random() == default);
        }
    }
}

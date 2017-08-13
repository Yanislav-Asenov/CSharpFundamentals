namespace BashSoft.Tests
{
    using System;
    using System.Collections.Generic;
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using NUnit.Framework;

    [TestFixture]
    public class OrderedDataStructureTests
    {
        private ISimpleOrderedBag<string> names;

        [Test]
        public void TestEmptyConstructor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(16, this.names.Capacity, "Empty constructor does not set correct default capacity.");
            Assert.AreEqual(0, this.names.Size, "Empty constructor does not set correct default size.");
        }

        [Test]
        public void TestConstructorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(20, this.names.Capacity, "Constructor with initial capacity does not set capacity.");
            Assert.AreEqual(0, this.names.Size, "Constructor with initial capacity does not set correct default size.");
        }

        [Test]
        public void TestConstructorWithAllParameters()
        {
            this.names = new SimpleSortedList<string>(30, StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(30, this.names.Capacity, "Constructor with all params does not set capacity");
            Assert.AreEqual(0, this.names.Size, "Constructor with all parameters does not set correct default size.");
        }

        [Test]
        public void TestConstructorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(16, this.names.Capacity, "Constructor with initial comparer does not set capacity.");
            Assert.AreEqual(0, this.names.Size, "Constructor with initial comparer does not set size.");
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Test element 1");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            this.names = new SimpleSortedList<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.names.Add(null);
            });
        }

        [Test]
        public void TestAddElementWhenCollectionCapacityIsFullShouldResize()
        {
            this.names = new SimpleSortedList<string>(1);
            this.names.Add("Test element 1");
            this.names.Add("Test element 2");

            Assert.AreEqual(2, this.names.Capacity);
        }

        [Test]
        public void TestAddUnsortedDataHeldSorted()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            var expected = new List<string>()
            {
                "Balkan",
                "Georgi",
                "Rosen"
            };

            CollectionAssert.AreEqual(expected, this.names);
        }

        [Test]
        public void TestAddAllIncreasesSize()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new List<string>()
            {
                "Test element 1",
                "Test element 2"
            });

            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddAllThrowsExceptionWhenNullIsProviededAsValue()
        {
            this.names = new SimpleSortedList<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.names.AddAll(null);
            });
        }

        [Test]
        public void TestAddAllKeepsCollectionSorted()
        {
            this.names = new SimpleSortedList<string>();
            this.names.AddAll(new List<string>()
            {
                "Rosen",
                "Georgi",
                "Balkan"
            });

            var expectedCollection = new List<string>()
            {
                "Balkan",
                "Georgi",
                "Rosen"
            };
            Assert.AreEqual(expectedCollection, this.names);
        }

        [Test]
        public void TestRemoveWithNullThrowsException()
        {
            this.names = new SimpleSortedList<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.names.Remove(null);
            });
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Test element 1");
            this.names.Add("Test element 2");

            this.names.Remove("Test element 1");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Test element 1");
            this.names.Add("Test element 2");
            this.names.Add("Test element 3");

            this.names.Remove("Test element 2");

            var expectedCollection = new List<string>()
            {
                "Test element 1",
                "Test element 3"
            };

            CollectionAssert.AreEqual(expectedCollection, this.names);
        }

        [Test]
        public void TestJoinWithNullThrowsException()
        {
            this.names = new SimpleSortedList<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.names.JoinWith(null);
            });
        }

        [Test]
        public void TestJoinWithWorksFineWithJoinerWithLengthOfOne()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Test element 1");
            this.names.Add("Test element 2");
            this.names.Add("Test element 3");

            string expected = "Test element 1_Test element 2_Test element 3";
            Assert.AreEqual(expected, this.names.JoinWith("_"));
        }

        [Test]
        public void TestJoinWithWorksFineWithJoinerWithLengthMoreThanOne()
        {
            this.names = new SimpleSortedList<string>();
            this.names.Add("Test element 1");
            this.names.Add("Test element 2");
            this.names.Add("Test element 3");

            string expected = "Test element 1__Test element 2__Test element 3";
            Assert.AreEqual(expected, this.names.JoinWith("__"));
        }
    }
}

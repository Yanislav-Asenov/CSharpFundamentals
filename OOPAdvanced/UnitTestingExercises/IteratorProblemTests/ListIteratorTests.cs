namespace IteratorProblemTests
{
    using IteratorProblem.Contracts;
    using IteratorProblem.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ListIteratorTests
    {
        private int[] arr;
        private IListIterator<int> listIterator;

        [SetUp]
        public void SetUp()
        {
            this.arr = new int[] { 1, 2, 3, 4 };
            this.listIterator = new ListIterator<int>(this.arr);
        }


        [Test]
        public void ShouldThrowExceptionWhenNullIsPassedToTheConstructor()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                IListIterator<int> listIterator = new ListIterator<int>(null);
            });
        }

        [Test]
        public void GetCurrentShouldThrowExceptionWhenEmpty()
        {
            int[] arr = new int[0];

            IListIterator<int> listIterator = new ListIterator<int>(arr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                int current = listIterator.GetCurrent();
            });
        }

        [Test]
        public void GetCurrentShouldWorkCorrectlyWithOneItemInTheCollection()
        {
            int[] arr = new int[] { 1 };

            IListIterator<int> listIterator = new ListIterator<int>(arr);

            Assert.AreEqual(1, listIterator.GetCurrent());
        }

        [Test]
        public void GetCurrentShouldWorkCorrectlyWithManyItemsInTheCollection()
        {
            Assert.AreEqual(1, this.listIterator.GetCurrent());
        }

        [Test]
        public void GetCurrentShouldWorkCorrectlyAfterMoveIsUsed()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.AreEqual(3, this.listIterator.GetCurrent());
        }

        [Test]
        public void HasNextShouldReturnTrueIfThereAreMoreItemsAvailable()
        {
            this.listIterator.Move();
            this.listIterator.Move();

            Assert.IsTrue(this.listIterator.HasNext());
        }

        [Test]
        public void HasNextShouldReturnFalseWhenTheCollectionHasNoItems()
        {
            listIterator.Move();
            listIterator.Move();
            listIterator.Move();

            Assert.IsFalse(this.listIterator.HasNext());
        }

        [Test]
        public void MoveNextShouldReturnFalseWhenThereAreNoMoreItems()
        {
            listIterator.Move();
            listIterator.Move();
            listIterator.Move();

            Assert.IsFalse(this.listIterator.Move());
        }

        [Test]
        public void MoveNextShouldReturnTrueWhenTheCollectionHasMoreItems()
        {
            listIterator.Move();
            listIterator.Move();

            Assert.IsTrue(this.listIterator.Move());
        }
    }
}
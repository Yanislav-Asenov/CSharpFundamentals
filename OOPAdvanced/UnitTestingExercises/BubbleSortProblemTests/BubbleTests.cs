namespace BubbleSortProblemTests
{
    using BubbleSortProblem.Contracts;
    using BubbleSortProblem.Models;
    using NUnit.Framework;

    [TestFixture]
    public class BubbleTests
    {
        [Test]
        public void ShouldWorkCorrectlyWithOneElement()
        {
            IBubble bubble = new Bubble();
            int[] numbers = new int[] { 1 };

            bubble.Sort(numbers);

            Assert.AreEqual(1, numbers[0]);
        }

        [Test]
        public void ShouldWorkCorrectlyWithTwoElements()
        {
            IBubble bubble = new Bubble();
            int[] numbers = new int[] { 2, 1 };

            bubble.Sort(numbers);

            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(2, numbers[1]);
        }

        [Test]
        public void ShouldWorkCorrectlyWithAlreadySortedCollection()
        {
            IBubble bubble = new Bubble();
            int[] numbers = new int[] { 1, 2, 3, 4 };

            bubble.Sort(numbers);

            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(2, numbers[1]);
            Assert.AreEqual(3, numbers[2]);
            Assert.AreEqual(4, numbers[3]);
        }

        [Test]
        public void ShouldWorkCorrectlyWithCollectionSortedByDescending()
        {
            IBubble bubble = new Bubble();
            int[] numbers = new int[] { 4, 3, 2, 1 };

            bubble.Sort(numbers);

            Assert.AreEqual(1, numbers[0]);
            Assert.AreEqual(2, numbers[1]);
            Assert.AreEqual(3, numbers[2]);
            Assert.AreEqual(4, numbers[3]);
        }

        [Test]
        public void ShouldDoNothingWithEmptyCollection()
        {
            IBubble bubble = new Bubble();
            int[] numbers = new int[0];

            bubble.Sort(numbers);

            Assert.AreEqual(0, numbers.Length);
        }
    }
}
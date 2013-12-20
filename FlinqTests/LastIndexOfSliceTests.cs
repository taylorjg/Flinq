using System;
using NUnit.Framework;
using Flinq;

namespace FlinqTests
{
    [TestFixture]
    class LastIndexOfSliceTests
    {
        [Test]
        public void LastIndexOfSliceGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var that = Utils.EmptySequence<int>();
            //var comparer = EqualityComparer<int>.Default;

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that));
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that, 2));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));

            //var ex3 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that, comparer));
            //Assert.That(ex3.ParamName, Is.EqualTo("source"));

            //var ex4 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that, 2, comparer));
            //Assert.That(ex4.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void LastIndexOfSliceGivenNullThatSequenceThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            var that = Utils.NullSequence<int>();
            //var comparer = EqualityComparer<int>.Default;

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that));
            Assert.That(ex1.ParamName, Is.EqualTo("that"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that, 2));
            Assert.That(ex2.ParamName, Is.EqualTo("that"));

            //var ex3 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that, comparer));
            //Assert.That(ex3.ParamName, Is.EqualTo("that"));

            //var ex4 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOfSlice(that, 2, comparer));
            //Assert.That(ex4.ParamName, Is.EqualTo("that"));
        }

        [TestCase(1, new int[] { }, 10)]
        [TestCase(2, new[] { 3 }, 7)]
        [TestCase(3, new[] { 18 }, -1)]
        [TestCase(4, new[] { 3, 4, 5 }, 7)]
        [TestCase(5, new[] { 5, 5, 5 }, -1)]
        public void LastIndexOfSliceWorks(int dummy, int[] that, int expected)
        {
            var source = new[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            var actual = source.LastIndexOfSlice(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, new int[] { }, 10, 10)]
        [TestCase(2, new int[] { }, 0, 10)]
        [TestCase(3, new int[] { }, 5, 10)]
        [TestCase(4, new[] { 3 }, 10, 7)]
        [TestCase(5, new[] { 3 }, 6, 2)]
        [TestCase(6, new[] { 3, 4, 5 }, 10, 7)]
        [TestCase(7, new[] { 3, 4, 5 }, 0, -1)]
        [TestCase(8, new[] { 3, 4, 5 }, 6, 2)]
        [TestCase(9, new[] { 5, 5, 5 }, 10, -1)]
        [TestCase(10, new[] { 5, 5, 5 }, 0, -1)]
        [TestCase(11, new[] { 5, 5, 5 }, 5, -1)]
        public void LastIndexOfSpecifyingFromSliceWorks(int dummy, int[] that, int end, int expected)
        {
            var source = new[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            var actual = source.LastIndexOfSlice(that, end);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

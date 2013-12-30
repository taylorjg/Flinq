using System;
using System.Collections.Generic;
using System.Linq;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class IndexOfSliceTests
    {
        [Test]
        public void IndexOfSliceGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var that = Utils.EmptySequence<int>();
            var comparer = EqualityComparer<int>.Default;

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that));
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));

            var ex3 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, comparer));
            Assert.That(ex3.ParamName, Is.EqualTo("source"));

            var ex4 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0, comparer));
            Assert.That(ex4.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void IndexOfSliceGivenNullThatSequenceThrowsException()
        {
            var source = new[] { 1, 2, 3 };
            var that = Utils.NullSequence<int>();
            var comparer = EqualityComparer<int>.Default;

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that));
            Assert.That(ex1.ParamName, Is.EqualTo("that"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("that"));

            var ex3 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, comparer));
            Assert.That(ex3.ParamName, Is.EqualTo("that"));

            var ex4 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0, comparer));
            Assert.That(ex4.ParamName, Is.EqualTo("that"));
        }

        [TestCase(1, new int[] {}, 0)]
        [TestCase(2, new[] {1}, 0)]
        [TestCase(3, new[] {1, 2, 3}, 0)]
        [TestCase(4, new[] {4, 5, 6}, 3)]
        [TestCase(5, new[] {8, 9, 10}, 7)]
        [TestCase(6, new[] {5, 5, 5}, -1)]
        public void IndexOfSliceWhenSourceSequenceIsNotAListWorks(int dummy, int[] that, int expected)
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.ToEnumerable().IndexOfSlice(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, new int[] {}, 0)]
        [TestCase(2, new[] {1}, 0)]
        [TestCase(3, new[] {1, 2, 3}, 0)]
        [TestCase(4, new[] {4, 5, 6}, 3)]
        [TestCase(5, new[] {8, 9, 10}, 7)]
        [TestCase(6, new[] {5, 5, 5}, -1)]
        public void IndexOfSliceWhenSourceSequenceIsAListWorks(int dummy, int[] that, int expected)
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.ToList().IndexOfSlice(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, new[] {1, 2}, 2, 5)]
        [TestCase(2, new[] {2, 7}, 4, -1)]
        [TestCase(3, new[] {2, 7}, 100, -1)]
        [TestCase(4, new int[] {}, 4, 4)]
        [TestCase(5, new int[] {}, -100, 0)]
        public void IndexOfSliceWhenSourceSequenceIsNotAListSpecifyingFromWorks(int dummy, int[] that, int from, int expected)
        {
            var source = new[] {1, 1, 2, 7, 1, 1, 2, 3, 4, 5};
            var actual = source.ToEnumerable().IndexOfSlice(that, from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, new[] {1, 2}, 2, 5)]
        [TestCase(2, new[] {2, 7}, 4, -1)]
        [TestCase(3, new[] {2, 7}, 100, -1)]
        [TestCase(4, new int[] {}, 4, 4)]
        [TestCase(5, new int[] { }, -100, 0)]
        public void IndexOfSliceWhenSourceSequenceIsAListSpecifyingFromWorks(int dummy, int[] that, int from, int expected)
        {
            var source = new[] {1, 1, 2, 7, 1, 1, 2, 3, 4, 5};
            var actual = source.ToList().IndexOfSlice(that, from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IndexOfSliceGivenTrickyCaseWorks()
        {
            var source = new[] {1, 1, 2, 1, 1, 1, 2, 3, 4, 5};
            var that = new[] {1, 1, 1, 2};
            var actual = source.IndexOfSlice(that);
            Assert.That(actual, Is.EqualTo(3));
        }

        // TODO: add testcases using a non-default comparer...
    }
}

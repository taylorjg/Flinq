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

        [Test, TestCaseSource("TestCasesNotSpecifyingFrom")]
        public void IndexOfSliceWhenSourceSequenceIsNotAListWorks(int dummy, int[] source, int[] that, int expected)
        {
            var actual = source.ToEnumerable().IndexOfSlice(that.ToEnumerable());
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, TestCaseSource("TestCasesNotSpecifyingFrom")]
        public void IndexOfSliceWhenSourceSequenceIsAListWorks(int dummy, int[] source, int[] that, int expected)
        {
            var actual = source.ToList().IndexOfSlice(that.ToList());
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, TestCaseSource("TestCasesForNonEmptyThatSequenceSpecifyingFrom")]
        public void IndexOfSliceWhenSourceSequenceIsNotAListAndThatIsNotEmptySpecifyingFromWorks(int dummy, int[] source, int[] that, int from, int expected)
        {
            var actual = source.ToEnumerable().IndexOfSlice(that.ToEnumerable(), from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, TestCaseSource("TestCasesForEmptyThatSequenceSpecifyingFrom")]
        public void IndexOfSliceWhenSourceSequenceIsNotAListAndThatIsEmptySpecifyingFromWorks(int dummy, int[] source, int[] that, int from, int expected)
        {
            var actual = source.ToEnumerable().IndexOfSlice(that.ToEnumerable(), from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, TestCaseSource("TestCasesForNonEmptyThatSequenceSpecifyingFrom")]
        public void IndexOfSliceWhenSourceSequenceIsAListAndThatIsNotEmptySpecifyingFromWorks(int dummy, int[] source, int[] that, int from, int expected)
        {
            var actual = source.ToList().IndexOfSlice(that.ToList(), from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test, TestCaseSource("TestCasesForEmptyThatSequenceSpecifyingFrom")]
        public void IndexOfSliceWhenSourceSequenceIsAListAndThatIsEmptySpecifyingFromWorks(int dummy, int[] source, int[] that, int from, int expected)
        {
            var actual = source.ToList().IndexOfSlice(that.ToList(), from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static object[] TestCasesNotSpecifyingFrom
        {
            get
            {
                var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                return new object[]
                    {
                        new object[] {1, source, new int[] {}, 0},
                        new object[] {2, source, new[] {1}, 0},
                        new object[] {3, source, new[] {1, 2, 3}, 0},
                        new object[] {4, source, new[] {4, 5, 6}, 3},
                        new object[] {5, source, new[] {8, 9, 10}, 7},
                        new object[] {6, source, new[] {5, 5, 5}, -1}
                    };
            }
        }

        private static object[] TestCasesForNonEmptyThatSequenceSpecifyingFrom
        {
            get
            {
                var source = new[] {1, 1, 2, 7, 1, 1, 2, 3, 4, 5};
                var that = new[] {2, 7};
                return new object[]
                    {
                        new object[] {1, source, that, 0, 2},
                        new object[] {2, source, that, 2, 2},
                        new object[] {3, source, that, 4, -1},
                        new object[] {4, source, that, 100, -1},
                        new object[] {5, source, that, -100, 2}
                    };
            }
        }

        private static object[] TestCasesForEmptyThatSequenceSpecifyingFrom
        {
            get
            {
                var source = new[] {1, 1, 2, 7, 1, 1, 2, 3, 4, 5};
                var that = new int[] {};
                return new object[]
                    {
                        new object[] {1, source, that, 0, 0},
                        new object[] {2, source, that, 4, 4},
                        new object[] {3, source, that, 9, 9},
                        new object[] {4, source, that, 10, 10},
                        new object[] {5, source, that, 11, -1},
                        new object[] {6, source, that, 100, -1},
                        new object[] {7, source, that, -100, 0}
                    };
            }
        }

        // TODO: add testcases using a non-default comparer...
    }
}

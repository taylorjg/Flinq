using System;
//using System.Collections.Generic;
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

            //var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0));
            //Assert.That(ex2.ParamName, Is.EqualTo("source"));

            //var ex3 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, comparer));
            //Assert.That(ex3.ParamName, Is.EqualTo("source"));

            //var ex4 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0, comparer));
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

            //var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0));
            //Assert.That(ex2.ParamName, Is.EqualTo("that"));

            //var ex3 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, comparer));
            //Assert.That(ex3.ParamName, Is.EqualTo("that"));

            //var ex4 = Assert.Throws<ArgumentNullException>(() => source.IndexOfSlice(that, 0, comparer));
            //Assert.That(ex4.ParamName, Is.EqualTo("that"));
        }

        [Test]
        public void LastIndexOfSliceWorks()
        {
            var source = new[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            var that = new[] {3, 4, 5};
            var actual = source.LastIndexOfSlice(that);
            Assert.That(actual, Is.EqualTo(7));
        }
    }
}

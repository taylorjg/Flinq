using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class FlatMapTests
    {
        [Test]
        public void FlatMapGivenNullSourceSequenceThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().FlatMap<int, int>(_ => Utils.EmptySequence<int>()));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void FlatMapGivenNullFnThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new[] {1, 2, 3}.FlatMap<int, int>(null));
            Assert.That(ex.ParamName, Is.EqualTo("fn"));
        }

        [Test]
        public void FlatMapWorks()
        {
            var actual = new[] { 1, 2, 3 }.FlatMap(i => new[] {i, i, i});
            Assert.That(actual, Is.EqualTo(new[] {1, 1, 1, 2, 2, 2, 3, 3, 3}));
        }
    }
}

using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class SliceTests
    {
        [Test]
        public void SliceGivenNullSourceSequenceThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().Slice(0, 0));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void SliceWorks()
        {
            var actual = System.Linq.Enumerable.Range(1, 10).Slice(3, 6);
            Assert.That(actual, Is.EqualTo(new[] {4, 5, 6}));
        }
    }
}

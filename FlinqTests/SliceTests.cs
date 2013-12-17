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
            var source = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.Slice(0, 0));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void SliceWorks()
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.Slice(3, 6);
            Assert.That(actual, Is.EqualTo(new[] {4, 5, 6}));
        }
    }
}

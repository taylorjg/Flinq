using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class FoldLeftTests
    {
        [Test]
        public void FoldLeftGivenNullSourceSequenceThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().FoldLeft<int, int>(0, (_, __) => _));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void FoldLeftGivenNullFnThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.FoldLeft(0, null));
            Assert.That(ex.ParamName, Is.EqualTo("fn"));
        }

        [Test]
        public void FoldLeftWorks()
        {
            var actual = new[] { 1, 2, 3 }.FoldLeft(0, (b, a) => b + a);
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void FoldLeftWorks2()
        {
            var actual = new[] { 1, 2, 3 }.FoldLeft("XXX", (b, a) => b + System.Convert.ToString(a));
            Assert.That(actual, Is.EqualTo("XXX123"));
        }

        [Test]
        public void FoldLeftGivenAnEmptyListReturnsZ()
        {
            const int z = 42;
            var actual = System.Linq.Enumerable.Empty<int>().FoldLeft(z, (_, __) => 0);
            Assert.That(actual, Is.EqualTo(z));
        }
    }
}

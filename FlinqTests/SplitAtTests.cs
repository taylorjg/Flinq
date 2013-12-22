using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class SplitAtTests
    {
        [Test]
        public void IndexOfGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.SplitAt(42));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [TestCase(1, new[] {1, 2, 3, 4, 5}, 2, new[] {1, 2}, new[] {3, 4, 5})]
        [TestCase(2, new[] {1, 2, 3, 4, 5}, -100, new int[] {}, new[] {1, 2, 3, 4, 5})]
        [TestCase(3, new[] {1, 2, 3, 4, 5}, 100, new[] {1, 2, 3, 4, 5}, new int[] {})]
        [TestCase(4, new int[] {}, 2, new int[] {}, new int[] {})]
        public void SplitAtWorks(int dummy, int[] source, int n, int[] expectedList1, int[] expectedList2)
        {
            var actual = source.SplitAt(n);
            Assert.That(actual.Item1, Is.EqualTo(expectedList1));
            Assert.That(actual.Item2, Is.EqualTo(expectedList2));
        }
    }
}

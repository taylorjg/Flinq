using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class FoldRightTests
    {
        [Test]
        public void FoldRightWorks()
        {
            var actual = new[] { 1, 2, 3 }.FoldRight(0, (a, b) => a + b);
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void FoldRightWorks2()
        {
            var actual = new[] { 1, 2, 3 }.FoldRight("XXX", (a, b) => System.Convert.ToString(a) + b);
            Assert.That(actual, Is.EqualTo("123XXX"));
        }

        [Test]
        public void FoldRightGivenAnEmptyListReturnsZ()
        {
            const int z = 42;
            var actual = System.Linq.Enumerable.Empty<int>().FoldRight(z, (_, __) => 0);
            Assert.That(actual, Is.EqualTo(z));
        }
    }
}

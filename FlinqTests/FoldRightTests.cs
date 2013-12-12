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
            var actual = new[] { 1, 2, 3 }.FoldRight(0, (b, a) => b + a);
            Assert.That(actual, Is.EqualTo(1 + 2 + 3));
        }

        [Test]
        public void FoldRightWorks2()
        {
            var actual = new[] { 1, 2, 3 }.FoldRight(string.Empty, (a, b) => b + System.Convert.ToString(a));
            Assert.That(actual, Is.EqualTo("321"));
        }
    }
}

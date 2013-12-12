using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class FoldLeftTests
    {
        [Test]
        public void FoldLeftWorks()
        {
            var actual = new[] { 1, 2, 3 }.FoldLeft(0, (agg, i) => agg + i);
            Assert.That(actual, Is.EqualTo(1 + 2 + 3));
        }

        [Test]
        public void FoldLeftWorks2()
        {
            var actual = new[] { 1, 2, 3 }.FoldLeft(string.Empty, (agg, i) => agg + System.Convert.ToString(i));
            Assert.That(actual, Is.EqualTo("123"));
        }
    }
}

using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class SliceTests
    {
        [Test]
        public void SliceWorks()
        {
            var actual = System.Linq.Enumerable.Range(1, 10).Slice(3, 6);
            Assert.That(actual, Is.EqualTo(new[] {4, 5, 6}));
        }
    }
}

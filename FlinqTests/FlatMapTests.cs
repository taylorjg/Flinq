using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class FlatMapTests
    {
        [Test]
        public void FlatMapWorks()
        {
            var actual = new[] { 1, 2, 3 }.FlatMap(i => new[] {i, i, i});
            Assert.That(actual, Is.EqualTo(new[] {1, 1, 1, 2, 2, 2, 3, 3, 3}));
        }
    }
}

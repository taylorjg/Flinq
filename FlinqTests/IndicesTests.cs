using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class IndicesTests
    {
        [Test]
        public void IndicesWorks()
        {
            var actual = new[] { "A", "B", "C" }.Indices();
            Assert.That(actual, Is.InstanceOf<System.Collections.Generic.IEnumerable<int>>());
            Assert.That(actual, Is.EqualTo(new[] { 0, 1, 2 }));
        }

        [Test]
        public void IndicesLongWorks()
        {
            var actual = new[] { "A", "B", "C" }.IndicesLong();
            Assert.That(actual, Is.InstanceOf<System.Collections.Generic.IEnumerable<long>>());
            Assert.That(actual, Is.EqualTo(new[] { 0L, 1L, 2L }));
        }
    }
}

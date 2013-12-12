using System.Linq;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class MapTests
    {
        [Test]
        public void MapWorks()
        {
            var actual = new[] { 1, 2, 3 }.Map(i => i * i);
            Assert.That(actual, Is.EqualTo(new[] {1, 4, 9}));
        }

        [Test]
        public void MapYields()
        {
            var enumerableSpy = new EnumerableSpy<int>(new[] {1, 2, 3});

            var actual = enumerableSpy.Map(i => i * i);
            Assert.That(enumerableSpy.NumCallsToMoveNext, Is.EqualTo(0));

            Assert.That(actual.ElementAt(1), Is.EqualTo(4));
            Assert.That(enumerableSpy.NumCallsToMoveNext, Is.EqualTo(2));
        }
    }
}

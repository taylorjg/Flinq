using NUnit.Framework;
using Flinq;

namespace FlinqTests
{
    [TestFixture]
    internal class IsEmptyTests
    {
        [Test]
        public void IsEmptyReturnsTrueWhenGivenAnEmptyListOfValueType()
        {
            var actual = System.Linq.Enumerable.Empty<int>().IsEmpty();
            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsEmptyReturnsFalseWhenGivenANoneEmptyListOfValueType()
        {
            var actual = new[] {1, 2, 3}.IsEmpty();
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsEmptyReturnsTrueWhenGivenAnEmptyListOfReferenceType()
        {
            var actual = System.Linq.Enumerable.Empty<string>().IsEmpty();
            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsEmptyReturnsFalseWhenGivenANoneEmptyListOfReferenceType()
        {
            var actual = new[] {"A", "B", "C"}.IsEmpty();
            Assert.That(actual, Is.False);
        }
    }
}

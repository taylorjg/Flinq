using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class IndexWhereTests
    {
        [Test]
        public void IndexWhereGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.IndexWhere(_ => true));
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexWhere(_ => true, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void IndexWhereGivenNullPredicateThrowsException()
        {
            var source = Utils.EmptySequence<int>();

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.IndexWhere(null));
            Assert.That(ex1.ParamName, Is.EqualTo("p"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexWhere(null, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("p"));
        }

        [Test]
        public void IndexWhereWorks()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var actual = source.IndexWhere(n => n % 2 == 0 && n > 5);
            Assert.That(actual, Is.EqualTo(5));
        }

        [Test]
        public void IndexWhereSpecifyingFromWorks()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var actual = source.IndexWhere(n => n % 2 == 0, 6);
            Assert.That(actual, Is.EqualTo(7));
        }
    }
}

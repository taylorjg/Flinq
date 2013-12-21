using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class LastIndexWhereTests
    {
        [Test]
        public void LastIndexWhereGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.LastIndexWhere(_ => true));
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.LastIndexWhere(_ => true, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void LastIndexWhereGivenNullPredicateThrowsException()
        {
            var source = Utils.EmptySequence<int>();

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.LastIndexWhere(null));
            Assert.That(ex1.ParamName, Is.EqualTo("p"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.LastIndexWhere(null, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("p"));
        }

        [TestCase(1, 8)]
        [TestCase(2, 9)]
        [TestCase(3, -1)]
        public void LastIndexWhereWorks(int predicateNumber, int expected)
        {
            var source = new[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            Func<int, bool> predicate = null;

            switch (predicateNumber)
            {
                case 1:
                    predicate = n => n % 2 == 0;
                    break;

                case 2:
                    predicate = n => n % 2 == 1;
                    break;

                case 3:
                    predicate = n => n > 100;
                    break;
            }

            var actual = source.LastIndexWhere(predicate);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 9, 8)]
        [TestCase(2, 100, 8)]
        [TestCase(3, 4, 3)]
        public void LastIndexWhereSpecifyingEndWorks(int dummy, int end, int expected)
        {
            var source = new[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            var actual = source.LastIndexWhere(n => n < 5, end);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

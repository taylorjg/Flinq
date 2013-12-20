using System;
using Flinq;
using FlinqTests.Builders;
using FlinqTests.SampleDomainClasses;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class ContainsTests
    {
        [Test]
        public void ContainsGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.Contains(42));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [TestCase(1, 1, true)]
        [TestCase(2, 10, true)]
        [TestCase(3, 5, true)]
        [TestCase(4, 42, false)]
        public void ContainsWorks(int dummy, int elem, bool expected)
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var actual = source.Contains(elem);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 'L', true)]
        [TestCase(2, 'M', true)]
        [TestCase(3, 'S', false)]
        public void ContainsUsingExplicitComparerWorks(int dummy, char deskSize, bool expected)
        {
            var source = EmployeeCollectionBuilder.Build("LMLL");
            var elem = EmployeeCollectionBuilder.EmployeeWithDeskSize(deskSize);
            var actual = source.Contains(elem, new EmployeeDeskSizeComparer());
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

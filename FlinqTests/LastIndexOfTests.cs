using System;
using Flinq;
using System.Collections.Generic;
using FlinqTests.Builders;
using FlinqTests.SampleDomainClasses;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class LastIndexOfTests
    {
        [Test]
        public void LastIndexOfGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var comparer = EqualityComparer<int>.Default;

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOf(42));
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOf(42, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));

            var ex3 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOf(42, comparer));
            Assert.That(ex3.ParamName, Is.EqualTo("source"));

            var ex4 = Assert.Throws<ArgumentNullException>(() => source.LastIndexOf(42, 0, comparer));
            Assert.That(ex4.ParamName, Is.EqualTo("source"));
        }

        [TestCase(1, 5, 9)]
        [TestCase(2, 1, 5)]
        [TestCase(3, 11, -1)]
        public void LastIndexOfWorks(int dummy, int elem, int expected)
        {
            var source = new[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            var actual = source.LastIndexOf(elem);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 5, 9, 9)]
        [TestCase(2, 5, 100, 9)]
        [TestCase(3, 4, 5, 3)]
        [TestCase(3, 11, 9, -1)]
        public void LastIndexOfSpecifiyingEndWorks(int dummy, int elem, int end, int expected)
        {
            var source = new[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            var actual = source.LastIndexOf(elem, end);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 'L', 4, 4)]
        [TestCase(2, 'L', 100, 4)]
        [TestCase(3, 'M', 4, -1)]
        [TestCase(4, 'S', 4, 3)]
        [TestCase(5, 'S', 2, 1)]
        public void LastIndexOfUsingExplicitComparerWorks(int dummy, char deskSize, int end, int expected)
        {
            var source = EmployeeCollectionBuilder.Build("LSLSL");
            var elem = EmployeeCollectionBuilder.EmployeeWithDeskSize(deskSize);
            var actual = source.LastIndexOf(elem, end, new EmployeeDeskSizeComparer());
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

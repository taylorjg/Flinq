using System;
using System.Collections.Generic;
using Flinq;
using FlinqTests.Builders;
using FlinqTests.SampleDomainClasses;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class IndexOfTests
    {
        [Test]
        public void IndexOfGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var comparer = EqualityComparer<int>.Default;

            var ex1 = Assert.Throws<ArgumentNullException>(() => source.IndexOf(42));
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => source.IndexOf(42, 0));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));

            var ex3 = Assert.Throws<ArgumentNullException>(() => source.IndexOf(42, comparer));
            Assert.That(ex3.ParamName, Is.EqualTo("source"));

            var ex4 = Assert.Throws<ArgumentNullException>(() => source.IndexOf(42, 0, comparer));
            Assert.That(ex4.ParamName, Is.EqualTo("source"));
        }

        [TestCase(1, 1, 0)]
        [TestCase(2, 4, 3)]
        [TestCase(3, 11, -1)]
        public void IndexOfWorks(int dummy, int elem, int expected)
        {
            var source = new[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            var actual = source.IndexOf(elem);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 1, 0, 0)]
        [TestCase(2, 1, 2, 5)]
        [TestCase(3, 11, 0, -1)]
        [TestCase(4, 3, 100, -1)]
        public void IndexOfSpecifiyingFromWorks(int dummy, int elem, int from, int expected)
        {
            var source = new[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            var actual = source.IndexOf(elem, from);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, 'L', 0, 0)]
        [TestCase(2, 'M', 0, -1)]
        [TestCase(3, 'S', 0, 3)]
        [TestCase(4, 'L', 3, 4)]
        public void IndexOfUsingExplicitComparerWorks(int dummy, char deskSize, int from, int expected)
        {
            var source = EmployeeCollectionBuilder.Build("LLLSL");
            var elem = EmployeeCollectionBuilder.EmployeeWithDeskSize(deskSize);
            var actual = source.IndexOf(elem, from, new EmployeeDeskSizeComparer());
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

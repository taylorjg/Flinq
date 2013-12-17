using System;
using Flinq;
using FlinqTests.Builders;
using FlinqTests.SampleDomainClasses;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class ContainsSliceTests
    {
        [Test]
        public void ContainsSliceGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var that = Utils.EmptySequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.ContainsSlice(that));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void ContainsSliceGivenNullThatSequenceThrowsException()
        {
            var source = new[] {1, 2, 3};
            var that = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.ContainsSlice(that));
            Assert.That(ex.ParamName, Is.EqualTo("that"));
        }

        [TestCase(1, new int[] {}, true)]
        [TestCase(2, new[] {1, 2, 3}, true)]
        [TestCase(3, new[] {4, 5, 6}, true)]
        [TestCase(4, new[] {8, 9, 10}, true)]
        [TestCase(5, new[] {5, 5, 5}, false)]
        public void ContainsSliceWorks(int dummy, int[] that, bool expected)
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.ContainsSlice(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, "", true)]
        [TestCase(2, "LMS", true)]
        [TestCase(3, "MSL", true)]
        [TestCase(4, "LLL", true)]
        [TestCase(5, "SSL", false)]
        public void ContainsSliceUsingAnExplicitComparerWorks(int dummy, string deskSizes, bool expected)
        {
            var source = EmployeeCollectionBuilder.Build("LMSLLL");
            var that = EmployeeCollectionBuilder.Build(deskSizes);
            var actual = source.ContainsSlice(that, new EmployeeDeskSizeComparer());
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

using System;
using Flinq;
using FlinqTests.Builders;
using FlinqTests.SampleDomainClasses;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class EndsWithTests
    {
        [Test]
        public void EndsWithGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var that = Utils.EmptySequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.EndsWith(that));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void EndsWithGivenNullThatSequenceThrowsException()
        {
            var source = new[] {1, 2, 3};
            var that = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.EndsWith(that));
            Assert.That(ex.ParamName, Is.EqualTo("that"));
        }

        [TestCase(1, new int[] {}, true)]
        [TestCase(2, new[] {10}, true)]
        [TestCase(3, new[] {8, 9, 10}, true)]
        [TestCase(4, new[] {4}, false)]
        [TestCase(5, new[] {4, 5, 6}, false)]
        public void EndsWithGivenANonEmptySequenceWorks(int dummy, int[] that, bool expected)
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.EndsWith(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, new int[] {}, true)]
        [TestCase(2, new[] {10}, false)]
        [TestCase(3, new[] {8, 9, 10}, false)]
        [TestCase(4, new[] {4}, false)]
        [TestCase(5, new[] {4, 5, 6}, false)]
        public void EndsWithGivenAnEmptySequenceWorks(int dummy, int[] that, bool expected)
        {
            var source = Utils.EmptySequence<int>();
            var actual = source.EndsWith(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, "", true)]
        [TestCase(2, "MSL", true)]
        [TestCase(3, "SSL", false)]
        public void EndsWithUsingAnExplicitComparerWorks(int dummy, string deskSizes, bool expected)
        {
            var source = EmployeeCollectionBuilder.Build("LLLMSL");
            var that = EmployeeCollectionBuilder.Build(deskSizes);
            var actual = source.EndsWith(that, new EmployeeDeskSizeComparer());
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

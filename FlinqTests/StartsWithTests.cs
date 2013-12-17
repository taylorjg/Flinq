using System;
using Flinq;
using FlinqTests.Builders;
using FlinqTests.SampleDomainClasses;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class StartsWithTests
    {
        [Test]
        public void StartsWithGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var that = Utils.EmptySequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.StartsWith(that));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void StartsWithGivenNullThatSequenceThrowsException()
        {
            var source = new[] {1, 2, 3};
            var that = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.StartsWith(that));
            Assert.That(ex.ParamName, Is.EqualTo("that"));
        }

        [TestCase(1, new int[] {}, true)]
        [TestCase(2, new[] {1}, true)]
        [TestCase(3, new[] {1, 2, 3}, true)]
        [TestCase(4, new[] {4}, false)]
        [TestCase(5, new[] {4, 5, 6}, false)]
        public void StartsWithGivenANonEmptySequenceWorks(int dummy, int[] that, bool expected)
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.StartsWith(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, new int[] {}, true)]
        [TestCase(2, new[] {1}, false)]
        [TestCase(3, new[] {1, 2, 3}, false)]
        [TestCase(4, new[] {4}, false)]
        [TestCase(5, new[] {4, 5, 6}, false)]
        public void StartsWithGivenAnEmptySequenceWorks(int dummy, int[] that, bool expected)
        {
            var source = Utils.EmptySequence<int>();
            var actual = source.StartsWith(that);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, "", true)]
        [TestCase(2, "LMS", true)]
        [TestCase(3, "LLL", false)]
        public void StartsWithUsingAnExplicitComparerWorks(int dummy, string deskSizes, bool expected)
        {
            var source = EmployeeCollectionBuilder.Build("LMSLLL");
            var that = EmployeeCollectionBuilder.Build(deskSizes);
            var actual = source.StartsWith(that, new EmployeeDeskSizeComparer());
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

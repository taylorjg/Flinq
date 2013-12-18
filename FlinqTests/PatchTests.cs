using System;
using System.Linq;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class PatchTests
    {
        // ReSharper disable ReturnValueOfPureMethodIsNotUsed

        [Test]
        public void PatchGivenNullSourceSequenceThrowsException()
        {
            var source = Utils.NullSequence<int>();
            var patch = new[] {1, 2, 3};
            var ex = Assert.Throws<ArgumentNullException>(() => source.Patch(0, patch, 0).ToList());
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void PatchGivenNullPatchSequenceThrowsException()
        {
            var source = new[] {1, 2, 3};
            var patch = Utils.NullSequence<int>();
            var ex = Assert.Throws<ArgumentNullException>(() => source.Patch(0, patch, 0).ToList());
            Assert.That(ex.ParamName, Is.EqualTo("patch"));
        }

        [Test]
        public void PatchDisposesOfTheEnumerator()
        {
            var source = Utils.EmptySequence<int>();
            var patch = Utils.EmptySequence<int>();
            var enumerableSpy = new EnumerableSpy<int>(source);
            enumerableSpy.Patch(0, patch, 0).ToList();
            Assert.That(enumerableSpy.NumCallsToDispose, Is.EqualTo(1));
        }

        [TestCase(3, new[] { 10, 11, 12 }, 2, new[] { 1, 2, 3, 10, 11, 12, 6, 7, 8, 9, 10 })]
        [TestCase(3, new[] {10, 11, 12}, 0, new[] {1, 2, 3, 10, 11, 12, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(0, new[] {10, 11, 12}, 2, new[] {10, 11, 12, 3, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(4, new int[] {}, 2, new[] {1, 2, 3, 4, 7, 8, 9, 10})]
        public void PatchGivenANonEmptySequenceWorks(int from, int[] patch, int replaced, int[] expected)
        {
            var source = System.Linq.Enumerable.Range(1, 10);
            var actual = source.Patch(from, patch, replaced);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(3, new[] {10, 11, 12}, 2, new[] {10, 11, 12})]
        [TestCase(3, new[] {10, 11, 12}, 0, new[] {10, 11, 12})]
        [TestCase(0, new[] {10, 11, 12}, 2, new[] {10, 11, 12})]
        [TestCase(4, new int[] {}, 2, new int[] {})]
        public void PatchGivenAnEmptySequenceWorks(int from, int[] patch, int replaced, int[] expected)
        {
            var source = Utils.EmptySequence<int>();
            var actual = source.Patch(from, patch, replaced);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

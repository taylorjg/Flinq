using System.Linq;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class PatchTests
    {
        [Test]
        public void PatchGivenNullSequenceThrowsException()
        {
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            Assert.Throws<System.ArgumentNullException>(() => Utils.NullSequence<int>().Patch(0, new[] { 1, 2, 3 }, 0).ToList());
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
        }

        [Test]
        public void PatchDisposesOfTheEnumerator()
        {
            var source = new int[] {};
            var enumerableSpy = new EnumerableSpy<int>(source);
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            enumerableSpy.Patch(0, new int[]{}, 0).ToList();
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            Assert.That(enumerableSpy.NumCallsToDispose, Is.EqualTo(1));
        }

        [TestCase(3, new[] { 10, 11, 12 }, 2, new[] { 1, 2, 3, 10, 11, 12, 6, 7, 8, 9, 10 })]
        [TestCase(3, new[] {10, 11, 12}, 0, new[] {1, 2, 3, 10, 11, 12, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(0, new[] {10, 11, 12}, 2, new[] {10, 11, 12, 3, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(4, new int[] {}, 2, new[] {1, 2, 3, 4, 7, 8, 9, 10})]
        public void PatchWorksGivenANonEmptySequence(int from, int[] that, int replaced, int[] expected)
        {
            var actual = System.Linq.Enumerable.Range(1, 10).Patch(from, that, replaced);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(3, new[] {10, 11, 12}, 2, new[] {10, 11, 12})]
        [TestCase(3, new[] {10, 11, 12}, 0, new[] {10, 11, 12})]
        [TestCase(0, new[] {10, 11, 12}, 2, new[] {10, 11, 12})]
        [TestCase(4, new int[] {}, 2, new int[] {})]
        public void PatchWorksGivenAnEmptySequence(int from, int[] that, int replaced, int[] expected)
        {
            var actual = System.Linq.Enumerable.Empty<int>().Patch(from, that, replaced);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class ReduceRightTests
    {
        // ReSharper disable ReturnValueOfPureMethodIsNotUsed

        [Test]
        public void ReduceRightGivenNullSourceSequenceThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().ReduceRight<int, int>((_, __) => _));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void ReduceRightGivenNullFnThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.ReduceRight<int, int>(null));
            Assert.That(ex.ParamName, Is.EqualTo("fn"));
        }

        [Test]
        public void ReduceRightDisposesOfTheEnumerator()
        {
            var source = new[] { 1, 2, 3 };
            var enumerableSpy = new EnumerableSpy<int>(source);
            enumerableSpy.ReduceRight<int, int>((_, __) => _);
            Assert.That(enumerableSpy.NumCallsToDispose, Is.EqualTo(1));
        }

        [Test]
        public void ReduceRightWorks()
        {
            var actual = new[] {1, 2, 3}.ReduceRight<int, int>((a, b) => a + b);
            Assert.That(actual, Is.EqualTo(6));
        }

        [Test]
        public void ReduceRightWorks2()
        {
            var actual = new[] { "A", "B", "C" }.ReduceRight<string, string>((a, b) => a + b);
            Assert.That(actual, Is.EqualTo("ABC"));
        }

        [Test]
        public void ReduceRightGivenAnEmptyListThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => System.Linq.Enumerable.Empty<string>().ReduceRight<string, string>((a, b) => a + b));
        }

        [Test]
        public void ReduceRightGivenAListContainingASingleElementReturnsThatElement()
        {
            var actual = new[] {"A"}.ReduceRight<string, string>((a, b) => a + b);
            Assert.That(actual, Is.EqualTo("A"));
        }
    }
}

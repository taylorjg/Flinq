using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class ReduceLeftTests
    {
        // ReSharper disable ReturnValueOfPureMethodIsNotUsed

        [Test]
        public void ReduceLeftGivenNullSourceSequenceThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().ReduceLeft<int, int>((_, __) => _));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void ReduceLeftGivenNullFnThrowsException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3 }.ReduceLeft<int, int>(null));
            Assert.That(ex.ParamName, Is.EqualTo("fn"));
        }

        [Test]
        public void ReduceLeftDisposesOfTheEnumerator()
        {
            var source = new[] {1, 2, 3};
            var enumerableSpy = new EnumerableSpy<int>(source);
            enumerableSpy.ReduceLeft<int, int>((_, __) => _);
            Assert.That(enumerableSpy.NumCallsToDispose, Is.EqualTo(1));
        }

        [Test]
        public void ReduceLeftWorks()
        {
            var actual = new[] { 1, 2, 3 }.ReduceLeft<int, int>((b, a) => b + a);
            Assert.That(actual, Is.EqualTo(1 + 2 + 3));
        }

        [Test]
        public void ReduceLeftWorks2()
        {
            var actual = new[] { "A", "B", "C" }.ReduceLeft<string, string>((b, a) => b + a);
            Assert.That(actual, Is.EqualTo("ABC"));
        }

        [Test]
        public void ReduceLeftGivenAnEmptyListThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => System.Linq.Enumerable.Empty<string>().ReduceLeft<string, string>((b, a) => b + a));
        }

        [Test]
        public void ReduceLeftGivenAListContainingASingleElementReturnsThatElement()
        {
            var actual = new[] {"A"}.ReduceLeft<string, string>((b, a) => b + a);
            Assert.That(actual, Is.EqualTo("A"));
        }
    }
}

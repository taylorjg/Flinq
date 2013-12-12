using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class ReduceLeftTests
    {
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
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<System.ArgumentException>(() => System.Linq.Enumerable.Empty<string>().ReduceLeft<string, string>((b, a) => b + a));
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void ReduceLeftGivenAListContainingASingleElementReturnsThatElement()
        {
            var actual = new[] {"A"}.ReduceLeft<string, string>((b, a) => b + a);
            Assert.That(actual, Is.EqualTo("A"));
        }
    }
}

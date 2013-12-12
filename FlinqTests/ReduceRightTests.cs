using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    public class ReduceRightTests
    {
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
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<System.ArgumentException>(() => System.Linq.Enumerable.Empty<string>().ReduceRight<string, string>((a, b) => a + b));
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void ReduceRightGivenAListContainingASingleElementReturnsThatElement()
        {
            var actual = new[] {"A"}.ReduceRight<string, string>((a, b) => a + b);
            Assert.That(actual, Is.EqualTo("A"));
        }
    }
}

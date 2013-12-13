using System;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class MkStringTests
    {
        [Test]
        public void MkStringGivenNullSequenceThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().MkString());
            Assert.That(ex1.ParamName, Is.EqualTo("source"));

            var ex2 = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().MkString("sep"));
            Assert.That(ex2.ParamName, Is.EqualTo("source"));

            var ex3 = Assert.Throws<ArgumentNullException>(() => Utils.NullSequence<int>().MkString("start", "sep", "end"));
            Assert.That(ex3.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void MkStringWithNoSepWorks()
        {
            var actual = new[] {1, 2, 3}.MkString();
            Assert.That(actual, Is.EqualTo("123"));
        }

        [Test]
        public void MkStringWithSepWorks()
        {
            var actual = new[] { 1, 2, 3 }.MkString("-");
            Assert.That(actual, Is.EqualTo("1-2-3"));
        }

        [Test]
        public void MkStringWithStartAndSepAndEndWorks()
        {
            var actual = new[] { 1, 2, 3 }.MkString("[", "-", "]");
            Assert.That(actual, Is.EqualTo("[1-2-3]"));
        }
    }
}

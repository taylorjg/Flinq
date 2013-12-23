using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class BufferTests
    {
        [Test]
        public void ConstructorWorksCorrectlyWhenEndIndexIsBeforeTheLastIndexOfSourceSequence()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var buffer = new Buffer<int>(source, 5);
            Assert.That(buffer.Count, Is.EqualTo(6));
            Assert.That(buffer.Items[0], Is.EqualTo(1));
            Assert.That(buffer.Items[1], Is.EqualTo(2));
            Assert.That(buffer.Items[2], Is.EqualTo(3));
            Assert.That(buffer.Items[3], Is.EqualTo(4));
            Assert.That(buffer.Items[4], Is.EqualTo(5));
            Assert.That(buffer.Items[5], Is.EqualTo(6));
        }

        [Test]
        public void ConstructorWorksCorrectlyWhenEndIndexIsSameAsTheLastIndexOfSourceSequence()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var buffer = new Buffer<int>(source, 4);
            Assert.That(buffer.Count, Is.EqualTo(5));
            Assert.That(buffer.Items[0], Is.EqualTo(1));
            Assert.That(buffer.Items[1], Is.EqualTo(2));
            Assert.That(buffer.Items[2], Is.EqualTo(3));
            Assert.That(buffer.Items[3], Is.EqualTo(4));
            Assert.That(buffer.Items[4], Is.EqualTo(5));
        }

        [Test]
        public void ConstructorWorksCorrectlyWhenEndIndexIsAfterTheLastIndexOfSourceSequence()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var buffer = new Buffer<int>(source, 100);
            Assert.That(buffer.Count, Is.EqualTo(5));
            Assert.That(buffer.Items[0], Is.EqualTo(1));
            Assert.That(buffer.Items[1], Is.EqualTo(2));
            Assert.That(buffer.Items[2], Is.EqualTo(3));
            Assert.That(buffer.Items[3], Is.EqualTo(4));
            Assert.That(buffer.Items[4], Is.EqualTo(5));
        }
    }
}

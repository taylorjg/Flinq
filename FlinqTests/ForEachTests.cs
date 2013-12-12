﻿using System;
using System.Collections.Generic;
using Flinq;
using NUnit.Framework;

namespace FlinqTests
{
    [TestFixture]
    internal class ForEachTests
    {
        [Test]
        public void ForEachWorks()
        {
            var actual = new List<int>();
            new[] {1, 2, 3}.ForEach(actual.Add);
            Assert.That(actual, Is.EqualTo(new[] {1, 2, 3}));
        }

        [Test]
        public void ForEachWithIndexWorks()
        {
            var actual = new List<Tuple<string, int>>();
            new[] {1, 2, 3}.ForEach((a, index) => actual.Add(Tuple.Create(Convert.ToString(a), index)));
            Assert.That(actual, Is.EqualTo(new[]
                {
                    Tuple.Create("1", 0),
                    Tuple.Create("2", 1),
                    Tuple.Create("3", 2)
                }));
        }

        [Test]
        public void ForEachWithLongIndexWorks()
        {
            var actual = new List<Tuple<string, long>>();
            new[] {1, 2, 3}.ForEach((a, index) => actual.Add(Tuple.Create(Convert.ToString(a), index)));
            Assert.That(actual, Is.EqualTo(new[]
                {
                    Tuple.Create("1", 0L),
                    Tuple.Create("2", 1L),
                    Tuple.Create("3", 2L)
                }));
        }
    }
}

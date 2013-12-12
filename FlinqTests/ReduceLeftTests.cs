using System.Collections.Generic;
using System.Linq;
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

        //internal class Employee
        //{
        //    public Employee(string firstName, string lastName)
        //    {
        //        FirstName = firstName;
        //        LastName = lastName;
        //    }

        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //}

        //internal class Manager : Employee
        //{
        //    public Manager(string firstName, string lastName, params Employee[] directReports)
        //        : base(firstName, lastName)
        //    {
        //        DirectReports = directReports;
        //    }

        //    public Employee[] DirectReports { get; private set; }
        //}

        //[Test]
        //public void FoldLeftWorks2()
        //{
        //    var e1 = new Employee("Jim", "Khana");
        //    var e2 = new Employee("Percy", "Flage");
        //    var m1 = new Manager("Lara", "Croft", e1, e2);

        //    var employees = new[] {e1, e2, m1};
        //}
    }
}

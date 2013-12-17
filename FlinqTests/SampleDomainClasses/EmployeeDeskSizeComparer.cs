using System.Collections.Generic;

namespace FlinqTests.SampleDomainClasses
{
    internal class EmployeeDeskSizeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee e1, Employee e2)
        {
            return e1.DeskSize == e2.DeskSize;
        }

        public int GetHashCode(Employee obj)
        {
            throw new System.NotImplementedException();
        }
    }
}

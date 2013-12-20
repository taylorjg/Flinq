using System.Collections.Generic;
using System.Linq;
using FlinqTests.SampleDomainClasses;

namespace FlinqTests.Builders
{
    internal static class EmployeeCollectionBuilder
    {
        public static IEnumerable<Employee> Build(string deskSizes)
        {
            return deskSizes.Select(EmployeeWithDeskSize);
        }

        public static Employee EmployeeWithDeskSize(char c, int index = 1)
        {
            var firstName = string.Format("FirstName{0}", index + 1);
            var lastName = string.Format("LastName{0}", index + 1);
            var deskSize = CharToDeskSize(c);
            return new Employee(firstName, lastName, deskSize);
        }

        private static DeskSize CharToDeskSize(char c)
        {
            switch (c)
            {
                case 'S':
                    return DeskSize.Small;
                case 'M':
                    return DeskSize.Medium;
                default:
                    return DeskSize.Large;
            }
        }
    }
}

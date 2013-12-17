namespace FlinqTests.SampleDomainClasses
{
    internal class Employee
    {
        public Employee(string firstName, string lastName, DeskSize deskSize)
        {
            FirstName = firstName;
            LastName = lastName;
            DeskSize = deskSize;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DeskSize DeskSize { get; private set; }
    }
}

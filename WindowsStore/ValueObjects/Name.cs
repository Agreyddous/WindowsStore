namespace WindowsStore.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() => FirstName + " " + MiddleName + " " + LastName;
    }
}
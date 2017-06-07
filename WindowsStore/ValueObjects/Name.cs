using System.Runtime.Serialization;

namespace WindowsStore.ValueObjects
{
    [DataContract]
    public class Name
    {
        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        [DataMember]
        public string FirstName { get; private set; }
        [DataMember]
        public string MiddleName { get; private set; }
        [DataMember]
        public string LastName { get; private set; }

        public override string ToString() => FirstName + " " + MiddleName + " " + LastName;
    }
}
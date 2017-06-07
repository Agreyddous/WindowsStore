using System;
using System.Runtime.Serialization;

namespace WindowsStore.ValueObjects
{
    [DataContract]
    public class Birthday
    {
        public Birthday(DateTime date) => Date = date;

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
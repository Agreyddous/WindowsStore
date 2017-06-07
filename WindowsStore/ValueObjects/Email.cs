using System.Runtime.Serialization;

namespace WindowsStore.ValueObjects
{
    [DataContract]
    public class Email
    {
        public Email(string endereco) => Endereco = endereco;

        [DataMember]
        public string Endereco { get; private set; }
    }
}
using System.Runtime.Serialization;

namespace WindowsStore.ValueObjects
{
    [DataContract]
    public class Documents
    {
        public Documents(string cpf)
        {
            CPF = cpf;
        }

        [DataMember]
        public string CPF { get; private set; }
    }
}
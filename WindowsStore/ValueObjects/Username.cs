using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.ValueObjects
{
    [DataContract]
    public class Username
    {
        public Username(string name) => Name = name;

        [DataMember]
        private string Name;

        public override string ToString() => Name;
    }
}
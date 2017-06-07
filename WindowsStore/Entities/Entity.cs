using System;
using System.Runtime.Serialization;

namespace WindowsStore.Entities
{
    [DataContract]
    public class Entity
    {
        public Entity() => Id = Guid.NewGuid();

        [DataMember]
        public Guid Id { get; private set; }
    }
}
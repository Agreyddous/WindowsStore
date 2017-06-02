using System;

namespace WindowsStore.Entities
{
    public class Entity
    {
        public Entity() => Id = Guid.NewGuid();

        public Guid Id { get; private set; }
    }
}
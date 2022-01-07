using System;

namespace Library.Classes
{
    public abstract class Entity
    {
        public string Id { get; set; }
    }

    public abstract class EntityBase : Entity
    {
        public DateTime DateHourRegister { get; set; }
        public DateTime DateHourChange { get; set; }
    }
}

using Flunt.Notifications;
using System;

namespace DevStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}

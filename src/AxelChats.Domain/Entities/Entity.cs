using System;

namespace AxelChats.Domain.Entities
{
    public abstract record Entity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}

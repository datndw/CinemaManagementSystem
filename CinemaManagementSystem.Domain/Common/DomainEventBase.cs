using System;
using MediatR;

namespace CinemaManagementSystem.Domain.Common
{
    public abstract class DomainEventBase : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}


using System;
using CinemaManagementSystem.Domain.Common;

namespace CinemaManagementSystem.Domain.Interfaces
{
	public interface IDomainEventDispatcher
	{
        Task DispatchAndClearEvents(IEnumerable<BaseDomainEntity> entitiesWithEvents);
    }
}


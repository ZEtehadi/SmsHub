﻿using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Consumer.MediatorDtos.Queries;

namespace SmsHub.Application.Features.Consumer.Handlers.Queries.Contracts
{
    public interface IConsumerSafeIpGetSingleHandler
    {
        Task<GetConsumerSafaIpDto>  Handle(IntId Id);
    }
}

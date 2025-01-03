﻿using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Config.Queries.Contracts
{
    public interface IConfigTypeQueryService
    {
        Task<ICollection<ConfigType>> Get();
        Task<ConfigType> Get(short id);
    }
}

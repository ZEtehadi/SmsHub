﻿using SmsHub.Domain.Features.Entities;

namespace SmsHub.Persistence.Features.Contact.Queries.Contracts
{
    public interface IContactCategoryQueryService
    {
        Task<ICollection<ContactCategory>> Get();
        Task<ContactCategory> Get(int id);
    }
}

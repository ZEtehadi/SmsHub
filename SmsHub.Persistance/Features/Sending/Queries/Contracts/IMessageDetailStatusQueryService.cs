﻿using SmsHub.Domain.Features.Sending.Entities;

namespace SmsHub.Persistence.Features.Sending.Queries.Contracts
{
    public interface IMessageDetailStatusQueryService
    {
        Task<MessageDetailStatus> GetById(long Id);
        Task<MessageDetailStatus> GetByProviderServerId(long Id);
        Task<ICollection<MessageDetailStatus>> GetByMessageDetailId(long Id);
        Task<ICollection<MessageDetailStatus>> GetAll();
        Task<ICollection<MessageDetailStatus>> GetIncludeProviderResponseAndDelivery();
    }
}

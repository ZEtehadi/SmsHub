﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts
{
    public interface ISendManagerCreateHandler
    {
        Task<MobileText> Handle(int templateId,int lineId, CancellationToken cancellationToken);
    }
}
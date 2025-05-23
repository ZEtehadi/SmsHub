﻿using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Delete.Contracts
{
    public interface IMessageDetailStatusDeleteHandler
    {
        Task Handle(DeleteMessageDetailStatusDto request,CancellationToken cancellationToken);
    }
}

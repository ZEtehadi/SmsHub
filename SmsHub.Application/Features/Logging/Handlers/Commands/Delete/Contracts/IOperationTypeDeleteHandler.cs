﻿using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Delete;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Delete.Contracts
{
    public interface IOperationTypeDeleteHandler
    {
        Task Handle(DeleteOperationTypeDto deleteOperationTypeDto, CancellationToken cancellationToken);
    }
}
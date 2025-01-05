﻿namespace SmsHub.Application.Features.Auth.Handlers.Commands.Delete.Contracts
{
    public interface IUserTokenDeleteHandler
    {
        Task Handle(Guid userId, CancellationToken cancellationToken);
    }
}
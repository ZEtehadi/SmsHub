﻿using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Sending.Commands.Contracts;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using FluentValidation;

namespace SmsHub.Application.Features.Sending.Handlers.Commands.Create.Implementations
{
    public class MessageDetailCreateHandler : IMessageDetailCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IMessageDetailCommandService _messageDetailCommandService;
        private readonly IValidator<CreateMessageDetailDto> _validator;
        public MessageDetailCreateHandler(
            IMapper mapper,
            IMessageDetailCommandService messageDetailCommandService, 
            IValidator<CreateMessageDetailDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _messageDetailCommandService = messageDetailCommandService;
            _messageDetailCommandService.NotNull(nameof(_messageDetailCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateMessageDetailDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var messageDetail = _mapper.Map<Entities.MessagesDetail>(request);
            await _messageDetailCommandService.Add(messageDetail);
        }
    }
}

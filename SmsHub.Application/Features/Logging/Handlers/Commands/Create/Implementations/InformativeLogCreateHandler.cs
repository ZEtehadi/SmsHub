﻿using AutoMapper;
using SmsHub.Common.Extensions;
using Entities = SmsHub.Domain.Features.Entities;
using SmsHub.Persistence.Features.Logging.Commands.Contracts;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using FluentValidation;

namespace SmsHub.Application.Features.Logging.Handlers.Commands.Create.Implementations
{
    public class InformativeLogCreateHandler : IInformativeLogCreateHandler
    {
        private readonly IMapper _mapper;
        private readonly IInformativeLogCommandService _informativeLogCommandService;
        private readonly IValidator<CreateInformativeLogDto> _validator;
        public InformativeLogCreateHandler(
            IMapper mapper,
            IInformativeLogCommandService informativeLogCommandService, 
            IValidator<CreateInformativeLogDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(_mapper));

            _informativeLogCommandService = informativeLogCommandService;
            _informativeLogCommandService.NotNull(nameof(_informativeLogCommandService));

            _validator = validator;
            _validator.NotNull(nameof(_validator));
        }

        public async Task Handle(CreateInformativeLogDto request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new InvalidDataException();
            }

            var informativeLog = _mapper.Map<Entities.InformativeLog>(request);
            await _informativeLogCommandService.Add(informativeLog);
        }
    }
}

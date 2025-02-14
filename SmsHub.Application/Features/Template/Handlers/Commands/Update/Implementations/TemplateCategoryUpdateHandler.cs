﻿using AutoMapper;
using FluentValidation;
using SmsHub.Application.Exceptions;
using SmsHub.Application.Features.Template.Handlers.Commands.Update.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Template.MediatorDtos.Commands;
using SmsHub.Persistence.Features.Template.Queries.Contracts;

namespace SmsHub.Application.Features.Template.Handlers.Commands.Update.Implementations
{
    public class TemplateCategoryUpdateHandler : ITemplateCategoryUpdateHandler
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryQueryService _templateCategoryQueryService;
        private readonly IValidator<UpdateTemplateCategoryDto> _validator;
        public TemplateCategoryUpdateHandler(
            IMapper mapper,
            ITemplateCategoryQueryService templateCategoryQueryService,
            IValidator<UpdateTemplateCategoryDto> validator)
        {
            _mapper = mapper;
            _mapper.NotNull(nameof(mapper));

            _templateCategoryQueryService = templateCategoryQueryService;
            _templateCategoryQueryService.NotNull(nameof(templateCategoryQueryService));

            _validator = validator;
            _validator.NotNull(nameof(validator));
        }
        public async Task Handle(UpdateTemplateCategoryDto updateTemplateCategoryDto, CancellationToken cancellationToken)
        {
            await CheckValidator(updateTemplateCategoryDto, cancellationToken);


            var templateCategory = await _templateCategoryQueryService.Get(updateTemplateCategoryDto.Id);
            _mapper.Map(updateTemplateCategoryDto, templateCategory);
        }
        private async Task CheckValidator(UpdateTemplateCategoryDto updateMessageStateDto, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(updateMessageStateDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new FluentValidationException(message);
            }
        }

    }
}

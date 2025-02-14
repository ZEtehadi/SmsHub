﻿using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Validations
{
    public class PermittedTimeUpdateValidation : AbstractValidator<UpdatePermittedTimeDto>
    {
        public PermittedTimeUpdateValidation()
        {
            RuleFor(x => x.FromTime)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .Length(5).WithMessage(MessageResources.ItemEqual5)
                .Must(ValidationAnsiString.CheckTime).WithMessage(MessageResources.ItemByInvalidFormatTime)
                .Must(ValidationAnsiString.ValidateAnsi).WithMessage(MessageResources.ItemNotPersian);

            RuleFor(x => x.ToTime)
                .NotEmpty().WithMessage(MessageResources.ItemNotNull)
                .Length(5).WithMessage(MessageResources.ItemEqual5)
                .Must(ValidationAnsiString.ValidateAnsi).WithMessage(MessageResources.ItemNotPersian)
                .Must(ValidationAnsiString.CheckTime).WithMessage(MessageResources.ItemByInvalidFormatTime);
        }
    }
}

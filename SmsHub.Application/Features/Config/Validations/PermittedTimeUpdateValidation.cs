﻿using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class PermittedTimeUpdateValidation:AbstractValidator<UpdatePermittedTimeDto>
    {
        public PermittedTimeUpdateValidation()
        {
            RuleFor(x => x.FromTime).NotEmpty().Length(5).Must(ValidationAnsiString.Execute);
            RuleFor(x => x.ToTime).NotEmpty().Length(5).Must(ValidationAnsiString.Execute);
        }
    }
}
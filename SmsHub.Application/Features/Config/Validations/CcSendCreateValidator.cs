﻿using FluentValidation;
using SmsHub.Application.Common.Base;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create;

namespace SmsHub.Application.Features.Config.Validations
{
    internal class CcSendCreateValidator:AbstractValidator<CreateCcSendDto>
    {
        public CcSendCreateValidator()
        {
            RuleFor(x => x.Mobile).NotEmpty().Length(11)
                .Must(ValidationAnsiString.CheckPersianPhoneNumber);
        }
    }
}

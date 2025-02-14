﻿using SmsHub.Domain.Providers.Kavenegar.Entities.Base;
using SmsHub.Domain.Providers.Kavenegar.Entities.Responses;
using KaveRequest = SmsHub.Domain.Providers.Kavenegar.Entities.Requests;

namespace SmsHub.Infrastructure.Providers.Kavenegar.Http.Contracts
{
    public interface IKavenegarHttpSendSimpleService
    {
        Task<ResponseGeneric<SimpleSendDto>> Trigger(KaveRequest.SimpleSendDto simpleSendDto, string apiKey);
    }
}
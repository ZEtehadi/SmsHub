﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Features.Entities;
using SmsHub.Domain.Features.Sending.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Sending.Querries
{
    [Route(nameof(MessageStateCategory))]
    [ApiController]
    public class MessageStateCategoryGetSingleController : ControllerBase
    {
        private readonly IMessageStateCategoryGetSingleHandler _getSingleHandler;
        public MessageStateCategoryGetSingleController(IMessageStateCategoryGetSingleHandler getSingleHandler)
        {
            _getSingleHandler = getSingleHandler;
            _getSingleHandler.NotNull(nameof(getSingleHandler));
        }

        [HttpPost]
        [Route(nameof(GetSingle))]
        public async Task<GetMessageStateCategoryDto> GetSingle([FromBody] IntId Id)
        {
            var messageStateCategory = await _getSingleHandler.Handle(Id);
            return messageStateCategory;
        }
    }
}
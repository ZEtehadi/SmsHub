﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Sending.Handlers.Commands.Create.Contracts;
using SmsHub.Application.Features.Sending.Services;
using SmsHub.Application.Features.Template.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Sending.Commands.Create
{
    [ApiController]
    [Route("Send")]
    public class SendManagerCreateController : BaseController
    {
        private readonly ITemplateGetSingleHandler _templateGetSingleHandler;
        private readonly IUnitOfWork _uow;
        private readonly ISendManagerCreateHandler _sendManagerCreateHandler;
        public SendManagerCreateController(ITemplateGetSingleHandler templateGetSingleHandler,
            IUnitOfWork uow, ISendManagerCreateHandler sendManagerCreateHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _templateGetSingleHandler = templateGetSingleHandler;
            _templateGetSingleHandler.NotNull(nameof(templateGetSingleHandler));

            _sendManagerCreateHandler = sendManagerCreateHandler;
            _sendManagerCreateHandler.NotNull(nameof(sendManagerCreateHandler));
        }


        [HttpPost]
        [Route("SendManager/{templateId}/{lineId}")]
        public async Task<IActionResult> SendManager(int templateId,int lineId)
        {
           var mobileText= await _sendManagerCreateHandler.Handle(templateId,lineId, new CancellationToken());
            return Ok(mobileText);
        }

        [HttpPost]
        [Route("x")]
        public async Task<IActionResult> x(ICollection<MobileText> mobileText)
        {
            var s= MessageBatchFactory.Create(mobileText,1,"one");
            return Ok(s);
        }

    }
}
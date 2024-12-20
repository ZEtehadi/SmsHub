﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmsHub.Application.Features.Line.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Persistence.Contexts.UnitOfWork;
using System.ComponentModel;
using System.Diagnostics.Tracing;

namespace SmsHub.Api.Controllers.V1.Line.Commands.Create
{
    [Route(nameof(Line))]
    [ApiController]
    public class LineCreateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly ILineCreateHandler _createCommandHandler;
        public LineCreateController(
            IUnitOfWork uow,
            ILineCreateHandler createCommandHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _createCommandHandler = createCommandHandler;
            _createCommandHandler.NotNull(nameof(_createCommandHandler));
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateLineDto createDto, CancellationToken cancellationToken)
        {
            await _createCommandHandler.Handle(createDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(createDto);
        }

       
    }
}

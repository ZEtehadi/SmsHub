﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Config.Handlers.Commands.Update.Contracts;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Config.Handlers.Queries.Implementations;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Commands;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Commands.Update
{
    [Route("config")]
    [ApiController]
    [Authorize]
    public class ConfigUpdateController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfigUpdateHandler _updateCommandHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        private readonly IConfigTypeGroupGetSingleHandler _configTypeGroupGetSingleHandler;
        public ConfigUpdateController(
            IUnitOfWork uow,
            IConfigUpdateHandler updateCommandHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler,
            IConfigTypeGroupGetSingleHandler configTypeGroupGetSingleHandler)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _updateCommandHandler = updateCommandHandler;
            _updateCommandHandler.NotNull(nameof(updateCommandHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));


            _configTypeGroupGetSingleHandler = configTypeGroupGetSingleHandler;
            _configTypeGroupGetSingleHandler.NotNull(nameof(configTypeGroupGetSingleHandler));
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<UpdateConfigDto>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.Config + LogLevelMessageResources.UpdateDescription)]
        public async Task<IActionResult> Update([FromBody] UpdateConfigDto updateDto, CancellationToken cancellationToken)
        {
            IntId configTypeGroupId = updateDto.ConfigTypeGroupId;
            var configTypeGroup = await _configTypeGroupGetSingleHandler.Handle(configTypeGroupId);

            await _updateCommandHandler.Handle(updateDto, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(updateDto);
        }
    }
}

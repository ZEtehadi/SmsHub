﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Api.Attributes;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Application.Features.Logging.Handlers.Commands.Create.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Config.MediatorDtos.Queries;
using SmsHub.Persistence.Contexts.UnitOfWork;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route("config-type-group")]
    [ApiController]
    [Authorize]
    public class ConfigTypeGroupGetListController : BaseController
    {
        private readonly IConfigTypeGroupGetListHandler _getListHandler;
        private readonly IInformativeLogCreateHandler _informativeLogCreateHandler;
        private readonly IUnitOfWork _uow;

        public ConfigTypeGroupGetListController( 
            IConfigTypeGroupGetListHandler getListHandler,
            IInformativeLogCreateHandler informativeLogCreateHandler,
            IUnitOfWork uow)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));

            _informativeLogCreateHandler = informativeLogCreateHandler;
            _informativeLogCreateHandler.NotNull(nameof(informativeLogCreateHandler));

            _uow = uow;
            _uow.NotNull(nameof(uow));
        }

        [HttpPost]
        [Route("all")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<GetConfigTypeGroupDto>>), StatusCodes.Status200OK)]
        [InformativeLogFilter(LogLevelEnum.InternalOperation, LogLevelMessageResources.SendConfigSection, LogLevelMessageResources.ConfigTypeGroup+ LogLevelMessageResources.GetDescription)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken)
        {
            var configTypeGroups = await _getListHandler.Handle();
            await _uow.SaveChangesAsync(cancellationToken);
            return Ok(configTypeGroups);
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Logging.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Logging.MediatorDtos.Queries;

namespace SmsHub.Api.Controllers.V1.Logging.Querries
{
    [Route(nameof(LogLevel))]
    [ApiController]
    public class LogLevelGetListController : ControllerBase
    {
        private readonly ILogLevelGetListHandler _getListHandler;
        public LogLevelGetListController(ILogLevelGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<ICollection<GetLogLevelDto>> GetList()
        {
            var logLevels = await _getListHandler.Handle();
            return logLevels;
        }
    }
}
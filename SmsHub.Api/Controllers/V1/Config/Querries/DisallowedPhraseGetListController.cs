﻿using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Application.Features.Config.Handlers.Queries.Contracts;
using SmsHub.Common.Extensions;
using SmsHub.Domain.Features.Entities;

namespace SmsHub.Api.Controllers.V1.Config.Querries
{
    [Route(nameof(DisallowedPhrase))]
    [ApiController]
    public class DisallowedPhraseGetListController : BaseController
    {
        private readonly IDisallowedPhraseGetListHandler _getListHandler;
        public DisallowedPhraseGetListController(IDisallowedPhraseGetListHandler getListHandler)
        {
            _getListHandler = getListHandler;
            _getListHandler.NotNull(nameof(getListHandler));
        }

        [HttpPost]
        [Route(nameof(GetList))]
        public async Task<IActionResult> GetList()
        {
            var disallowedPhrases = await _getListHandler.Handle();
            return Ok(disallowedPhrases);
        }

    }
}

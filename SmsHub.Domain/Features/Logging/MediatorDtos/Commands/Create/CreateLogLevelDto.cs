﻿using SmsHub.Domain.Constants;

namespace SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Create
{
    public record CreateLogLevelDto  
    {
        public LogLevelEnum Id { get; set; }
        public string Title { get; set; } = null!;
        public string Css { get; set; } = null!;
    }
}

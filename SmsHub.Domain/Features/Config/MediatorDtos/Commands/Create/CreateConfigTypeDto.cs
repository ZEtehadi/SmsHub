﻿namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateConfigTypeDto  
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

﻿namespace SmsHub.Domain.Features.Config.MediatorDtos.Commands.Create
{
    public record CreateConfigTypeGroupDto  
    {
        public string? Title { get; init; } 
        public string? Description { get; init; } 
    }
}

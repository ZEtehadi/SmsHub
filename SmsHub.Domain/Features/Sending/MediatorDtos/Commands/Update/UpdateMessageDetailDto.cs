﻿namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Update
{
    public record UpdateMessageDetailDto  
    {
        public long Id { get; init; }
        public Guid MessagesHolderId { get; init; }
        public string Receptor { get; init; } = null!;
        public DateTime SendDateTime { get; init; }
        public string Text { get; init; } = null!;
        public short SmsCount { get; init; }
    }
}

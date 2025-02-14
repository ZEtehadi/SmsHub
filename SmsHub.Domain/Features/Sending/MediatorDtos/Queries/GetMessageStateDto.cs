﻿namespace SmsHub.Domain.Features.Sending.MediatorDtos.Queries
{
    public record GetMessageStateDto 
    {
        public long Id { get; init; }
        public int MessageStateCategoryId { get; init; }
        public long? MessagesDetailId { get; init; }
        public DateTime InsertDateTime { get; init; }

    }
}

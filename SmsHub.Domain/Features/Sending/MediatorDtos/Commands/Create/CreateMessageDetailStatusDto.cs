﻿namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessageDetailStatusDto
    {
        public DateTime InsertDateTime { get; set; }
        public long ProviderServerId { get; set; }
        public long MessagesDetailId { get; set; }
        public Guid MessagesHolderId { get; set; }
        public int ProviderDeliveryStatusId { get; set; }
        public int? ProviderResponseStatusId { get; set; }

    }
}

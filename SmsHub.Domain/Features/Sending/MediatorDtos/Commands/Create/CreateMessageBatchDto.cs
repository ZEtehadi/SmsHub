﻿using MediatR;

namespace SmsHub.Domain.Features.Sending.MediatorDtos.Commands.Create
{
    public record CreateMessageBatchDto
    {
        public int HolerSize { get; init; }
        public int AllSize { get; init; }
        public DateTime InsertDateTime { get; init; }
        public int LineId { get; init; }
    }
}
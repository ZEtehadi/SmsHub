﻿namespace SmsHub.Domain.Features.Security.Dtos
{
    public record FirstStepOutput
    {
        public string TempCode { get; set; } = default!;
        public Guid Id { get; set; }
        public int FromMin { get; set; }
        public FirstStepOutput(Guid id, int fromMin, string tempCode)
        {
            TempCode = tempCode;
            FromMin = fromMin;
            Id = id;
        }
    }
}

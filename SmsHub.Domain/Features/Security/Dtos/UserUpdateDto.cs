﻿namespace SmsHub.Domain.Features.Security.Dtos
{
    public record UserUpdateDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; } = null!;
        public string DisplayName { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string Mobile { get; init; } = null!;
        public ICollection<int> RoleIds { get; set; }
    }
}
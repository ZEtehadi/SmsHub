﻿namespace SmsHub.Domain.Features.Security.Dtos
{
    public class ApiSettings
    {
        public string LoginPath { get; set; } = default!;
        public string LogoutPath { get; set; } = default!;
        public string RefreshTokenPath { get; set; } = default!;
        public string AccessTokenObjectKey { get; set; } = default!;
        public string RefreshTokenObjectKey { get; set; } = default!;
        public string AdminRoleName { get; set; } = default!;
    }
}
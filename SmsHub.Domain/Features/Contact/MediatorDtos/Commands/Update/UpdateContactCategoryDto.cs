﻿using MediatR;

namespace SmsHub.Domain.Features.Contact.MediatorDtos.Commands
{
    public record UpdateContactCategoryDto : IRequest
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } 
        public string Css { get; init; } = null!;
    }
}
﻿namespace SmsHub.Domain.Features.Template.MediatorDtos.Queries
{
    public record GetTemplateDto 
    {
        public int Id { get; init; }
        public string Expression { get; init; } = null!;
        public string Title { get; init; } = null!;
        public int TemplateCategoryId { get; init; }
        public bool IsActive { get; init; }
        public string Parameters { get; init; } = null!;
        public int MinCredit { get; init; }
        public int ConfigTypeGroupId { get; set; }

    }
}

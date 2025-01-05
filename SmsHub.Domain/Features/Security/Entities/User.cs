﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Security.Entities;

[Table(nameof(User))]
public class User 
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public bool MobileConfirmed { get; set; }
    public bool HasTwoStepVerification { get; set; }
    public int InvalidLoginAttemptCount { get; set; }
    public string? SerialNumber { get; set; }
    public DateTime? LatestLoginDateTime { get; set; }
    public DateTime? LockTimespan { get; set; }
    public Guid? PreviousId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public string InsertLogInfo { get; set; } = default!;
    public string? RemoveLogInfo { get; set; }

    public virtual ICollection<User> InversePrevious { get; set; } = new List<User>();

    public virtual User? Previous { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
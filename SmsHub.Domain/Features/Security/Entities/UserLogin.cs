﻿using SmsHub.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsHub.Domain.Features.Security.Entities;

[Table(nameof(UserLogin))]
public class UserLogin
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public Guid? UserId { get; set; }
    public DateTime FirstStepDateTime { get; set; }
    public string Ip { get; set; } = null!;
    public bool FirstStepSuccess { get; set; }
    public string? WrongPassword { get; set; }
    public InvalidLoginReasonEnum? InvalidLoginReasonId { get; set; }
    public string AppVersion { get; set; } = null!;
    public string? TwoStepCode { get; set; }
    public DateTime? TwoStepExpireDateTime { get; set; }
    public DateTime? TwoStepInsertDateTime { get; set; }
    public bool? TwoStepWasSuccessful { get; set; }
    public bool PreviousFailureIsShown { get; set; }
    public DateTime? LogoutDateTime { get; set; }
    public LogoutReasonEnum? LogoutReasonId { get; set; }
    public string LogInfo { get; set; } = default!;


    public virtual User? User { get; set; }
    public virtual  InvalidLoginReason? InvalidLoginReason { get; set; }
    public virtual LogoutReason? LogoutReason { get; set; }  
}
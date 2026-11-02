using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime? PasswordChangedAt { get; set; }

    public int FailedLoginAttempts { get; set; }

    public int PasswordResetFailedAttempts { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public string? PasswordResetTokenHash { get; set; }

    public DateTime? PasswordResetExpiresAt { get; set; }

    public DateTime? PasswordResetLastSentAt { get; set; }

    public DateTime? PasswordResetBlockedUntil { get; set; }

    public bool MustChangePassword { get; set; }

    public virtual ICollection<KitchenOrderHistory> KitchenOrderHistories { get; set; } = new List<KitchenOrderHistory>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

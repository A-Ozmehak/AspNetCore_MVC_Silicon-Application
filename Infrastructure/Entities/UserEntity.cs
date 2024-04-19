﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData]
    public string? Bio { get; set; }

    [ProtectedPersonalData]
    public string? ProfileImage { get; set; } = "default-avatar.png";

    public ICollection<AddressEntity> Addresses { get; set; } = [];

    public bool IsAccountExternal { get; set; } = false;
}

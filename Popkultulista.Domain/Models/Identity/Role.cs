// <copyright file="Role.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;

namespace Popkultulista.Domain.Models.Identity;

/// <summary>
/// Temporary Role until Identity is added.
/// </summary>
public class Role : IdentityRole<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    public Role()
    {
    }
}
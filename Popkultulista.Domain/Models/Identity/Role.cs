// <copyright file="Role.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models.Identity;

/// <summary>
/// Temporary Role until Identity is added.
/// </summary>
public class Role
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    /// <param name="rolename">Name of a role.</param>
    public Role(string rolename)
    {
        this.RoleName = rolename;
    }

    /// <summary>
    /// Gets or sets the name of a role.
    /// </summary>
    public string RoleName { get; set; }
}
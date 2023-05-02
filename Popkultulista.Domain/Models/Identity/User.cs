// <copyright file="User.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models.Identity;

using System;

/// <summary>
/// A temporary User until Identity is added.
/// </summary>
public class User
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="username">Username of the user.</param>
    public User(string username)
    {
        this.Username = username;
    }

    /// <summary>
    /// Gets or sets an Id of a user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a username of a user.
    /// </summary>
    public string Username { get; set; }
}
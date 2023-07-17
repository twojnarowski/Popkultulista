// <copyright file="User.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models.Identity;

using System;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// A temporary User until Identity is added.
/// </summary>
public class User : IdentityUser<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    public User()
    {
    }

    /// <summary>
    /// Gets the <see cref="FomoVote"/>s made on this <see cref="FomoItem"/>.
    /// </summary>
    public ICollection<FomoVote> FomoVotes { get; } = null!;

    /// <summary>
    /// Gets the <see cref="Vote"/>s made on this <see cref="Item"/>.
    /// </summary>
    public ICollection<Vote> Votes { get; } = null!;
}
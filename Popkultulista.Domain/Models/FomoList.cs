// <copyright file="FomoList.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using Popkultulista.Domain.Models.Common;
using Popkultulista.Domain.Models.Identity;

/// <summary>
/// A class representing a list of <see cref="FomoItem"/>s.
/// </summary>
public class FomoList : NamedEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FomoList"/> class.
    /// </summary>
    /// <param name="user"><see cref="User"/> who owns this list.</param>
    public FomoList(User user)
        : base()
    {
        ArgumentNullException.ThrowIfNull(user);

        this.User = user;
        this.UserId = user.Id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FomoList"/> class.
    /// </summary>
    public FomoList()
        : base()
    {
    }

    /// <summary>
    /// Gets a collection of <see cref="FomoItem"/>s on this list.
    /// </summary>
    public ICollection<FomoItem> FomoItems { get; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="User"/> who made the <see cref="Vote"/>.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of a User who made this <see cref="Vote"/>.
    /// </summary>
    public Guid UserId { get; set; }
}
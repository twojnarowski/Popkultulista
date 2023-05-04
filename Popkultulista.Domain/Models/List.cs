// <copyright file="List.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models;

using System.Collections.Generic;
using Popkultulista.Domain.Models.Common;
using Popkultulista.Domain.Models.Identity;

/// <summary>
/// A class representing a list of items.
/// </summary>
public class List : NamedEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="List"/> class.
    /// </summary>
    /// <param name="isPrivate">Private or public <see cref="List"/>.</param>
    /// <param name="user"><see cref="User"/> who owns the list.</param>
    public List(bool isPrivate, User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        this.IsPrivate = isPrivate;
        this.User = user;
        this.UserId = user.Id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="List"/> class.
    /// </summary>
    public List()
        : base()
    {
    }

    /// <summary>
    /// Gets a collection of <see cref="Item"/>s on this list.
    /// </summary>
    public ICollection<Item> Items { get; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="List"/> is private to its owner.
    /// </summary>
    public bool IsPrivate { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="User"/> who made the <see cref="Vote"/>.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets the <see cref="Guid"/> of a User who made this <see cref="Vote"/>.
    /// </summary>
    public Guid UserId { get; set; }
}
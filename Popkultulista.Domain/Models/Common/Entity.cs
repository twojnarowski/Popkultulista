// <copyright file="Entity.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models.Common;

/// <summary>
/// A basic class for all entities that holds common properties.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <param name="createdBy">User which created or edited this object.</param>
    protected Entity(Guid createdBy)
    {
        this.CreatedAt = DateTime.Now;
        this.CreatedBy = createdBy;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    protected Entity()
    {
        this.CreatedAt = DateTime.Now;
        this.CreatedBy = Guid.Empty;
    }

    /// <summary>
    /// Gets or sets the Id of a record in the database.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the date at which this record was created or edited.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the user which created or edited this object.
    /// </summary>
    public Guid CreatedBy { get; set; }
}
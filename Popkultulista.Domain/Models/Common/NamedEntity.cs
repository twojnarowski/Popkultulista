// <copyright file="NamedEntity.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Models.Common;

/// <summary>
/// A class representing an <see cref="Entity"/> with a name.
/// </summary>
public abstract class NamedEntity : Entity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NamedEntity"/> class.
    /// </summary>
    /// <param name="name">Name of an <see cref="Entity"/>.</param>
    /// <param name="createdBy">User which created or edited this object.</param>
    protected NamedEntity(string name, Guid createdBy)
        : base(createdBy)
    {
        this.Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NamedEntity"/> class.
    /// </summary>
    /// <param name="name">Name of an <see cref="Entity"/>.</param>
    protected NamedEntity(string name)
        : base()
    {
        this.Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NamedEntity"/> class.
    /// </summary>
    protected NamedEntity()
        : base()
    {
        this.Name = string.Empty;
    }

    /// <summary>
    /// Gets or sets the name of an <see cref="Entity"/>.
    /// </summary>
    public string Name { get; set; }
}
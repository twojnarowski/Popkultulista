// <copyright file="Repository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// Base class for all repositories.
/// </summary>
public abstract class Repository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Repository"/> class with the specified database context.
    /// </summary>
    /// <param name="context">The database context for this repository.</param>
    protected Repository(Context context)
    {
        this.Context = context;
    }

    /// <summary>
    /// Gets the database context for this repository.
    /// </summary>
    protected Context Context { get; }
}
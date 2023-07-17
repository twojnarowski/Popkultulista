// <copyright file="IFomoListRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoList"/> repository.
/// </summary>
public interface IFomoListRepository : IRepository
{
    /// <summary>
    /// Adds a new <see cref="FomoList"/> to the database.
    /// </summary>
    /// <param name="fomoList">A new instance of <see cref="FomoList"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public Task AddFomoListAsync(FomoList fomoList, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a specific <see cref="FomoList"/> by given <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> of a <see cref="FomoList"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>An instance of an existing <see cref="FomoList"/>.</returns>
    public Task<FomoList> GetFomoListAsync(Guid fomoListId, CancellationToken cancellationToken);

    /// <summary>
    /// Removes an existing <see cref="FomoList"/> from the database.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> of a <see cref="FomoList"/> to be removed.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public Task DeleteFomoListAsync(Guid fomoListId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing <see cref="FomoList"/> in the database.
    /// </summary>
    /// <param name="fomoList">An updated <see cref="FomoList"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public Task UpdateFomoListAsync(FomoList fomoList, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the <see cref="FomoList"/> for a user.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <returns>A <see cref="FomoList"/>.</returns>
    public Task<FomoList> GetFomoListForUserAsync(Guid userId);

    /// <summary>
    /// Gets all <see cref="FomoList"/>s.
    /// </summary>
    /// <returns>A list of <see cref="FomoList"/>s.</returns>
    public Task<IQueryable<FomoList>> BrowseFomoListsAsync();
}
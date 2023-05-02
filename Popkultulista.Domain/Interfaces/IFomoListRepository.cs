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
    /// <returns>A completed task.</returns>
    public Task AddFomoListAsync(FomoList fomoList);

    /// <summary>
    /// Gets a specific <see cref="FomoList"/> by given <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> of a <see cref="FomoList"/>.</param>
    /// <returns>An instance of an existing <see cref="FomoList"/>.</returns>
    public Task GetFomoListAsync(Guid fomoListId);

    /// <summary>
    /// Removes an existing <see cref="FomoList"/> from the database.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> of a <see cref="FomoList"/> to be removed.</param>
    /// <returns>A completed task.</returns>
    public Task DeleteFomoListAsync(Guid fomoListId);

    /// <summary>
    /// Updates an existing <see cref="FomoList"/> in the database.
    /// </summary>
    /// <param name="fomoList">An updated <see cref="FomoList"/>.</param>
    /// <returns>A completed task.</returns>
    public Task UpdateFomoListAsync(FomoList fomoList);

    /// <summary>
    /// Gets all <see cref="FomoList"/>s for a user.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <returns>A list of <see cref="FomoList"/>s.</returns>
    public Task GetFomoListsForUserAsync(Guid userId);

    /// <summary>
    /// Gets all <see cref="FomoList"/>s.
    /// </summary>
    /// <returns>A list of <see cref="FomoList"/>s.</returns>
    public Task BrowseFomoListsAsync();
}
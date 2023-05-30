// <copyright file="IListRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="List"/> repository.
/// </summary>
public interface IListRepository : IRepository
{
    /// <summary>
    /// Adds a new <see cref="List"/> to the database.
    /// </summary>
    /// <param name="list">A new instance of <see cref="List"/>.</param>
    /// <returns>A completed task.</returns>
    public Task AddListAsync(List list);

    /// <summary>
    /// Gets a specific <see cref="List"/> by given <see cref="Guid"/>.
    /// </summary>
    /// <param name="listId"><see cref="Guid"/> of a <see cref="List"/>.</param>
    /// <returns>An instance of an existing <see cref="List"/>.</returns>
    public Task<List> GetListAsync(Guid listId);

    /// <summary>
    /// Removes an existing <see cref="List"/> from the database.
    /// </summary>
    /// <param name="listId"><see cref="Guid"/> of a <see cref="List"/> to be removed.</param>
    /// <returns>A completed task.</returns>
    public Task DeleteListAsync(Guid listId);

    /// <summary>
    /// Updates an existing <see cref="List"/> in the database.
    /// </summary>
    /// <param name="list">An updated <see cref="List"/>.</param>
    /// <returns>A completed task.</returns>
    public Task UpdateListAsync(List list);

    /// <summary>
    /// Gets all <see cref="List"/>s for a user.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <returns>A list of <see cref="List"/>s.</returns>
    public Task<IQueryable<List>> GetListsForUserAsync(Guid userId);

    /// <summary>
    /// Gets all <see cref="List"/>s.
    /// </summary>
    /// <returns>A list of <see cref="List"/>s.</returns>
    public Task<IQueryable<List>> BrowseListsAsync();
}
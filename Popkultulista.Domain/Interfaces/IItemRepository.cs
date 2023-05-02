// <copyright file="IItemRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="Item"/> repository.
/// </summary>
public interface IItemRepository : IRepository
{
    /// <summary>
    /// Gets one <see cref="Item"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="itemId"><see cref="Guid"/> if a <see cref="Item"/>.</param>
    /// <returns>An instance of <see cref="Item"/>.</returns>
    public Task GetItemAsync(Guid itemId);

    /// <summary>
    /// Gets all <see cref="Item"/>s from a <see cref="List"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="listId"><see cref="Guid"/> of a <see cref="List"/>.</param>
    /// <returns>A collection of <see cref="Item"/>s.</returns>
    public Task GetItemsFromListAsync(Guid listId);

    /// <summary>
    /// Adds one new <see cref="Item"/> to the database.
    /// </summary>
    /// <param name="item">A new instance of <see cref="Item"/>.</param>
    /// <returns>A completed task.</returns>
    public Task AddItemAsync(Item item);

    /// <summary>
    /// Removes one <see cref="Item"/> from the database.
    /// </summary>
    /// <param name="itemId"><see cref="Guid"/> of a <see cref="Item"/> to be removed.</param>
    /// <returns>A completed task.</returns>
    public Task DeleteItemAsync(Guid itemId);

    /// <summary>
    /// Updates an existing <see cref="Item"/> in the database.
    /// </summary>
    /// <param name="item">An instance of an edited <see cref="Item"/>.</param>
    /// <returns>A completed Task.</returns>
    public Task UpdateItemAsync(Item item);
}
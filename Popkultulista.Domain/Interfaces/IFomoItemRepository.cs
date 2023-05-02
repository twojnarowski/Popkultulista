// <copyright file="IFomoItemRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoItem"/> repository.
/// </summary>
public interface IFomoItemRepository : IRepository
{
    /// <summary>
    /// Gets one <see cref="FomoItem"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoItemId"><see cref="Guid"/> if a <see cref="FomoItem"/>.</param>
    /// <returns>An instance of <see cref="FomoItem"/>.</returns>
    public Task GetFomoItemAsync(Guid fomoItemId);

    /// <summary>
    /// Gets all <see cref="FomoItem"/>s from a <see cref="FomoList"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> if a <see cref="FomoList"/>.</param>
    /// <returns>A collection of <see cref="FomoItem"/>s.</returns>
    public Task GetFomoItemsFromFomoListAsync(Guid fomoListId);

    /// <summary>
    /// Adds one new <see cref="FomoItem"/> to the database.
    /// </summary>
    /// <param name="fomoItem">A new instance of <see cref="FomoItem"/>.</param>
    /// <returns>A completed task.</returns>
    public Task AddFomoItemAsync(FomoItem fomoItem);

    /// <summary>
    /// Removes one <see cref="FomoItem"/> from the database.
    /// </summary>
    /// <param name="fomoItemId"><see cref="Guid"/> of a <see cref="FomoItem"/> to be removed.</param>
    /// <returns>A completed task.</returns>
    public Task DeleteFomoItemAsync(Guid fomoItemId);

    /// <summary>
    /// Updates an existing <see cref="FomoItem"/> in the database.
    /// </summary>
    /// <param name="fomoItem">An instance of an edited <see cref="FomoItem"/>.</param>
    /// <returns>A completed Task.</returns>
    public Task UpdateFomoItemAsync(FomoItem fomoItem);
}
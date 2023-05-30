// <copyright file="FomoItemRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// Represents an implementation of the <see cref="IFomoItemRepository"/> interface using EF Core.
/// </summary>
public class FomoItemRepository : Repository, IFomoItemRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FomoItemRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="DbContext"/> instance to use.</param>
    public FomoItemRepository(Context context)
        : base(context)
    {
    }

    /// <summary>
    /// Gets one <see cref="FomoItem"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoItemId">The <see cref="Guid"/> of the <see cref="FomoItem"/> to get.</param>
    /// <returns>An instance of <see cref="FomoItem"/>.</returns>
    public async Task<FomoItem> GetFomoItemAsync(Guid fomoItemId)
    {
        var fomoItem = await this.Context.FomoItems.FirstOrDefaultAsync(i => i.Id == fomoItemId);
        if (fomoItem is null)
        {
            throw new InvalidOperationException($"FomoItem with id {fomoItemId} not found");
        }

        return fomoItem;
    }

    /// <summary>
    /// Gets all <see cref="FomoItem"/>s from a <see cref="FomoList"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoListId">The <see cref="Guid"/> of the <see cref="FomoList"/> to get <see cref="FomoItem"/>s from.</param>
    /// <returns>A collection of <see cref="FomoItem"/>s.</returns>
    public async Task<IQueryable<FomoItem>> GetFomoItemsFromFomoListAsync(Guid fomoListId)
    {
        var fomoItems = this.Context.FomoItems.Where(i => i.Id == fomoListId);
        return await Task.FromResult(fomoItems.AsQueryable());
    }

    /// <summary>
    /// Adds one new <see cref="FomoItem"/> to the database.
    /// </summary>
    /// <param name="fomoItem">The new instance of <see cref="FomoItem"/> to add.</param>
    /// <returns>A completed <see cref="Task"/>.</returns>
    public async Task AddFomoItemAsync(FomoItem fomoItem)
    {
        await this.Context.FomoItems.AddAsync(fomoItem);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Removes one <see cref="FomoItem"/> from the database.
    /// </summary>
    /// <param name="fomoItemId">The <see cref="Guid"/> of the <see cref="FomoItem"/> to remove.</param>
    /// <returns>A completed <see cref="Task"/>.</returns>
    public async Task DeleteFomoItemAsync(Guid fomoItemId)
    {
        var fomoItem = await this.Context.FomoItems.FirstOrDefaultAsync(i => i.Id == fomoItemId);

        if (fomoItem != null)
        {
            this.Context.FomoItems.Remove(fomoItem);
            await this.Context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Updates an existing <see cref="FomoItem"/> in the database.
    /// </summary>
    /// <param name="fomoItem">The instance of an edited <see cref="FomoItem"/>.</param>
    /// <returns>A completed <see cref="Task"/>.</returns>
    public async Task UpdateFomoItemAsync(FomoItem fomoItem)
    {
        this.Context.FomoItems.Update(fomoItem);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if the <see cref="FomoItemRepository"/> is empty.
    /// </summary>
    /// <returns>Emptiness of <see cref="FomoItemRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync()
    {
        return !(await this.Context.FomoItems.AnyAsync());
    }
}
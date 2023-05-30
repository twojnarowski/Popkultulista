// <copyright file="ItemRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// Represents an implementation of the <see cref="IItemRepository"/> interface using EF Core.
/// </summary>
public class ItemRepository : Repository, IItemRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ItemRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="Context"/> instance to use.</param>
    public ItemRepository(Context context)
        : base(context)
    {
    }

    /// <summary>
    /// Gets one <see cref="Item"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="itemId">The <see cref="Guid"/> of the <see cref="Item"/> to get.</param>
    /// <returns>An instance of <see cref="Item"/>.</returns>
    public async Task<Item> GetItemAsync(Guid itemId)
    {
        var item = await this.Context.Items.FirstOrDefaultAsync(i => i.Id == itemId);
        if (item is null)
        {
            throw new InvalidOperationException($"Item with id {itemId} not found");
        }

        return item;
    }

    /// <summary>
    /// Gets all <see cref="Item"/>s from a <see cref="List"/> by its <see cref="Guid"/>.
    /// </summary>
    /// <param name="listId">The <see cref="Guid"/> of the <see cref="List"/> to get <see cref="Item"/>s from.</param>
    /// <returns>A collection of <see cref="Item"/>s.</returns>
    public async Task<IQueryable<Item>> GetItemsFromListAsync(Guid listId)
    {
        var items = this.Context.Items.Where(i => i.ListId == listId);
        return await Task.FromResult(items.AsQueryable());
    }

    /// <summary>
    /// Adds one new <see cref="Item"/> to the database.
    /// </summary>
    /// <param name="item">The new instance of <see cref="Item"/> to add.</param>
    /// <returns>A completed <see cref="Task"/>.</returns>
    public async Task AddItemAsync(Item item)
    {
        await this.Context.Items.AddAsync(item);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Removes one <see cref="Item"/> from the database.
    /// </summary>
    /// <param name="itemId">The <see cref="Guid"/> of the <see cref="Item"/> to remove.</param>
    /// <returns>A completed <see cref="Task"/>.</returns>
    public async Task DeleteItemAsync(Guid itemId)
    {
        var item = await this.Context.Items.FirstOrDefaultAsync(i => i.Id == itemId);

        if (item != null)
        {
            this.Context.Items.Remove(item);
            await this.Context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Updates an existing <see cref="Item"/> in the database.
    /// </summary>
    /// <param name="item">The instance of an edited <see cref="Item"/>.</param>
    /// <returns>A completed <see cref="Task"/>.</returns>
    public async Task UpdateItemAsync(Item item)
    {
        this.Context.Items.Update(item);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if the <see cref="ItemRepository"/> is empty.
    /// </summary>
    /// <returns>Emptiness of <see cref="ItemRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync()
    {
        return !(await this.Context.Items.AnyAsync());
    }
}
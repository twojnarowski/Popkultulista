// <copyright file="ListRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// An implementation of the interface for <see cref="List"/> repository.
/// </summary>
public class ListRepository : Repository, IListRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="Context"/> instance to use.</param>
    public ListRepository(Context context)
        : base(context)
    {
    }

    /// <summary>
    /// Adds a new <see cref="List"/> to the database.
    /// </summary>
    /// <param name="list">A new instance of <see cref="List"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public async Task AddListAsync(List list, CancellationToken cancellationToken)
    {
        this.Context.Lists.Add(list);
        await this.Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Gets a specific <see cref="List"/> by given <see cref="Guid"/>.
    /// </summary>
    /// <param name="listId"><see cref="Guid"/> of a <see cref="List"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>An instance of an existing <see cref="List"/>.</returns>
    public async Task<List> GetListAsync(Guid listId, CancellationToken cancellationToken)
    {
        var list = await this.Context.Lists.FirstOrDefaultAsync(x => x.Id == listId, cancellationToken);
        if (list is null)
        {
            throw new InvalidOperationException($"List with id {listId} not found");
        }

        return list;
    }

    /// <summary>
    /// Removes an existing <see cref="List"/> from the database.
    /// </summary>
    /// <param name="listId"><see cref="Guid"/> of a <see cref="List"/> to be removed.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public async Task DeleteListAsync(Guid listId, CancellationToken cancellationToken)
    {
        var list = await this.Context.Lists.FirstOrDefaultAsync(i => i.Id == listId, cancellationToken);

        if (list != null)
        {
            this.Context.Lists.Remove(list);
            await this.Context.SaveChangesAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Updates an existing <see cref="List"/> in the database.
    /// </summary>
    /// <param name="list">An updated <see cref="List"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public async Task UpdateListAsync(List list, CancellationToken cancellationToken)
    {
        this.Context.Lists.Update(list);
        await this.Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Gets all <see cref="List"/>s for a user.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <returns>A list of <see cref="List"/>s.</returns>
    public async Task<IQueryable<List>> GetListsForUserAsync(Guid userId)
    {
        var lists = this.Context.Lists.Where(i => i.UserId == userId);
        return await Task.FromResult(lists.AsQueryable());
    }

    /// <summary>
    /// Gets all <see cref="List"/>s.
    /// </summary>
    /// <returns>A list of <see cref="List"/>s.</returns>
    public async Task<IQueryable<List>> BrowseListsAsync()
    {
        var lists = this.Context.Lists;
        return await Task.FromResult(lists.AsQueryable());
    }

    /// <summary>
    /// Checks if the <see cref="ListRepository"/> is empty.
    /// </summary>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>Emptiness of <see cref="ListRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync(CancellationToken cancellationToken)
    {
        return !(await this.Context.Lists.AnyAsync(cancellationToken));
    }
}
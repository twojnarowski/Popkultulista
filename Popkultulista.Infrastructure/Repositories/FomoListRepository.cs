// <copyright file="FomoListRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure;
using Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// An implementation of the interface for <see cref="FomoList"/> repository.
/// </summary>
public class FomoListRepository : Repository, IFomoListRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FomoListRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="Context"/> instance to use.</param>
    public FomoListRepository(Context context)
        : base(context)
    {
    }

    /// <summary>
    /// Adds a new <see cref="FomoList"/> to the database.
    /// </summary>
    /// <param name="fomoList">A new instance of <see cref="FomoList"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public async Task AddFomoListAsync(FomoList fomoList, CancellationToken cancellationToken)
    {
        this.Context.FomoLists.Add(fomoList);
        await this.Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Gets a specific <see cref="FomoList"/> by given <see cref="Guid"/>.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> of a <see cref="FomoList"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>An instance of an existing <see cref="FomoList"/>.</returns>
    public async Task<FomoList> GetFomoListAsync(Guid fomoListId, CancellationToken cancellationToken)
    {
        var fomoList = await this.Context.FomoLists.FirstOrDefaultAsync(x => x.Id == fomoListId, cancellationToken);
        if (fomoList is null)
        {
            throw new InvalidOperationException($"FomoList with id {fomoListId} not found");
        }

        return fomoList;
    }

    /// <summary>
    /// Removes an existing <see cref="FomoList"/> from the database.
    /// </summary>
    /// <param name="fomoListId"><see cref="Guid"/> of a <see cref="FomoList"/> to be removed.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public async Task DeleteFomoListAsync(Guid fomoListId, CancellationToken cancellationToken)
    {
        var fomoList = await this.Context.FomoLists.FirstOrDefaultAsync(i => i.Id == fomoListId, cancellationToken);

        if (fomoList != null)
        {
            this.Context.FomoLists.Remove(fomoList);
            await this.Context.SaveChangesAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Updates an existing <see cref="FomoList"/> in the database.
    /// </summary>
    /// <param name="fomoList">An updated <see cref="FomoList"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A completed task.</returns>
    public async Task UpdateFomoListAsync(FomoList fomoList, CancellationToken cancellationToken)
    {
        this.Context.FomoLists.Update(fomoList);
        await this.Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Gets all <see cref="FomoList"/>s for a user.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <returns>A fomoList of <see cref="FomoList"/>s.</returns>
    public async Task<IQueryable<FomoList>> GetFomoListsForUserAsync(Guid userId)
    {
        var fomoLists = this.Context.FomoLists.Where(i => i.UserId == userId);
        return await Task.FromResult(fomoLists.AsQueryable());
    }

    /// <summary>
    /// Gets all <see cref="FomoList"/>s.
    /// </summary>
    /// <returns>A fomoList of <see cref="FomoList"/>s.</returns>
    public async Task<IQueryable<FomoList>> BrowseFomoListsAsync()
    {
        var fomoLists = this.Context.FomoLists;
        return await Task.FromResult(fomoLists.AsQueryable());
    }

    /// <summary>
    /// Checks if the <see cref="FomoListRepository"/> is empty.
    /// </summary>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>Emptiness of <see cref="FomoListRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync(CancellationToken cancellationToken)
    {
        return !(await this.Context.FomoLists.AnyAsync(cancellationToken));
    }
}
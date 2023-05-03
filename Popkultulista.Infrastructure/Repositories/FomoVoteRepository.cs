// <copyright file="FomoVoteRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// An implementation of the interface for <see cref="FomoVote"/> repository.
/// </summary>
public class FomoVoteRepository : Repository, IFomoVoteRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FomoVoteRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="Context"/> instance to use.</param>
    public FomoVoteRepository(Context context)
        : base(context)
    {
    }

    /// <summary>
    /// Adding a new FomoVote to the repository.
    /// </summary>
    /// <param name="fomoVote">A new <see cref="FomoVote"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task AddFomoVoteAsync(FomoVote fomoVote)
    {
        await this.Context.FomoVotes.AddAsync(fomoVote);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Removing a <see cref="FomoVote"/>. from the repository.
    /// </summary>
    /// <param name="fomoVoteId"><see cref="Guid"/> of a <see cref="FomoVote"/> to be deleted.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task DeleteFomoVoteAsync(Guid fomoVoteId)
    {
        var fomoVote = await this.Context.FomoVotes.FirstOrDefaultAsync(i => i.Id == fomoVoteId);

        if (fomoVote != null)
        {
            this.Context.FomoVotes.Remove(fomoVote);
            await this.Context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Get a <see cref="FomoVote"/> of given user for given <see cref="FomoItem"/>.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <param name="fomoItemId"><see cref="Guid"/> of an <see cref="FomoItem"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task<FomoVote> GetFomoVoteByUserAndFomoItemAsync(Guid userId, Guid fomoItemId)
    {
        var fomoVote = await this.Context.FomoVotes.Where(x => x.UserId == userId).FirstOrDefaultAsync(i => i.FomoItemId == fomoItemId);
        if (fomoVote is null)
        {
            throw new InvalidOperationException($"FomoVote not found");
        }

        return fomoVote;
    }

    /// <summary>
    /// Gets all <see cref="FomoVote"/>s in the repository.
    /// </summary>
    /// <param name="fomoItemId"><see cref="Guid"/> of an <see cref="FomoItem"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task<IEnumerable<FomoVote>> GetFomoVotesAsync(Guid fomoItemId)
    {
        return await this.Context.FomoVotes.Where(x => x.FomoItemId == fomoItemId).ToListAsync();
    }

    /// <summary>
    /// Checks if the <see cref="FomoVoteRepository"/> is empty.
    /// </summary>
    /// <returns>Emptiness of <see cref="FomoVoteRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync()
    {
        return !(await this.Context.FomoVotes.AnyAsync());
    }
}
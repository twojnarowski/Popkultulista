// <copyright file="VoteRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Infrastructure.Repositories.Common;

/// <summary>
/// An implementation of the interface for <see cref="Vote"/> repository.
/// </summary>
public class VoteRepository : Repository, IVoteRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoteRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="Context"/> instance to use.</param>
    public VoteRepository(Context context)
        : base(context)
    {
    }

    /// <summary>
    /// Adding a new Vote to the repository.
    /// </summary>
    /// <param name="vote">A new <see cref="Vote"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task AddVoteAsync(Vote vote)
    {
        await this.Context.Votes.AddAsync(vote);
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Removing a <see cref="Vote"/>. from the repository.
    /// </summary>
    /// <param name="voteId"><see cref="Guid"/> of a <see cref="Vote"/> to be deleted.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task DeleteVoteAsync(Guid voteId)
    {
        var vote = await this.Context.Votes.FirstOrDefaultAsync(i => i.Id == voteId);

        if (vote != null)
        {
            this.Context.Votes.Remove(vote);
            await this.Context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Get a <see cref="Vote"/> of given user for given <see cref="Item"/>.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <param name="itemId"><see cref="Guid"/> of an <see cref="Item"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task<Vote> GetVoteByUserAndItemAsync(Guid userId, Guid itemId)
    {
        var vote = await this.Context.Votes.Where(x => x.UserId == userId).FirstOrDefaultAsync(i => i.ItemId == itemId);
        if (vote is null)
        {
            throw new InvalidOperationException($"Vote not found");
        }

        return vote;
    }

    /// <summary>
    /// Gets all <see cref="Vote"/>s in the repository.
    /// </summary>
    /// <param name="itemId"><see cref="Guid"/> of an <see cref="Item"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task<IEnumerable<Vote>> GetVotesAsync(Guid itemId)
    {
        return await this.Context.Votes.Where(x => x.ItemId == itemId).ToListAsync();
    }

    /// <summary>
    /// Checks if the <see cref="VoteRepository"/> is empty.
    /// </summary>
    /// <returns>Emptiness of <see cref="VoteRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync()
    {
        return !(await this.Context.Votes.AnyAsync());
    }
}
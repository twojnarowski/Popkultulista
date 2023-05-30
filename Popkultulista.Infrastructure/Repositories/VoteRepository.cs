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
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task AddVoteAsync(Vote vote, CancellationToken cancellationToken)
    {
        await this.Context.Votes.AddAsync(vote, cancellationToken);
        await this.Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Removing a <see cref="Vote"/>. from the repository.
    /// </summary>
    /// <param name="voteId"><see cref="Guid"/> of a <see cref="Vote"/> to be deleted.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task DeleteVoteAsync(Guid voteId, CancellationToken cancellationToken)
    {
        var vote = await this.Context.Votes.FirstOrDefaultAsync(i => i.Id == voteId, cancellationToken);

        if (vote != null)
        {
            this.Context.Votes.Remove(vote);
            await this.Context.SaveChangesAsync(cancellationToken);
        }
    }

    /// <summary>
    /// Get a <see cref="Vote"/> of given user for given <see cref="Item"/>.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <param name="itemId"><see cref="Guid"/> of an <see cref="Item"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public async Task<Vote> GetVoteByUserAndItemAsync(Guid userId, Guid itemId, CancellationToken cancellationToken)
    {
        var vote = await this.Context.Votes.Where(x => x.UserId == userId).FirstOrDefaultAsync(i => i.ItemId == itemId, cancellationToken);
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
    public async Task<IQueryable<Vote>> GetVotesAsync(Guid itemId)
    {
        var votes = this.Context.Votes.Where(x => x.ItemId == itemId);
        return await Task.FromResult(votes.AsQueryable());
    }

    /// <summary>
    /// Checks if the <see cref="VoteRepository"/> is empty.
    /// </summary>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>Emptiness of <see cref="VoteRepository"/>.</returns>
    public async Task<bool> IsEmptyAsync(CancellationToken cancellationToken)
    {
        return !(await this.Context.Votes.AnyAsync(cancellationToken));
    }
}
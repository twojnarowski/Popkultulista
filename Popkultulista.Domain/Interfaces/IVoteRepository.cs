// <copyright file="IVoteRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="Vote"/> repository.
/// </summary>
public interface IVoteRepository : IRepository
{
    /// <summary>
    /// Adding a new Vote to the repository.
    /// </summary>
    /// <param name="vote">A new <see cref="Vote"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public Task AddVoteAsync(Vote vote, CancellationToken cancellationToken);

    /// <summary>
    /// Removing a <see cref="Vote"/>. from the repository.
    /// </summary>
    /// <param name="voteId"><see cref="Guid"/> of a <see cref="Vote"/> to be deleted.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public Task DeleteVoteAsync(Guid voteId, CancellationToken cancellationToken);

    /// <summary>
    /// Get a <see cref="Vote"/> of given user for given <see cref="Item"/>.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a user.</param>
    /// <param name="itemId"><see cref="Guid"/> of an <see cref="Item"/>.</param>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public Task<Vote> GetVoteByUserAndItemAsync(Guid userId, Guid itemId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all <see cref="Vote"/>s in the repository.
    /// </summary>
    /// <param name="itemId"><see cref="Guid"/> of an <see cref="Item"/>.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    public Task<IQueryable<Vote>> GetVotesAsync(Guid itemId);
}
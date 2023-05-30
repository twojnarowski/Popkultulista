// <copyright file="IFomoVoteRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoVote"/> repository.
/// </summary>
public interface IFomoVoteRepository : IRepository
{
    /// <summary>
    /// Adds a new <see cref="FomoVote"/> to the database.
    /// </summary>
    /// <param name="fomoVote">A new instance of <see cref="FomoVote"/>.</param>
    /// <returns>A completed Task.</returns>
    public Task AddFomoVoteAsync(FomoVote fomoVote);

    /// <summary>
    /// Removes an existing <see cref="FomoVote"/> from the database.
    /// </summary>
    /// <param name="fomoVoteId"><see cref="Guid"/> of a <see cref="FomoVote"/> to be deleted.</param>
    /// <returns>A completed task.</returns>
    public Task DeleteFomoVoteAsync(Guid fomoVoteId);

    /// <summary>
    /// Gets a <see cref="FomoVote"/> made by a specified user for given <see cref="FomoItem"/>.
    /// </summary>
    /// <param name="userId"><see cref="Guid"/> of a User.</param>
    /// <param name="fomoItemId"><see cref="Guid"/> of a <see cref="FomoItem"/>.</param>
    /// <returns>An instance of <see cref="FomoVote"/>.</returns>
    public Task<FomoVote> GetFomoVoteByUserAndFomoItemAsync(Guid userId, Guid fomoItemId);

    /// <summary>
    /// Gets all <see cref="FomoVote"/>s for specified <see cref="FomoItem"/>.
    /// </summary>
    /// <param name="fomoItemId"><see cref="Guid"/> of a <see cref="FomoItem"/>.</param>
    /// <returns>A list of <see cref="FomoVote"/>s.</returns>
    public Task<IQueryable<FomoVote>> GetFomoVotesAsync(Guid fomoItemId);
}
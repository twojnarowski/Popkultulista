// <copyright file="IVoteRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces;

using Popkultulista.Domain.Interfaces.Common;
using Popkultulista.Domain.Models;

public interface IVoteRepository : IRepository
{
    public Task AddVoteAsync(Vote vote);

    public Task DeleteVoteAsync(Guid voteId);

    public Task GetVoteByUserAndItemAsync(Guid userId, Guid itemId);

    public Task GetVotesAsync(Guid itemId);
}
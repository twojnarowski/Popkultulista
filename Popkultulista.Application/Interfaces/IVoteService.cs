// <copyright file="IVoteService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoItem"/> service.
/// </summary>
public interface IVoteService
{
    public void CreateVote(Vote vote);

    public Vote GetVote(int id);

    public IEnumerable<Vote> GetVotes();

    public void DeleteVote(int id);

    public void UpdateVote(Vote vote);
}
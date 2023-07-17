// <copyright file="VoteService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using System.Collections.Generic;
using Popkultulista.Domain.Models;

/// <summary>
/// An impementation of <see cref="Vote"/> service.
/// </summary>
public class VoteService : IVoteService
{
    public void CreateVote(Vote vote)
    {
        throw new NotImplementedException();
    }

    public void DeleteVote(int id)
    {
        throw new NotImplementedException();
    }

    public Vote GetVote(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Vote> GetVotes()
    {
        throw new NotImplementedException();
    }

    public void UpdateVote(Vote vote)
    {
        throw new NotImplementedException();
    }
}
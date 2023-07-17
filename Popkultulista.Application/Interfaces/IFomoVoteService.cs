// <copyright file="IFomoVoteService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoVote"/> service.
/// </summary>
public interface IFomoVoteService
{
    public void CreateFomoVote(FomoVote fomoVote);

    public FomoVote GetFomoVote(int id);

    public IEnumerable<FomoVote> GetFomoVote();

    public void DeleteFomoVote(int id);

    public void UpdateFomoVote(FomoVote fomoVote);
}
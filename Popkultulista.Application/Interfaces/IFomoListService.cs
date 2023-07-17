// <copyright file="IFomoListService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoList"/> service.
/// </summary>
public interface IFomoListService
{
    public void CreateFomoList(FomoList fomoList);

    public FomoList GetFomoList(int id);

    public Task<FomoList> GetFomoListForUserAsync(Guid id);

    public IEnumerable<FomoList> GetFomoLists();

    public void DeleteFomoList(int id);

    public void UpdateFomoList(FomoList fomoList);
}
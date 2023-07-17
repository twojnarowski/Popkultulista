// <copyright file="IFomoItemService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoItem"/> service.
/// </summary>
public interface IFomoItemService
{
    public void CreateFomoItem(FomoItem fomoItem);

    public FomoItem GetFomoItem(int id);

    public IEnumerable<FomoItem> GetFomoItems();

    public void DeleteFomoItem(int id);

    public void UpdateFomoItem(FomoItem fomoItem);
}
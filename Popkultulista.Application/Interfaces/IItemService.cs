// <copyright file="IItemService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="Item"/> service.
/// </summary>
public interface IItemService
{
    public void CreateItem(Item item);

    public Item GetItem(int id);

    public IEnumerable<Item> GetItems();

    public void DeleteItem(int id);

    public void UpdateItem(Item item);
}
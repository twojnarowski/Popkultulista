// <copyright file="ItemService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using System.Collections.Generic;
using Popkultulista.Domain.Models;

/// <summary>
/// An impementation of <see cref="Item"/> service.
/// </summary>
public class ItemService : IItemService
{
    public void CreateItem(Item item)
    {
        throw new NotImplementedException();
    }

    public void DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public Item GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> GetItems()
    {
        throw new NotImplementedException();
    }

    public void UpdateItem(Item item)
    {
        throw new NotImplementedException();
    }
}
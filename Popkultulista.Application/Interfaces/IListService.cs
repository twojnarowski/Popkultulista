// <copyright file="IListService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using Popkultulista.Domain.Models;

/// <summary>
/// An interface for <see cref="FomoItem"/> service.
/// </summary>
public interface IListService
{
    public void CreateList(List list);

    public List GetList(int id);

    public IEnumerable<List> GetLists();

    public void DeleteList(int id);

    public void UpdateList(List list);
}
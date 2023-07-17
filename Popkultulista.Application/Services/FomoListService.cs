// <copyright file="FomoListService.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Application.Interfaces;

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Domain.Models;
using Popkultulista.Domain.Models.Identity;

/// <summary>
/// An impementation of <see cref="FomoList"/> service.
/// </summary>
public class FomoListService : IFomoListService
{
    private readonly IFomoListRepository _fomoListRepository;

    private readonly UserManager<User> _userManager;

    public FomoListService(IFomoListRepository fomoListRepository, UserManager<User> userManager)
    {
        _fomoListRepository = fomoListRepository;
        _userManager = userManager;
    }

    public void CreateFomoList(FomoList fomoList)
    {
        throw new NotImplementedException();
    }

    public void DeleteFomoList(int id)
    {
        throw new NotImplementedException();
    }

    public FomoList GetFomoList(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<FomoList> GetFomoListForUserAsync(Guid id)
    {
        var fomoList = await _fomoListRepository.GetFomoListForUserAsync(id);
        return fomoList;
    }

    public IEnumerable<FomoList> GetFomoLists()
    {
        throw new NotImplementedException();
    }

    public void UpdateFomoList(FomoList fomoList)
    {
        throw new NotImplementedException();
    }
}
// <copyright file="DependencyInjection.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>
namespace Popkultulista.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Popkultulista.Domain.Interfaces;
using Popkultulista.Infrastructure.Repositories;

/// <summary>
/// A class with an extension registering all dependencies implemented in this project.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registering all dependencies for the Popkultulista.Infrastructure project.
    /// </summary>
    /// <param name="services">Services from app builder.</param>
    /// <returns>Services collection with added dependencies.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IFomoItemRepository, FomoItemRepository>();
        services.AddTransient<IFomoListRepository, FomoListRepository>();
        services.AddTransient<IFomoVoteRepository, FomoVoteRepository>();
        services.AddTransient<IItemRepository, ItemRepository>();
        services.AddTransient<IListRepository, ListRepository>();
        services.AddTransient<IVoteRepository, VoteRepository>();

        return services;
    }
}
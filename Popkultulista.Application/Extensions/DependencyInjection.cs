using Microsoft.Extensions.DependencyInjection;
using Popkultulista.Application.Interfaces;

namespace Popkultulista.Application.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Registering all dependencies for the project.
    /// </summary>
    /// <param name="services">Services from app builder.</param>
    /// <returns>Services collection with added dependencies.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IFomoItemService, FomoItemService>();
        services.AddTransient<ItemService, ItemService>();
        services.AddTransient<IFomoListService, FomoListService>();
        services.AddTransient<IListService, ListService>();
        services.AddTransient<IFomoVoteService, FomoVoteService>();
        services.AddTransient<IVoteService, VoteService>();

        return services;
    }
}
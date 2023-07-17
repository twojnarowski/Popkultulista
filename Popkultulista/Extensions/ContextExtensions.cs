using Popkultulista.Application.Bogus;

namespace Popkultulista.Infrastructure.Extensions;

public static class ContextExtensions
{
    /// <summary>
    /// Used to seed data in DB.
    /// </summary>
    /// <param name="context">Context.</param>
    public static void SeedData(Context context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        bool isDbEmpty = true;

        StringComparison comparison = StringComparison.InvariantCulture;
        foreach (var prop in context.GetType().GetProperties().Where(p => p.PropertyType.Name.StartsWith("DbSet", comparison)))
        {
            if (prop != null)
            {
                var entities = prop!.GetValue(context) as IEnumerable<object>;
                if (entities!.Any())
                {
                    isDbEmpty = false;
                    break;
                }
            }
        }

        if (isDbEmpty)
        {
            var list = FomoListFaker.GetFomoListGenerator().Generate();
            list.User = new Domain.Models.Identity.User();
            context.Add(list);
            context.SaveChanges();
        }
    }
}
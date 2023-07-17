using Bogus;
using Popkultulista.Domain.Models;

namespace Popkultulista.Application.Bogus;

public class FomoListFaker
{
    public static Faker<FomoList> GetFomoListGenerator()
    {
        return new Faker<FomoList>("pl")
        .RuleFor(x => x.Name, f => f.Internet.UserName())
        .RuleFor(x => x.CreatedAt, _ => DateTime.Now)
        .RuleFor(x => x.CreatedBy, _ => Guid.NewGuid());
    }
}
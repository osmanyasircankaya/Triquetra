using Triquetra.Domain.Data.Entities;

namespace Triquetra.Migrations;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(DatabaseContext context)
    {
        // if (!context.MaterialUnits.Any())
        // {
        //     context.MaterialUnits.Add(new MaterialUnit()
        //     {
        //         Name = "Adet",
        //     });
        //     context.MaterialUnits.Add(new MaterialUnit()
        //     {
        //         Name = "m",
        //     });
        //     context.MaterialUnits.Add(new MaterialUnit()
        //     {
        //         Name = "Set",
        //     });
        //
        //     await context.SaveChangesAsync();
        // }
        //
        // if (!context.Materials.Any())
        // {
        //     context.Materials.Add(new Material
        //     {
        //         Name = "solar",
        //         Description = "panel",
        //         Amount = 3,
        //         MaterialUnitId = 2,
        //         Cost = 2.22,
        //         Price = 34.21,
        //     });
        //     
        //     await context.SaveChangesAsync();
        // }

    }
}
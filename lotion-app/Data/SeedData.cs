using lotion_app.Data;
using lotionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new lotion_appContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<lotion_appContext>>()))
        {
            // Look for any movies.
            if (context.Lotions.Any())
            {
                return;   // DB has been seeded
            }

            var dataList = GenerateRandomLotions(10);

            context.Lotions.AddRange(dataList);
            context.SaveChanges();
        }
    }

    public static List<Lotion> GenerateRandomLotions(int count)
    {
        var random = new Random();
        var names = new[] { "Moisturizing Lotion", "Sunscreen Lotion", "Aloe Vera Gel", "Vitamin E Lotion", "Fragrance-Free Lotion" };
        var brands = new[] { "Soft Touch" };
        var scents = new[] { "Lavender", "Rose", "Citrus", "Vanilla","Aqua", "Unscented" };
        var ingredients = new[] { "Water, Glycerin, Aloe Vera", "Water, Glycerin, SPF", "Water, Aloe Vera, Vitamin E", "Water, Glycerin, Vitamin E", "Water, Glycerin, Fragrance-Free" };

        var lotions = new List<Lotion>();

        for (int i = 0; i < count; i++)
        {
            var lotion = new Lotion
            {
                Name = names[random.Next(names.Length)],
                Brand = brands[random.Next(brands.Length)],
                Volume = (float)Math.Round(random.NextDouble() * (500.0 - 50.0) + 50.0, 2), // Volume between 50ml and 500ml
                Price = (float)Math.Round(random.NextDouble() * (50.0 - 5.0) + 5.0, 2), // Price between $5 and $50
                Scent = scents[random.Next(scents.Length)],
                SPF = random.Next(0, 50), // SPF between 0 and 50
                Ingredients = ingredients[random.Next(ingredients.Length)]
            };

            lotions.Add(lotion);
        }

        return lotions;
    }
}
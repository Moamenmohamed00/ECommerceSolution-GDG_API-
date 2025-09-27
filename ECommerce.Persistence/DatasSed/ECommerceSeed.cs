using ECommerce.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ECommerce.Domain.Entities;
namespace ECommerce.Persistence.DatasSed
{
    public class ECommerceSeed
    {
        public static async Task SeedAsync(ECommerceDb context)
        {
            // Seed Brands first
            if (!await context.Brands.AnyAsync())
            {
                var brandsData = await File.ReadAllTextAsync("../ECommerce.Persistence/DataJson/brands.json");
                var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
                if (brands != null && brands.Count > 0)
                {
                    await context.Brands.AddRangeAsync(brands);
                    await context.SaveChangesAsync(); // Save to get the generated IDs
                }
            }

            // Seed Types
            if (!await context.Types.AnyAsync())
            {
                var typesData = await File.ReadAllTextAsync("../ECommerce.Persistence/DataJson/types.json");
                var types = JsonSerializer.Deserialize<List<ECommerce.Domain.Entities.Type>>(typesData);
                if (types != null && types.Count > 0)
                {
                    await context.Types.AddRangeAsync(types);
                    await context.SaveChangesAsync(); // Save to get the generated IDs
                }
            }

            // Seed Products with proper foreign key references
            if (!await context.Products.AnyAsync())
            {
                var productsData = await File.ReadAllTextAsync("../ECommerce.Persistence/DataJson/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null && products.Count > 0)
                {
                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}

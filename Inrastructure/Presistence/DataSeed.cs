using Domain.InterFace;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence
{
    public class DataSeed(StoreDbContext dbContext) : IDataSeeed
    {
        public async Task SeedingDataAsync()
        {
            try
            {
                var Mig = await dbContext.Database.GetPendingMigrationsAsync();
                if (Mig.Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
                if (!dbContext.ProductTypes.Any())
                { // Use OpenRead As Retuen FileStream To Avoid File Locking Issues And to Work with Deserialization Async
                    var ProductTypesData = File.OpenRead("../Inrastructure/Presistence/DataSeddingFies/types.json");
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductTypes>>(ProductTypesData);
                    if (ProductTypes != null && ProductTypes.Any())
                        await dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                }
                if (!dbContext.ProductBrands.Any())
                {
                    var ProductBrandsData = File.OpenRead("../Inrastructure/Presistence/DataSeddingFies/brands.json");
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrands>>(ProductBrandsData);
                    if (ProductBrands != null && ProductBrands.Any())
                        await dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                }
                if (!dbContext.Products.Any())
                {
                    var ProductData = File.OpenRead("../Inrastructure/Presistence/DataSeddingFies/products.json");
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Products != null && Products.Any())
                        await dbContext.Products.AddRangeAsync(Products);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

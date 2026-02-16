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
        public void SeedingData()
        {
            try
            {
                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();
                }
                if (!dbContext.ProductTypes.Any())
                {
                    var ProductTypesData = File.ReadAllText("../Inrastructure/Presistence/DataSeddingFies/types.json");
                    var ProductTypes = JsonSerializer.Deserialize<List<ProductTypes>>(ProductTypesData);
                    if (ProductTypes != null && ProductTypes.Any())
                        dbContext.ProductTypes.AddRange(ProductTypes);
                }
                if (!dbContext.ProductBrands.Any())
                {
                    var ProductBrandsData = File.ReadAllText("../Inrastructure/Presistence/DataSeddingFies/brands.json");
                    var ProductBrands = JsonSerializer.Deserialize<List<ProductBrands>>(ProductBrandsData);
                    if (ProductBrands != null && ProductBrands.Any())
                        dbContext.ProductBrands.AddRange(ProductBrands);
                }
                if (!dbContext.Products.Any())
                {
                    var ProductData = File.ReadAllText("../Inrastructure/Presistence/DataSeddingFies/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                    if (Products != null && Products.Any())
                        dbContext.Products.AddRange(Products);
                }

                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace OptimiseTechnicalTest.Server.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app){
        var group  = app.MapGroup("/api");

        group.MapGet("productList", async (OptimiseDbContext context,  string code,  string description) =>
        {
            var products = await context.Products
            .FromSqlInterpolated($"EXEC osp_GetProductSearch {code}, {description}")
            .ToListAsync();
            return products;
        })
        .WithName("GetProductListFromArguments");
    }
}

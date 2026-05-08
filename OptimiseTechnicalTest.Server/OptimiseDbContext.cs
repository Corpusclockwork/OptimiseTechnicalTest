using System;
using Microsoft.EntityFrameworkCore;
using OptimiseTechnicalTest.Server.Models;

namespace OptimiseTechnicalTest.Server;

public class OptimiseDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}

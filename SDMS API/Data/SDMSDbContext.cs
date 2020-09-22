using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class SDMSDbContext : DbContext
    {
        public SDMSDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<ChartofAccount> ChartofAccounts { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Menu> Menues { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}

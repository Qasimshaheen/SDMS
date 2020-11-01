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
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankAccoountDetail> BankAccoountDetails { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set; }
        public DbSet<CustomerOpeningBalanceMaster> CustomerOpeningBalanceMasters { get; set; }
        public DbSet<CustomerOpeningBalanceDetail> CustomerOpeningBalanceDetails { get; set; }
        public DbSet<VendorOpeningBalanceMaster> vendorOpeningBalanceMasters { get; set; }
        public DbSet<VendorOpeningBalanceDetail> vendorOpeningBalanceDetails { get; set; }
        public DbSet<VoucherMaster> VoucherMasters { get; set; }
        public DbSet<VoucherDetail> VoucherDetails { get; set; }
        public DbSet<ProductOpeningBalanceMaster> ProductOpeningBalanceMasters { get; set; }
        public DbSet<ProductOpeningBalanceDetail> ProductOpeningBalanceDetails { get; set; }
        public DbSet<ProductLedger> ProductLedgers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ManufacturingMaster> ManufacturingMasters { get; set; }
        public DbSet<ManufacturingDetail> ManufacturingDetails { get; set; }
        public DbSet<ManufacturingRawDetail> ManufacturingRawDetails { get; set; }
        public DbSet<PurchaseMaster> PurchaseMasters { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<SOrderMaster> SOrderMasters { get; set; }
        public DbSet<SOrderDetail> SOrderDetails { get; set; }
        public DbSet<SalesMaster> SalesMasters { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<ProductFormulaMaster> ProductFormulaMasters { get; set; }
        public DbSet<ProductFormulaDetail> ProductFormulaDetails { get; set; }
        public DbSet<BankOpeningBalanceMaster> BankOpeningBalanceMasters { get; set; }
        public DbSet<BankOpeningBalanceDetail> BankOpeningBalanceDetails { get; set; }
        public DbSet<ManufacturingBillMaster> ManufacturingBillMasters { get; set; }
        public DbSet<ManufacturingBillProductDetail> ManufacturingBillProductDetails { get; set; }
        public DbSet<ManufacturingBillExpenses> ManufacturingBillExpenses { get; set; }
    }
}

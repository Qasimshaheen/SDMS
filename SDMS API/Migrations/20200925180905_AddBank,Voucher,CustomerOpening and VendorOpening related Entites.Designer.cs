﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SDMS_API.Data;

namespace SDMS_API.Migrations
{
    [DbContext(typeof(SDMSDbContext))]
    [Migration("20200925180905_AddBank,Voucher,CustomerOpening and VendorOpening related Entites")]
    partial class AddBankVoucherCustomerOpeningandVendorOpeningrelatedEntites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SDMS_API.Data.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("SDMS_API.Data.BankAccoountDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("AccountTitle")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("BankAccountTypeId")
                        .HasColumnType("int");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("COAId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountTypeId");

                    b.HasIndex("BankId");

                    b.HasIndex("COAId");

                    b.ToTable("BankAccoountDetails");
                });

            modelBuilder.Entity("SDMS_API.Data.BankAccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("BankAccountTypes");
                });

            modelBuilder.Entity("SDMS_API.Data.ChartofAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDebit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDetailAccount")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ParentAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentAccountId");

                    b.ToTable("ChartofAccounts");
                });

            modelBuilder.Entity("SDMS_API.Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SDMS_API.Data.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NTN")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SDMS_API.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("COAId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("COAId");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SDMS_API.Data.CustomerOpeningBalanceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.Property<int>("CustomerOBMId")
                        .HasColumnType("int");

                    b.Property<decimal>("OpeningAdvance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OpeningReceipt")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerOBMId");

                    b.ToTable("CustomerOpeningBalanceDetails");
                });

            modelBuilder.Entity("SDMS_API.Data.CustomerOpeningBalanceMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPosted")
                        .HasColumnType("bit");

                    b.Property<int>("VoucherMasterId")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("VoucherMasterId");

                    b.ToTable("CustomerOpeningBalanceMasters");
                });

            modelBuilder.Entity("SDMS_API.Data.MeasureUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MeasureUnits");
                });

            modelBuilder.Entity("SDMS_API.Data.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsReport")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ParentMenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentMenueId");

                    b.ToTable("Menues");
                });

            modelBuilder.Entity("SDMS_API.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("CostOfGoodsSoldCOAId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InventoryCOAId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MeasureUnitID")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SaleCOAId")
                        .HasColumnType("int");

                    b.Property<int?>("SaleDiscountCOAId")
                        .HasColumnType("int");

                    b.Property<int?>("SaleReturnCOAId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CostOfGoodsSoldCOAId");

                    b.HasIndex("InventoryCOAId");

                    b.HasIndex("MeasureUnitID");

                    b.HasIndex("SaleCOAId");

                    b.HasIndex("SaleDiscountCOAId");

                    b.HasIndex("SaleReturnCOAId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SDMS_API.Data.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("SDMS_API.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SDMS_API.Data.UserRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAllow")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPost")
                        .HasColumnType("bit");

                    b.Property<int>("MenueId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenueId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRights");
                });

            modelBuilder.Entity("SDMS_API.Data.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("COAId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("COAId");

                    b.HasIndex("CityId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("SDMS_API.Data.VendorOpeningBalanceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("OpeningAdvance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OpeningBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OpeningReceipt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VendorOBMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VendorOBMasterId");

                    b.ToTable("vendorOpeningBalanceDetails");
                });

            modelBuilder.Entity("SDMS_API.Data.VendorOpeningBalanceMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPosted")
                        .HasColumnType("bit");

                    b.Property<int>("VoucherMasterId")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("VoucherMasterId");

                    b.ToTable("vendorOpeningBalanceMasters");
                });

            modelBuilder.Entity("SDMS_API.Data.VoucherDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("COAId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDebit")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendorId")
                        .HasColumnType("int");

                    b.Property<int>("VoucherMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("COAId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VendorId");

                    b.HasIndex("VoucherMasterId");

                    b.ToTable("VoucherDetails");
                });

            modelBuilder.Entity("SDMS_API.Data.VoucherMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ChequeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ChequeNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPosted")
                        .HasColumnType("bit");

                    b.Property<string>("Narration")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("TotalCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VoucherNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoucherType")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("VoucherMasters");
                });

            modelBuilder.Entity("SDMS_API.Data.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("SDMS_API.Data.BankAccoountDetail", b =>
                {
                    b.HasOne("SDMS_API.Data.BankAccountType", "TblBankAccountType")
                        .WithMany("BankAccoountDetails")
                        .HasForeignKey("BankAccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.Bank", "TblBank")
                        .WithMany("BankAccoountDetails")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblChartofAccount")
                        .WithMany("BankAccoountDetails")
                        .HasForeignKey("COAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.ChartofAccount", b =>
                {
                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblParentChartOfAccount")
                        .WithMany("TblChildChartOfAccounts")
                        .HasForeignKey("ParentAccountId");
                });

            modelBuilder.Entity("SDMS_API.Data.Company", b =>
                {
                    b.HasOne("SDMS_API.Data.Warehouse", "TblWarehouse")
                        .WithMany("Companies")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.Customer", b =>
                {
                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblChartofAccount")
                        .WithMany("Customers")
                        .HasForeignKey("COAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.City", "TblCity")
                        .WithMany("Customers")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.CustomerOpeningBalanceDetail", b =>
                {
                    b.HasOne("SDMS_API.Data.Customer", "TblCustomer")
                        .WithMany("CustomerOpeningBalanceDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.CustomerOpeningBalanceMaster", "CustomerOpeningBalanceMaster")
                        .WithMany("CustomerOpeningBalanceDetails")
                        .HasForeignKey("CustomerOBMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.CustomerOpeningBalanceMaster", b =>
                {
                    b.HasOne("SDMS_API.Data.VoucherMaster", "TblVoucherMaster")
                        .WithMany("CustomerOpeningBalanceMasters")
                        .HasForeignKey("VoucherMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.Menu", b =>
                {
                    b.HasOne("SDMS_API.Data.Menu", "TblParentMenue")
                        .WithMany("TblChildMenues")
                        .HasForeignKey("ParentMenueId");
                });

            modelBuilder.Entity("SDMS_API.Data.Product", b =>
                {
                    b.HasOne("SDMS_API.Data.ProductCategory", "TblProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblCostOfGoodsSoldChartOfAccount")
                        .WithMany("TblCostOfGoodsSoldProducts")
                        .HasForeignKey("CostOfGoodsSoldCOAId");

                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblInventoryChartOfAccount")
                        .WithMany("TblInventoryProducts")
                        .HasForeignKey("InventoryCOAId");

                    b.HasOne("SDMS_API.Data.MeasureUnit", "TblMeasureUnit")
                        .WithMany("Products")
                        .HasForeignKey("MeasureUnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblSaleChartOfAccount")
                        .WithMany("TblSaleProducts")
                        .HasForeignKey("SaleCOAId");

                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblSaleDiscountChartOfAccount")
                        .WithMany("TblSaleDiscountProducts")
                        .HasForeignKey("SaleDiscountCOAId");

                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblSaleReturnChartOfAccount")
                        .WithMany("TblSaleReturnProducts")
                        .HasForeignKey("SaleReturnCOAId");
                });

            modelBuilder.Entity("SDMS_API.Data.UserRight", b =>
                {
                    b.HasOne("SDMS_API.Data.Menu", "Menue")
                        .WithMany("UserRights")
                        .HasForeignKey("MenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.User", "User")
                        .WithMany("UserRights")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.Vendor", b =>
                {
                    b.HasOne("SDMS_API.Data.ChartofAccount", "TblChartofAccount")
                        .WithMany("Vendors")
                        .HasForeignKey("COAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.City", "TblCity")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.VendorOpeningBalanceDetail", b =>
                {
                    b.HasOne("SDMS_API.Data.Customer", "TblCustomer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.VendorOpeningBalanceMaster", "TblVendorOpeningBalanceMaster")
                        .WithMany("VendorOpeningBalanceDetails")
                        .HasForeignKey("VendorOBMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.VendorOpeningBalanceMaster", b =>
                {
                    b.HasOne("SDMS_API.Data.VoucherMaster", "TblVoucherMaster")
                        .WithMany("VendorOpeningBalanceMasters")
                        .HasForeignKey("VoucherMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.VoucherDetail", b =>
                {
                    b.HasOne("SDMS_API.Data.ChartofAccount", "ChartofAccount")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("COAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SDMS_API.Data.Customer", "Customer")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("CustomerId");

                    b.HasOne("SDMS_API.Data.Vendor", "Vendor")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("VendorId");

                    b.HasOne("SDMS_API.Data.VoucherMaster", "TblVoucherMaster")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("VoucherMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SDMS_API.Data.VoucherMaster", b =>
                {
                    b.HasOne("SDMS_API.Data.Bank", "TblBank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.SalesDetail;
using SDMS_API.ViewModels.SalesMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public SalesController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<SalesListingVM>> GetSales()
        {
            var results = await _dbContext.SalesMasters.Select(x => new SalesListingVM
            {
                Id = x.Id,
                SINo = x.Code,
                Date = x.Date,
                SOrderNo = x.TblSOrderMaster.Code,
                CustomerName = x.TblCustomer.Name,
                TotalAmount = x.TotalAmount,
                DiscountAmount = x.DiscountAmount,
                NetAmount = x.NetAmount,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                SalesDetails = x.SalesDetails.Select(y => new SalesDetailListingVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    BatchNo = y.BatchNo,
                    Quantity = y.Quantity,
                    Price = y.Price,
                    TotalAmount = y.TotalAmount,
                    DiscountAmount = y.DiscountAmount,
                    NetAmount = y.NetAmount,
                    WarehouseName = y.TblWarehouse.Name
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<SalesMasterDetailVM> GetSalesById(int salesMasterId)
        {
            var result = await _dbContext.SalesMasters.Where(x => x.Id == salesMasterId).Select(x => new SalesMasterDetailVM
            {
                Id = x.Id,
                Date = x.Date,
                SINo = x.Code,
                CustomerName = x.TblCustomer.Name,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                SOrderNo = x.TblSOrderMaster.Code,
                TotalAmount = x.TotalAmount,
                DiscountAmount = x.DiscountAmount,
                DiscountPerc = x.DiscountPerc,
                NetAmount = x.NetAmount,
                Remarks = x.Remarks,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                SalesDetails = x.SalesDetails.Select(y => new SalesDetailDetailVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    BatchNo = y.BatchNo,
                    Price = y.Price,
                    Quantity = y.Quantity,
                    TotalAmount = y.TotalAmount,
                    DiscountPerc = y.DiscountPerc,
                    DiscountAmount = y.DiscountAmount,
                    NetAmount = y.NetAmount,
                    WarehouseName = y.TblWarehouse.Name
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteSalesById(int salesMasterId)
        {
            var result = await _dbContext.SalesMasters.Where(x => x.Id == salesMasterId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.SalesMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateSales(SalesMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastSINo = string.Empty;
                var LastSI = _dbContext.SalesMasters.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastSI != null)
                    lastSINo = LastSI.Code;
                var salesMaster = new SalesMaster()
                {
                    Date = model.Date,
                    Code = lastSINo.GenerateNextCode("SI"),
                    CustomerId = model.CustomerId,
                    SOrderId = model.SOrderId,
                    TotalAmount = model.SalesDetails.Sum(x => x.TotalAmount),
                    DiscountPerc = model.DiscountPerc,
                    DiscountAmount = model.DiscountAmount,
                    NetAmount = model.SalesDetails.Sum(x => x.TotalAmount) - model.DiscountAmount,
                    IsPosted = model.IsPosted,
                    Remarks = model.Remarks,
                    AddedBy = model.AddedBy,
                    AddedOn = DateTime.Now,
                    SalesDetails = model.SalesDetails.Select(y => new SalesDetail
                    {
                        ProductId = y.ProductId,
                        Quantity = y.Quantity,
                        Price = y.Price,
                        BatchNo = y.BatchNo,
                        WarehouseId = y.WarehouseId,
                        TotalAmount = y.TotalAmount,
                        DiscountPerc = y.DiscountPerc,
                        DiscountAmount = y.DiscountAmount,
                        NetAmount = y.TotalAmount - y.DiscountAmount
                    }).ToList()
                };
                await _dbContext.SalesMasters.AddAsync(salesMaster);
                await _dbContext.SaveChangesAsync();
                return salesMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditSalesById(SalesMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.SalesMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    result.SOrderId = model.SOrderId;
                    result.CustomerId = model.CustomerId;
                    result.TotalAmount = model.TotalAmount;
                    result.DiscountPerc = model.DiscountPerc;
                    result.DiscountAmount = model.DiscountAmount;
                    result.NetAmount = model.TotalAmount - model.DiscountAmount;
                    result.UpdatedBy = model.UpdatedBy;
                    result.UpdatedOn = DateTime.Now;
                    result.Remarks = model.Remarks;
                    result.IsPosted = model.IsPosted;
                    var existingSalesDetails = await _dbContext.SalesDetails.Where(x => x.SalesMasterId == model.Id).ToListAsync();
                    if (existingSalesDetails != null && existingSalesDetails.Count > 0)
                        _dbContext.SalesDetails.RemoveRange(existingSalesDetails);
                    var salesDetail = model.SalesDetails.Select(x => new SalesDetail
                    {
                        SalesMasterId = result.Id,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        BatchNo = x.BatchNo,
                        WarehouseId = x.WarehouseId,
                        TotalAmount = x.TotalAmount,
                        DiscountPerc = x.DiscountPerc,
                        DiscountAmount = x.DiscountAmount,
                        NetAmount = x.TotalAmount - x.DiscountAmount
                    }).ToList();
                    await _dbContext.SalesDetails.AddRangeAsync(salesDetail);
                    var count = await _dbContext.SaveChangesAsync();
                    return count > 0;
                }
                else
                    return false;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<bool> PostSales(int salesMasterId)
        {
            var salesItem = _dbContext.SalesMasters.Where(x => x.Id == salesMasterId).Select(x => new
            {
                salesMaster = x,
                salesDetail = x.SalesDetails,
                inventories = x.SalesDetails.Select(y => new
                {
                    y.TblProduct.SaleCOAId,
                    y.ProductId,
                    y.TotalAmount
                }),
                customerCOAId = x.TblCustomer.COAId
            }).FirstOrDefault();

            // Add Records in ProductLedger
            foreach (var masterDetailItem in salesItem.salesDetail)
            {
                var productLedger = new ProductLedger()
                {
                    Date = salesItem.salesMaster.Date,
                    ProductId = masterDetailItem.ProductId,
                    TransNo = salesItem.salesMaster.Code,
                    Quantity = masterDetailItem.Quantity,
                    BatchNo = masterDetailItem.BatchNo,
                    WarehouseId = masterDetailItem.WarehouseId,
                    IsOut = true,
                    AddedBy = salesItem.salesMaster.AddedBy,
                    AddedOn = DateTime.Now,
                    Remarks = "Sales"
                };
                await _dbContext.ProductLedgers.AddAsync(productLedger);
            }

            // Voucher Number Generation
            string lastVoucherNumber = string.Empty;
            var LastVoucherNumber = _dbContext.VoucherMasters.AsNoTracking().Where(x => x.VoucherNumber.StartsWith("JV")).OrderByDescending(x => x.Id).FirstOrDefault();
            if (LastVoucherNumber != null)
                lastVoucherNumber = LastVoucherNumber.VoucherNumber;

            // Voucher Master Entry
            var voucherMaster = new VoucherMaster()
            {
                Date = salesItem.salesMaster.Date,
                VoucherNumber = lastVoucherNumber.GenerateNextCode("JV"),
                VoucherType = "SI",
                Narration = salesItem.salesMaster.Remarks,
                IsPosted = true,
                AddedBy = salesItem.salesMaster.AddedBy,
                AddedOn = DateTime.Now
            };

            // Credit In VoucherDetail
            voucherMaster.VoucherDetails = salesItem.inventories.GroupBy(x => x.SaleCOAId).Select(x => new VoucherDetail
            {
                Amount = x.Sum(y => y.TotalAmount),
                CustomerId = null,
                VendorId = null,
                COAId = x.Key.HasValue ? x.Key.Value : 1,
                IsDebit = false,
                Remarks = null
            }).ToList();

            //Debit In VoucherDetail
            voucherMaster.VoucherDetails.Add(new VoucherDetail()
            {
                CustomerId = salesItem.salesMaster.CustomerId,
                VendorId = null,
                IsDebit = true,
                COAId = salesItem.customerCOAId,
                Amount = voucherMaster.VoucherDetails.Sum(y => y.Amount),
                Remarks = null
            });
            voucherMaster.TotalDebit = voucherMaster.VoucherDetails.Where(x => x.IsDebit).Sum(x => x.Amount);
            voucherMaster.TotalCredit = voucherMaster.VoucherDetails.Where(x => !x.IsDebit).Sum(x => x.Amount);

            await _dbContext.VoucherMasters.AddAsync(voucherMaster);

            await _dbContext.SaveChangesAsync();

            salesItem.salesMaster.VoucherMasterId = voucherMaster.Id;
            salesItem.salesMaster.IsPosted = true;
            var count = await _dbContext.SaveChangesAsync();
            return count > 0;
        }
    }
}

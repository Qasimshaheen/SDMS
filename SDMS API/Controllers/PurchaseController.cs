using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.PurchaseDetail;
using SDMS_API.ViewModels.PurchaseMaster;
using SDMS_API.ViewModels.VoucherMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public PurchaseController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<PurchaseListingVM>> GetPurchases()
        {
            var results = await _dbContext.PurchaseMasters.Select(x => new PurchaseListingVM
            {
                Id = x.Id,
                Date = x.Date,
                VendorName = x.TblVendor.Name,
                BatchNo = x.BatchNo,
                WarehouseName = x.TblWarehouse.Name,
                Remarks = x.Remarks,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PurchaseDetails = x.PurchaseDetails.Select(y => new PurchaseDetailListingVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    Quantity = y.Quantity,
                    Price = y.Price,
                    TotalAmount = y.TotalAmount,
                    DiscountAmount = y.DiscountAmount,
                    NetAmount = y.NetAmount
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<PurchaseMasterDetailVM> GetPurchaseById(int purchaseMasterId)
        {
            var result = await _dbContext.PurchaseMasters.Where(x => x.Id == purchaseMasterId).Select(x => new PurchaseMasterDetailVM
            {
                Id = x.Id,
                Date = x.Date,
                Code = x.Code,
                VendorName = x.TblVendor.Name,
                BatchNo = x.BatchNo,
                WarehouseName = x.TblWarehouse.Name,
                TotalAmount = x.TotalAmount,
                DiscountAmount = x.DiscountAmount,
                DiscountPerc = x.DiscountPerc,
                NetAmount = x.NetAmount,
                Remarks = x.Remarks,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                PurchaseDetails = x.PurchaseDetails.Select(y => new PurchaseDetailDetailVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    Quantity = y.Quantity,
                    Price = y.Price,
                    TotalAmount = y.TotalAmount,
                    DiscountPerc = y.DiscountPerc,
                    DiscountAmount = y.DiscountAmount,
                    NetAmount = y.NetAmount
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeletePurchaseById(int purchaseMasterId)
        {
            var result = await _dbContext.PurchaseMasters.Where(x => x.Id == purchaseMasterId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.PurchaseMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreatePurchase(PurchaseMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastPurchaseCode = string.Empty;
                var LastPurchase = _dbContext.PurchaseMasters.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastPurchase != null)
                    lastPurchaseCode = LastPurchase.Code;
                var purchaseMaster = new PurchaseMaster()
                {
                    Date = model.Date,
                    VendorId = model.VendorId,
                    Code = lastPurchaseCode.GenerateNextCode("PI"),
                    WarehouseId = model.WarehouseId,
                    BatchNo = model.BatchNo,
                    TotalAmount = model.TotalAmount,
                    DiscountPerc = model.DiscountPerc,
                    DiscountAmount = model.DiscountAmount,
                    NetAmount = model.TotalAmount - model.DiscountAmount,
                    Remarks = model.Remarks,
                    IsPosted = model.IsPosted,
                    AddedBy = model.AddedBy,
                    AddedOn = DateTime.Now,
                    PurchaseDetails = model.PurchaseDetails.Select(x => new PurchaseDetail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        TotalAmount = x.TotalAmount,
                        DiscountPerc = x.DiscountPerc,
                        DiscountAmount = x.DiscountAmount,
                        NetAmount = x.TotalAmount - x.DiscountAmount
                    }).ToList()
                };
                await _dbContext.PurchaseMasters.AddAsync(purchaseMaster);
                await _dbContext.SaveChangesAsync();
                return purchaseMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditPurchaseById(PurchaseMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.PurchaseMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    result.BatchNo = model.BatchNo;
                    result.VendorId = model.VendorId;
                    result.WarehouseId = model.WarehouseId;
                    result.TotalAmount = model.TotalAmount;
                    result.DiscountPerc = model.DiscountPerc;
                    result.DiscountAmount = model.DiscountAmount;
                    result.NetAmount = model.TotalAmount - model.DiscountAmount;
                    result.IsPosted = model.IsPosted;
                    result.Remarks = model.Remarks;
                    var existingPurchaseDetails = await _dbContext.PurchaseDetails.Where(x => x.PurchaseMasterId == model.Id).ToListAsync();
                    if (existingPurchaseDetails != null && existingPurchaseDetails.Count > 0)
                        _dbContext.PurchaseDetails.RemoveRange(existingPurchaseDetails);
                    var purchaseDetail = model.PurchaseDetails.Select(x => new PurchaseDetail
                    {
                        PurchaseMasterId = result.Id,
                        ProductId = x.ProductId,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        TotalAmount = x.TotalAmount,
                        DiscountPerc = x.DiscountPerc,
                        DiscountAmount = x.DiscountAmount,
                        NetAmount = x.NetAmount
                    }).ToList();
                    await _dbContext.PurchaseDetails.AddRangeAsync(purchaseDetail);
                    var count = await _dbContext.SaveChangesAsync();
                    return count > 0;
                }
                else
                    return false;
            }
            else
                return false;
        }


        /// <summary>
        /// 1. Create new Product Ledgers
        /// 2. Create new Voucher with Voucher Details
        /// 3. In Voucher Details we have 
        ///    1. Debit entry
        ///    2. Credit entry
        /// 4. Update the PurchaseMaster with VoucherMasterId and IsPosted
        /// </summary>
        /// <param name="purchaseMasterId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> PostPurchase(int purchaseMasterId)
        {
            var purchaseItem = _dbContext.PurchaseMasters.Where(x => x.Id == purchaseMasterId).Select(x => new
            {
                purchaseMaster = x,
                Details = x.PurchaseDetails,
                Inventories = x.PurchaseDetails.Select(y => new
                {
                    y.TblProduct.InventoryCOAId,
                    y.ProductId,
                    y.TotalAmount
                }),
                vendorCOAId = x.TblVendor.COAId
            }).FirstOrDefault();

            foreach (var masterDetailItem in purchaseItem.Details)
            {
                var productLedger = new ProductLedger()
                {
                    Date = purchaseItem.purchaseMaster.Date,
                    ProductId = masterDetailItem.ProductId,
                    TransNo = purchaseItem.purchaseMaster.Code,
                    Quantity = masterDetailItem.Quantity,
                    WarehouseId = purchaseItem.purchaseMaster.WarehouseId,
                    BatchNo = purchaseItem.purchaseMaster.BatchNo,
                    IsOut = false,
                    AddedBy = purchaseItem.purchaseMaster.AddedBy,
                    AddedOn = DateTime.Now,
                    Remarks = "Purchase"
                };
                await _dbContext.ProductLedgers.AddAsync(productLedger);
            }

            // Voucher Number Generation
            string lastVoucherNumber = string.Empty;
            var LastVoucherNumber = _dbContext.VoucherMasters.AsNoTracking().Where(x => x.VoucherNumber.StartsWith("JV")).OrderByDescending(x => x.Id).FirstOrDefault();
            if (LastVoucherNumber != null)
                lastVoucherNumber = LastVoucherNumber.VoucherNumber;

            var voucherMaster = new VoucherMaster
            {
                Date = purchaseItem.purchaseMaster.Date,
                VoucherNumber = lastVoucherNumber.GenerateNextCode("JV"),
                VoucherType = "PI",
                Narration = purchaseItem.purchaseMaster.Remarks,
                IsPosted = true,
                AddedBy = purchaseItem.purchaseMaster.AddedBy,
                AddedOn = DateTime.Now,
            };

            //Debit in Voucher Details
            voucherMaster.VoucherDetails = purchaseItem.Inventories.GroupBy(x => x.InventoryCOAId).Select(x => new VoucherDetail
            {
                Amount = x.Sum(y => y.TotalAmount),
                COAId = x.Key.HasValue ? x.Key.Value : 1,
                IsDebit = true,
                VendorId = null,
                CustomerId = null,
                Remarks = null,
            }).ToList();

            //Credit in Voucher Details
            voucherMaster.VoucherDetails.Add(new VoucherDetail()
            {
                IsDebit = false,
                CustomerId = null,
                VendorId = purchaseItem.purchaseMaster.VendorId,
                COAId = purchaseItem.vendorCOAId,
                Amount = voucherMaster.VoucherDetails.Sum(y => y.Amount),
                Remarks = null
            });

            voucherMaster.TotalDebit = voucherMaster.VoucherDetails.Where(x => x.IsDebit).Sum(x => x.Amount);
            voucherMaster.TotalCredit = voucherMaster.VoucherDetails.Where(x => x.IsDebit == false).Sum(x => x.Amount);

            await _dbContext.VoucherMasters.AddAsync(voucherMaster);

            var count = await _dbContext.SaveChangesAsync();

            purchaseItem.purchaseMaster.VoucherMasterId = voucherMaster.Id;
            purchaseItem.purchaseMaster.IsPosted = true;

            count = await _dbContext.SaveChangesAsync();

            return count > 0;
        }
    }
}

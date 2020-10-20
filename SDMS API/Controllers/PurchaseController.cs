using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.PurchaseDetail;
using SDMS_API.ViewModels.PurchaseMaster;

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
                VendorName = x.TblVendor.Name,
                BatchNo = x.BatchNo,
                WarehouseName = x.TblWarehouse.Name,
                TotalAmount = x.TotalAmount,
                DiscountAmount = x.DiscountAmount,
                DiscountPerc = x.DiscountPerc,
                NetAmount = x.NetAmount,
                Remarks = x.Remarks,
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
    }
}

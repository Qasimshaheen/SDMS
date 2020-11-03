using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.ProductOpeningDetail;
using SDMS_API.ViewModels.ProductOpeningMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductOpeningController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ProductOpeningController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductOpeningListingVM>> GetProductOpenings()
        {
            var results = await _dbContext.ProductOpeningBalanceMasters.Select(x => new ProductOpeningListingVM
            {
                Id = x.Id,
                Date = x.Date,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                ProductOpeningDetails = x.ProductOpeningBalanceDetails.Select(y => new ProductOpeningDetailListingVM
                {
                    ProductName = y.TblProduct.Name,
                    BatchNo = y.BatchNo,
                    WarehouseName = y.TblWarehouse.Name,
                    Quantity = y.Quantity,
                    Price = y.Price,
                    Amount = y.Amount
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ProductOpeningMasterDetailVM> GetProductOpeningById(int productOpeningId)
        {
            var result = await _dbContext.ProductOpeningBalanceMasters.Where(x => x.Id == productOpeningId).Select(x => new ProductOpeningMasterDetailVM
            {
                Id = x.Id,
                Date = x.Date,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                ProductOpeningDetails = x.ProductOpeningBalanceDetails.Select(y => new ProductOpeningDetailDetailVM
                {
                    ProductName = y.TblProduct.Name,
                    BatchNo = y.BatchNo,
                    WarehouseName = y.TblWarehouse.Name,
                    Quantity = y.Quantity,
                    Price = y.Price,
                    Amount = y.Amount
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteProductOpeningById(int productOpeningId)
        {
            var result = await _dbContext.ProductOpeningBalanceMasters.Where(x => x.Id == productOpeningId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ProductOpeningBalanceMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateProductOpening(ProductOpeningMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var productOpeningMaster = new ProductOpeningBalanceMaster()
                {
                    Date = model.Date,
                    IsPosted = model.IsPosted,
                    ProductOpeningBalanceDetails = model.ProductOpeningDetails.Select(x => new ProductOpeningBalanceDetail
                    {
                        ProductId = x.ProductId,
                        WarehouseId = x.WarehouseId,
                        BatchNo = x.BatchNo,
                        Quantity = x.Quantity,
                        Price = x.Price,
                        Amount = x.Amount
                    }).ToList()
                };
                await _dbContext.ProductOpeningBalanceMasters.AddAsync(productOpeningMaster);
                await _dbContext.SaveChangesAsync();
                return productOpeningMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditProductOpeningById(ProductOpeningMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.ProductOpeningBalanceMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    var existingProductOpeningDetals = await _dbContext.ProductOpeningBalanceDetails.Where(x => x.ProductOBMId == model.Id).ToListAsync();
                    if (existingProductOpeningDetals != null && existingProductOpeningDetals.Count > 0)
                        _dbContext.ProductOpeningBalanceDetails.RemoveRange(existingProductOpeningDetals);
                    var productOpeningDetails = model.ProductOpeningDetails.Select(y => new ProductOpeningBalanceDetail
                    {
                        ProductOBMId = result.Id,
                        ProductId = y.ProductId,
                        WarehouseId = y.WarehouseId,
                        BatchNo = y.BatchNo,
                        Quantity = y.Quantity,
                        Price = y.Price,
                        Amount = y.Amount
                    }).ToList();
                    await _dbContext.ProductOpeningBalanceDetails.AddRangeAsync(productOpeningDetails);
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
        public async Task<bool> PostOpeningBalance(int openingMasterId)
        {
            if (openingMasterId != 0)
            {
                var openingProducts = await _dbContext.ProductOpeningBalanceMasters.Where(x => x.Id == openingMasterId).Select(mMaster => new
                {
                    openingMaster = mMaster,
                    openingDetail = mMaster.ProductOpeningBalanceDetails
                }).FirstOrDefaultAsync();

                foreach (var masterDetailItem in openingProducts.openingDetail)
                {
                    var productLedger = new ProductLedger()
                    {
                        Date = openingProducts.openingMaster.Date,
                        ProductId = masterDetailItem.ProductId,
                        TransNo = "OB",
                        Quantity = masterDetailItem.Quantity,
                        WarehouseId = masterDetailItem.WarehouseId,
                        BatchNo = masterDetailItem.BatchNo,
                        IsOut = false,
                        AddedBy = _dbContext.Users.AsNoTracking().Select(x => x.Id).FirstOrDefault(),
                        AddedOn = DateTime.UtcNow.AddHours(5),
                        Remarks = "Opening Balance"
                    };
                    await _dbContext.ProductLedgers.AddAsync(productLedger);
                }
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
    }
}

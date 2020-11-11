using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.ManufacturingBillExpense;
using SDMS_API.ViewModels.ManufacturingBillMaster;
using SDMS_API.ViewModels.ManufacturingBillProductDetail;
using SDMS_API.ViewModels.ManufacturingMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManufacturingBillController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ManufacturingBillController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ManufacturingBillMasterListingVM>> GetManufacturingBills()
        {
            var results = await _dbContext.ManufacturingBillMasters.Select(x => new ManufacturingBillMasterListingVM
            {
                Id = x.Id,
                Date = x.Date,
                Code = x.Code,
                ManufacturingNumber = x.TblManufacturingMaster.Code,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                ManufacturingBillDetails = x.ManufacturingBillProductDetails.Select(y => new ManufacturingBillDetailListingVM
                {
                    ProductName = y.TblProduct.Name,
                    BatchNo = y.BatchNo,
                    Quantity = y.Quantity,
                    Price = y.Price
                }),
                ManufacturingBillExpenses = x.ManufacturingBillExpenses.Select(e => new ManufacturingBillExpenseListingVM
                {
                    AccountName = e.TblChartofAccount.Name,
                    Amount = e.Amount
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ManufacturingBillMasterDetailVM> GetManufacturingBillById(int manufacturingBillId)
        {
            var result = await _dbContext.ManufacturingBillMasters.Where(x => x.Id == manufacturingBillId).Select(x => new ManufacturingBillMasterDetailVM
            {
                Id = x.Id,
                Code = x.Code,
                Date = x.Date,
                ManufacturingNumber = x.TblManufacturingMaster.Code,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                CreatedBy = x.TblUpdatedByUser != null ? x.TblUpdatedByUser.Name : x.TblAddedByUser.Name,
                RawMaterialCost = x.RawMaterialCost,
                ExpenseCost = x.ExpenseCost,
                TotalCost = x.TotalCost,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                ManufacturingBillDetails = x.ManufacturingBillProductDetails.Select(y => new ManufacturingBillDetailDetailVM
                {
                    ProductName = y.TblProduct.Name,
                    Quantity = y.Quantity,
                    BatchNo = y.BatchNo,
                    Price = y.Price
                }),
                ManufacturingBillExpenses = x.ManufacturingBillExpenses.Select(e => new ManufacturingBillExpenseDetailVM
                {
                    AccountName = e.TblChartofAccount.Name,
                    Amount = e.Amount
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteManufacturingBillById(int manufacturingBillId)
        {
            var result = await _dbContext.ManufacturingBillMasters.Where(x => x.Id == manufacturingBillId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ManufacturingBillMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateManufacturingBill(ManufacturingBillMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastBOMCode = string.Empty;
                var LastBOM = _dbContext.ManufacturingBillMasters.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastBOM != null)
                    lastBOMCode = LastBOM.Code;
                var manufacturingBillMaster = new ManufacturingBillMaster()
                {
                    Date = model.Date,
                    Code = lastBOMCode.GenerateNextCode("MB"),
                    ManufacturingId = model.ManufacturingId,
                    ExpenseCost = model.ExpenseCost,
                    RawMaterialCost = model.RawMaterialCost,
                    TotalCost = model.RawMaterialCost + model.ExpenseCost,
                    IsPosted = model.IsPosted,
                    AddedBy = model.AddedBy,
                    AddedOn = DateTime.UtcNow.AddHours(5),
                    ManufacturingBillProductDetails = model.ManufacturingBillDetails.Select(x => new ManufacturingBillProductDetail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Amount,
                        BatchNo = x.BatchNo
                    }).ToList(),
                    ManufacturingBillExpenses = model.ManufacturingBillExpenses.Select(y => new ManufacturingBillExpenses
                    {
                        COAId = y.COAId,
                        Amount = y.Amount
                    }).ToList()
                };
                await _dbContext.ManufacturingBillMasters.AddAsync(manufacturingBillMaster);
                await _dbContext.SaveChangesAsync();
                return manufacturingBillMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditManufacturingBillById(ManufacturingBillMasterEditVM model)
        {
            var result = await _dbContext.ManufacturingBillMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Date = model.Date;
                result.ManufacturingId = model.ManufacturingId;
                result.RawMaterialCost = model.RawMaterialCost;
                result.ExpenseCost = model.ExpenseCost;
                result.TotalCost = model.RawMaterialCost + model.ExpenseCost;
                result.UpdatedBy = model.UpdatedBy;
                result.UpdatedOn = DateTime.UtcNow.AddHours(5);
                var existingManufacturingBillDetails = await _dbContext.ManufacturingBillProductDetails.Where(x => x.BillId == model.Id).ToListAsync();
                if (existingManufacturingBillDetails != null && existingManufacturingBillDetails.Count > 0)
                    _dbContext.ManufacturingBillProductDetails.RemoveRange(existingManufacturingBillDetails);
                var existingManufacturingBillExpense = await _dbContext.ManufacturingBillExpenses.Where(x => x.BillId == model.Id).ToListAsync();
                if (existingManufacturingBillExpense != null && existingManufacturingBillExpense.Count > 0)
                    _dbContext.ManufacturingBillExpenses.RemoveRange(existingManufacturingBillExpense);
                var manufacturingBillDetail = model.ManufacturingBillDetails.Select(x => new ManufacturingBillProductDetail
                {
                    BillId = result.Id,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    BatchNo = x.BatchNo,
                }).ToList();
                var manufacturingBillExpense = model.ManufacturingBillExpenses.Select(y => new ManufacturingBillExpenses
                {
                    BillId = result.Id,
                    COAId = y.COAId,
                    Amount = y.Amount
                }).ToList();
                await _dbContext.ManufacturingBillProductDetails.AddRangeAsync(manufacturingBillDetail);
                await _dbContext.ManufacturingBillExpenses.AddRangeAsync(manufacturingBillExpense);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }

        [HttpGet]
        public async Task<IEnumerable<RawMaterialPriceVM>> GetRawMaterialPrices(int id)
        {
            //var abc = await _dbContext.PurchaseMasters.Where(x => selectedBatchNo.Contains(x.BatchNo)).Select(x => x.PurchaseDetails.FirstOrDefault(y => y.ProductId))

            var records = await _dbContext.ManufacturingRawDetails.Where(x => x.TblManufacturingDetail.ManufacturingMasterId == id).Select(x => new
            {
                x.TblManufacturingDetail.ProductId,
                ProductName = x.TblManufacturingDetail.TblProduct.Name,
                x.Quantity,
                x.BatchNo,
            }).ToListAsync();

            var selectedBatchNo = records.Select(x => x.BatchNo);
            var selectedProductId = records.Select(x => x.ProductId);

            var productPurchasePrices = await _dbContext.PurchaseDetails.Where(x =>
            selectedProductId.Contains(x.ProductId) &&
            selectedBatchNo.Contains(x.TblPurchaseMaster.BatchNo))
                .Select(x => new { x.Price, x.ProductId, x.TblPurchaseMaster.BatchNo }).ToListAsync();


            var productOpeningPrices = await _dbContext.ProductOpeningBalanceDetails
                .Where(x => selectedProductId.Contains(x.ProductId) && selectedBatchNo.Contains(x.BatchNo))
                .Select(x => new { x.Price, x.ProductId, x.BatchNo }).ToListAsync();


            var response = records.Select(x => new RawMaterialPriceVM()
            {
                Id = x.ProductId ?? 0,
                Name = x.ProductName,
                Quantity = x.Quantity,
                BatchNo = x.BatchNo,
                AvgRate =
                    productPurchasePrices.FirstOrDefault(y => y.BatchNo == x.BatchNo && y.ProductId == x.ProductId) != null ?
                    productPurchasePrices.FirstOrDefault(y => y.BatchNo == x.BatchNo && y.ProductId == x.ProductId).Price :
                    (productOpeningPrices.FirstOrDefault(y => y.BatchNo == x.BatchNo && y.ProductId == x.ProductId) != null ? 
                    productOpeningPrices.FirstOrDefault(y => y.BatchNo == x.BatchNo && y.ProductId == x.ProductId).Price : 0)
            }).ToList();

            return response;
        }
    }
}

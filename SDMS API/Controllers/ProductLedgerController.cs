using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.ProductLedger;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductLedgerController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ProductLedgerController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductLedgerListingVM>> GetProductLedgers()
        {
            var results = await _dbContext.ProductLedgers.Select(x => new ProductLedgerListingVM
            {
                Id = x.Id,
                ProductName = x.TblProduct.Name,
                Date = x.Date,
                TransNo = x.TransNo,
                SerialNo = x.SerialNo,
                Quantity = x.Quantity,
                InOutStatus = x.IsOut ? "O" : "I",
                WarehouseName = x.TblWarehouse.Name,
                BatchNo = x.BatchNo
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductLedgerListingVM>> GetProductLedgersByTransNo(string TransNo)
        {
            var results = await _dbContext.ProductLedgers.Where(x=> x.TransNo==TransNo).Select(x => new ProductLedgerListingVM
            {
                Id = x.Id,
                ProductName = x.TblProduct.Name,
                Date = x.Date,
                TransNo = x.TransNo,
                SerialNo = x.SerialNo,
                Quantity = x.Quantity,
                InOutStatus = x.IsOut ? "O" : "I",
                WarehouseName = x.TblWarehouse.Name,
                BatchNo = x.BatchNo
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ProductLedgerDetailVM> GetProductLedgerById(int productLedgerId)
        {
            var result = await _dbContext.ProductLedgers.Where(x => x.Id == productLedgerId).Select(x => new ProductLedgerDetailVM
            {
                Id = x.Id,
                ProductName = x.TblProduct.Name,
                Date = x.Date,
                TransNo = x.TransNo,
                SerialNo = x.SerialNo,
                Quantity = x.Quantity,
                InOutStatus = x.IsOut ? "I" : "O",
                WarehouseName = x.TblWarehouse.Name,
                BatchNo = x.BatchNo,
                Remarks = x.Remarks
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteProductLedgerById(int productLedgerId)
        {
            var result = await _dbContext.ProductLedgers.Where(x => x.Id == productLedgerId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ProductLedgers.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateProductLedger(ProductLedgerCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var productLedger = new ProductLedger()
                {
                    Date = model.Date,
                    ProductId = model.ProductId,
                    TransNo = model.TransNo,
                    SerialNo = model.SerialNo,
                    Quantity = model.Quantity,
                    IsOut = model.IsOut,
                    WarehouseId = model.WarehouseId,
                    BatchNo = model.BatchNo,
                    AddedBy=model.AddedBy,
                    AddedOn=DateTime.Now,
                    Remarks = model.Remarks
                };
                await _dbContext.ProductLedgers.AddAsync(productLedger);
                await _dbContext.SaveChangesAsync();
                return productLedger.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditProductLedgerById(ProductLedgerEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.ProductLedgers.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    result.ProductId = model.ProductId;
                    result.TransNo = model.TransNo;
                    result.Quantity = model.Quantity;
                    result.SerialNo = model.SerialNo;
                    result.IsOut = model.IsOut;
                    result.WarehouseId = model.WarehouseId;
                    result.BatchNo = model.BatchNo;
                    result.Remarks = model.Remarks;
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

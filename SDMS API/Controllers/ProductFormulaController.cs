using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.ProductFormulaDetail;
using SDMS_API.ViewModels.ProductFormulaMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductFormulaController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;
        public ProductFormulaController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductFormulaListingVM>> GetProductFormulas()
        {
            var results = await _dbContext.ProductFormulaMasters.Select(x => new ProductFormulaListingVM
            {
                Id = x.Id,
                ProductName = x.TblProduct.Name,
                ProductFormulaDetails = x.ProductFormulaDetails.Select(y => new ProductFormulaDetailListingVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    Quantity = y.Quantity
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ProductFormulaMasterDetailVM> GetProductFormulaById(int productFormulaId)
        {
            var result = await _dbContext.ProductFormulaMasters.Where(x => x.Id == productFormulaId).Select(x => new ProductFormulaMasterDetailVM
            {
                Id = x.Id,
                ProductId = x.TblProduct.Id,
                ProductFormulaDetails = x.ProductFormulaDetails.Select(y => new ProductFormulaDetailDetailVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    Quantity = y.Quantity
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteProductFormulaById(int productFormulaId)
        {
            var result = await _dbContext.ProductFormulaMasters.Where(x => x.Id == productFormulaId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ProductFormulaMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateProductFormula(ProductFormulaMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var productFormulaMaster = new ProductFormulaMaster()
                {
                    ProductId = model.ProductId,
                    ProductFormulaDetails = model.ProductFormulaDetails.Select(x => new ProductFormulaDetail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    }).ToList()
                };
                await _dbContext.ProductFormulaMasters.AddAsync(productFormulaMaster);
                await _dbContext.SaveChangesAsync();
                return productFormulaMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditProductFormulaById(ProductFormulaMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.ProductFormulaMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.ProductId = model.ProductId;
                    var existingVoucherDetails = await _dbContext.ProductFormulaDetails.Where(x => x.FormulaMasterId == model.Id).ToListAsync();
                    if (existingVoucherDetails != null && existingVoucherDetails.Count > 0)
                    {
                        _dbContext.ProductFormulaDetails.RemoveRange(existingVoucherDetails);
                    }
                    var productFormulaDetails = model.ProductFormulaDetails.Select(x => new ProductFormulaDetail
                    {
                        FormulaMasterId = result.Id,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    }).ToList();
                    await _dbContext.ProductFormulaDetails.AddRangeAsync(productFormulaDetails);
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

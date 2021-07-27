using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.Product;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;
        public ProductController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductListingVM>> GetProducts()
        {
            var results = await _dbContext.Products.Select(x => new ProductListingVM
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Date = x.CreatedDate,
                CategoryName = x.TblProductCategory.Name,
                MeasureUnitName = x.TblMeasureUnit.Name,
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ProductDetailVM> GetProductById(int productId)
        {
            var result = await _dbContext.Products.Where(x => x.Id == productId).Select(x => new ProductDetailVM
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Date = x.CreatedDate,
                Remarks = x.Remarks,
                Status = x.IsActive ? "Active" : "Inactive",
                CategoryName = x.TblProductCategory.Name,
                MeasureUnitName = x.TblMeasureUnit.Name,
                RetailPrice=x.RetailPrice,
                ActualPrice=x.ActualPrice
                
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteProductById(int productId)
        {
            var result = await _dbContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Products.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateProduct(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastProductCode = string.Empty;
                var LastProduct = _dbContext.Products.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastProduct != null)
                    lastProductCode = LastProduct.Code;
                var product = new Product()
                {
                    
                    Code = lastProductCode.GenerateNextCode("PC"),
                    Name = model.Name,
                    CreatedDate = model.Date,
                    CategoryId = model.ProductCategoryId,
                    MeasureUnitID = model.MeasureUnitId,
                    RetailPrice = model.RetailPrice,
                    ActualPrice = model.ActualPrice,
                    IsActive = model.IsActive,
                    Remarks = model.Remarks,
                    InventoryCOAId = model.InventoryCOAId,
                    CostOfGoodsSoldCOAId = model.CostOfGoodsSoldCOAId,
                    SaleCOAId = model.SaleCOAId,
                    SaleDiscountCOAId = model.SaleDiscountCOAId,
                    SaleReturnCOAId = model.SaleReturnCOAId,
                };
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
            return -1;
        }

        [HttpPut]
        public async Task<int> EditProduct(ProductEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Products.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    result.CreatedDate = model.Date;
                    result.MeasureUnitID = model.MeasureUnitId;
                    result.CategoryId = model.ProductCategoryId;
                    result.RetailPrice = model.RetailPrice;
                    result.ActualPrice = model.ActualPrice;
                    result.CostOfGoodsSoldCOAId = model.CostOfGoodsSoldCOAId;
                    result.InventoryCOAId = model.InventoryCOAId;
                    result.SaleCOAId = model.SaleCOAId;
                    result.SaleDiscountCOAId = model.SaleDiscountCOAId;
                    result.SaleReturnCOAId = model.SaleReturnCOAId;
                    result.Remarks = model.Remarks;
                    result.IsActive = model.IsActive;
                    await _dbContext.SaveChangesAsync();
                    return result.Id;
                }
                else
                    return -1;
            }
            else return -1;
        }
    }
}

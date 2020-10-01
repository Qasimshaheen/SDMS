using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.ProductCategory;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ProductCategoryController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductCategoryListingVM>> GetProductCategories()
        {
            var results = await _dbContext.ProductCategories.Select(x => new ProductCategoryListingVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ProductCategoryDetailVM> GetProductCategoryById(int ProductCategoryId)
        {
            var result = await _dbContext.ProductCategories.Where(x => x.Id == ProductCategoryId).Select(x => new ProductCategoryDetailVM
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteProductCategoryById(int ProductCategoryId)
        {
            var result = await _dbContext.ProductCategories.Where(x => x.Id == ProductCategoryId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ProductCategories.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateProductCategory(ProductCategoryCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var productcategory = new ProductCategory()
                {
                    Name = model.Name
                };
                await _dbContext.ProductCategories.AddAsync(productcategory);
                await _dbContext.SaveChangesAsync();
                return productcategory.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditProductCategory(ProductCategoryEditVM model)
        {
            var result = await _dbContext.ProductCategories.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Name = model.Name;
                await _dbContext.SaveChangesAsync();
                return result.Id;
            }
            else
                return -1;
        }
    }
}

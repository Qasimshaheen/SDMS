using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Warehouse;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public WarehouseController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<WarehouseListingVM>> GetWarehouses()
        {
            var results = await _dbContext.Warehouses.Select(x => new WarehouseListingVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<WarehouseDetailVM> GetWarehouseById(int warehouseId)
        {
            var result = await _dbContext.Warehouses.Where(x => x.Id == warehouseId).Select(x => new WarehouseDetailVM
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteWarehouseById(int warehouseiId)
        {
            var result = await _dbContext.Warehouses.Where(x => x.Id == warehouseiId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Warehouses.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateWarehouse(WarehouseCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var warehouse = new Warehouse()
                {
                    Name = model.Name,
                    Address = model.Address
                };
                await _dbContext.Warehouses.AddAsync(warehouse);
                await _dbContext.SaveChangesAsync();
                return warehouse.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditWarehouse(WarehouseEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Warehouses.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    result.Address = model.Address;
                    await _dbContext.SaveChangesAsync();
                    return model.Id;
                }
                else return -1;
            }
            else return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.City;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public CityController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<CityListingVM>> GetCities()
        {
            var results = await _dbContext.Cities.Select(x => new CityListingVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<CityDetailVM> GetCityById(int cityId)
        {
            var result = await _dbContext.Cities.Where(x => x.Id == cityId).Select(x => new CityDetailVM
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpPost]
        public async Task<int> CreateCity(CityCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var city = new City()
                {
                    Name = model.Name
                };
                await _dbContext.Cities.AddAsync(city);
                await _dbContext.SaveChangesAsync();
                return city.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditCityById(CityEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Cities.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    await _dbContext.SaveChangesAsync();
                    return result.Id;
                }
                else
                    return -1;
            }
            else
                return -1;
        }
        [HttpDelete]
        public async Task<bool> DeleteCityById(int cityId)
        {
            var result = await _dbContext.Cities.Where(x => x.Id == cityId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Cities.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.MesureUnit;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeasureUnitController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public MeasureUnitController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<MeasureUnitListingVM>> GetMeasureUnits()
        {
            var results = await _dbContext.MeasureUnits.Select(x => new MeasureUnitListingVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<MeasureUnitDetailVM> GetMeasureUnitsById(int mesureUnitId)
        {
            var result = await _dbContext.MeasureUnits.Where(x => x.Id == mesureUnitId).Select(x => new MeasureUnitDetailVM
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteMeasureUnitById(int mesureUnitId)
        {
            var result = await _dbContext.MeasureUnits.Where(x => x.Id == mesureUnitId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.MeasureUnits.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateMeasureUnit(MeasureUnitCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var mesureUnit = new MeasureUnit()
                {
                    Name = model.Name
                };
                await _dbContext.MeasureUnits.AddAsync(mesureUnit);
                await _dbContext.SaveChangesAsync();
                return mesureUnit.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditMeasureUnt(MeasureUnitEditVM model)
        {
            var result = await _dbContext.MeasureUnits.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Shift;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ShiftController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ShiftListingVM>> GetShifts()
        {
            var results = await _dbContext.Shifts.Select(x => new ShiftListingVM
            {
                Id = x.Id,
                Name = x.Name

            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ShiftDetailVM> GetShiftById(int shiftId)
        {
            var result = await _dbContext.Shifts.Where(x => x.Id == shiftId).Select(x => new ShiftDetailVM
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteShiftById(int shiftId)
        {
            var result = await _dbContext.Shifts.Where(x => x.Id == shiftId).FirstOrDefaultAsync();
            if(result != null)
            {
                _dbContext.Shifts.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateShift(ShiftCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var shift = new Shift()
                {
                    Name = model.Name
                };
                await _dbContext.AddAsync(shift);
                await _dbContext.SaveChangesAsync();
                return shift.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditShiftById(ShiftEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Shifts.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
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
        
    }
}

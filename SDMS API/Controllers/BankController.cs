using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Bank;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public BankController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<BankListingVM>> GetBanks()
        {
            var results = await _dbContext.Bank.Select(x => new BankListingVM()
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.IsActive ? "Active" : "InActive"
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<BankDetailVM> GetBankById(int bankId)
        {
            var result = await _dbContext.Bank.Where(x => x.Id == bankId).Select(x => new BankDetailVM()
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.IsActive ? "Active" : "InActive"
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteBankById(int bankId)
        {
            var result = await _dbContext.Bank.Where(x => x.Id == bankId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Bank.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateBank(BankCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var bank = new Bank()
                {
                    Name = model.Name,
                    IsActive = model.IsActive
                };
                await _dbContext.Bank.AddAsync(bank);
                await _dbContext.SaveChangesAsync();
                return bank.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditBankById(BankEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Bank.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    result.IsActive = model.IsActive;
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

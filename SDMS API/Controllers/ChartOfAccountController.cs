using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SDMS_API.Data;
using SDMS_API.ViewModels.ChartOfAccount;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ChartOfAccountController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ChartOfAccountListingVM>> GetChartOfAccounts()
        {
            var results = await _dbContext.ChartofAccounts.Select(x => new ChartOfAccountListingVM 
            { 
                Id=x.Id,
                Name=x.Name,
                AccountCode=x.Code,
                Category=x.Category
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ChartOfAccountDetailVM> GetChartOfAccountById(int chartOfAccountId)
        {
            var result = await _dbContext.ChartofAccounts.Where(x=>x.Id==chartOfAccountId).Select(x => new ChartOfAccountDetailVM
            {
                Id = x.Id,
                Name = x.Name,
                AccountCode = x.Code,
                Category = x.Category,
                IsDetailAccount=x.IsDetailAccount,
                Status=x.IsActive ? "Active" : "Inctive",
                ParentAccount=x.TblParentChartOfAccount !=null ? x.TblParentChartOfAccount.Name : ""
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteChartOfAccountById(int chartOfAccountId)
        {
            var result = await _dbContext.ChartofAccounts.Where(x => x.Id == chartOfAccountId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ChartofAccounts.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateChartOfAccount(ChartOfAccountCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var chartOfAccount = new ChartofAccount()
                {
                    Name = model.Name,
                    Code = model.AccountCode,
                    Category = model.Category,
                    ParentAccountId = model.ParentAccountId,
                    IsDetailAccount = model.IsDetailAccount,
                    IsDebit = model.IsDebit,
                    IsActive = model.IsActive
                };
                await _dbContext.ChartofAccounts.AddAsync(chartOfAccount);
                await _dbContext.SaveChangesAsync();
                return chartOfAccount.Id;
            }
            else
                return -1;
        }
    }
}

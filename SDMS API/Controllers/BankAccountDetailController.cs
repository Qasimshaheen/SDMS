using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Bank;
using SDMS_API.ViewModels.BankAccountDetail;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankAccountDetailController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public BankAccountDetailController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<BankAccountDetailListingVM>> GetBankAccountDetails()
        {
            var results = await _dbContext.BankAccoountDetails.Select(x => new BankAccountDetailListingVM()
            {
                Id = x.Id,
                BankName = x.TblBank.Name,
                BranchName = x.BranchName,
                BankAccountTypeName = x.TblBankAccountType.Description,
                AccountNumber = x.AccountNumber,
                AccountTitle = x.AccountTitle
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<BankAccountDetailDetailVM> GetBankAccountDetailById(int bankAccountDetailId)
        {
            var result = await _dbContext.BankAccoountDetails.Where(x => x.Id == bankAccountDetailId).Select(x => new BankAccountDetailDetailVM
            {
                Id = x.Id,
                BankName = x.TblBank.Name,
                BranchName = x.BranchName,
                BankAccountTypeName = x.TblBankAccountType.Description,
                AccountNumber = x.AccountNumber,
                AccountTitle = x.AccountTitle,
                ChartofAccountName = x.TblChartofAccount.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteBankAccountDetailById(int bankAccountDetailId)
        {
            var result = await _dbContext.BankAccoountDetails.Where(x => x.Id == bankAccountDetailId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.BankAccoountDetails.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateBankAccountDetail(BankAccountDetailCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var bankAccountDetail = new BankAccoountDetail()
                {
                    BankId = model.BankId,
                    BankAccountTypeId = model.BankAccountTypeId,
                    BranchName = model.BranchName,
                    COAId = model.COAId,
                    AccountNumber = model.AccountNumber,
                    AccountTitle = model.AccountTitle
                };
                await _dbContext.BankAccoountDetails.AddAsync(bankAccountDetail);
                await _dbContext.SaveChangesAsync();
                return bankAccountDetail.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditBankAccountDetailById(BankAccountDetailEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.BankAccoountDetails.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.BankId = model.BankId;
                    result.BankAccountTypeId = model.BankAccountTypeId;
                    result.BranchName = model.BranchName;
                    result.COAId = model.COAId;
                    result.AccountNumber = model.AccountNumber;
                    result.AccountTitle = model.AccountTitle;
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

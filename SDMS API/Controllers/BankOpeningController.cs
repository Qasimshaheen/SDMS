using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.BankOpeningDetail;
using SDMS_API.ViewModels.BankOpeningMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankOpeningController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public BankOpeningController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<BankOpeningMasterListingVM>> GetBankOpenings()
        {
            var results = await _dbContext.BankOpeningBalanceMasters.Select(x => new BankOpeningMasterListingVM
            {
                Id = x.Id,
                Date = x.Date,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                BankOpeningDetails = x.BankOpeningBalanceDetails.Select(y => new BankOpeningDetailListingVM
                {
                    Id = y.Id,
                    BankAccountName = $"{ y.TblBankAccoountDetail.BranchName } - {y.TblBankAccoountDetail.TblBank.Name}",
                    OpeningBalance = y.OpeningBalance
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<BankOpeningMasterDetailVM> GetBankOpeningById(int bankOpeningId)
        {
            var result = await _dbContext.BankOpeningBalanceMasters.Where(x => x.Id == bankOpeningId).Select(x => new BankOpeningMasterDetailVM
            {
                Date = x.Date,
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                BankOpeningDetails = x.BankOpeningBalanceDetails.Select(y => new BankOpeningDetailDetailVM
                {
                    Id = y.Id,
                    BankAccountName = $"{ y.TblBankAccoountDetail.BranchName } - {y.TblBankAccoountDetail.TblBank.Name}",
                    OpeningBalance = y.OpeningBalance
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteBankOpeningById(int bankOpeningId)
        {
            var result = await _dbContext.BankOpeningBalanceMasters.Where(x => x.Id == bankOpeningId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.BankOpeningBalanceMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateBankOpening(BankOpeningMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var bankOpeningMaster = new BankOpeningBalanceMaster()
                {
                    Date = model.Date,
                    IsPosted = model.IsPosted,
                    BankOpeningBalanceDetails = model.BankOpeningDetails.Select(x => new BankOpeningBalanceDetail
                    {
                        OpeningBalance = x.OpeningBalance,
                        BankAccountDetailId = x.BankAccountDetailId
                    }).ToList()
                };
                await _dbContext.BankOpeningBalanceMasters.AddAsync(bankOpeningMaster);
                await _dbContext.SaveChangesAsync();
                return bankOpeningMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditBankOpeningBalanceById(BankOpeningMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.BankOpeningBalanceMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    var existingBankOpeningDetails = await _dbContext.BankOpeningBalanceDetails.Where(x => x.BankOBMId == model.Id).ToListAsync();
                    if (existingBankOpeningDetails != null && existingBankOpeningDetails.Count > 0)
                        _dbContext.BankOpeningBalanceDetails.RemoveRange(existingBankOpeningDetails);
                    var bankOpeningDetail = model.BankOpeningDetails.Select(x => new BankOpeningBalanceDetail
                    {
                        BankOBMId = result.Id,
                        BankAccountDetailId = x.BankAccountDetailId,
                        OpeningBalance = x.OpeningBalance
                    }).ToList();
                    await _dbContext.BankOpeningBalanceDetails.AddRangeAsync(bankOpeningDetail);
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

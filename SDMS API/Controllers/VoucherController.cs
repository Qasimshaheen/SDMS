using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.VoucherMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public VoucherController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<VoucherListingVM>> GetVoucherMasters()
        {
            var results = await _dbContext.VoucherMasters.Select(x => new VoucherListingVM
            {
                Id = x.Id,
                VoucherNumber = x.VoucherNumber,
                TotalCredit = x.TotalCredit,
                TotalDebit = x.TotalDebit,
                CreatedBy = x.TblUpdatedByUser != null ? x.TblUpdatedByUser.Name : x.TblAddedByUser.Name,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                VoucherDetails = x.VoucherDetails.Select(y => new ViewModels.VoucherDetail.VoucherDetailListingVM
                {
                    Id = y.Id,
                    CustomerName = y.TblCustomer != null ? y.TblCustomer.Name : "",
                    VendorName = y.TblVendor != null ? y.TblVendor.Name : "",
                    AccountName = y.ChartofAccount.Name,
                    FlagDC = y.IsDebit ? "D" : "C",
                    Amount = y.Amount,
                    Remarks = y.Remarks
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<VoucherMasterDetailVM> GetVoucherMasterById(int voucherMasterId)
        {
            var result = await _dbContext.VoucherMasters.Where(x => x.Id == voucherMasterId).Select(x => new VoucherMasterDetailVM
            {
                Id = x.Id,
                Date = x.Date,
                VoucherType = x.VoucherType,
                VoucherNumber = x.VoucherNumber,
                TotalCredit = x.TotalCredit,
                TotalDebit = x.TotalDebit,
                Narration = x.Narration,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                CreatedBy = x.TblUpdatedByUser != null ? x.TblUpdatedByUser.Name : x.TblAddedByUser.Name,
                VoucherDetails = x.VoucherDetails.Select(y => new ViewModels.VoucherDetail.VoucherDetailDetailVM
                {
                    Id = y.Id,
                    CustomerName = y.TblCustomer != null ? y.TblCustomer.Name : "",
                    VendorName = y.TblVendor != null ? y.TblVendor.Name : "",
                    AccountName = y.ChartofAccount.Name,
                    FlagDC = y.IsDebit ? "D" : "C",
                    Amount = y.Amount,
                    Remarks = y.Remarks
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteVoucherMasterById(int voucherMasterId)
        {
            var result = await _dbContext.VoucherMasters.Where(x => x.Id == voucherMasterId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.VoucherMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateVoucherMaster(VoucherMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastVoucherNumber = string.Empty;
                var LastVoucherNumber = _dbContext.VoucherMasters.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastVoucherNumber != null)
                    lastVoucherNumber = LastVoucherNumber.VoucherNumber;

                var voucherMaster = new VoucherMaster()
                {
                    Date = model.Date,
                    VoucherType = model.VoucherType,
                    VoucherNumber = lastVoucherNumber.GenerateNextCode(model.VoucherType),
                    Narration = model.Narration,
                    ChequeNo = model.ChequeNo,
                    ChequeDate = model.ChequeDate,
                    IsPosted = model.IsPosted,
                    TotalCredit = model.VoucherDetails.Where(x => !x.IsDebit).Sum(x => x.Amount),
                    TotalDebit = model.VoucherDetails.Where(x => x.IsDebit).Sum(x => x.Amount),
                    AddedOn = DateTime.Now,
                    AddedBy = model.AddedBy,
                    VoucherDetails = model.VoucherDetails.Select(x => new VoucherDetail
                    {
                        CustomerId = x.CustomerId,
                        VendorId = x.VendorId,
                        COAId = x.COAId,
                        IsDebit = x.IsDebit,
                        Amount = x.Amount,
                        Remarks = x.Remarks
                    }).ToList()
                };
                await _dbContext.VoucherMasters.AddAsync(voucherMaster);
                await _dbContext.SaveChangesAsync();
                return voucherMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditVoucherMasterById(VoucherMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.VoucherMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    result.Narration = model.Narration;
                    result.TotalCredit = model.VoucherDetails.Where(x => !x.IsDebit).Sum(x => x.Amount);
                    result.TotalDebit = model.VoucherDetails.Where(x => x.IsDebit).Sum(x => x.Amount);
                    result.ChequeNo = model.ChequeNo;
                    result.ChequeDate = model.ChequeDate;
                    result.UpdatedOn = DateTime.Now;
                    result.UpdatedBy = model.UpdatedBy;
                    var existingVoucherDetails = await _dbContext.VoucherDetails.Where(x => x.VoucherMasterId == model.Id).ToListAsync();
                    if (existingVoucherDetails != null && existingVoucherDetails.Count > 0)
                    {
                        _dbContext.VoucherDetails.RemoveRange(existingVoucherDetails);
                    }
                    var voucherDetails = model.VoucherDetails.Select(x => new VoucherDetail
                    {
                        VoucherMasterId = result.Id,
                        CustomerId = x.CustomerId,
                        VendorId = x.VendorId,
                        COAId = x.COAId,
                        IsDebit = x.IsDebit,
                        Amount = x.Amount,
                        Remarks = x.Remarks
                    }).ToList();
                    await _dbContext.VoucherDetails.AddRangeAsync(voucherDetails);
                   var count= await _dbContext.SaveChangesAsync();
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

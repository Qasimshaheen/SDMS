using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.CustomerOpeningDetail;
using SDMS_API.ViewModels.CustomerOpeningMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerOpeningController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public CustomerOpeningController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<CustomerOpeningMasterListingVM>> GetCustomerOpenings()
        {
            var results = await _dbContext.CustomerOpeningBalanceMasters.Select(x => new CustomerOpeningMasterListingVM
            {
                Id = x.Id,
                Date = x.Date,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                CustomerOpeningDetails = x.CustomerOpeningBalanceDetails.Select(y => new CustomerOpeningDetailListingVM
                {
                    Id = y.Id,
                    CustomerName = y.TblCustomer.Name,
                    OpeningBalance = y.OpeningBalance,
                    OpeningReceipt = y.OpeningReceipt,
                    OpeningAdvance = y.OpeningAdvance,

                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<CustomerOpeningMasterDetailVM> GetCustomerOpeningById(int customerOBMId)
        {
            var result = await _dbContext.CustomerOpeningBalanceMasters.Where(x => x.Id == customerOBMId).Select(x => new CustomerOpeningMasterDetailVM
            {
                Id = x.Id,
                Date = x.Date,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                VoucherNumber = x.TblVoucherMaster != null ? x.TblVoucherMaster.VoucherNumber : "",
                CustomerOpeningDetails = x.CustomerOpeningBalanceDetails.Select(y => new CustomerOpeningDetailDetailVM
                {
                    CustomerName = y.TblCustomer.Name,
                    OpeningBalance = y.OpeningBalance,
                    OpeningReceipt = y.OpeningReceipt,
                    OpeningAdvance = y.OpeningAdvance
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteCustomerOpeningById(int customeOBMId)
        {
            var result = await _dbContext.CustomerOpeningBalanceMasters.Where(x => x.Id == customeOBMId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.CustomerOpeningBalanceMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateCustomerOpening(CustomerOpeningMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var customerOpeningMaster = new CustomerOpeningBalanceMaster()
                {
                    Date = model.Date,
                    IsPosted = model.IsPosted,
                    CustomerOpeningBalanceDetails = model.CustomerOpeningDetails.Select(x => new CustomerOpeningBalanceDetail
                    {
                        CustomerId = x.CustomerId,
                        OpeningBalance = x.OpeningBalance,
                        OpeningReceipt = x.OpeningReceipt,
                        OpeningAdvance = x.OpeningAdvance
                    }).ToList()
                };
                await _dbContext.CustomerOpeningBalanceMasters.AddAsync(customerOpeningMaster);
                await _dbContext.SaveChangesAsync();
                return customerOpeningMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditCustomerOpeningById(CustomerOpeningMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.CustomerOpeningBalanceMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    var existingCustomerOpeningDetals = await _dbContext.CustomerOpeningBalanceDetails.Where(x => x.CustomerOBMId == model.Id).ToListAsync();
                    if (existingCustomerOpeningDetals != null && existingCustomerOpeningDetals.Count > 0)
                        _dbContext.CustomerOpeningBalanceDetails.RemoveRange(existingCustomerOpeningDetals);
                    var customerOpeningDetail = model.CustomerOpeningDetails.Select(x => new CustomerOpeningBalanceDetail
                    {
                        CustomerOBMId = result.Id,
                        CustomerId = x.CustomerId,
                        OpeningBalance = x.OpeningBalance,
                        OpeningReceipt = x.OpeningReceipt,
                        OpeningAdvance = x.OpeningAdvance
                    }).ToList();
                    await _dbContext.CustomerOpeningBalanceDetails.AddRangeAsync(customerOpeningDetail);
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

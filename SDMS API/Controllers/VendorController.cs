using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.Vendor;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public VendorController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<VendorListingVM>> GetVendors()
        {
            var results = await _dbContext.Vendors.Select(x => new VendorListingVM
            {
                Id = x.Id,
                Code = x.Code,
                AccountName = x.TblChartofAccount != null ? x.TblChartofAccount.Name : "",
                Name = x.Name,
                CityName = x.TblCity != null ? x.TblCity.Name : "",
                Status = x.IsActive ? "Active" : "Inactive"
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<VendorDetailVM> GetVendorById(int vendorId)
        {
            var result = await _dbContext.Vendors.Where(x => x.Id == vendorId).Select(x => new VendorDetailVM
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                AccountName = x.TblChartofAccount != null ? x.TblChartofAccount.Name : "",
                CityName = x.TblCity != null ? x.TblCity.Name : "",
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                Email = x.Email,
                Status = x.IsActive ? "Active" : "Inactive"
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteVendorById(int vendorId)
        {
            var result = await _dbContext.Vendors.Where(x => x.Id == vendorId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Vendors.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateVendor(VendorCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastVendorCode = string.Empty;
                var LastVendor = _dbContext.Vendors.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastVendor != null)
                    lastVendorCode = LastVendor.Code;
                var vendor = new Vendor()
                {
                    CityId = model.CityId,
                    COAId = model.COAId,
                    Code = lastVendorCode.GenerateNextCode("V"),
                    Name = model.Name,
                    Email = model.Email,
                    ContactNumber = model.ContactNumber,
                    Address = model.Address,
                    IsActive = model.IsActive
                };
                await _dbContext.Vendors.AddAsync(vendor);
                await _dbContext.SaveChangesAsync();
                return vendor.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditVendorById(VendorEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Vendors.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    result.CityId = model.CityId;
                    result.COAId = model.COAId;
                    result.ContactNumber = model.ContactNumber;
                    result.Email = model.Email;
                    result.Address = model.Address;
                    result.IsActive = model.IsActive;
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

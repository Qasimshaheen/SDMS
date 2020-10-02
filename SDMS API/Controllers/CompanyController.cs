using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Company;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public CompanyController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<CompanyListingVM>> GetCompanies()
        {
            var results = await _dbContext.Companies.Select(x => new CompanyListingVM
            {
                Id = x.Id,
                Name = x.Name,
                WarehouseName = x.TblWarehouse.Name
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<CompanyDetailVM> GetCompanyById(int companyId)
        {
            var result = await _dbContext.Companies.Where(x => x.Id == companyId).Select(x => new CompanyDetailVM
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                ContactNumber = x.ContactNumber,
                Email = x.Email,
                NTN = x.NTN,
                WarehouseName = x.TblWarehouse.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteCompanyById(int companyId)
        {
            var result = await _dbContext.Companies.Where(x => x.Id == companyId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Companies.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateCompany(CompanyCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var company = new Company()
                {
                    Name = model.Name,
                    Address = model.Address,
                    WarehouseId = model.WarehouseId,
                    ContactNumber = model.ContactNumber,
                    NTN = model.NTN,
                    Email = model.Email
                };
                await _dbContext.AddAsync(company);
                await _dbContext.SaveChangesAsync();
                return company.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditWarehouseById(CompanyEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Companies.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    result.NTN = model.NTN;
                    result.Address = model.Address;
                    result.Email = model.Email;
                    result.ContactNumber = model.ContactNumber;
                    result.WarehouseId = model.WarehouseId;
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

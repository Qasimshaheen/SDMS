using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.Customer;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public CustomerController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<CustomerListingVM>> GetCustomers()
        {
            var results = await _dbContext.Customers.Select(x => new CustomerListingVM
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                CityName = x.TblCity.Name,
                AccountName = x.TblChartofAccount.Name,
                Status = x.IsActive ? "Active" : "Inactive"
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<CustomerDetailVM> GetCustomerById(int customerId)
        {
            var result = await _dbContext.Customers.Where(x => x.Id == customerId).Select(x => new CustomerDetailVM
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                AccountName = x.TblChartofAccount != null ? x.TblChartofAccount.Name : "",
                CityName = x.TblCity.Name,
                ContactNumber = x.ContactNumber,
                Email = x.Email,
                Address = x.Address,
                Status = x.IsActive ? "Active" : "Inactive"
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteCustomerById(int customerId)
        {
            var result = await _dbContext.Customers.Where(x => x.Id == customerId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Customers.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateCustomer(CustomerCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastCustomerCode = string.Empty;
                var LastCustomer = _dbContext.Customers.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastCustomer != null)
                    lastCustomerCode = LastCustomer.Code;
                var customer = new Customer()
                {
                    Code = lastCustomerCode.GenerateNextCode("C"),
                    Name = model.Name,
                    CityId = model.CityId,
                    COAId = model.COAId,
                    Email = model.Email,
                    ContactNumber = model.ContactNumber,
                    IsActive = model.IsActive,
                    Address = model.Address
                };
                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
                return customer.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditCustomerById(CustomerEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Customers.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Employee;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public EmployeeController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<EmployeeListingVM>> GetEmployees()
        {
            var results = await _dbContext.Employees.Select(x => new EmployeeListingVM
            {
                Id = x.Id,
                Name = x.Name,
                DepartmentName = x.TblDepartment != null ? x.TblDepartment.Name : "",
                ShiftName = x.TblShift != null ? x.TblShift.Name : "",
                ContactNo = x.ContactNumber,
                Status = x.IsActive ? "Active" : "Inactive"
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<EmployeeDetailVM> GetEmployeeById(int employeeId)
        {
            var result = await _dbContext.Employees.Where(x => x.Id == employeeId).Select(x => new EmployeeDetailVM
            {
                Id = x.Id,
                Name = x.Name,
                HireDate = x.HireDate,
                DepartmentName = x.TblDepartment != null ? x.TblDepartment.Name : "",
                ShiftName = x.TblShift != null ? x.TblShift.Name : "",
                FatherName = x.FatherName,
                Gender = x.Gender,
                Email = x.Email,
                ContactNo = x.ContactNumber,
                NIC = x.NIC,
                Address = x.Address,
                Status = x.IsActive ? "Active" : "Inactive"
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteEmployeeById(int employeeId)
        {
            var result = await _dbContext.Employees.Where(x => x.Id == employeeId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Employees.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateEmployee(EmployeeCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    Name = model.Name,
                    ShiftId = model.ShiftId,
                    DepartmentId = model.DepartmentId,
                    HireDate = model.HireDate,
                    FatherName = model.FatherName,
                    Gender = model.Gender,
                    ContactNumber = model.ContactNo,
                    Email = model.Email,
                    NIC = model.NIC,
                    Address = model.Address,
                    IsActive = model.IsActive
                };
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return employee.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditEmployeeById(EmployeeEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Employees.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
                    result.DepartmentId = model.DepartmentId;
                    result.ShiftId = model.ShiftId;
                    result.HireDate = model.HireDate;
                    result.FatherName = model.FatherName;
                    result.Gender = model.Gender;
                    result.ContactNumber = model.ContactNo;
                    result.Email = model.Email;
                    result.NIC = model.NIC;
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

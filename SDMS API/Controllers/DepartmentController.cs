using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ViewModels.Department;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public DepartmentController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<DepartmentListVM>> GetDepartments()
        {
            var results = await _dbContext.Departments.Select(x => new DepartmentListVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<DepartmentDetailVM> GetDepartmentById(int departmentId)
        {
            var result = await _dbContext.Departments.Where(x => x.Id == departmentId).Select(x => new DepartmentDetailVM
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteDepartmentById(int departmentId)
        {
            var result = await _dbContext.Departments.Where(x => x.Id == departmentId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.Departments.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            return false;
        }
        [HttpPost]
        public async Task<int> CreateDepartment(DepartmentCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Name = model.Name
                };
                await _dbContext.AddAsync(department);
                await _dbContext.SaveChangesAsync();
                return department.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<int> EditDepartmentById(DepartmentEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.Departments.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Name = model.Name;
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

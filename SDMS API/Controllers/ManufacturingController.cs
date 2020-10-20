using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.ExtensionMethods;
using SDMS_API.Data;
using SDMS_API.ViewModels.ManufacturingDetail;
using SDMS_API.ViewModels.ManufacturingMaster;
using SDMS_API.ViewModels.ManufacturingRawDetail;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManufacturingController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;

        public ManufacturingController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<ManufacturingListingVM>> ManufacturingListings()
        {
            var results = await _dbContext.ManufacturingMasters.Select(x => new ManufacturingListingVM
            {
                Id = x.Id,
                FormulaMasterId = x.FormulaMasterId,
                Code = x.Code,
                ProductName = x.TblProduct.Name,
                BatchNo = x.BatchNo,
                Quantity = x.Quantity,
                WarehouseName = x.TblWarehouse.Name,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                ManufacturingDetails = x.ManufacturingDetails.Select(y => new ManufacturingDetailListingVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    ManufacturingRawDetails = y.ManufacturingRawDetails.Select(z => new ManufacturingRawDetailListingVM
                    {
                        Id = z.Id,
                        BatchNo = z.BatchNo,
                        Quantity = z.Quantity,
                        WarehouseName = z.TblWarehouse.Name
                    })
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<ManufacturingMasterDetailVM> GetManufacturingById(int manufacturingMasterId)
        {
            var result = await _dbContext.ManufacturingMasters.Where(x => x.Id == manufacturingMasterId).Select(x => new ManufacturingMasterDetailVM
            {
                FormulaMasterId = x.FormulaMasterId,
                Date = x.Date,
                Code = x.Code,
                ProductName = x.TblProduct.Name,
                BatchNo = x.BatchNo,
                WarehouseName = x.TblWarehouse.Name,
                Quantity = x.Quantity,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                ManufacturingDetails = x.ManufacturingDetails.Select(y => new ManufacturingDetailDetailVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    ManufacturingRawDetails = y.ManufacturingRawDetails.Select(z => new ManufacturingRawDetailDetailVM
                    {
                        Id = z.Id,
                        BatchNo = z.BatchNo,
                        Quantity = z.Quantity,
                        WarehouseName = z.TblWarehouse.Name
                    })
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteManufacturingById(int manufacturingId)
        {
            var result = await _dbContext.ManufacturingMasters.Where(x => x.Id == manufacturingId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.ManufacturingMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateManufacturing(ManufacturingMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastManufacturingCode = string.Empty;
                var LastManufacturing = _dbContext.ManufacturingMasters.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastManufacturing != null)
                    lastManufacturingCode = LastManufacturing.Code;
                var manufacturingMaster = new ManufacturingMaster()
                {
                    FormulaMasterId = model.FormulaMasterId,
                    Date = model.Date,
                    Code = lastManufacturingCode.GenerateNextCode("MF"),
                    ProductId = model.ProductId,
                    Quantity = model.Quantity,
                    WarehouseId = model.WarehouseId,
                    BatchNo = model.BatchNo,
                    IsPosted = model.IsPosted,
                    AddedBy = model.AddedBy,
                    AddedOn = model.AddedOn,
                    ManufacturingDetails = model.ManufacturingDetails.Select(x => new ManufacturingDetail
                    {
                        ProductId = x.ProductId,
                        ManufacturingRawDetails = x.ManufacturingRawDetails.Select(y => new ManufacturingRawDetail
                        {
                            Quantity = y.Quantity,
                            WarehouseId = y.WarehouseId,
                            BatchNo = y.BatchNo
                        }).ToList()

                    }).ToList()
                };
                await _dbContext.ManufacturingMasters.AddAsync(manufacturingMaster);
                await _dbContext.SaveChangesAsync();
                return manufacturingMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditManufacturingById(ManufacturingMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.ManufacturingMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    result.FormulaMasterId = model.FormulaMasterId;
                    result.ProductId = model.ProductId;
                    result.Quantity = model.Quantity;
                    result.BatchNo = model.BatchNo;
                    result.WarehouseId = model.WarehouseId;
                    result.UpdatedBy = model.UpdatedBy;
                    result.UpdatedOn = model.UpdatedOn;
                    var existingManufacturingDetails = await _dbContext.ManufacturingDetails.Where(x => x.ManufacturingMasterId == model.Id).Include(x=> x.ManufacturingRawDetails).ToListAsync();
                    if (existingManufacturingDetails != null && existingManufacturingDetails.Count > 0)
                    {
                        _dbContext.ManufacturingDetails.RemoveRange(existingManufacturingDetails);
                    }
                    var manufacturingDetails = model.ManufacturingDetails.Select(x => new ManufacturingDetail
                    {
                        ManufacturingMasterId=model.Id,
                        ProductId = x.ProductId,
                        ManufacturingRawDetails = x.ManufacturingRawDetails.Select(y => new ManufacturingRawDetail
                        {
                            Quantity = y.Quantity,
                            WarehouseId = y.WarehouseId,
                            BatchNo = y.BatchNo
                        }).ToList()

                    }).ToList();
                    await _dbContext.ManufacturingDetails.AddRangeAsync(manufacturingDetails);
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

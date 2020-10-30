using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDMS_API.Data;
using SDMS_API.ExtensionMethods;
using SDMS_API.ViewModels.SOrderDetail;
using SDMS_API.ViewModels.SOrderMaster;

namespace SDMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SOrderController : ControllerBase
    {
        private readonly SDMSDbContext _dbContext;
        public SOrderController(SDMSDbContext sDMSDbContext)
        {
            this._dbContext = sDMSDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<SOrderListingsVM>> GetSOrders()
        {
            var results = await _dbContext.SOrderMasters.Select(x => new SOrderListingsVM
            {

                Date = x.Date,
                CustomerName = x.TblCustomer.Name,
                TotalAmount = x.TotalAmount,
                DiscountAmount = x.DiscountAmount,
                NetAmount = x.NetAmount,
                Remarks = x.Remarks,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                SOrderDetails = x.SOrderDetails.Select(y => new SOrderDetailListingVM
                {
                    Id = y.Id,
                    ProductName = y.TblProduct.Name,
                    Price = y.Price,
                    Quantity = y.Quantity,
                    TotalAmount = y.TotalAmount,
                    DiscountAmount = y.DiscountAmount,
                    NetAmount = y.NetAmount
                })
            }).ToListAsync();
            return results;
        }
        [HttpGet]
        public async Task<SOrderMasterDetailVM> GetSOrderById(int sorderId)
        {
            var result = await _dbContext.SOrderMasters.Where(x => x.Id == sorderId).Select(x => new SOrderMasterDetailVM
            {
                Date = x.Date,
                DueDate = x.DueDate,
                CustomerName = x.TblCustomer.Name,
                TotalAmount = x.TotalAmount,
                DiscountPerc = x.DiscountPerc,
                DiscountAmount = x.DiscountAmount,
                NetAmount = x.NetAmount,
                Remarks = x.Remarks,
                PostStatus = x.IsPosted ? "Posted" : "UnPost",
                SOrderDetails = x.SOrderDetails.Select(y => new SOrderDetailDetailVM
                {
                    ProductName = y.TblProduct.Name,
                    Price = y.Price,
                    Quantity = y.Quantity,
                    TotalAmount = y.TotalAmount,
                    DiscountPerc = y.DiscountPerc,
                    DiscountAmount = y.DiscountAmount,
                    NetAmount = y.NetAmount
                })
            }).FirstOrDefaultAsync();
            return result;
        }
        [HttpDelete]
        public async Task<bool> DeleteSorderById(int sorderId)
        {
            var result = await _dbContext.SOrderMasters.Where(x => x.Id == sorderId).FirstOrDefaultAsync();
            if (result != null)
            {
                _dbContext.SOrderMasters.Remove(result);
                var count = await _dbContext.SaveChangesAsync();
                return count > 0;
            }
            else
                return false;
        }
        [HttpPost]
        public async Task<int> CreateSorderMaster(SOrderMasterCreateVM model)
        {
            if (ModelState.IsValid)
            {
                string lastSOrderNo = string.Empty;
                var LastSOrder = _dbContext.SOrderMasters.AsNoTracking().OrderByDescending(x => x.Id).FirstOrDefault();
                if (LastSOrder != null)
                    lastSOrderNo = LastSOrder.Code;
                var sorderMaster = new SOrderMaster
                {
                    Date = model.Date,
                    DueDate = model.DueDate,
                    Code = lastSOrderNo.GenerateNextCode("SO"),
                    CustomerId = model.CustomerId,
                    TotalAmount = model.SOrderDetails.Sum(x=> x.TotalAmount),
                    DiscountPerc = model.DiscountPerc,
                    DiscountAmount = model.DiscountAmount,
                    NetAmount = model.SOrderDetails.Sum(x => x.TotalAmount) - model.DiscountAmount,
                    Remarks = model.Remarks,
                    AddedBy = model.AddedBy,
                    AddedOn = DateTime.Now,
                    IsPosted = model.IsPosted,
                    SOrderDetails = model.SOrderDetails.Select(x => new SOrderDetail
                    {
                        ProductId = x.ProductId,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        TotalAmount = x.TotalAmount,
                        DiscountPerc = x.DiscountPerc,
                        DiscountAmount = x.DiscountAmount,
                        NetAmount = x.TotalAmount - x.DiscountAmount
                    }).ToList()
                };
                await _dbContext.SOrderMasters.AddAsync(sorderMaster);
                await _dbContext.SaveChangesAsync();
                return sorderMaster.Id;
            }
            else
                return -1;
        }
        [HttpPut]
        public async Task<bool> EditSorderMasterById(SOrderMasterEditVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dbContext.SOrderMasters.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.Date = model.Date;
                    result.DueDate = model.DueDate;
                    result.TotalAmount = model.TotalAmount;
                    result.DiscountPerc = model.DiscountPerc;
                    result.DiscountAmount = model.DiscountAmount;
                    result.NetAmount = model.TotalAmount = model.DiscountAmount;
                    var existingSOrderDetails = await _dbContext.SOrderDetails.Where(x => x.SOrderId == model.Id).ToListAsync();
                    if (existingSOrderDetails != null && existingSOrderDetails.Count > 0)
                        _dbContext.SOrderDetails.RemoveRange(existingSOrderDetails);

                    var sorderDetails = model.SOrderDetails.Select(x => new SOrderDetail
                    {
                        SOrderId=result.Id,
                        ProductId = x.ProductId,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        TotalAmount = x.TotalAmount,
                        DiscountPerc = x.DiscountPerc,
                        DiscountAmount = x.DiscountAmount,
                        NetAmount = x.TotalAmount - x.DiscountAmount
                    }).ToList();
                    await _dbContext.SOrderDetails.AddRangeAsync(sorderDetails);
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

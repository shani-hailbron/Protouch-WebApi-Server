using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IItemsBL itemsBL;
        public ValuesController(IItemsBL _itemsBL)
        {
            itemsBL = _itemsBL;
        }

        [HttpGet("GetAllItems")]
        public async Task<ActionResult<List<Items>>> GetAllItems()
        {
            return await itemsBL.GetAllItemsAsync();
        }

        [HttpPut("UpdatePrice/{id}/{newPrice}")]
        public async Task<ActionResult<List<Items>>> UpdatePrice(long id, int newPrice)
        {
            return await itemsBL.UpdatePriceByIdAsync(id , newPrice);
        }

        [HttpGet("SearchByBracode/{id}")]
        public async Task<ActionResult<List<Items>>> SearchByBracode(long id)
        {
            return await itemsBL.SearchByBracodeAsync(id);
        }

        [HttpGet("SearchBySupplier/{supplier}")]
        public async Task<ActionResult<List<Items>>> SearchBySupplier(string supplier)
        {
            return await itemsBL.SearchBySupplierAsync(supplier);
        }

        [HttpGet("SearchByName/{name}")]
        public async Task<ActionResult<List<Items>>> SearchByName(string name)
        {
            return await itemsBL.SearchByNameAsync(name);
        }
        
    }
}

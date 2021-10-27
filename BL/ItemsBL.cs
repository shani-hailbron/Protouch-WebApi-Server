using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL
{
    public class ItemsBL : IItemsBL
    {
        IItemsDL itemsDL;
        public ItemsBL(IItemsDL _itemsDL)
        {
            itemsDL = _itemsDL;
        }
        public async Task<List<Items>> GetAllItemsAsync()
        {
            return await itemsDL.GetAllItemsAsync();
        }
        public async Task<List<Items>> UpdatePriceByIdAsync(long id, int newPrice)
        {
            return await itemsDL.UpdatePriceByIdAsync(id, newPrice);
        }
        public async Task<List<Items>> SearchByBracodeAsync(long id)
        {
            return await itemsDL.SearchByBracodeAsync(id);
        }

        public async Task<List<Items>> SearchByNameAsync(string name)
        {
            return await itemsDL.SearchByNameAsync(name);
        }

        public async Task<List<Items>> SearchBySupplierAsync(string supplier)
        {
            return await itemsDL.SearchBySupplierAsync(supplier);
        }


    }
}

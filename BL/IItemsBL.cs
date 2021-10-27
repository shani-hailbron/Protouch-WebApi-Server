using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IItemsBL
    {
      Task<List<Items>> GetAllItemsAsync();
        Task<List<Items>> UpdatePriceByIdAsync(long id, int newPrice);
        Task<List<Items>> SearchByBracodeAsync(long id);
        Task<List<Items>> SearchBySupplierAsync(string supplier);
        Task<List<Items>> SearchByNameAsync(string name);


    }
}

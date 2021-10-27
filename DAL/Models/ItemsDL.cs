using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ItemsDL : IItemsDL
    {
        ItemsContext db;
        public ItemsDL(ItemsContext _db)
        {
            db = _db;
        }
        public async Task<List<Items>> GetAllItemsAsync()
        {
            return await db.Items.ToListAsync();
        }

        public async Task<List<Items>> UpdatePriceByIdAsync(long id , int newPrice)
        {
            var it = await db.Items.FirstOrDefaultAsync(i => id==i.Id);
            if (it != null) {

                if (it.NewPrice > 0)
                {
                    if (it.Discount.Equals("down"))
                        it.NewPrice = Convert.ToInt32(it.NewPrice - ((Convert.ToDouble(it.NewPrice)) / 100 * newPrice));
                    if (it.Discount.Equals("up"))
                        it.NewPrice = Convert.ToInt32(it.NewPrice + ((Convert.ToDouble(it.NewPrice)) / 100 * newPrice));
                }
                else
                {
                    it.NewPrice = Convert.ToInt32(Convert.ToDouble(it.Price) - (Convert.ToDouble(it.Price) / 100 * newPrice));
                    it.Discount = "down";
                }
                await db.SaveChangesAsync();
            }
            return await GetAllItemsAsync();
        }

        public async Task<List<Items>> SearchByBracodeAsync(long id)
        {
            return await db.Items.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<List<Items>> SearchByNameAsync(string name)
        {
            return await db.Items.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<Items>> SearchBySupplierAsync(string supplier)
        {
            return await db.Items.Where(x => x.Supplier.Contains(supplier)).ToListAsync();
        }
    }
}

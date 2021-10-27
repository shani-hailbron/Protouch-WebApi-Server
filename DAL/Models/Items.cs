using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Items
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int NewPrice { get; set; }
        public string Image { get; set; }
        public string Supplier { get; set; }
        public string Editable { get; set; }
        public string Discount { get; set; }

        internal int parseInt(object price)
        {
            throw new NotImplementedException();
        }
    }
}

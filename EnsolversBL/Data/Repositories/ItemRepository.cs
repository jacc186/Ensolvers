using EnsolversBL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.Data.EFCore
{
    public class ItemRepository : BaseRepository<Item>
    {
        public ItemRepository(EnsolversContext context) : base(context)
        {
        }
    }
}

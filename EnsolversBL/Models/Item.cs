using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.Models
{
    public class Item
    {
        private int itemId;
        private string data;
        private bool state;

        public Item(string data)
        {
            this.data = data;
            state = false;
        }

        [Key]
        public int ItemId { get => itemId; set => itemId = value; }

        [Required(ErrorMessage = "data is required")]
        [Column(TypeName = "nvarchar(100)")]
        public string Data { get => data; set => data = value; }

        [Required(ErrorMessage = "ItemStatus is required")]
        [Column(TypeName = "bit")]
        public bool State { get => state; set => state = value; }
    }
}

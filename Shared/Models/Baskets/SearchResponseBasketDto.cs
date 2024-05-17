using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Baskets
{
    public class SearchResponseBasketDto
    {
        public int BasketId { get; set; }
        public int BasketCount { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageFileName { get; set; }
    }
}

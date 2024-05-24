﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Project2_Api.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int price { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual AppUser User { get; set; } = default!;
        public virtual Product Product { get; set; } = default!;
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Project2_Api.Data.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Count { get; set; }
        public virtual User User { get; set; } = default!;
        public virtual Product Product { get; set; } = default!;
        public DateTime? CreatedAt { get; internal set; }
    }
}

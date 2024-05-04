
namespace Project2_Api.Controllers
{
    public class ProductAddRequestDto
    {
        internal string Name;
        internal int Price;
        internal DateTime CreatedAt;
        internal string ImageFileName;
        public string Description { get; internal set; }
        public int CategoryId { get; internal set; }
    }
}
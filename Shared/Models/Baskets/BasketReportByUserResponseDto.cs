using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Baskets
{
    public class BasketReportByUserResponseDto
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
        public int? TotalSum { get; set; }
    }
}

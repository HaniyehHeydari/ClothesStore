using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Basket
{
    public class BasketAddRequestDto
    {
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// تعداد محصول
        /// </summary>
        public int Count { get; set; }
    }
}

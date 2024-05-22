using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Order
{
    public class OrderAddRequestDto
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
        /// تعداد سفارش
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// قیمت سفارش
        /// </summary>
        public int price { get; set; }
    }
}

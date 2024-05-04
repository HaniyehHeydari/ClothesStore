using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Category
{
    public class CategoryAddRequestDto
    {
        /// <summary>
        /// نام دسته بندی
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// عکس دسته بندی
        /// </summary>
        public string ImageFileName { get; set; }
    }
}

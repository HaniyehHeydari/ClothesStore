﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Baskets
{
    public class SearchRequestBasketDto
    {
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int? Count { get; set; }
        public string? UserName { get; set; }
        public string? ProductName { get; set; }
    }
}
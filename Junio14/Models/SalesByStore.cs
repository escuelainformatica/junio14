﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Junio14.Models
{
    public partial class SalesByStore
    {
        public int StoreId { get; set; }
        public string Store { get; set; }
        public string Manager { get; set; }
        public decimal? TotalSales { get; set; }
    }
}

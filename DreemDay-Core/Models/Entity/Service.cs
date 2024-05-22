﻿using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Entity
{
    public class Service : MainEntity
    {
        public int ServiceProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Uint {  get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public bool isHaveDiscount { get; set; }
    }
}

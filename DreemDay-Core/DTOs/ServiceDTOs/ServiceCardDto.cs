﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.DTOs.ServiceDTOs
{
    public class ServiceCardDto
    {
        public int Id { get; set; }
        public int ServiceProviderId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle {  get; set; }  
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
       

    }
}

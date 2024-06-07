using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Entity
{
    public class Cart : MainEntity
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        

    }
}

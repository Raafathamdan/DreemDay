using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Entity
{
    public class WishList: MainEntity
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }

    }
}

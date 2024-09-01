using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Models.Entity
{
    public class Payment : MainEntity
    {
        public string CardNumber { get; set; }
        public string Code { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal? Balance { get; set; }

    }
}

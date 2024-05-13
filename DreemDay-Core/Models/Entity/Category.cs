using DreemDay_Core.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreemDay_Core.Helper.Enums.SystemEnum;

namespace DreemDay_Core.Models.Entity
{
    public class Category : MainEntity
    {
        public Title Title { get; set; }
        public string Description { get; set; }
    }
}

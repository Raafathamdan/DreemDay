﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Helper.Enums
{
    public class SystemEnum
    {
        public enum Role 
        {
            Admin,
            ServiceProvider,
            Customer
        }
        public enum OrderStatus
        {
            New,
            Processing,
            Completed,
            Cancelled
        }
        public enum PaymentMethod
        {
            Cliacq = 100,
            Wallet = 101,
            Cash = 102
        }
        public enum Title
        {
            Halls,
            Cars
        }
    }
}

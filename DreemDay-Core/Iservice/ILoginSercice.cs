﻿using DreemDay_Core.DTOs.LoginDTOs;
using DreemDay_Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreemDay_Core.Iservice
{
    public interface ILoginSercice
    {
        Task<int> CreateLogin(Login login);
    }
}

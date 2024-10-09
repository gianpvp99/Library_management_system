﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DOMAIN.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int userId, string userEmail);
    }
}

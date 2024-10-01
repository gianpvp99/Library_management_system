﻿using Library_management_system.Application.DTOs.Responses;
using Library_management_system.DOMAIN.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Querys
{
    public class GetAllPrestamoQuery:IRequest<ResultResponse<List<GetAllPrestamoResponse>>>
    {
    }
}

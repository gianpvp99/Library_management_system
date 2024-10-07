using AutoMapper;
using Library_management_system.Application.Commands;
using Library_management_system.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Mappers
{
    public class ConfigurationMapper: Profile
    {
        public ConfigurationMapper()
        {
            //La estructura es la siguiente CreateMap<Proviene,Destino>()
            CreateMap<AddPrestamoCommand,PrestamoEntity >();
        }
    }
}

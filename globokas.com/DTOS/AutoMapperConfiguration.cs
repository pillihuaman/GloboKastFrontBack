using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace globokas.com.DTOS
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioDTO>()
                  .ReverseMap();
                cfg.CreateMap<Cliente, ClienteDTO>()
                 .ReverseMap();
                cfg.CreateMap<Rol, RolDTO>()
                 .ReverseMap();
                cfg.CreateMap<Calificacion, CalificacionDTO>()
                 .ReverseMap();


            });
        }
    }
}

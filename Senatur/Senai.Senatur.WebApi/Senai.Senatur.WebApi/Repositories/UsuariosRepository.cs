﻿using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<UsuariosDomain> Listar()
        {   
            return ctx.Usuarios.ToList();
        }

        public List<UsuariosDomain> ListarComTiposUsuario()
        {
        
            return ctx.Usuarios.Include(e => e.IdTipoUsuarioNavigation).ToList();
            
        }

    }
}

﻿using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class TiposUsuarioDomain
    {
        public TiposUsuarioDomain()
        {
            Usuarios = new HashSet<UsuariosDomain>();
        }

        public int IdTipoUsuario { get; set; }
        public string Titulo { get; set; }

        public ICollection<UsuariosDomain> Usuarios { get; set; }
    }
}

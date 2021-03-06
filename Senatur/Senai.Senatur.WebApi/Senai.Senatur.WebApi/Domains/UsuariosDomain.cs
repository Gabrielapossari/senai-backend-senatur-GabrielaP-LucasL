﻿using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class UsuariosDomain
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TiposUsuarioDomain IdTipoUsuarioNavigation { get; set; }
    }
}

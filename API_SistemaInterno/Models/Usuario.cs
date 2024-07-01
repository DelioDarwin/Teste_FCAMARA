﻿using System.ComponentModel.DataAnnotations;

namespace API_SistemaInterno.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains {
    public class GeneroDomain {
        public int IdGenero { get; set; }
        [Required(ErrorMessage ="O Nome do Gênero é obrigatório")]
        public string Nome { get; set; }
    }
}

﻿using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Interfaces {
    public interface ILocalizacaoRepository {
        void Cadastrar (Localizacoes loc);
        List<Localizacoes> Listar ();
    }
}

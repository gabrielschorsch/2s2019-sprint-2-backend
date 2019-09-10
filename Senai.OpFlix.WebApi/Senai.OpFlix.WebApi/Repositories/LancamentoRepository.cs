﻿using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories {
    public class LancamentoRepository : ILancamentoRepository {
        public void AtualizarLancamento (int id , Lancamentos lanc) {
            using (OpFlixContext ctx = new OpFlixContext()) {
                var lancamento = ctx.Lancamentos.Find(id);
                if (lanc.Titulo != null) {
                    lancamento.Titulo = lanc.Titulo;
                }
                if (lanc.DataLancamento != null) {
                    lancamento.DataLancamento = lanc.DataLancamento;
                }
                if (lanc.Sinopse != null) {
                    lancamento.Sinopse = lanc.Sinopse;
                }
                if (lanc.IdCategoria != null) {
                    lancamento.IdCategoria = lanc.IdCategoria;
                }
                if (lanc.IdTipo != null) {
                    lancamento.IdTipo = lanc.IdTipo;
                }
#pragma warning disable CS0472 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
                if (lanc.TempoDuracao != null) {
#pragma warning restore CS0472 // O resultado da expressão é sempre o mesmo, pois um valor deste tipo nunca é 'null' 
                    lancamento.TempoDuracao = lanc.TempoDuracao;
                }
                if(lanc.Plataforma != null) {
                    lancamento.Plataforma = lanc.Plataforma;
                }
                if(lanc.DataLancamento != null) {
                    lancamento.DataLancamento = lanc.DataLancamento;
                }
                ctx.Update(lancamento);
                ctx.SaveChanges();




            }
        }

        public void CadastrarLancamentos (Lancamentos lanc) {
            using (OpFlixContext ctx = new OpFlixContext()) {
                ctx.Lancamentos.Add(lanc);
                ctx.SaveChanges();
            }
        }

        public List<Lancamentos> ListarLancamentos () {
            using (OpFlixContext ctx = new OpFlixContext()) {
                var lista = ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdTipoNavigation)
                    .Include(x => x.PlataformaNavigation).ToList();
                foreach(var item in lista) {
                    item.IdCategoriaNavigation.Lancamentos = null;
                    item.IdTipoNavigation.Lancamentos = null;
                    item.PlataformaNavigation.Lancamentos = null;
                }
                return lista;
            }
        }

        public void RemoverLancamentos (int id) {
            using (OpFlixContext ctx = new OpFlixContext()) {
                var lanc = ctx.Lancamentos.Find(id);
                ctx.Remove(lanc);
                ctx.SaveChanges();
            }
        }
    }
}
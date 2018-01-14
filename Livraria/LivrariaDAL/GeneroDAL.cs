using LivrariaDTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace LivrariaDAL
{
    public class GeneroDAL
    {
        LivrariaContexto contexto = new LivrariaContexto();

        public void Inserir(GeneroDTO genero)
        {
            contexto.Genero.Add(genero);
            contexto.SaveChanges();
        }

        public void Editar(GeneroDTO genero)
        {
            contexto.Entry(genero).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Deletar(GeneroDTO genero)
        {
            contexto.Entry(genero).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public GeneroDTO Detalhar(int? id)
        {
            return contexto.Genero.Find(id);
        }

        public bool PodeExcluir(GeneroDTO generoFiltro)
        {
            return !contexto.Livro.Any(x => x.Genero.IDGenero == generoFiltro.IDGenero);
        }

        public List<GeneroDTO> Listar()
        {
            return contexto.Genero.ToList();
        }
    }
}

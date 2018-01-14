using LivrariaDTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace LivrariaDAL
{
    public class AutorDAL
    {
        LivrariaContexto contexto = new LivrariaContexto();

        public void Inserir(AutorDTO autor)
        {
            contexto.Autor.Add(autor);
            contexto.SaveChanges();
        }

        public void Editar(AutorDTO autor)
        {
            contexto.Entry(autor).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Deletar(AutorDTO autor)
        {
            contexto.Entry(autor).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public AutorDTO Detalhar(int? id)
        {
            return contexto.Autor.Find(id);
        }

        public List<AutorDTO> Listar()
        {
            return contexto.Autor.ToList();
        }

        public bool PodeExcluir(AutorDTO autorFiltro)
        {
            return !contexto.Livro.Any(x => x.Autor.IDAutor == autorFiltro.IDAutor);
        }
    }
}

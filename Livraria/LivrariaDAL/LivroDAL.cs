using LivrariaDTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace LivrariaDAL
{
    public class LivroDAL
    {
        LivrariaContexto contexto = new LivrariaContexto();

        public void Inserir(LivroDTO livro)
        {
            contexto.Livro.Add(livro);
            contexto.SaveChanges();
        }

        public void Editar(LivroDTO livro)
        {
            try
            {
                contexto.Entry(livro).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Deletar(LivroDTO livro)
        {
            contexto.Entry(livro).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public LivroDTO Detalhar(int? id)
        {
            return contexto.Livro.Find(id);
        }

        public List<LivroDTO> Listar()
        {
            return contexto.Livro.ToList();
        }
    }
}

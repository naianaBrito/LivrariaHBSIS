using LivrariaDAL;
using LivrariaDTO;
using System.Collections.Generic;
using System;

namespace LivrariaBLL
{
    public class LivroBLL
    {
        LivroDAL livroDAL = new LivroDAL();

        public void Inserir(LivroDTO livro)
        {
            livroDAL.Inserir(livro);
        }

        public void Editar(LivroDTO livro)
        {
            livroDAL.Editar(livro);
        }

        public void Deletar(int? id)
        {
            var livro = this.Detalhar(id);

            if (livro != null)
            {
                livroDAL.Deletar(livro);
            }
        }

        public LivroDTO Detalhar(int? id)
        {
            return livroDAL.Detalhar(id);
        }

        public List<LivroDTO> Listar()
        {
            return livroDAL.Listar();
        }
    }
}

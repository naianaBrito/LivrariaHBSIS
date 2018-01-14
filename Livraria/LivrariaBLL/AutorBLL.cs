using LivrariaDAL;
using LivrariaDTO;
using System;
using System.Collections.Generic;

namespace LivrariaBLL
{
    public class AutorBLL
    {
        AutorDAL autorDAL = new AutorDAL();

        public void Inserir(AutorDTO autor)
        {
            autorDAL.Inserir(autor);
        }

        public void Editar(AutorDTO autor)
        {
            autorDAL.Editar(autor);
        }

        public void Deletar(int? id)
        {
            try
            {
                var autor = this.Detalhar(id);

                if (!this.PodeExcluir(autor))
                {
                    throw new Exception("Autor já associado a um livro.");
                }

                if (autor != null)
                {
                    autorDAL.Deletar(autor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool PodeExcluir(AutorDTO autorFiltro)
        {
            AutorDAL autorDAL = new AutorDAL();
            return autorDAL.PodeExcluir(autorFiltro);
        }

        public AutorDTO Detalhar(int? id)
        {
            return autorDAL.Detalhar(id);
        }

        public List<AutorDTO> Listar()
        {
            return autorDAL.Listar();
        }
    }
}

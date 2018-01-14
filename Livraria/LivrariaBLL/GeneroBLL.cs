using LivrariaDAL;
using LivrariaDTO;
using System.Collections.Generic;
using System;

namespace LivrariaBLL
{
    public class GeneroBLL
    {
        GeneroDAL generoDAL = new GeneroDAL();

        public void Inserir(GeneroDTO genero)
        {
            generoDAL.Inserir(genero);
        }

        public void Editar(GeneroDTO genero)
        {
            generoDAL.Editar(genero);
        }

        public void Deletar(int? id)
        {
            try
            {
                var genero = this.Detalhar(id);

                if (!this.PodeExcluir(genero))
                {
                    throw new Exception("Gênero já associado a um livro.");
                }

                if (genero != null)
                {
                    generoDAL.Deletar(genero);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool PodeExcluir(GeneroDTO generoFiltro)
        {
            GeneroDAL generoDAL = new GeneroDAL();
            return generoDAL.PodeExcluir(generoFiltro);
        }

        public GeneroDTO Detalhar(int? id)
        {
            return generoDAL.Detalhar(id);
        }

        public List<GeneroDTO> Listar()
        {
            return generoDAL.Listar();
        }
    }
}

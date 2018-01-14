using LivrariaDAL;
using LivrariaDTO;
using System;
using System.Collections.Generic;

namespace LivrariaBLL
{
    public class EditoraBLL
    {
        EditoraDAL editoraDAL = new EditoraDAL();

        public void Inserir(EditoraDTO editora)
        {
            editoraDAL.Inserir(editora);
        }

        public void Editar(EditoraDTO editora)
        {
            editoraDAL.Editar(editora);
        }

        public void Deletar(int? id)
        {
            try
            {
                var editora = this.Detalhar(id);

                if (!this.PodeExcluir(editora))
                {
                    throw new Exception("Editora já associado a um livro.");
                }

                if (editora != null)
                {
                    editoraDAL.Deletar(editora);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool PodeExcluir(EditoraDTO editoraFiltro)
        {
            EditoraDAL editoraDAL = new EditoraDAL();
            return editoraDAL.PodeExcluir(editoraFiltro);
        }

        public EditoraDTO Detalhar(int? id)
        {
            return editoraDAL.Detalhar(id);
        }

        public List<EditoraDTO> Listar()
        {
            return editoraDAL.Listar();
        }
    }
}

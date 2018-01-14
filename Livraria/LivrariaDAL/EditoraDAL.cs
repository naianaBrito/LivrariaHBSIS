using LivrariaDTO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace LivrariaDAL
{
    public class EditoraDAL
    {
        LivrariaContexto contexto = new LivrariaContexto();

        public void Inserir(EditoraDTO editora)
        {
            contexto.Editora.Add(editora);
            contexto.SaveChanges();
        }

        public void Editar(EditoraDTO editora)
        {
            contexto.Entry(editora).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Deletar(EditoraDTO editora)
        {
            contexto.Entry(editora).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public EditoraDTO Detalhar(int? id)
        {
            return contexto.Editora.Find(id);
        }

        public List<EditoraDTO> Listar()
        {
            return contexto.Editora.ToList();
        }

        public bool PodeExcluir(EditoraDTO editoraFiltro)
        {
            return !contexto.Livro.Any(x => x.Editora.IDEditora == editoraFiltro.IDEditora);
        }
    }
}

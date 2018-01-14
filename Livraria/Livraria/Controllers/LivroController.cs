using System.Web.Mvc;
using LivrariaBLL;
using LivrariaDTO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Controllers
{
    public class LivroController : Controller
    {
        LivroBLL livroBLL = new LivroBLL();      

        // GET: Livro
        public ActionResult Index()
        {
            return View(livroBLL.Listar().OrderBy(x => x.Titulo));
        }

        // GET: Livro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(livroBLL.Detalhar(id));
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            LivroDTO livro = new LivroDTO();
            livro.Editoras = new EditoraBLL().Listar();
            livro.Autores = new AutorBLL().Listar();
            livro.Generos = new GeneroBLL().Listar();

            return View(livro);
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroDTO livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livroBLL.Inserir(livro);
                    return RedirectToAction("Index");
                }
                livro.Editoras = new EditoraBLL().Listar();
                livro.Autores = new AutorBLL().Listar();
                livro.Generos = new GeneroBLL().Listar();

                return View(livro);
            }
            catch (Exception ex)
            {
                throw ex;                
                return View(livro);
            }

        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            LivroDTO livroDTO = livroBLL.Detalhar(id);

            livroDTO.Editoras = new EditoraBLL().Listar();
            livroDTO.Autores = new AutorBLL().Listar();
            livroDTO.Generos = new GeneroBLL().Listar();

            return View(livroDTO);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, LivroDTO livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livroBLL.Editar(livro);
                    return RedirectToAction("Index");
                }
                return View(livro);
            }
            catch
            {
                return View(livro);
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
        {
            LivroDTO livro = null;

            if (id.HasValue)
            {
                livro = livroBLL.Detalhar(id);
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                livroBLL.Deletar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private LivroDTO CarregarInformacoesLivro()
        {
            LivroDTO livro = new LivroDTO();
            livro.Editoras = new EditoraBLL().Listar();
            livro.Autores = new AutorBLL().Listar();
            livro.Generos = new GeneroBLL().Listar();

            return livro;
        }
    }
}

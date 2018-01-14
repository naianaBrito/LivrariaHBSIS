using System.Web.Mvc;
using LivrariaBLL;
using LivrariaDTO;
using System.Net;
using System;

namespace Livraria.Controllers
{
    public class EditoraController : Controller
    {
        EditoraBLL editoraBLL = new EditoraBLL();      

        // GET: Editora
        public ActionResult Index()
        {
            return View(editoraBLL.Listar());
        }

        // GET: Editora/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(editoraBLL.Detalhar(id));
        }

        // GET: Editora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editora/Create
        [HttpPost]
        public ActionResult Create(EditoraDTO editora)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    editoraBLL.Inserir(editora);
                    return RedirectToAction("Index");
                }
                return View(editora);
            }
            catch (Exception ex)
            {
                return View(editora);
            }            
        }

        // GET: Editora/Edit/5
        public ActionResult Edit(int id)
        {
            return View(editoraBLL.Detalhar(id));
        }

        // POST: Editora/Edit/5
        [HttpPost]
        public ActionResult Edit(EditoraDTO editora)
        {
            try
            {
                if (ModelState.IsValid)
                {                  
                    editoraBLL.Editar(editora);
                    return RedirectToAction("Index");
                }
                return View(editora);
            }
            catch
            {
                return View(editora);
            }
        }

        // GET: Editora/Delete/5
        public ActionResult Delete(int? id)
        {
            EditoraDTO editora = null;

            if (id.HasValue)
            {
                editora = editoraBLL.Detalhar(id);
            }

            return View(editora);
        }

        // POST: Editora/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                editoraBLL.Deletar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View(editoraBLL.Detalhar(id));
            }
        }
    }
}

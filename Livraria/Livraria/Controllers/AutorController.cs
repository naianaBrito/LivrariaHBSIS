using System.Web.Mvc;
using LivrariaBLL;
using LivrariaDTO;
using System.Net;
using System;

namespace Livraria.Controllers
{
    public class AutorController : Controller
    {
        AutorBLL autorBLL = new AutorBLL();

        // GET: Autor
        public ActionResult Index()
        {
            return View(autorBLL.Listar());
        }

        // GET: Autor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(autorBLL.Detalhar(id));
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public ActionResult Create(AutorDTO autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    autorBLL.Inserir(autor);
                    return RedirectToAction("Index");
                }
                return View(autor);
            }
            catch (Exception)
            {
                return View(autor);
            }            
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            return View(autorBLL.Detalhar(id));
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(AutorDTO autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    autorBLL.Editar(autor);
                    return RedirectToAction("Index");
                }
                return View(autor);
            }
            catch
            {
                return View(autor);
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int? id)
        {
            AutorDTO autor = null;

            if (id.HasValue)
            {
                autor = autorBLL.Detalhar(id);
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                autorBLL.Deletar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View(autorBLL.Detalhar(id));
            }
        }
    }
}

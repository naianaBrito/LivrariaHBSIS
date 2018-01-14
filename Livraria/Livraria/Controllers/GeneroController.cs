using System.Web.Mvc;
using LivrariaBLL;
using LivrariaDTO;
using System.Net;
using System;

namespace Livraria.Controllers
{
    public class GeneroController : Controller
    {
        GeneroBLL generoBLL = new GeneroBLL();

        public ActionResult Index()
        {
            return View(generoBLL.Listar());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(generoBLL.Detalhar(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GeneroDTO genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    generoBLL.Inserir(genero);
                    return RedirectToAction("Index");
                }
                return View(genero);
            }
            catch
            {               
                return View(genero);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(generoBLL.Detalhar(id));
        }

        [HttpPost]
        public ActionResult Edit(GeneroDTO genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    generoBLL.Editar(genero);
                    return RedirectToAction("Index");
                }
                return View(genero);
            }
            catch
            {
                return View(genero);
            }
        }

        public ActionResult Delete(int? id)
        {
            GeneroDTO genero = null;

            if (id.HasValue)
            {
                genero = generoBLL.Detalhar(id);
            }

            return View(genero);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                generoBLL.Deletar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex.Message;
                return View(generoBLL.Detalhar(id));
            }
        }
    }
}

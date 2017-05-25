using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBootstrap.Models;
using System.Data.Entity;

namespace MvcBootstrap.Controllers
{
    public class PessoaController : Controller
    {
		PessoaContexto contexto = new PessoaContexto();

        public ActionResult Index()
        {
			if (contexto != null)
			{
				List<Pessoa> lista = contexto.Pessoas.ToList();
				return View(lista);
			}	
            return View ();
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
		public ActionResult Create(Pessoa p /*FormCollection collection*/)
        {
			//DbContextTransaction trans = null;
            try {
				//trans = contexto.Database.BeginTransaction();
				contexto.Pessoas.Add(p);
				contexto.SaveChanges();
				//trans.Commit();
                return RedirectToAction ("Index");
            } catch {
				//trans.Rollback();
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
			try
			{
				Pessoa p = contexto.Pessoas.Find(id);
				return View(p);
			}
			catch
			{
				return RedirectToAction("Index");
			}
        }

        [HttpPost]
        public ActionResult Edit(Pessoa p/*int id, FormCollection collection*/)
        {
            try {
				if (ModelState.IsValid)
				{
					contexto.Entry(p).State = EntityState.Modified;
					contexto.SaveChanges();
				}
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
			try
			{
				Pessoa p = contexto.Pessoas.Find(id);
				contexto.Pessoas.Remove(p);
				contexto.SaveChanges();
			}
			catch
			{

			}
			return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
    }
}
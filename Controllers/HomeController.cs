using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Desafio_cliente_vs.Models;

namespace Desafio_cliente_vs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<VistaReuniones> reu = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/");
                var resposetask = client.GetAsync("Values");
                resposetask.Wait();

                var result = resposetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<VistaReuniones>>();
                    readJob.Wait();
                    reu = readJob.Result;
                }
                else
                {
                    reu = Enumerable.Empty<VistaReuniones>();
                    ModelState.AddModelError(string.Empty, "Error al consultar API");
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
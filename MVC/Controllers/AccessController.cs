using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        //función
        public ActionResult Enter(string user, string password)
        {
            try
            {
                //búsqueda para ver si el usuario existe
                using (MVCEntities db = new MVCEntities())
                {
                    var list = from d in db.Users
                              where d.email == user && d.password == password && d.idState == 1
                              select d;
                    if(list.Count()>0)
                    {
                        Users oUser = list.First();
                        Session["User"] = list.First(); //trae un tipo de dato llamado models user
                    }
                    else
                    {
                        return Content("Usuario inválido ");
                    }
                }

                return Content("1");
            }
            catch (Exception ex)
            { //Content es una función que regresa un string en lugar de vista
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }
    }
}
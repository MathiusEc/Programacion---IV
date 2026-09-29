using S1_P4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S1_P4.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            var productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Laptop", Precio = 850.00m },
                new Producto { Id = 2, Nombre = "Mouse", Precio = 20.50m },
                new Producto { Id = 3, Nombre = "Teclado", Precio = 35.00m }
            };

            return View(productos);
        }
    }
}
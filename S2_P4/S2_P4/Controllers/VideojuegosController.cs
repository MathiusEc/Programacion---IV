using Microsoft.AspNetCore.Mvc;
using S2_P4.Models;

namespace S2_P4.Controllers
{
    public class VideojuegosController : Controller   // Two points means reference 
    {
        private static List<Videojuego> videojuegos = new List<Videojuego>
        {
            new Videojuego{id=1, titulo="Halo", plataforma="Xbox", precio=39.99m},
            new Videojuego{id=2, titulo="Call of Duty", plataforma="PS5", precio=60.00m},
            new Videojuego{id=3, titulo="FC27", plataforma="Xbox", precio=45.12m},
            new Videojuego{id=4, titulo="Gorila Aplastar Ciudad Ataque Prisión Escapa Juego", plataforma="Android", precio=1.99m},
            new Videojuego{id=5, titulo="Papers Please", plataforma="Steam", precio=9.99m},
            new Videojuego{id=6, titulo="Zelda Ocarina of Time", plataforma="Nintendo", precio=59.99m},
            new Videojuego{id=7, titulo="Slatoon", plataforma="Nintendo", precio=29.99m},
            new Videojuego{id=8, titulo="Celeste", plataforma="Steam", precio=19.99m},
            new Videojuego{id=9, titulo="Granny", plataforma="Steam", precio=7.99m}
        };
        public IActionResult Index()
        {
            return View(videojuegos);
        }
    }
}

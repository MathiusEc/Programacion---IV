using Microsoft.AspNetCore.Mvc;
using S2_P4.Models;

namespace S2_P4.Controllers
{
    public class ComicsController : Controller
    {
        private static List<Comic> comics = new List<Comic>
        {
            new Comic{id=1, titulo="Caitan Escudo", autor="Mi ña", editorial="ele", pags=20, precio=3.99m},
            new Comic{id=2, titulo="El Espectro Nocturno", autor="Carlos Páez", editorial="Planeta Cómic", pags=32, precio=4.50m},
            new Comic{id=3, titulo="Guerreros del Sol", autor="Ana Cueva", editorial="Estudio Visual", pags=24, precio=2.99m},
            new Comic{id=4, titulo="Eco Urbano", autor="Luis Morocho", editorial="ele", pags=16, precio=1.50m},
            new Comic{id=5, titulo="Centinela Galáctico", autor="Sofía Vega", editorial="Nova Prensa", pags=48, precio=6.25m},
            new Comic{id=6, titulo="La Sombra del Inka", autor="Mateo Silva", editorial="ele", pags=28, precio=3.75m},
            new Comic{id=7, titulo="Ciber Ciudadanos", autor="Elena Torres", editorial="Futura", pags=20, precio=3.99m},
            new Comic{id=8, titulo="Crónicas del Laberinto", autor="Diego Meza", editorial="Minotauro", pags=36, precio=5.00m},
            new Comic{id=9, titulo="Viento y Acero", autor="Diana Ríos", editorial="Estudio Visual", pags=22, precio=2.80m},
            new Comic{id=10, titulo="El Guardián del Chimborazo", autor="Juan Larrea", editorial="ele", pags=30, precio=4.20m},
            new Comic{id=11, titulo="Luz de Neon", autor="Fabián Castro", editorial="Futura", pags=18, precio=2.50m}
        };

        public IActionResult Index()
        {
            return View(comics);
        }
    }
}

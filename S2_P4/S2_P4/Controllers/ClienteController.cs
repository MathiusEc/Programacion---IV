using Microsoft.AspNetCore.Mvc;
using S2_P4.Models;

namespace S2_P4.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente{id=1, nombre="Pepe Tola", cedula="9999999999", direccion="Eloy Alfaro", edad=18, mail="pene@g.com"},
            new Cliente{id=2, nombre="María Loor", cedula="1712345678", direccion="Av. Amazonas", edad=25, mail="mloor@g.com"},
            new Cliente{id=3, nombre="Juan Saltos", cedula="0923456781", direccion="9 de Octubre", edad=34, mail="jsaltos@g.com"},
            new Cliente{id=4, nombre="Ana Cevallos", cedula="0104567892", direccion="Calle Larga", edad=21, mail="acevallos@g.com"},
            new Cliente{id=5, nombre="Carlos Mendoza", cedula="1305678901", direccion="Malecón de Manta", edad=45, mail="cmendoza@g.com"},
            new Cliente{id=6, nombre="Sofía Benítez", cedula="1726789012", direccion="Av. De la Prensa", edad=19, mail="sbenitez@g.com"},
            new Cliente{id=7, nombre="Luis Plaza", cedula="0917890123", direccion="Urdesa Central", edad=28, mail="lplaza@g.com"},
            new Cliente{id=8, nombre="Elena Noboa", cedula="1808901234", direccion="Cevallos y Espejo", edad=52, mail="enoboa@g.com"},
            new Cliente{id=9, nombre="Diego Jaramillo", cedula="1109012345", direccion="Av. Cuxibamba", edad=31, mail="djaramillo@g.com"},
            new Cliente{id=10, nombre="Gabriela Vaca", cedula="0601234567", direccion="Daniel León Borja", edad=23, mail="gvaca@g.com"},
            new Cliente{id=11, nombre="Pedro Chimbo", cedula="0202345678", direccion="Av. El Inca", edad=40, mail="pchimbo@g.com"}

        };
        public IActionResult Index()
        {
            return View(clientes);
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9.Models;

namespace TP9.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        viewBag.listaSagas = BD.ListarSagas();
        return View();
    }
    public IActionResult VerPersonajes(int IdSaga)
    {
      ViewBag.listaPersonajes = BD.ListarPersonajes(IdSaga);
      return View("Personajes");
    }
 
    public IActionResult AgregarPersonaje(int IdSaga)
     {
        ViewBag.Saga = IdSaga;
        return View("AgregarPersonaje");
     }
     public IActionResult GuardarJugador(Personaje Per, IFormFile ArchivoFoto)
        {   
            if (ArchivoFoto.Length>0)
            {
                string wwwRootLocal = this.Environment.ContentRootPath +  @"\wwwroot\" + ArchivoFoto.FileName;
                using (var stream = System.IO.File.Create(wwwRootLocal))
                {
                    ArchivoFoto.CopyTo(stream);
                    Per.FotoPersonaje = ArchivoFoto.FileName;
                }
            }
            
            BD.AgregarPersonaje(Per);
            ViewBag.listaPersonajes = BD.ListarPersonajes(Per.IdSaga);
            return Redirect(Url.Action("Personajes", "Home", new {IdSaga = Per.IdSaga}));
        }

    public IActionResult EliminarPersonaje(int IdPersonaje, int IdSaga)
    {
        BD.EliminarPersonaje(IdPersonaje);
        ViewBag.detalleSagas = BD.VerInfoSagas(IdSaga);
        ViewBag.listaJugadores = BD.ListarPersonajes(IdSaga);
        return View();
     }
    public Sagas verInfoSagasAjax(int IdSaga)
        {

        return BD.VerInfoSagas(IdSaga); 

        }
        public Sagas verHabilidadesAjax(int IdPersonaje)
        {

        return BD.VerInfoHabilidades(IdPersonaje); 

        }
        public Sagas verTransformacionesAjax(int IdPersonaje)
        {

        return BD.VerInfoTransformaciones(IdPersonaje); 

        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

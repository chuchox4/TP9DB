using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TP9.Models;

namespace TP9.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public IActionResult Index()
    {
        ViewBag.listaSagas = BD.ListarSagas();
        return View();
    }
    public IActionResult VerPersonajes(int IdSaga, int IdPersonaje)
    {
        //BD.GetPersonajeById(IdPersonaje);
        ViewBag.idSaga = IdSaga;
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
    public Saga VerInfoSagasAjax(int IdSaga)
        {

        return BD.VerInfoSagas(IdSaga); 

        }
        public Habilidad VerHabilidadesAjax(int IdPersonaje)
        {

        return BD.VerInfoHabilidades(IdPersonaje); 

        }
        public Transformacion VerTransformacionesAjax(int IdPersonaje)
        {

        return BD.VerInfoTransformaciones(IdPersonaje); 

        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

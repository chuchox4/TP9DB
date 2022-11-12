using System.Net;
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
    public IActionResult VerPersonajes(int IdSaga)
    {
      ViewBag.IdSaga = IdSaga;
      ViewBag.listaPersonajes = BD.ListarPersonajes(IdSaga);
      return View("Personajes"); 
    }
 
    public IActionResult AgregarPersonaje(int IdSaga)
     {
         ViewBag.listaPlanetas = BD.TraerPlanetas();
         ViewBag.IdSaga = IdSaga;
         return View("AgregarPersonaje");
     }
     public IActionResult AgregarHabilidad(int IdPersonaje, int IdSaga)
     {
         ViewBag.IdSaga = IdSaga;
         ViewBag.IdPersonaje = IdPersonaje;
         return View("AgregarHabilidad");
     }
     public IActionResult AgregarTransformacion(int IdPersonaje, int IdSaga)
     {
         ViewBag.IdSaga = IdSaga;
         ViewBag.IdPersonaje = IdPersonaje;
         return View("AgregarTransformacion");
     }
     [HttpPost]
     public IActionResult GuardarHabilidad(Habilidad Hab, IFormFile ArchivoFoto,int IdSaga)
        {   
            if (ArchivoFoto.Length>0)
            {
                string wwwRootLocal = this.Environment.ContentRootPath +  @"\wwwroot\" + ArchivoFoto.FileName;
                using (var stream = System.IO.File.Create(wwwRootLocal))
                {
                    ArchivoFoto.CopyTo(stream);
                    Hab.FotoHabilidad = ArchivoFoto.FileName;
                }
            }
            
            BD.AgregarHabilidad(Hab);
            return Redirect(Url.Action("VerPersonajes", "Home", new {IdSaga}));
        }
        [HttpPost]
        public IActionResult GuardarTransformacion(Transformacion Tran, IFormFile ArchivoFoto,int IdSaga)
        {   
            if (ArchivoFoto.Length>0)
            {
                string wwwRootLocal = this.Environment.ContentRootPath +  @"\wwwroot\" + ArchivoFoto.FileName;
                using (var stream = System.IO.File.Create(wwwRootLocal))
                {
                    ArchivoFoto.CopyTo(stream);
                    Tran.FotoTransformacion = ArchivoFoto.FileName;
                }
            }
            
            BD.AgregarTransformacion(Tran);
            return Redirect(Url.Action("VerPersonajes", "Home", new {IdSaga}));
        }

     public IActionResult ModificarPersonaje(int IdPersonaje, int IdSaga)
     {
        ViewBag.listaPlanetas = BD.TraerPlanetas();
        ViewBag.IdSaga = IdSaga;
        ViewBag.IdPersonaje = IdPersonaje;
        return View("ModificarPersonaje");

     }

    [HttpPost]
    public IActionResult ActualizarPersonaje(Personaje Per, IFormFile ArchivoFoto)
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

        BD.ModificarPersonaje(Per);
        return RedirectToAction("VerPersonajes", "Home", new {IdSaga = Per.IdSaga});
    }

     [HttpPost]
     public IActionResult GuardarPersonaje(Personaje Per, IFormFile ArchivoFoto)
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
            //ViewBag.listaPersonajes = BD.ListarPersonajes(Per.IdSaga);
            return Redirect(Url.Action("VerPersonajes", "Home", new {IdSaga = Per.IdSaga}));
        }

    public IActionResult EliminarPersonaje(int IdPersonaje, int IdSaga)
    {
        BD.EliminarHabilidadesPersonajes(IdPersonaje);
        BD.EliminarTransformacionesPersonajes(IdPersonaje);
        BD.EliminarPersonaje(IdPersonaje);
        //ViewBag.detalleSagas = BD.VerInfoSagas(IdSaga);
        //ViewBag.listaJugadores = BD.ListarPersonajes(IdSaga);
        return RedirectToAction("VerPersonajes", "Home", new {IdSaga});
     }
    public Saga VerInfoSagasAjax(int IdSaga)
        {

        return BD.VerInfoSagas(IdSaga); 

        }
        public List<Habilidad> VerHabilidadesAjax(int IdPersonaje)
        {
            return BD.ListarHabilidades(IdPersonaje);

        }
        public List<Transformacion> VerTransformacionesAjax(int IdPersonaje)
        {   

        return BD.ListarTransformaciones(IdPersonaje); 

        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

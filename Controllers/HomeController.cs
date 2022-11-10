﻿using System.Diagnostics;
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
        //BD.GetPersonajeById(IdPersonaje);
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
     public IActionResult ModificarPersonaje(Personaje Per)
     {
        BD.ModificarPersonajes(Per);
        return View("ModificarPersonaje");

     }
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
            ViewBag.listaPersonajes = BD.ListarPersonajes(Per.IdSaga);
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

using System.ComponentModel.DataAnnotations.Schema;
using System;

public class Habilidad
{

    public int _IdHabilidad;

    public string _FotoHabilidad;

    public string _Nombre;

    public string _Tipo;

    public int _IdPersonaje;

    public Habilidad(){

    }

    public Habilidad(int IdHabilidad, string FotoHabilidad, string Nombre, string Tipo, int IdPersonaje)
    {
        _IdHabilidad = IdHabilidad;
        _FotoHabilidad = FotoHabilidad;
        _Nombre = Nombre;
        _Tipo = Tipo;
        _IdPersonaje = IdPersonaje;
    }

    public int IdHabilidad{
        set{_IdHabilidad = value;}
        get{return _IdHabilidad;}
    }

    public string FotoHabilidad{
        set{_FotoHabilidad = value;}
        get{return _FotoHabilidad;}
    }

    public string Nombre{
        set{_Nombre = value;}
        get{return _Nombre;}
    }

     public string Tipo{
        set{_Tipo = value;}
        get{return _Tipo;}
    }
    
    public int IdPersonaje{
        set{_IdPersonaje = value;}
        get{return _IdPersonaje;}
    }































}
using System.ComponentModel;
using System;

public class Transformacion{

    public int _IdTransformacion;

    public string _FotoTransformacion;

    public string _Nombre;

    public string _Multiplicador;

    public int _IdPersonaje;


    public Transformacion (int IdTransformacion , string FotoTransformacion, string Nombre, string Multiplicador, int IdPersonaje){

    _IdTransformacion = IdTransformacion;
    _FotoTransformacion = FotoTransformacion;
    _Nombre = Nombre;
    _Multiplicador = Multiplicador;
    _IdPersonaje = IdPersonaje;
    }
    public Transformacion ()
    {

    }

    public int IdTransformacion{
        set{_IdTransformacion = value;}
        get{return _IdTransformacion;}
    }

    public string FotoTransformacion{
        set{_FotoTransformacion =value;}
        get{return _FotoTransformacion;}
    }
    
     public string Nombre{
        set{_Nombre = value;}
        get{return _Nombre;}
    }

    public string Multiplicador{
        set{_Multiplicador = value;}
        get{return _Multiplicador;}
    }

    public int IdPersonaje{
        set{_IdPersonaje = value;}
        get{return _IdPersonaje;}
    }
}
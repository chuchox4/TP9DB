using System;

public class Personaje
{

    public int _IdPersonaje;

    public string _FotoPersonaje;

    public string _Nombre;

    public string _Genero;

    public DateTime _FechaNacimiento;

    public int _Edad;

    public int _Poder;

    public string _Raza;

    public int _IdPlaneta;

    public string _NombrePlaneta;

  

    public Personaje()
    {

    }


    public Personaje(int IdPersonaje, string FotoPersonaje,  string Nombre, string Genero, DateTime FechaNacimiento,  int Edad, int Poder, string Raza, int IdPlaneta, string NombrePlaneta){

        _IdPersonaje = IdPersonaje;
        _FotoPersonaje = FotoPersonaje;
        _Nombre = Nombre;
        _Genero = Genero;
        _FechaNacimiento = FechaNacimiento;
        _Edad = Edad;
        _Poder = Poder;
        _Raza = Raza;
        _IdPlaneta = IdPlaneta;
        _NombrePlaneta = NombrePlaneta

    }

    public int IdPersonaje{
        set{_IdPersonaje = value;}
        get{return _IdPersonaje;}
    }
    public string Foto{
    set{_FotoPersonaje = value;}
    get{return _FotoPersonaje;}
}

    public string Nombre{
        set{_Nombre = value;}
        get{return _Nombre;}
    }

    public string Genero{
        set{_Genero = value;}
        get{return _Genero;}
    }
    public DateTime FechaNacimiento{
        set{_FechaNacimiento = value;}
        get{return _FechaNacimiento;}
    }

    public int Edad{
        set{_Edad = value;}
        get{return _Edad;}
    }

      public int Poder{
        set{_Poder = value;}
        get{return _Poder;}
    }

    public string Raza{
        set{_Raza = value;}
        get{return _Raza;}
    }

    public int IdPlaneta{
        set{_IdPlaneta = value;}
        get{return _IdPlaneta;}
    }

     public int NombrePlaneta{
        set{_NombrePlaneta = value;}
        get{return _NombrePlaneta;}
    }












}
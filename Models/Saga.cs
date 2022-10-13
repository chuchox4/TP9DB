using System;
public class Saga
{

    public int _IdSaga;

    public string _FotoSaga;

    public string _Nombre;

    public DateTime _Año;

    public string _Villano;

    public string _Heroe;

    public string _Informacion;


public Saga (int IdSaga, string FotoSaga , string Nombre, DateTime Año,  string Villano, string Heroe, string Informacion){
    _IdSaga = IdSaga;
    _FotoSaga = FotoSaga;
    _Nombre = Nombre;
    _Año = Año;
    _Villano = Villano;
    _Heroe = Heroe;
    _Informacion = Informacion;

}  

public int IdSaga{
    set{_IdSaga = value;}
    get{return _IdSaga;}
}

public string Foto{
    set{_FotoSaga = value;}
    get{return _FotoSaga;}
}

public string Nombre{
    set{_Nombre = value;}
    get{return _Nombre;}
}

public DateTime Año{
    set{_Año = value;}
    get{return _Año;}
}

public string Villano{
    set{_Villano = value;}
    get{return _Villano;}
}


public string Heroe{
    set{_Heroe = value;}
    get{return _Heroe;}
}
public string Informacion{
    set{_Informacion = value;}
    get{return _Informacion;}
}






















}

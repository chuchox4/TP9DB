using System;

public class Planeta{


    public int _IdPlaneta;

    public string _FotoPlaneta;

    public string _NombrePlaneta;

    public string _RazaHabitante;

    public string _Informacion;

    public Planeta()
    {
        
    }

    public Planeta(int IdPlaneta, string FotoPlaneta, string NombrePlaneta, string RazaHabitante, string Informacion){
        _IdPlaneta = IdPlaneta;
        _FotoPlaneta = FotoPlaneta;
        _NombrePlaneta = NombrePlaneta;
        _RazaHabitante = RazaHabitante;
        _Informacion = Informacion;
    }

    public int IdPlaneta{
        set{_IdPlaneta = value;}
        get{return _IdPlaneta;}
    }

    public string FotoPlaneta{
        set{_FotoPlaneta = value;}
        get{return _FotoPlaneta;}
    }

    public string NombrePlaneta{
    set{_NombrePlaneta = value;}
    get{return _NombrePlaneta;}
    }

    public string RazaHabitante{
        set{_RazaHabitante = value;}
        get{return _RazaHabitante;}
    }

    public string Informacion{
        set{_Informacion = value;}
        get{return _Informacion;}

    }


























}
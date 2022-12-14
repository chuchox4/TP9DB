using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace TP9.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=A-PHZ2-CIDI-032; DataBase=BDDBTP9;Trusted_Connection=True;";


        public static void AgregarPersonaje(Personaje Per)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Personaje(FotoPersonaje,Nombre,Genero,FechaNacimiento,Edad,Poder,Raza,IdPlaneta,IdSaga)VALUES(@FotoPersonaje,@Nombre,@Genero,@FechaNacimiento,@Edad,@Poder,@Raza,@IdPlaneta,@IdSaga)  ";
                db.Execute(sql, Per);
            }
        }
        public static void AgregarHabilidad(Habilidad Hab)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Habilidad(FotoHabilidad,Nombre,Tipo,IdPersonaje) VALUES(@FotoHabilidad,@Nombre,@Tipo,@IdPersonaje)  ";
                db.Execute(sql, new {@FotoHabilidad = Hab.FotoHabilidad,@Nombre = Hab.Nombre,@Tipo = Hab.Tipo,@IdPersonaje = Hab.IdPersonaje});
            }
        }
        public static void AgregarTransformacion(Transformacion Trans)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Transformacion(FotoTransformacion,Nombre,Multiplicador,IdPersonaje) VALUES(@FotoTransformacion,@Nombre,@Multiplicador,@IdPersonaje)  ";
                db.Execute(sql, new {@FotoTransformacion = Trans.FotoTransformacion,@Nombre = Trans.Nombre,@Multiplicador = Trans.Multiplicador,@IdPersonaje = Trans.IdPersonaje});
            }
        }
        private static List<Saga> _ListaSagas = new List<Saga>();
        public static List<Saga> ListarSagas()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Saga";
                _ListaSagas = db.Query<Saga>(sql).ToList();
            }
            return _ListaSagas;
        }

        public static List<Personaje> ListarPersonajes(int IdSaga)
        {
            List<Personaje> _ListaPersonajes = new List<Personaje>();
            string sql = "SELECT * FROM Personaje INNER JOIN Planeta ON Planeta.IdPlaneta = Personaje.IdPlaneta WHERE IdSaga = @IdSaga";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                _ListaPersonajes = db.Query<Personaje>(sql, new { @IdSaga = IdSaga }).ToList();
            }
            return _ListaPersonajes;
        }

        public static Personaje GetPersonajeById(int IdPersonaje)
        {
            Personaje MiPersonaje = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "Select * FROM Personaje INNER JOIN Planeta on Planeta.IdPlaneta = Personaje.IdPlaneta where IdPersonaje = @IdPersonaje";
                MiPersonaje = db.QueryFirstOrDefault<Personaje>(sql, new { @IdPersonaje = IdPersonaje });
            }
            return MiPersonaje;

        }

        public static List<Habilidad> ListarHabilidades(int IdPersonaje)
        {
            List<Habilidad> _ListaHabilidades = new List<Habilidad>();
            string sql = "SELECT * FROM Habilidad WHERE IdPersonaje = @IdPersonaje";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                _ListaHabilidades = db.Query<Habilidad>(sql, new { @IdPersonaje = IdPersonaje }).ToList();
            }
            return _ListaHabilidades;
        }

        public static List<Transformacion> ListarTransformaciones(int IdPersonaje)
        {
            List<Transformacion> _ListaTransformaciones = new List<Transformacion>();
            string sql = "SELECT * FROM Transformacion WHERE IdPersonaje = @IdPersonaje";
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                _ListaTransformaciones = db.Query<Transformacion>(sql, new { IdPersonaje }).ToList();
            }
            return _ListaTransformaciones;
        }

        private static List<Planeta> _ListaPlanetas = new List<Planeta>();
        public static List<Planeta> TraerPlanetas()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Planeta";
                _ListaPlanetas = db.Query<Planeta>(sql).ToList();
            }
            return _ListaPlanetas;
        }

        public static Saga VerInfoSagas(int IdSaga)
        {
            Saga MiSaga = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Saga WHERE IdSaga = @IdSaga";
                MiSaga = db.QueryFirstOrDefault<Saga>(sql, new { @IdSaga = IdSaga });
            }
            return MiSaga;
        }

        public static Habilidad VerInfoHabilidades(int IdPersonaje)
        {
            Habilidad MiHbabilidad = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Habilidad WHERE IdPersonaje = @IdPersonaje";
                MiHbabilidad = db.QueryFirstOrDefault<Habilidad>(sql, new { @IdPersonaje = IdPersonaje });
            }
            return MiHbabilidad;
        }
        public static Transformacion VerInfoTransformaciones(int IdPersonaje)
        {
            Transformacion MiTransformacion = null;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Transformacion WHERE IdPersonaje = @IdPersonaje";
                MiTransformacion = db.QueryFirstOrDefault<Transformacion>(sql, new { @IdPersonaje = IdPersonaje });
            }
            return MiTransformacion;
        }

        public static void EliminarPersonaje(int IdPersonaje)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Personaje WHERE IdPersonaje = @IdPersonaje";
                db.Execute(sql, new { @IdPersonaje = IdPersonaje });
            }
        }

         public static void EliminarHabilidadesPersonajes(int IdPersonaje)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Habilidad WHERE IdPersonaje = @IdPersonaje";
                db.Execute(sql, new { @IdPersonaje = IdPersonaje });
            }
        }

         public static void EliminarTransformacionesPersonajes(int IdPersonaje)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Transformacion WHERE IdPersonaje = @IdPersonaje";
                db.Execute(sql, new { @IdPersonaje = IdPersonaje });
            }
        }

        public static Personaje ModificarPersonaje(Personaje Per)
        {
             using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Personaje Set FotoPersonaje = @FotoPersonaje, Nombre = @Nombre, Genero = @Genero, FechaNacimiento = @FechaNacimiento, Edad = @Edad, Poder = @Poder, Raza = @Raza, IdPlaneta = @IdPlaneta WHERE IdPersonaje = @IdPersonaje";
                db.Execute(sql, Per);
            }
            return GetPersonajeById(Per.IdPersonaje);
        }


    }
}

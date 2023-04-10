using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Plataforma : Conexion
    {

        public int id_plataforma { get; set; } // 
        public string nombre_plataforma { get; set; } // 



        public Plataforma()
        {
        }

        public Plataforma(int id_plataforma, string nombre_plataforma) //
        {
            this.id_plataforma = id_plataforma; //
            this.nombre_plataforma = nombre_plataforma; //

        }


        public List<Plataforma> GetPlataforma()
        {
            List<Plataforma> lista = new List<Plataforma>();
            const string SQL = "SELECT * FROM Plataforma;";
            DataTable tabla = GetQuery(SQL);
            if (tabla.Rows.Count < 2) return lista;
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Plataforma((int)row["id_plataforma"], (string)row["nombre_plataforma"]));
            }
            return lista;
        }

        public bool AddPlataforma(Plataforma plataformacita)
        {
            const string SQL = "INSERT INTO Plataforma(id_plataforma, nombre_plataforma) VALUES(:plataforma, :nombre);";
            NpgsqlParameter paramIdPlat = new NpgsqlParameter(":item", plataformacita.id_plataforma);
            NpgsqlParameter paramNomPlat = new NpgsqlParameter(":nombre", plataformacita.nombre_plataforma);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramIdPlat, paramNomPlat };

            return GetQuery(SQL, lista).Rows.Count > 0;
        }

        public void DeletePlataforma(Plataforma plataformacita)
        {
            const string SQL = "DELETE from Plataforma where id_plataforma=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", plataformacita.id_plataforma) };
            GetQuery(SQL, lista);

        }

        public Plataforma ObtenerPlataformaById(int id)
        {
            const string SQL = "SELECT * FROM plataforma WHERE id_plataforma=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Plataforma();
            DataRow row = tabla.Rows[0];
            return new Plataforma((int)row["id_plataforma"], (string)row["nombre_plataforma"]);
        }

        public void UpdatePlataforma(Plataforma plataformacita)
        {
            const string SQL = "UPDATE plataformacita set id_plataforma = :plataforma, nombre_plataforma = :nom WHERE id_plataforma = :id";

            NpgsqlParameter paramIdPlat = new NpgsqlParameter(":plataforma", plataformacita.id_plataforma);
            NpgsqlParameter paramNom = new NpgsqlParameter(":nom", plataformacita.nombre_plataforma);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramIdPlat, paramNom };
            GetQuery(SQL, lista);
        }
    }
}

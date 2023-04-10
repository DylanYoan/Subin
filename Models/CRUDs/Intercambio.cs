using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Intercambio : Conexion
    {

        public int id_intercambio { get; set; } // 
        public DateTime fecha { get; set; } = DateTime.Now; // 
        public int id_usuario { get; set; } // 
        public int id_usuario2 { get; set; } // 
        public int id_item { get; set; } // 
        public int id_item2 { get; set; } // 



        public Intercambio()
        {
        }

        public Intercambio(int id_intercambio, DateTime fecha, int id_usuario, int id_usuario2, int id_item, int id_item2) //
        {
            this.id_intercambio = id_intercambio; //
            this.fecha = fecha; //
            this.id_usuario = id_usuario;
            this.id_usuario2 = id_usuario2;
            this.id_item = id_item;
            this.id_item2 = id_item2;

        }


        public List<Intercambio> GetIntercambio()
        {
            List<Intercambio> lista = new List<Intercambio>();
            const string SQL = "SELECT * FROM intercambio;";
            DataTable tabla = GetQuery(SQL);
            //if (tabla.Rows.Count < 2) return lista;
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Intercambio((int)row["id_intercambio"], (DateTime)row["fecha"], (int)row["id_usuario"], (int)row["id_usuario2"], (int)row["id_item"], (int)row["id_item2"]));
            }
            return lista;
        }

        public bool AddIntercambio(Intercambio intercambiocito)
        {
            const string SQL = "INSERT INTO Intercambio(fecha, id_usuario, id_usuario2, id_item, id_item2) VALUES(:fecha, :id_usuario, :id_usuario2, :id_item, :id_item2);";
            NpgsqlParameter paramFecha = new NpgsqlParameter(":fecha", intercambiocito.fecha);
            NpgsqlParameter paramIdUsuario = new NpgsqlParameter(":id_usuario", intercambiocito.id_usuario);
            NpgsqlParameter paramIdUsuario2 = new NpgsqlParameter(":id_usuario2", intercambiocito.id_usuario2);
            NpgsqlParameter paramIdItem = new NpgsqlParameter(":id_item", intercambiocito.id_item);
            NpgsqlParameter paramIdItem2 = new NpgsqlParameter(":id_item2", intercambiocito.id_item2);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramFecha, paramIdUsuario, paramIdUsuario2, paramIdItem, paramIdItem2 };

            return GetQuery(SQL, lista).Rows.Count > 0;
        }

        public void DeleteIntercambio(Intercambio intercambiocito)
        {
            const string SQL = "DELETE from Intercambio where id_intercambio=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", intercambiocito.id_intercambio) };
            GetQuery(SQL, lista);

        }

        public Intercambio ObtenerIntercambioById(int id)
        {
            const string SQL = "SELECT * FROM Intercambio WHERE id_intercambio=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Intercambio();
            DataRow row = tabla.Rows[0];
            return new Intercambio((int)row["id_intercambio"], (DateTime)row["fecha"], (int)row["id_usuario"], (int)row["id_usuario2"], (int)row["id_item"], (int)row["id_item2"]);
        }

        public void UpdateIntercambio(Intercambio intercambiocito)
        {
            const string SQL = "UPDATE Intercambio set id_intercambio = :intercambio, fecha = :fecha, id_usuario = :id_usuario, id_usuario2 = :id_usuario2, id_item = :id_item, id_item2 = :id_item2 WHERE id_intercambio = :id";
            NpgsqlParameter paramIdInter = new NpgsqlParameter(":intercambio", intercambiocito.id_intercambio);
            NpgsqlParameter paramFecha = new NpgsqlParameter(":fecha", intercambiocito.fecha);
            NpgsqlParameter paramIdUsuario = new NpgsqlParameter(":id_usuario", intercambiocito.id_usuario);
            NpgsqlParameter paramIdUsuario2 = new NpgsqlParameter(":id_usuario2", intercambiocito.id_usuario2);
            NpgsqlParameter paramIdItem = new NpgsqlParameter(":id_item", intercambiocito.id_item);
            NpgsqlParameter paramIdItem2 = new NpgsqlParameter(":id_item2", intercambiocito.id_item2);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramIdInter, paramFecha, paramIdUsuario, paramIdUsuario2, paramIdItem, paramIdItem2 };

            GetQuery(SQL, lista);
        }
    }
}

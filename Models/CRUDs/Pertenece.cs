using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Pertenece : Conexion
    {
        public int id_usuario { get; set; } //
        public int id_item { get; set; } // 


        public Pertenece()
        {
        }

        public Pertenece(int id_usuario, int id_item) //
        {
            this.id_usuario = id_usuario; //
            this.id_item = id_item; //

        }


        public List<Pertenece> GetPertenece()
        {
            List<Pertenece> lista = new List<Pertenece>();
            const string SQL = "SELECT * FROM Pertenece;";
            DataTable tabla = GetQuery(SQL);
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Pertenece((int)row["id_usuario"], (int)row["id_item"]));
            }
            return lista;
        }



        public bool AddPertenece(Pertenece pertenecito)
        {
            const string SQL = "INSERT INTO Pertenece(id_usuario, id_item) VALUES(:usuario, :item);";
            NpgsqlParameter paramUsuario = new NpgsqlParameter(":usuario", pertenecito.id_usuario);
            NpgsqlParameter paramItem = new NpgsqlParameter(":item", pertenecito.id_item);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramUsuario, paramItem};

            return GetQuery(SQL, lista).Rows.Count > 0;
        }

        public void DeletePertenece(Pertenece pertenecito)
        {
            const string SQL = "DELETE from Pertenece where id_usuario=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", pertenecito.id_usuario) };
            GetQuery(SQL, lista);

        }

        public Pertenece ObtenerPerteneceById(int id)
        {
            const string SQL = "SELECT * FROM Pertenece WHERE id_usuario=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Pertenece();
            DataRow row = tabla.Rows[0];
            return new Pertenece((int)row["id_usuario"], (int)row["id_item"]);
        }

        public void UpdatePertenece(Pertenece pertenecito)
        {
            const string SQL = "UPDATE Pertenece set id_usuario = :usuario, id_item = :item WHERE id_usuario = :id";

            NpgsqlParameter paramItem = new NpgsqlParameter(":nom", pertenecito.id_item);
            NpgsqlParameter paramId = new NpgsqlParameter(":id", pertenecito.id_usuario);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramItem, paramId };
            GetQuery(SQL, lista);
        }

    }

}

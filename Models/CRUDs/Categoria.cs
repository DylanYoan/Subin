using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Categoria : Conexion
    {

        public int id_categoria { get; set; } // 
        public string titulo { get; set; } // 
        public int id_plataforma { get; set; } // 



        public Categoria()
        {
        }

        public Categoria(int id_categoria, string titulo, int id_plataforma) //
        {
            this.id_categoria = id_categoria; //
            this.titulo = titulo; //
            this.id_plataforma = id_plataforma;

        }


        public List<Categoria> GetCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            const string SQL = "SELECT * FROM Categoria;";
            DataTable tabla = GetQuery(SQL);
            if (tabla.Rows.Count < 2) return lista;
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Categoria((int)row["id_categoria"], (string)row["titulo"], (int)row["id_plataforma"]));
            }
            return lista;
        }

        public bool AddCategoria(Categoria categoriacito)
        {
            const string SQL = "INSERT INTO Categoria(id_categoria, titulo, id_plataforma) VALUES(:cat, :titulo, :plat);";
            NpgsqlParameter paramCat = new NpgsqlParameter(":item", categoriacito.id_categoria);
            NpgsqlParameter paramTitulo = new NpgsqlParameter(":nombre", categoriacito.titulo);
            NpgsqlParameter paramPlat = new NpgsqlParameter(":cat", categoriacito.id_plataforma);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramCat, paramTitulo, paramPlat };

            return GetQuery(SQL, lista).Rows.Count > 0;
        }

        public void DeleteCategoria(Categoria categoriacito)
        {
            const string SQL = "DELETE from Categoria where id_categoria=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", categoriacito.id_categoria) };
            GetQuery(SQL, lista);

        }

        public Categoria ObtenerCategoriaById(int id)
        {
            const string SQL = "SELECT * FROM Categoria WHERE id_categoria=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Categoria();
            DataRow row = tabla.Rows[0];
            return new Categoria((int)row["id_categoria"], (string)row["titulo"], (int)row["id_plataforma"]);
        }

        public void UpdateCategoria(Categoria categoriacito)
        {
            const string SQL = "UPDATE Categoria set id_categoria = :item, nombre_item = :nom, descripcion_item = :desc, id_categoria = :cat WHERE id_item = :id";
            NpgsqlParameter paramCat = new NpgsqlParameter(":item", categoriacito.id_categoria);
            NpgsqlParameter paramTitulo = new NpgsqlParameter(":nombre", categoriacito.titulo);
            NpgsqlParameter paramPlat = new NpgsqlParameter(":cat", categoriacito.id_plataforma);
            NpgsqlParameter paramId = new NpgsqlParameter(":id", categoriacito.id_categoria);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramCat, paramTitulo, paramPlat, paramId };
            GetQuery(SQL, lista);
        }
    }
}

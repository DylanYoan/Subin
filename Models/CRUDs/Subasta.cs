using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace SubIn.Models
{
    public class Subasta : Conexion
    {
        public int id_subasta { get; set; } // 
        public string title { get; set; } // 
        public DateTime fecha { get; set; }  // 
        public string descripcion_subasta { get; set; }
        public byte[] img_subasta { get; set; }



        public Subasta()
        {
        }

        public Subasta(int id_subasta, string title, DateTime fecha, string descripcion_subasta, byte[] img_subasta) //
        {
            this.id_subasta = id_subasta; //
            this.title = title;
            this.fecha = fecha; //
            this.descripcion_subasta = descripcion_subasta;
            this.img_subasta = img_subasta;
        }

 
        public List<Subasta> GetSubasta()
        {
            List<Subasta> lista = new List<Subasta>();
            const string SQL = "SELECT * FROM Subasta;";
            DataTable tabla = GetQuery(SQL);
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Subasta((int)row["id_subasta"], (string)row["title"], (DateTime)row["fecha"], (string)row["descripcion_subasta"], (byte[])row["img_subasta"]));
            }
            return lista;
        }

        public bool AddSubasta(Subasta subastita)
        {

                const string SQL = "INSERT INTO Subasta(title, fecha, descripcion_subasta, img_subasta) VALUES(:title, :nombre, :desc, :img);";
                NpgsqlParameter paramIdSub = new NpgsqlParameter(":title", subastita.title);
                NpgsqlParameter paramFecha = new NpgsqlParameter(":nombre", subastita.fecha);
                NpgsqlParameter paramDesc = new NpgsqlParameter(":desc", subastita.descripcion_subasta);
                NpgsqlParameter paramImg = new NpgsqlParameter(":img", subastita.img_subasta);
                List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramIdSub, paramFecha, paramDesc, paramImg };

                return GetQuery(SQL, lista).Rows.Count > 0;
            

            
        }

        public void DeleteSubasta(Subasta subastita)
        {
            const string SQL = "DELETE from subasta where id_subasta=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", subastita.id_subasta) };
            GetQuery(SQL, lista);

        }

        public Subasta ObtenerSubastaById(int id)
        {
            const string SQL = "SELECT * FROM Subasta WHERE id_subasta=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Subasta();
            DataRow row = tabla.Rows[0];
            return new Subasta((int)row["id_subasta"], (string)row["title"],(DateTime)row["fecha"], (string)row["descripcion_subasta"], (byte[])row["img_subasta"]);
        }

        public void UpdateSubasta(Subasta subastita)
        {
            const string SQL = "UPDATE Categoria set title = :title, fecha = :fecha, descripcion_subasta = :desc, img_subasta = :img WHERE id_subasta = :subasta";
            NpgsqlParameter paramIdSub = new NpgsqlParameter(":subasta", subastita.id_subasta);
            NpgsqlParameter paramTitle = new NpgsqlParameter(":title", subastita.title);
            NpgsqlParameter paramFecha = new NpgsqlParameter(":fecha", subastita.fecha);
            NpgsqlParameter paramDesc = new NpgsqlParameter(":desc", subastita.descripcion_subasta);
            NpgsqlParameter paramImg = new NpgsqlParameter(":img", subastita.img_subasta);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramTitle, paramFecha, paramDesc, paramImg, paramIdSub };
            GetQuery(SQL, lista);
        }
    }
}

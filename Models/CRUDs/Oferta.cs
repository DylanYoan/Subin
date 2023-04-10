using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Oferta : Conexion
    {

        public int id_oferta { get; set; } // 
        public double cantidad_oferta { get; set; } // 

        public int id_item { get; set; } // 
        public int id_subasta { get; set; } // 

        public int id_usuario { get; set; } // 




        public Oferta()
        {
        }

        public Oferta(int id_oferta, double cantidad_oferta, int id_item, int id_subasta, int id_usuario) //
        {
            this.id_oferta = id_oferta; //
            this.cantidad_oferta = cantidad_oferta; //
            this.id_item = id_item;
            this.id_subasta = id_subasta;
            this.id_usuario = id_usuario;

        }


        public List<Oferta> GetOferta()
        {
            List<Oferta> lista = new List<Oferta>();
            const string SQL = "SELECT * FROM Oferta;";
            DataTable tabla = GetQuery(SQL);
            if (tabla.Rows.Count < 2) return lista;
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Oferta((int)row["id_oferta"], (double)row["cantidad_oferta"], (int)row["id_item"], (int)row["id_subasta"], (int)row["id_usuario"]));
            }
            return lista;
        }

        public bool AddOferta(Oferta ofertita)
        {
            const string SQL = "INSERT INTO Oferta(id_oferta, cantidad_oferta, id_item, id_subasta, id_usuario) VALUES(:oferta, :cantidad, :item, :subasta, :usuario);";
            NpgsqlParameter paramIdOferta = new NpgsqlParameter(":oferta", ofertita.id_oferta);
            NpgsqlParameter paramCantOferta = new NpgsqlParameter(":cantidad", ofertita.cantidad_oferta);
            NpgsqlParameter paramIdItem = new NpgsqlParameter(":item", ofertita.id_item);
            NpgsqlParameter paramIdSubasta = new NpgsqlParameter(":subasta", ofertita.id_subasta);
            NpgsqlParameter paramIdUsuario = new NpgsqlParameter(":usuario", ofertita.id_usuario);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramIdOferta, paramCantOferta, paramIdItem, paramIdSubasta, paramIdUsuario };

            return GetQuery(SQL, lista).Rows.Count > 0;
        }

        public void DeleteOferta(Oferta ofertita)
        {
            const string SQL = "DELETE from Oferta where id_oferta=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", ofertita.id_oferta) };
            GetQuery(SQL, lista);

        }

        public Oferta ObtenerOfertaById(int id)
        {
            const string SQL = "SELECT * FROM Oferta WHERE id_oferta=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Oferta();
            DataRow row = tabla.Rows[0];
            return new Oferta((int)row["id_oferta"], (double)row["cantidad_oferta"], (int)row["id_item"], (int)row["id_subasta"], (int)row["id_usuario"]);
        }

        public void UpdateOferta(Oferta ofertita)
        {
            const string SQL = "UPDATE Oferta set id_oferta = :oferta, cantidad_oferta = :cantidad, id_item = :item, id_subasta = :subasta, id_usuario = :usuario WHERE id_oferta = :id";

            NpgsqlParameter paramIdOferta = new NpgsqlParameter(":oferta", ofertita.id_oferta);
            NpgsqlParameter paramCantOferta = new NpgsqlParameter(":cantidad", ofertita.cantidad_oferta);
            NpgsqlParameter paramIdItem = new NpgsqlParameter(":item", ofertita.id_item);
            NpgsqlParameter paramIdSubasta = new NpgsqlParameter(":subasta", ofertita.id_subasta);
            NpgsqlParameter paramIdUsuario = new NpgsqlParameter(":usuario", ofertita.id_usuario);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramIdOferta, paramCantOferta, paramIdItem, paramIdSubasta, paramIdUsuario };
            GetQuery(SQL, lista);
        }
    }
}

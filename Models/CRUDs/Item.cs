using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Item : Conexion
    {

        public int id_item { get; set; } // 
        public string nombre_item { get; set; } // 

        public string descripcion_item { get; set; } // 

        public int id_categoria { get; set; } // 



        public Item()
        {
        }

        public Item(int id_item, string nombre_item, string descripcion_item, int id_categoria) //
        {
            this.id_item = id_item; //
            this.nombre_item = nombre_item; //
            this.descripcion_item = descripcion_item;
            this.id_categoria = id_categoria;

        }


        public List<Item> GetItem()
        {
            List<Item> lista = new List<Item>();
            const string SQL = "SELECT * FROM Item;";
            DataTable tabla = GetQuery(SQL);
            if (tabla.Rows.Count < 2) return lista;
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Item((int)row["id_item"], (string)row["nombre_item"], (string)row["descripcion_item"], (int)row["id_categoria"]));
            }
            return lista;
        }

        public List<Item> GetInventario(int id)
        {
            List<Item> lista = new List<Item>();
            const string SQL = "SELECT * FROM Pertenece WHERE id_usuario=:id";
            List<NpgsqlParameter> list = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, list);
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Item().ObtenerItemById((int)row["id_item"]));
            }
            return lista;
        }


        public bool AddItem(Item itemcito)
        {
            const string SQL = "INSERT INTO Pertenece(id_item, nombre_item, descripcion_item, id_categoria) VALUES(:item, :nombre, :desc, :cat);";
            NpgsqlParameter paramItem = new NpgsqlParameter(":item", itemcito.id_item);
            NpgsqlParameter paramNomItem = new NpgsqlParameter(":nombre", itemcito.nombre_item);
            NpgsqlParameter paramDescItem = new NpgsqlParameter(":desc", itemcito.descripcion_item);
            NpgsqlParameter paramIdCategoria = new NpgsqlParameter(":cat", itemcito.id_categoria);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramItem, paramNomItem, paramDescItem, paramIdCategoria };

            return GetQuery(SQL, lista).Rows.Count > 0;
        }

        public void DeleteItem(Item itemcito)
        {
            const string SQL = "DELETE from item where id_item=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", itemcito.id_item) };
            GetQuery(SQL, lista);

        }

        public Item ObtenerItemById(int id)
        {
            const string SQL = "SELECT * FROM item WHERE id_item=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Item();
            DataRow row = tabla.Rows[0];
            return new Item((int)row["id_item"], (string)row["nombre_item"], (string)row["descripcion_item"], (int)row["id_categoria"]);
        }

        public void UpdateItem(Item itemcito)
        {
            const string SQL = "UPDATE Pertenece set id_item = :item, nombre_item = :nom, descripcion_item = :desc, id_categoria = :cat WHERE id_item = :id";

            NpgsqlParameter paramItem = new NpgsqlParameter(":item", itemcito.id_item);
            NpgsqlParameter paramNom = new NpgsqlParameter(":nom", itemcito.nombre_item);
            NpgsqlParameter paramDesc = new NpgsqlParameter(":desc", itemcito.descripcion_item);
            NpgsqlParameter paramCat = new NpgsqlParameter(":cat", itemcito.id_categoria);
            NpgsqlParameter paramId = new NpgsqlParameter(":id", itemcito.id_item);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramItem, paramNom, paramDesc, paramCat, paramId };
            GetQuery(SQL, lista);
        }

    }

}

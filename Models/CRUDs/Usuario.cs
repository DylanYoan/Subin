using SubIn.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SubIn.Models
{
    public class Usuario : Conexion
    {
        public int id_usuario { get; set; } //
        public string nombre { get; set; } // 
        public string apellidos { get; set; } // declaramos variable publicas para toda la clase
        public string email { get; set; } //
        public string contrasena { get; set; } //
        public Int64 telefono { get; set; } //

        public Usuario() // El contructor vacio 
        {
        }

        public Usuario(int id_usuario, string nombre, string apellidos, string email, string contrasena, Int64 telefono) //
        {
            this.id_usuario = id_usuario; //
            this.nombre = nombre; //
            this.apellidos = apellidos; // Declaramos el constructor de la clase usando paso de parmetros y las variable publicas previamente declaradas
            this.email = email; //
            this.contrasena = contrasena;
            this.telefono = telefono; //
        }


        public List<Usuario> GetUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            const string SQL = "SELECT * FROM Usuario;";
            DataTable tabla = GetQuery(SQL);  // Funcion que obtiene los.usjarios registrados en la.base de datos de la.tabala usuarios
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new Usuario((int)row["id_usuario"], (string)row["nombre"], (string)row["apellidos"], (string)row["email"], (string)row["contrasena"], (Int64)row["telefono"])); // la listade parametros que se mostraran en ka.vista
            }
            return lista;
        }

        public int GetUsuarioForLogin(string email, string contrasena)
        {
            const string SQL = "SELECT * FROM usuario WHERE email=:email and contrasena=:contrasena";
            NpgsqlParameter paramEmail = new NpgsqlParameter(":email", email);
            NpgsqlParameter paramContra = new NpgsqlParameter(":contrasena", contrasena);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramEmail, paramContra };
            DataTable tabla = GetQuery(SQL, lista);
            DataRow row = tabla.Rows[0];
            return (int)row["id_usuario"]; // devuelve la informacion del registro obtenido por id 

        }

        public bool AddUsuario(Usuario usuarito) // Funcion que permite añandir registro dentro de la tabla usuarios
        {
            const string SQL = "INSERT INTO usuario(nombre, apellidos, email, contrasena, telefono) VALUES(:nom, :ap, :email, :contrasena, :telefono);";
            NpgsqlParameter paramNombre = new NpgsqlParameter(":nom", usuarito.nombre);
            NpgsqlParameter paramAp = new NpgsqlParameter(":ap", usuarito.apellidos);
            NpgsqlParameter paramEmail = new NpgsqlParameter(":email", usuarito.email);
            NpgsqlParameter paramContra = new NpgsqlParameter(":contrasena", usuarito.contrasena);
            NpgsqlParameter paramTelefono = new NpgsqlParameter(":telefono", usuarito.telefono);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramNombre, paramAp, paramEmail, paramContra, paramTelefono };

            return GetQuery(SQL, lista).Rows.Count > 0; // Gracias alos parametros previamente declaras y añadidos a la conaulta regustra al usuario con una funcion usando el metodo de la clase conexion
        }

        public void DeletePersona(Usuario usuarito) // Funcion que permite borrar registros de la tabla usuarios
        {
            const string SQL = "DELETE from usuario where id_usuario=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", usuarito.id_usuario) };
            GetQuery(SQL, lista); // Ejecuta la conaulta dentro de posrgres donde se borra el.registro a partir del.id

        }

        public Usuario ObtenerUsuarioById(int id) // funcion que se dedica a obtener informacion de un registro por medio del.id 
        {
            const string SQL = "SELECT * FROM usuario WHERE id_usuario=:id";
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { new NpgsqlParameter(":id", id) };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Usuario();
            DataRow row = tabla.Rows[0];
            return new Usuario((int)row["id_usuario"], (string)row["nombre"], (string)row["apellidos"], (string)row["email"], (string)row["contrasena"], (Int64)row["telefono"]); // devuelve la informacion del registro obtenido por id 
        }

        public void UpdateUsuario(Usuario usuarito) // Funcion que se encarga de actualizar los datos, dandole.todos los dstoa por psrameteo en la co sukta
        {
            const string SQL = "UPDATE usuario set nombre = :nom, apellidos = :ap, email = :email, telefono = :telefono WHERE id_usuario = :id";

            NpgsqlParameter paramNom = new NpgsqlParameter(":nom", usuarito.nombre);
            NpgsqlParameter paramAp = new NpgsqlParameter(":ap", usuarito.apellidos);
            NpgsqlParameter paramEmail = new NpgsqlParameter(":curp", usuarito.email);
            NpgsqlParameter paramTelefono = new NpgsqlParameter(":telefono", usuarito.telefono);
            NpgsqlParameter paramId = new NpgsqlParameter(":id", usuarito.id_usuario);

            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramNom, paramAp, paramEmail, paramTelefono, paramId };
            GetQuery(SQL, lista);
        }

    }


   
}

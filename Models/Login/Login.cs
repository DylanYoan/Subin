using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SubIn.Models.Login
{
    public class Login : Conexion
    {


        public Usuario getUserByEmailPass(string correo, string contrasena)
        {
            const string SQL = "SELECT * FROM usuario WHERE email=:email and contrasena = :contrasena";
            NpgsqlParameter paramCorreo = new NpgsqlParameter(":email", correo);
            NpgsqlParameter paramContrasena = new NpgsqlParameter(":contrasena", contrasena);
            List<NpgsqlParameter> lista = new List<NpgsqlParameter>() { paramCorreo, paramContrasena };
            DataTable tabla = GetQuery(SQL, lista);
            if (tabla.Rows.Count <= 0) return new Usuario();
            DataRow row = tabla.Rows[0];
            return new Usuario((int)row["id_usuario"], (string)row["nombre"], (string)row["apellidos"], (string)row["email"], (string)row["contrasena"], (Int64)row["telefono"]); // devuelve la informacion del registro obtenido por id 

        }


    }
}
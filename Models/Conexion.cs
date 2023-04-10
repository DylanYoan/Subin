using System.Collections.Generic;
using System.Data;
using Npgsql;
namespace SubIn.Models{

public class Conexion{

private readonly string StrConexion="Server=localhost; UserId=postgres; Password=bd; Database=subin;";
private NpgsqlConnection _conexion = new NpgsqlConnection();
 public Conexion()
{
	_conexion.ConnectionString=StrConexion;
}
public DataTable GetQuery(string sql)
{
	DataTable tabla= new DataTable();
	NpgsqlDataAdapter adapter= new NpgsqlDataAdapter();
	using(_conexion = new NpgsqlConnection())
	{
		_conexion.ConnectionString=StrConexion;
		using(NpgsqlCommand comando = new NpgsqlCommand())
		{
			comando.Connection=_conexion;
			comando.CommandText= sql;
			adapter.SelectCommand= comando;
			adapter.Fill(tabla);
		}
	}
	return tabla;
}

public DataTable GetQuery(string sql,List<NpgsqlParameter> lstParameters)
{
	DataTable tabla= new DataTable();
	NpgsqlDataAdapter adapter= new NpgsqlDataAdapter();
	using(_conexion = new NpgsqlConnection())
	{
		_conexion.ConnectionString=StrConexion;
		using(NpgsqlCommand comando = new NpgsqlCommand())
		{
			comando.Connection=_conexion;
			comando.CommandText= sql;
			comando.Parameters.Clear();
			foreach(NpgsqlParameter param in lstParameters)
			{
				comando.Parameters.Add(param);
			}
			adapter.SelectCommand= comando;
			adapter.Fill(tabla);
		}
	}
	return tabla;
}
}
}




	

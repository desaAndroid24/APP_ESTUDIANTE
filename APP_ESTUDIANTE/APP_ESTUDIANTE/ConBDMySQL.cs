using MySqlConnector;
using System;

namespace APP_ESTUDIANTE
{
    internal class ConBDMySQL : conectarBD
    {
        MySqlConnection coneccion;

        private string cadenaConeccion;
        public ConBDMySQL()
        {
            cadenaConeccion =   "Server=" + server + ";Port=" + port + ";Uid=" + user + ";Pwd=" + password + ";Database=" + database;
            //cadenaConeccion = "Server=192.168.0.39;Port=3306;Uid=root;Pwd=25.Mysql.25;Database=pbdgx008";

            try
            {
                coneccion = new MySqlConnection(cadenaConeccion);
                coneccion.ConnectionString = cadenaConeccion;
                coneccion.Open();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public MySqlConnection getConnecccion()
        {
            return coneccion;
        }
    }
}

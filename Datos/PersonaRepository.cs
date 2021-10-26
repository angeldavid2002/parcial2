using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class PersonaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();
        public PersonaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona(identificacion,nombre,edad) 
                                        values (@identificacion,@nombre,@edad)";
                command.Parameters.AddWithValue("@identificacion", persona.identificacion);
                command.Parameters.AddWithValue("@nombre", persona.nombre);
                command.Parameters.AddWithValue("@edad", persona.edad);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Actualizar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"UPDATE Persona SET
                                        nombre=@nombre,edad=@edad WHERE identificacion=@identificacion";
                command.Parameters.AddWithValue("@identificacion",Convert.ToInt32(persona.identificacion));
                command.Parameters.AddWithValue("@nombre", persona.nombre);
                command.Parameters.AddWithValue("@edad", Convert.ToInt32(persona.edad));
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Persona where identificacion=@identificacion";
                command.Parameters.AddWithValue("@identificacion", persona.identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }
        public Persona BuscarPorIdentificacion(int identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from persona where identificacion=@identificacion";
                command.Parameters.AddWithValue("@identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.identificacion = (int)dataReader["identificacion"];
            persona.nombre = (string)dataReader["nombre"];
            persona.edad = (int)dataReader["edad"];
            return persona;
        }
        public int Totalizar()
        {
            return _personas.Count();
        }
    }
}
using crud01.Data;
using crud01.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace crud01.Services
{
    public class UsuarioService
    {
        Conexao conexao = new Conexao();

        public void Cadastrar(Usuario usuario)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO usuarios (nome, email) VALUES (@nome, @email)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM usuarios";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Usuario
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nome = reader["nome"].ToString(),
                        Email = reader["email"].ToString()
                    });
                }
            }

            return lista;
        }

        public void Remover(int id)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM usuarios WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_SamuelBelo.Models;

namespace TP3_SamuelBelo.Repositorys.Implementations
{
    public class PessoaRepository : IPessoaRepository

    {
        private readonly string _connectionString;
        public PessoaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("PessoaConnectionString");
        }


        public int Add(Pessoa pessoa)
        {
            var cmdText = "INSERT INTO Pessoa " +
                   " (Nome, DataNascimento) " +
                   " OUTPUT INSERTED.Id " +
                   " VALUES (@Nome, @DataNascimento);";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@Nome", SqlDbType.VarChar).Value = pessoa.Nome;
                sqlCommand.Parameters
                    .Add("@DataNascimento", SqlDbType.Date).Value = pessoa.DataNascimento;

                sqlConnection.Open();

                var resultScalar = sqlCommand.ExecuteScalar();

                var id = (int)resultScalar;

                return id;
            }
        }


        public IEnumerable<Pessoa> GetAll()
        {
            const string cmdText = "SELECT * FROM Pessoa;";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                var pessoas = new List<Pessoa>();
                using (var reader = sqlCommand.ExecuteReader())
                { 
                    while (reader.Read())
                    {
                        pessoas.Add(new Pessoa
                        {
                            Id = reader.GetFieldValue<int>(name: "Id"),
                            Nome = reader.GetFieldValue<string>(name: "Nome"),
                            DataNascimento = reader.GetFieldValue<DateTime>(name: "DataNascimento").ToString()
                        });
                    }
                }

                return pessoas;
            }
        }
        public Pessoa GetById(int id)
        {
            const string cmdText = "SELECT * FROM Pessoa WHERE Id = @id";

            using(var sqlConnection = new SqlConnection(_connectionString))
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters
                    .Add("@id", SqlDbType.Int).Value = id;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new Pessoa
                    {
                        Id = reader.GetFieldValue<int>(name: "Id"),
                        Nome = reader.GetFieldValue<string>(name: "Nome"),
                        DataNascimento = reader.GetFieldValue<DateTime>(name: "DataNascimento").ToString()
                    };
                }

            }
        }

        public void Update(int id, Pessoa pessoa)
        {
            const string cmdText = "UPDATE Pessoa " +
                   " SET Nome = (@nome), DataNascimento = (@dataNascimento) WHERE Id = @id; ";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@id", SqlDbType.Int).Value = pessoa.Id;
                sqlCommand.Parameters
                    .Add("@nome", SqlDbType.VarChar).Value = pessoa.Nome;
                sqlCommand.Parameters
                    .Add("@dataNascimento", SqlDbType.Date).Value = pessoa.DataNascimento;

                sqlConnection.Open();

                var resultScalar = sqlCommand.ExecuteScalar();

            }
        }

        public void Delete(int id)
        {

            const string cmdText = "DELETE FROM Pessoa WHERE Id = @id; ";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@id", SqlDbType.Int).Value = id;

                sqlConnection.Open();

                var resultScalar = sqlCommand.ExecuteScalar();

            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Teste.Entidades;

namespace Teste.DAO
{
    public class CadastroTesteDAO
    {
        public List<CadastroTeste> SelectAllClients()
        {
            string connectionString =
            @"Data Source=MTZNOTFS033786\SQLEXPRESS;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "SELECT * FROM CadastroTeste";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);


                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    var _Cadastro = new List<CadastroTeste>();

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _Cadastro.Add(new CadastroTeste()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Descricao = reader["Descricao"].ToString()

                        });
                    }
                    reader.Close();
                    return _Cadastro;
                }
                catch (Exception ex)
                {
                    throw ex;

                }

            }
        }

        public void InsertDataCadastroTeste(string Descricao)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString = "INSERT INTO dbo.CadastroTeste (Descricao) " +
                   "VALUES (@Descricao) ";



            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                // Create the Command and Parameter objects.
                SqlCommand cmd = new SqlCommand(queryString, connection);



                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {

                    cmd.Parameters.Add("@Descricao", SqlDbType.VarChar, 50).Value = Descricao;
                    

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();


                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
        }


        public void DeleteDataCadastroTeste(int Id)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";


            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                try
                {

                    string query = "DELETE FROM CadastroTeste WHERE IdEndereco=@Id";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Connection = connection;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }



                catch (Exception ex)
                {
                    throw ex;

                }


            }
        }

        public void UpdateDataCadastroTeste(CadastroTeste cadastroteste)
        {


            string connectionString =
            @"Data Source=localhost\sqlexpress;Initial Catalog=Teste;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
                "UPDATE CadastroTeste SET Id = @Id, Descricao = @Descricao WHERE Id = @Id";



            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {


                // Create the Command and Parameter objects.
                SqlCommand cmd = new SqlCommand(queryString, connection);



                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = cadastroteste.Id;
                    cmd.Parameters.Add("@Descricao", SqlDbType.VarChar, 50).Value = cadastroteste.Descricao;
                    

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();


                }
                catch (Exception ex)
                {
                    throw ex;

                }


            }
        }

    }
}

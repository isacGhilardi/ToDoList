using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Data.Sqlite;

namespace ToDoList.Models
{
    public class ConexaoSqlLite
    {
        public readonly string _connectionString;

        public ConexaoSqlLite()
        {
            _connectionString = "Data Source=todolist.db";
        }

        public SqliteConnection Conn()
        {
            var connection = new SqliteConnection(_connectionString);
            connection.Open();
            connection.CreateCommand();
            return connection;
        }
        public string CtbAtividade()
        {
            try
            {
                var comando = Conn().CreateCommand();
                comando.CommandText = @"Create or replace table Atividade (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Descricao TEXT NOT NULL,
                DataCriacao DATETIME NOT NULL,
                Status INTEGER NOT NULL
            )";
                comando.ExecuteNonQuery();
                return "Inserido com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
    


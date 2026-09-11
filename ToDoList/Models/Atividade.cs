using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class Atividade : ConexaoSqlLite
    {
        private int id;
        private string nome;
        private string descricao;
        private DateTime dataCriacao;
        private int status;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public int Status { get => status; set => status = value; }

        public string InserirAtividade(Atividade a)
        {
            try
            {
                var comando = Conn().CreateCommand();
                comando.CommandText = @"INSERT INTO Atividade (Nome, Descricao, DataCriacao, Status) VALUES (@Nome, @Descricao, @DataCriacao, @Status)";
                comando.Parameters.AddWithValue("@Nome", a.Nome);
                comando.Parameters.AddWithValue("@Descricao", a.Descricao);
                comando.Parameters.AddWithValue("@DataCriacao", a.DataCriacao);
                comando.Parameters.AddWithValue("@Status", a.Status);
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

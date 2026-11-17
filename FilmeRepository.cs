using System.Data;
using MySql.Data.MySqlClient;

public class FilmeRepository
{
    public void Inserir(Filme filme)
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "INSERT INTO filmes (titulo, genero, duracao) VALUES (@titulo, @genero, @duracao)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@titulo", filme.Titulo);
            comando.Parameters.AddWithValue("@genero", filme.Genero);
            comando.Parameters.AddWithValue("@duracao", filme.Duracao);
            comando.ExecuteNonQuery();
        }
    }

    public DataTable Listar()
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "SELECT id, titulo, genero, duracao FROM filmes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}

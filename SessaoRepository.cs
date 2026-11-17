using System.Data;
using MySql.Data.MySqlClient;

public class SessaoRepository
{
    public void Inserir(Sessao sessao)
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = "INSERT INTO sessoes (filme_id, horario, capacidade, ingressos_vendidos) VALUES (@filmeId, @horario, @capacidade, 0)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@filmeId", sessao.FilmeId);
            comando.Parameters.AddWithValue("@horario", sessao.Horario);
            comando.Parameters.AddWithValue("@capacidade", sessao.Capacidade);
            comando.ExecuteNonQuery();
        }
    }

    public DataTable ListarComFilmes()
    {
        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();
            string sql = @"SELECT s.id, f.titulo AS filme, s.horario, s.capacidade, s.ingressos_vendidos 
                           FROM sessoes s 
                           JOIN filmes f ON s.filme_id = f.id";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
}

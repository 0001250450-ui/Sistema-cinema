using MySql.Data.MySqlClient;
using System.Windows.Forms;

public class IngressoRepository
{
    public bool Vender(Ingresso ingresso, int capacidade, int vendidosAtuais)
    {
        if ((vendidosAtuais + ingresso.Quantidade) > capacidade)
        {
            MessageBox.Show("Erro: A quantidade de ingressos excede a capacidade máxima da sessão!", "Regra de Negócio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        Conexao banco = new Conexao();
        using (MySqlConnection conexao = banco.Conectar())
        {
            conexao.Open();

            string sqlIngresso = "INSERT INTO ingressos (sessao_id, quantidade, valor_total) VALUES (@sessaoId, @qtd, @total)";
            MySqlCommand cmd1 = new MySqlCommand(sqlIngresso, conexao);
            cmd1.Parameters.AddWithValue("@sessaoId", ingresso.SessaoId);
            cmd1.Parameters.AddWithValue("@qtd", ingresso.Quantidade);
            cmd1.Parameters.AddWithValue("@total", ingresso.ValorTotal);
            cmd1.ExecuteNonQuery();

            string sqlUpdate = "UPDATE sessoes SET ingressos_vendidos = ingressos_vendidos + @qtd WHERE id = @sessaoId";
            MySqlCommand cmd2 = new MySqlCommand(sqlUpdate, conexao);
            cmd2.Parameters.AddWithValue("@qtd", ingresso.Quantidade);
            cmd2.Parameters.AddWithValue("@sessaoId", ingresso.SessaoId);
            cmd2.ExecuteNonQuery();
        }
        return true;
    }
}

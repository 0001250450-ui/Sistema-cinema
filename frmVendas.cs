using System;
using System.Data;
using System.Windows.Forms;

public partial class frmVendas : Form
{
    private SessaoRepository sessaoRepo = new SessaoRepository();

    public frmVendas()
    {
        InitializeComponent();
        CarregarSessoes();
    }

    private void CarregarSessoes()
    {
        DataTable dt = sessaoRepo.ListarComFilmes();
        cmbSessoes.DataSource = dt;
        cmbSessoes.DisplayMember = "filme";
        cmbSessoes.ValueMember = "id";
    }

    private void btnFinalizar_Click(object sender, EventArgs e)
    {
        if (cmbSessoes.SelectedValue == null)
        {
            MessageBox.Show("Selecione uma sessão.");
            return;
        }

        int sessaoId = Convert.ToInt32(cmbSessoes.SelectedValue);
        
        if (!int.TryParse(numQuantidade.Text, out int qtd) || qtd <= 0)
        {
            MessageBox.Show("Informe uma quantidade válida de ingressos.");
            return;
        }

        DataRowView linhaSelecionada = (DataRowView)cmbSessoes.SelectedItem;
        int capacidade = Convert.ToInt32(linhaSelecionada["capacidade"]);
        int vendidosAtuais = Convert.ToInt32(linhaSelecionada["ingressos_vendidos"]);

        decimal valorUnitario = 25.00m;

        Ingresso ingresso = new Ingresso(sessaoId, qtd, valorUnitario);
        IngressoRepository ingressoRepo = new IngressoRepository();

        bool sucesso = ingressoRepo.Vender(ingresso, capacidade, vendidosAtuais);
        if (sucesso)
        {
            MessageBox.Show($"Compra finalizada com sucesso! Valor Total: R$ {ingresso.ValorTotal:F2}");
            CarregarSessoes();
        }
    }
}

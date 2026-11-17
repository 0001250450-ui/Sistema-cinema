using System;
using System.Windows.Forms;

public partial class frmFilmes : Form
{
    public frmFilmes()
    {
        InitializeComponent();
        CarregarGrid();
    }

    private void btnCadastrar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtGenero.Text) || string.IsNullOrWhiteSpace(txtDuracao.Text))
        {
            MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtDuracao.Text, out int duracao) || duracao <= 0)
        {
            MessageBox.Show("Informe uma duração válida em minutos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Filme filme = new Filme(txtTitulo.Text, txtGenero.Text, duracao);
        FilmeRepository repo = new FilmeRepository();
        repo.Inserir(filme);

        MessageBox.Show("Filme cadastrado com sucesso!");
        CarregarGrid();
        LimparCampos();
    }

    private void CarregarGrid()
    {
        FilmeRepository repo = new FilmeRepository();
        dgvFilmes.DataSource = repo.Listar();
    }

    private void LimparCampos()
    {
        txtTitulo.Clear();
        txtGenero.Clear();
        txtDuracao.Clear();
        txtTitulo.Focus();
    }
}

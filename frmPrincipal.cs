using System;
using System.Windows.Forms;

public partial class frmPrincipal : Form
{
    public frmPrincipal()
    {
        InitializeComponent();
    }

    private void btnAbrirFilmes_Click(object sender, EventArgs e)
    {
        frmFilmes telaFilmes = new frmFilmes();
        telaFilmes.ShowDialog();
    }

    private void btnAbrirVendas_Click(object sender, EventArgs e)
    {
        frmVendas telaVendas = new frmVendas();
        telaVendas.ShowDialog();
    }
}

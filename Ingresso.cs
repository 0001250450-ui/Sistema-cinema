public class Ingresso
{
    public int Id { get; set; }
    public int SessaoId { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorTotal { get; set; }

    public Ingresso() { }

    public Ingresso(int sessaoId, int quantidade, decimal valorUnitario)
    {
        SessaoId = sessaoId;
        Quantidade = quantidade;
        ValorTotal = quantidade * valorUnitario;
    }
}

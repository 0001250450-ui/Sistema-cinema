public class Sessao
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public string Horario { get; set; }
    public int Capacidade { get; set; }
    public int IngressosVendidos { get; set; }

    public Sessao() { }

    public Sessao(int filmeId, string horario, int capacidade)
    {
        FilmeId = filmeId;
        Horario = horario;
        Capacidade = capacidade;
        IngressosVendidos = 0;
    }
}

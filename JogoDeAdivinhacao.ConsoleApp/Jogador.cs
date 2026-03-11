public class Jogador
{
    
    public string Nome { get; set; }
    public int pontuacao { get; set; }

    public Jogador(string nome, int pontuacao)
    {
        Nome = nome;
        this.pontuacao = pontuacao;
    }

}
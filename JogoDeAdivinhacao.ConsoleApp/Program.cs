using System.Xml.Serialization;
using System.Text.Json;
using System.IO;
class Program
{
    public static bool jogarDeNovo()
    {
        bool respostaValida = true;
        bool jogarNovamente = true;
        String? resposta = "";

        while (respostaValida == true)
        {
            Console.WriteLine("Deseja jogar de novo? (s/n)");
            resposta = Console.ReadLine();


            if (String.Equals(resposta, "s", StringComparison.OrdinalIgnoreCase))
            {
                jogarNovamente = true;
                respostaValida = false;
            }
            else if (String.Equals(resposta, "n", StringComparison.OrdinalIgnoreCase))
            {
                jogarNovamente = false;
                respostaValida = false;
            }
            else
            {
                Console.WriteLine("Resposta inválida. Por favor, digite 's' para sim ou 'n' para não.");
                continue;
            }

        }

        return jogarNovamente;

    }

    public static int pontuacao(int pontuacaoJogador1, int numeroSorteado1, int numeroJogador1)
    {
        int pontuacaoJogador = pontuacaoJogador1;
        int numeroSorteado = numeroSorteado1;
        int numeroJogador = numeroJogador1;

        int diferenca = Math.Abs(numeroSorteado - numeroJogador);

        if (diferenca >= 10)
        {
            pontuacaoJogador -= 100;
        }
        else if (diferenca >= 5)
        {
            pontuacaoJogador -= 50;
        }
        else if (diferenca >= 1)
        {
            pontuacaoJogador -= 20;
        }

        return pontuacaoJogador;

    }

    public static String? verificaProximidade(int numeroSorteado, int numeroJogador)
    {
        int diferenca = Math.Abs(numeroSorteado - numeroJogador);

        if (diferenca >= 20)
        {
            return "Muito Longe";
        }
        else if (diferenca >= 10)
        {
            return "Longe";
        }
        else if (diferenca >= 5)
        {
            return "Perto";
        }
        else
        {
            return "Muito Perto";
        }

    }

    public static void mostrarRanking(List<Jogador> ranking)
    {
        if (ranking.Count == 0)
        {
            Console.WriteLine("O ranking está vazio. Jogue na dificuldade difícil para adicionar jogadores ao ranking.");
            Console.WriteLine("");
            return;
        }

        var top5 = ranking.OrderByDescending(j => j.pontuacao).Take(5).ToList();

        Console.WriteLine("Ranking Top 5:");
        for (int i = 0; i < top5.Count; i++)
        {
            var jogador = top5[i];
            Console.WriteLine($"{i + 1}° posição - Nome: {jogador.Nome} Pontuação: {jogador.pontuacao}");
        }
        Console.WriteLine("");
    }
    public static void salvarRanking(List<Jogador> ranking)
    {
        string jsonString = JsonSerializer.Serialize(ranking, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("ranking.json", jsonString);
    }
    public static List<Jogador> lerRanking(List<Jogador> ranking)
    {
        if (File.Exists("ranking.json"))
        {
            string jsonString = File.ReadAllText("ranking.json");
            return JsonSerializer.Deserialize<List<Jogador>>(jsonString) ?? new List<Jogador>();
        }
        return new List<Jogador>();
    }
    static string nomeArquivo = "ranking.json";
    static void Main(string[] args)
    {
        Console.WriteLine("Jogo de Adivinhação");
        Console.WriteLine("");


        int numeroJogador = 0, numeroSorteado = 0;
        int dificuldade = 0, tentativas = 0;
        Random random = new Random();
        bool verifica = true;
        bool verificarDificuldade = true;
        List<int> numerosDigitados = new List<int>();
        int pontuacaoJogador = 1000;

        List<Jogador> ranking = new List<Jogador>();
        ranking = lerRanking(ranking);

        int dica = 1;

        while (verifica == true)
        {

            while (verificarDificuldade == true)
            {

                Console.WriteLine("Escolha uma dificuldade:");
                Console.WriteLine("1 - Fácil (intervalo 1 a 10) / 10 tentativas");
                Console.WriteLine("2 - Médio (intervalo 1 a 50) / 5 tentativas");
                Console.WriteLine("3 - Difícil (intervalo 1 a 100) / 3 tentativas");
                Console.WriteLine("4 - Ranking (apenas para dificuldade difícil)");
                Console.WriteLine("Ou digite 0 para sair do jogo.");

                try
                {
                    dificuldade = Convert.ToInt32(Console.ReadLine());

                    if (dificuldade == 1)
                    {
                        dificuldade = 10;
                        tentativas = 10;
                    }
                    else if (dificuldade == 2)
                    {
                        dificuldade = 50;
                        tentativas = 5;
                    }
                    else if (dificuldade == 3)
                    {
                        dificuldade = 100;
                        tentativas = 3;
                    }
                    else if (dificuldade == 4)
                    {

                        mostrarRanking(ranking);

                        continue;
                    }
                    else if (dificuldade == 0)
                    {
                        Console.WriteLine("Obrigado por jogar! Até a próxima.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Dificuldade inválida. Por favor, escolha uma dificuldade válida (1, 2 ou 3).");
                        Console.WriteLine("");
                        continue;
                    }

                }
                catch (System.Exception)
                {
                    Console.WriteLine("Dificuldade inválida. Por favor, escolha uma dificuldade válida (1, 2 ou 3).");
                    Console.WriteLine("");
                    continue;
                }

                break;

            }

            numeroSorteado = random.Next(1, dificuldade + 1);
            bool acertou = false;

            for (int i = 0; i < tentativas; i++)
            {

                bool numeroRepetido = false;

                while (numeroRepetido == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Digite um número inteiro entre 1 e {dificuldade}:");

                    if (dica == 1)
                    {
                        Console.WriteLine("Digite ´D´ para receber UMA dica.");
                    }

                    Console.WriteLine("Ou digite 0 para sair do jogo.");
                    try
                    {
                        String? jogadorDigia = Console.ReadLine();

                        if (String.Equals(jogadorDigia, "D", StringComparison.OrdinalIgnoreCase) && dica == 1)
                        {

                            if (numeroSorteado % 2 == 0)
                            {
                                Console.WriteLine("O número sorteado é PAR.");
                            }
                            else
                            {
                                Console.WriteLine("O número sorteado é ÍMPAR.");
                            }

                            dica = 0;
                            continue;
                        }
                        else
                        {
                            numeroJogador = Convert.ToInt32(jogadorDigia);
                        }

                        if (numeroJogador == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"O número sorteado era {numeroSorteado}.");
                            Console.WriteLine("Obrigado por jogar! Até a próxima.");
                            Environment.Exit(0);
                        }

                        if (numeroJogador < 1 || numeroJogador > dificuldade)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"Número inválido. Por favor, digite um número inteiro entre 1 e {dificuldade}.");
                            continue;
                        }

                        numeroRepetido = true;
                        foreach (int numero in numerosDigitados)
                        {
                            if (numero == numeroJogador)
                            {
                                Console.WriteLine("Você já digitou esse número. Por favor, tente um número diferente.");
                                Console.WriteLine("");
                                numeroRepetido = false;
                            }
                        }

                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Número inválido. Por favor, digite um número inteiro entre 1 e 20.");
                        continue;
                    }

                }

                numerosDigitados.Add(numeroJogador);

                if (numeroJogador == numeroSorteado)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Parabéns! Você acertou o número sorteado.");
                    acertou = true;
                    i = tentativas;
                }
                else
                {

                    if (numeroJogador < numeroSorteado)
                    {

                        String? proximidade = verificaProximidade(numeroSorteado, numeroJogador);

                        Console.WriteLine("Número incorreto. O número sorteado é MAIOR do que o número que você digitou.");
                        Console.WriteLine($"Proximidade: {proximidade}");
                        Console.WriteLine($"Você tem {tentativas - 1 - i} tentativas restantes. Tente novamente.");
                        Console.WriteLine("");
                        pontuacaoJogador = pontuacao(pontuacaoJogador, numeroSorteado, numeroJogador);
                    }
                    else
                    {
                        String? proximidade = verificaProximidade(numeroSorteado, numeroJogador);

                        Console.WriteLine($"Número incorreto. O número sorteado é MENOR do que o número que você digitou.");
                        Console.WriteLine($"Proximidade: {proximidade}");
                        Console.WriteLine($"Você tem {tentativas - 1 - i} tentativas restantes. Tente novamente.");
                        Console.WriteLine("");
                        pontuacaoJogador = pontuacao(pontuacaoJogador, numeroSorteado, numeroJogador);
                    }

                }

            }

            if (acertou == false)
            {
                Console.WriteLine($"Suas tentativas acabaram. O número sorteado era {numeroSorteado}.");
                Console.WriteLine("");
                Console.WriteLine("A sua Pontuação final foi: " + pontuacaoJogador);
                Console.WriteLine("");

                if (dificuldade == 100)
                {

                    Console.WriteLine("Digite o seu nome: ");
                    string nomeJogador = Console.ReadLine()?? "Jogador sem nome";

                    Jogador Jogador1 = new Jogador(nomeJogador, pontuacaoJogador);

                    ranking.Add(Jogador1);

                    mostrarRanking(ranking);
                    salvarRanking(ranking);

                }
                dica = 1;
                pontuacaoJogador = 1000;
                verifica = jogarDeNovo();
            }
            else
            {
                Console.WriteLine($"O número sorteado era {numeroSorteado}.");
                Console.WriteLine("");
                Console.WriteLine("A sua Pontuação final foi: " + pontuacaoJogador);
                Console.WriteLine("");

                if (dificuldade == 100)
                {

                    Console.WriteLine("Digite o seu nome: ");
                    string nomeJogador = Console.ReadLine()?? "Jogador sem nome";

                    Jogador Jogador1 = new Jogador(nomeJogador, pontuacaoJogador);

                    ranking.Add(Jogador1);

                    mostrarRanking(ranking);
                    salvarRanking(ranking);

                }
                dica = 1;
                pontuacaoJogador = 1000;
                verifica = jogarDeNovo();
            }


        }

        Console.WriteLine("");
        Console.WriteLine("Obrigado por jogar! Até a próxima.");




    }

}

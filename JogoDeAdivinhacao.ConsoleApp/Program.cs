
bool jogarDeNovo()
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

Console.WriteLine("Jogo de Adivinhação");
Console.WriteLine("");

int numeroJogador = 0, numeroSorteado = 0;
Random random = new Random();
bool verifica = true;

while (verifica == true)
{

    Console.WriteLine("Digite um número inteiro entre 1 e 20:");
    try
    {
        numeroJogador = Convert.ToInt32(Console.ReadLine());
    }
    catch (System.Exception)
    {
        Console.WriteLine("Número inválido. Por favor, digite um número inteiro entre 1 e 20.");
        continue;
    }


    if (numeroJogador < 1 || numeroJogador > 20)
    {
        Console.WriteLine("Número inválido. Por favor, digite um número inteiro entre 1 e 20.");
        continue;
    }
    else
    {
        numeroSorteado = random.Next(1, 21);

        if (numeroJogador == numeroSorteado)
        {
            Console.WriteLine("Parabéns! Você acertou o número sorteado.");
            verifica = jogarDeNovo();
        }
        else
        {
            Console.WriteLine($"Que pena! O número sorteado era {numeroSorteado}.");
            verifica = jogarDeNovo();
        }
    }

}



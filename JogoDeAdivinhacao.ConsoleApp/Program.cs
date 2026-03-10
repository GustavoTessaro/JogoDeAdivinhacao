
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
int dificuldade = 0, tentativas = 0;
Random random = new Random();
bool verifica = true;
bool verificarDificuldade = true;
List<int> numerosDigitados = new List<int>();

while (verifica == true)
{

    while (verificarDificuldade == true)
    {

        Console.WriteLine("Escolha uma dificuldade:");
        Console.WriteLine("1 - Fácil (intervalo 1 a 10) / 10 tentativas");
        Console.WriteLine("2 - Médio (intervalo 1 a 50) / 5 tentativas");
        Console.WriteLine("3 - Difícil (intervalo 1 a 100) / 3 tentativas");
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

    for (int i = 0; i < tentativas - 1; i++)
    {

        bool numeroRepetido = false;

        while (numeroRepetido == false)
        {
            Console.WriteLine($"Digite um número inteiro entre 1 e {dificuldade}:");
            Console.WriteLine("Ou digite 0 para sair do jogo.");
            try
            {
                numeroJogador = Convert.ToInt32(Console.ReadLine());
    
                if (numeroJogador == 0)
                {
                    Console.WriteLine($"O número sorteado era {numeroSorteado}.");
                    Console.WriteLine("Obrigado por jogar! Até a próxima.");
                    Environment.Exit(0);
                }

                if (numeroJogador < 1 || numeroJogador > dificuldade)
                {
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
                Console.WriteLine("Número inválido. Por favor, digite um número inteiro entre 1 e 20.");
                continue;
            }

        }

        numerosDigitados.Add(numeroJogador);

        if (numeroJogador == numeroSorteado)
        {
            Console.WriteLine("Parabéns! Você acertou o número sorteado.");
            acertou = true;
            i = tentativas;
        }
        else
        {

            if (numeroJogador < numeroSorteado)
            {
                Console.WriteLine("Número incorreto. O número sorteado é MAIOR do que o número que você digitou.");
                Console.WriteLine($"Você tem {tentativas - 1 - i} tentativas restantes. Tente novamente.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"Número incorreto. O número sorteado é MENOR do que o número que você digitou.");
                Console.WriteLine($"Você tem {tentativas - 1 - i} tentativas restantes. Tente novamente.");
                Console.WriteLine("");
            }

        }

    }

    if (acertou == false)
    {
        Console.WriteLine($"Suas tentativas acabaram. O número sorteado era {numeroSorteado}.");
        verifica = jogarDeNovo();
    }
    else
    {
        Console.WriteLine($"O número sorteado era {numeroSorteado}.");
        verifica = jogarDeNovo();
    }


}

Console.WriteLine("Obrigado por jogar! Até a próxima.");



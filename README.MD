# 🎮 Jogo de Adivinhação em C#

## 📌 Descrição

Este projeto é um **jogo de adivinhação desenvolvido em C# para execução
no console**. O objetivo do jogo é adivinhar um número aleatório gerado
pelo sistema dentro de um intervalo definido pela dificuldade escolhida.

O jogador possui um número limitado de tentativas e recebe dicas sobre o
número sorteado, como:

-   Se o número correto é **maior ou menor** que o digitado
-   **Proximidade** do número correto
-   Uma **dica única** informando se o número é **par ou ímpar**

Além disso, o jogo possui um **sistema de pontuação** e um **ranking
persistente**, que salva os melhores jogadores em um arquivo JSON.

------------------------------------------------------------------------

# 🧩 Funcionalidades

-   🎯 Sistema de adivinhação de número
-   🎚️ 3 níveis de dificuldade
-   💡 Dica única durante o jogo (par ou ímpar)
-   📉 Sistema de pontuação baseado na proximidade
-   🏆 Ranking Top 5
-   💾 Persistência de dados em JSON
-   🔁 Opção de jogar novamente

------------------------------------------------------------------------

# 🎮 Níveis de Dificuldade

  Dificuldade   Intervalo do Número   Tentativas
  ------------- --------------------- ------------
  Fácil         1 a 10                10
  Médio         1 a 50                5
  Difícil       1 a 100               3

⚠️ Apenas no modo **Difícil** o jogador pode entrar no **ranking**.

------------------------------------------------------------------------

# 🏆 Sistema de Pontuação

O jogador começa com **1000 pontos**.

A cada tentativa incorreta, pontos são descontados com base na
**distância entre o número digitado e o número sorteado**.

  Diferença   Penalidade
  ----------- -------------
  ≥ 10        -100 pontos
  ≥ 5         -50 pontos
  ≥ 1         -20 pontos

Quanto **mais próximo do número correto**, **menor a penalidade**.

------------------------------------------------------------------------

# 💡 Sistema de Dicas

O jogador pode solicitar **apenas uma dica por partida** digitando:

    D

A dica informa se o número sorteado é:

-   **PAR**
-   **ÍMPAR**

Após utilizar a dica, ela não pode ser usada novamente na mesma partida.

------------------------------------------------------------------------

# 📊 Sistema de Ranking

O ranking armazena os jogadores que jogaram no modo **Difícil**.

Ele exibe:

-   Top 5 melhores pontuações
-   Nome do jogador
-   Pontuação final

Os dados são salvos no arquivo:

    ranking.json

Exemplo:

``` json
[
  {
    "Nome": "João",
    "pontuacao": 850
  },
  {
    "Nome": "Maria",
    "pontuacao": 920
  }
]
```

------------------------------------------------------------------------

# 📂 Estrutura do Código

## Classe Program

A classe principal contém toda a lógica do jogo.

### Main()

Responsável por:

-   Inicializar o jogo
-   Controlar o fluxo de execução
-   Escolher dificuldade
-   Gerar número aleatório
-   Processar tentativas
-   Calcular pontuação
-   Gerenciar ranking

------------------------------------------------------------------------

# 🔧 Métodos

### jogarDeNovo()

Pergunta ao jogador se deseja iniciar uma nova partida.

Entrada:

-   `s` → sim
-   `n` → não

Retorno:

-   `true` → continuar jogando
-   `false` → encerrar

------------------------------------------------------------------------

### pontuacao()

Calcula a nova pontuação com base na diferença entre o número digitado e
o número sorteado.

Parâmetros:

-   pontuacaoJogador
-   numeroSorteado
-   numeroJogador

------------------------------------------------------------------------

### verificaProximidade()

Indica o quão próximo o jogador está do número correto.

  Diferença   Retorno
  ----------- -------------
  ≥ 20        Muito Longe
  ≥ 10        Longe
  ≥ 5         Perto
  \< 5        Muito Perto

------------------------------------------------------------------------

### mostrarRanking()

Exibe o **Top 5 jogadores com maior pontuação**.

------------------------------------------------------------------------

### salvarRanking()

Salva os dados do ranking no arquivo:

    ranking.json

Utiliza **System.Text.Json**.

------------------------------------------------------------------------

### lerRanking()

Carrega os dados do arquivo `ranking.json` para a lista de jogadores.

Se o arquivo não existir, retorna uma lista vazia.

------------------------------------------------------------------------

# ▶️ Como Executar

1.  Instale o .NET SDK\
    https://dotnet.microsoft.com/

2.  Compile o projeto:

```{=html}
<!-- -->
```
    dotnet build

3.  Execute:

```{=html}
<!-- -->
```
    dotnet run

------------------------------------------------------------------------

# 🔮 Possíveis Melhorias

Algumas melhorias possíveis:

-   Interface gráfica
-   Estatísticas de partidas
-   Multiplayer
-   Sistema de conquistas
-   Ranking online
-   Banco de dados

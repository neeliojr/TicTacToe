using System;

namespace TicTacToe
{
    public class Posicao
    {
        public bool ocupado = false;
        public string ocupante;
    }

    public class Jogo
    {
        static void Main()
        {
            int vsComputer, escolhaPlayer;
            string player = "X", computador = "O";
            int[] placar = {0,0};

            // perguntando se o jogador deseja jogar contra o computador.
            Console.WriteLine("Deseja jogar contra o computador?");
            Console.WriteLine("[0] Não\n[1] Sim");
            vsComputer = Convert.ToInt32(Console.ReadLine());

            // perguntando se o jogador quer ser X ou O.
            if (vsComputer == 1)
            {
                Console.WriteLine("Você deja jogar com:");
                Console.WriteLine("[0] X\n[1] O");
                escolhaPlayer = Convert.ToInt32(Console.ReadLine());

                if (escolhaPlayer == 1)
                {
                    player = "O";
                    computador = "X";
                }

            }

            // coração do jogo.
            while (true)
            {
                int jogada = 10, ocupados = 0;
                bool gameEnd = false;
                string vez = player, win = "";

                Random sorteador = new Random();

                // criando as posições.
                Posicao[] posicao = new Posicao[9];

                for (int i = 0; i < posicao.Length; i++)
                {
                    posicao[i] = new Posicao();
                    posicao[i].ocupante = Convert.ToString(i + 1);
                }

                while (!gameEnd)
                {

                    Tabuleiro:
                    Console.Clear();
                    // grando o tabuleiro.
                    Console.WriteLine("  X ({0}) - O ({1})", placar[0], placar[1]);
                    Console.WriteLine("    Vez do: {0}\n", vez);
                    Console.WriteLine("     |     |     ");
                    Console.WriteLine("  {0}  |  {1}  |  {2}  ", posicao[0].ocupante, posicao[1].ocupante, posicao[2].ocupante);
                    Console.WriteLine("_____|_____|_____");
                    Console.WriteLine("     |     |     ");
                    Console.WriteLine("  {0}  |  {1}  |  {2}  ", posicao[3].ocupante, posicao[4].ocupante, posicao[5].ocupante);
                    Console.WriteLine("_____|_____|_____");
                    Console.WriteLine("     |     |     ");
                    Console.WriteLine("  {0}  |  {1}  |  {2}  ", posicao[6].ocupante, posicao[7].ocupante, posicao[8].ocupante);
                    Console.WriteLine("     |     |     ");

                    // escolha do jogador.
                    if (!gameEnd && vez == player || !gameEnd && vsComputer == 0 && vez == "O")
                    {
                        Console.WriteLine("\nQual posição você deseja jogar?");
                        jogada = Convert.ToInt32(Console.ReadLine()) - 1;
                    }
                    else
                    {
                        // caso a partida dê empate, printar isto.
                        if (win == "empate")
                        {
                            Console.WriteLine("EMPATE!");
                        }
                        // caso a partida não dê empate, printar isto.
                        else
                        {
                            if (win == "X")
                            {
                                placar[0] += 1;
                            }
                            else
                            {
                                placar[1] += 1;
                            }

                            Console.WriteLine("{0} venceu!", win);
                        }
                        Console.WriteLine("\nTecle ENTER para uma nova partida.");
                        Console.ReadLine();
                        break;
                    }

                    // conferindo se o local que o jogador escolheu está ocupado.
                    ConferirJogada:
                    if (posicao[jogada].ocupado == false)
                    {
                        posicao[jogada].ocupado = true;
                        posicao[jogada].ocupante = vez;

                        ocupados++;

                        // checando se alguem venceu.
                        if (posicao[0].ocupante == vez && posicao[1].ocupante == vez && posicao[2].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[3].ocupante == vez && posicao[4].ocupante == vez && posicao[5].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[6].ocupante == vez && posicao[7].ocupante == vez && posicao[8].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[0].ocupante == vez && posicao[3].ocupante == vez && posicao[6].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[1].ocupante == vez && posicao[4].ocupante == vez && posicao[7].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[2].ocupante == vez && posicao[5].ocupante == vez && posicao[8].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[0].ocupante == vez && posicao[4].ocupante == vez && posicao[8].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }
                        else if (posicao[2].ocupante == vez && posicao[4].ocupante == vez && posicao[6].ocupante == vez)
                        {
                            gameEnd = true;
                            win = vez;
                            goto Tabuleiro;
                        }

                        // trocando o jogador.
                        if (vez == "X")
                        {
                            vez = "O";
                        }
                        else
                        {
                            vez = "X";
                        }

                        // conferindo e marcando empate.
                        if (ocupados == 9)
                        {
                            gameEnd = true;
                            win = "empate";
                            goto Tabuleiro;
                        }
                    }

                    // jogada do computador.
                    if (vez == computador && vsComputer == 1)
                    {
                        jogada = sorteador.Next(0, 9);
                        while (posicao[jogada].ocupado == true)
                        {
                            jogada = sorteador.Next(0, 9);
                        }

                        goto ConferirJogada;
                    }


                }

            }
        }
    }
}
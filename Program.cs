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
            while (true)
            {
                int jogada, ocupados = 0;
                bool gameEnd = false;
                string vez = "X", win = "";

                jogada = 10;

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
                    if (!gameEnd && vez == "X")
                    {
                        Console.WriteLine("\nQual posição você deseja jogar?");
                        jogada = Convert.ToInt32(Console.ReadLine()) - 1;
                    }
                    else
                    {
                        if (win == "empate")
                        {
                            Console.WriteLine("EMPATE!");
                        }
                        else
                        {
                            Console.WriteLine("{0} venceu!", win);
                        }
                        Console.WriteLine("\nTecle ENTER para uma nova partida.");
                        Console.ReadLine();
                        break;
                    }

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
                        else
                        {
                            if (vez == "X")
                            {
                                vez = "O";
                            }
                            else
                            {
                                vez = "X";
                            }
                        }

                        if (ocupados == 9)
                        {
                            gameEnd = true;
                            win = "empate";
                            goto Tabuleiro;
                        }
                    }

                    if (vez == "O")
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
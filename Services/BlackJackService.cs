using BlackJackConsoleApplication.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlackJackConsoleApplication.Services
{
    internal class BlackJackService
    {
        private static int pontosPlayer = 0;
        private static int pontosDealer = 0;

        public static void menu()
        {
            bool jogando = true;
            while (jogando)
            {
                Console.WriteLine("======== BlackJack ========");
                Console.WriteLine("1 - Jogar");
                Console.WriteLine("2 - Sair");
                Console.WriteLine($"Pontos do Player: {pontosPlayer} | Pontos do Dealer: {pontosDealer}");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            if (iniciar())
                            {
                                pontosPlayer++;
                            }
                            else
                            {
                                pontosDealer++;
                            }
                            break;
                        case 2:
                            jogando = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                }
            }
        }

        private static bool iniciar()
        {
            BlackJack blackJack = new BlackJack();
            bool jogando = true;
            int pontoPlayer = 0;
            int pontoDealer = 0;
            while (jogando)
            {
                if (pontoDealer < 17)
                {
                    int cartaPlayer = blackJack.sortear();
                    int cartaDealer = blackJack.sortear();
                    if (cartaPlayer > 10)
                    {
                        pontoPlayer += 10;
                    }
                    else
                    {
                        pontoPlayer += cartaPlayer;
                    }
                    if (cartaDealer > 10)
                    {
                        pontoDealer += 10;
                    }
                    else
                    {
                        pontoDealer += cartaDealer;
                    }
                    Console.WriteLine($"\nCarta do Dealer:\n{BlackJack.carta(cartaDealer)} \nTotal: {pontoDealer}\n");
                    Console.WriteLine($"Sua carta:\n{BlackJack.carta(cartaPlayer)} \nTotal: {pontoPlayer}\n");
                    Console.WriteLine("Deseja continuar? (s/n)");
                    string continuar = Console.ReadLine();
                    if (continuar.ToLower() != "s")
                    {
                        if (pontoDealer < 17)
                        {
                            while (pontoDealer < 17)
                            {
                                int cartaDealerExtra = blackJack.sortear();
                                if (cartaDealerExtra > 10)
                                {
                                    pontoDealer += 10;
                                }
                                else
                                {
                                    pontoDealer += cartaDealerExtra;
                                }
                                Console.WriteLine($"\nCarta extra do Dealer:\n{BlackJack.carta(cartaDealerExtra)} \nTotal: {pontoDealer}\n");
                            }
                        }
                        jogando = false;
                    }
                }
                else 
                {
                    int cartaPlayer = blackJack.sortear();
                    if (cartaPlayer > 10)
                    {
                        pontoPlayer += 10;
                    }
                    else
                    {
                        pontoPlayer += cartaPlayer;
                    }
                    Console.WriteLine($"Total do Dealer: {pontoDealer}\n");
                    Console.WriteLine($"Sua carta:\n{BlackJack.carta(cartaPlayer)} \nTotal: {pontoPlayer}\n");
                    Console.WriteLine("Deseja continuar? (s/n)");
                    string continuar = Console.ReadLine();
                    if (continuar.ToLower() != "s")
                    {
                        jogando = false;
                    }
                }
            }
            if(pontoPlayer > 21)
            {
                Console.WriteLine("Você estourou! Dealer vence.\n");
                return false;
            }
            else if (pontoDealer > 21)
            {
                Console.WriteLine("Dealer estourou! Você vence.\n");
                return true;
            }
            else if (pontoPlayer > pontoDealer)
            {
                Console.WriteLine("Você venceu!\n");
                return true;
            }
            else if (pontoDealer > pontoPlayer)
            {
                Console.WriteLine("Dealer venceu!\n");
                return false;
            }
            else
            {
                Console.WriteLine("Empate!\n");
                pontosDealer--;
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackConsoleApplication.Models
{
    internal class BlackJack
    {
        public int cartaPlayer { get; set; }
        public int cartasDealer { get; set; }

        public static string carta(int valor)
        {
            
            string valorCarta;
            switch (valor)
            {
                case 1:
                    valorCarta = "A";
                    break;
                case 11:
                    valorCarta = "J";
                    break;
                case 12:
                    valorCarta = "Q";
                    break;
                case 13:
                    valorCarta = "K";
                    break;
                default:
                    valorCarta = valor.ToString();
                    break;
            }
            string padrao = "---\n " + valorCarta + " \n---";
            return padrao;
        }

        public int sortear()
        {
            Random random = new Random();
            return random.Next(1, 14);
        }
    }
}

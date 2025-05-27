using System;
using System.Collections.Generic;

namespace Jogo_da_forca
{
    class Program
    {
        static void Main(string[] args)
        {
            int tentativas = 6;
            string[] palavras = new string[6] { "MEDICO", "PROFESSOR", "BANCARIO", "MINERADOR", "BOMBEIRO", "POLICIA" };
            Random rand = new Random();
            string palavraa = palavras[rand.Next(palavras.Length)].ToUpper();

            List<char> letrac = new List<char>();
            List<char> letrae = new List<char>();

            while (tentativas > 0)
            {
                Console.Clear();
                Console.WriteLine("### JOGO DA FORCA ###");
                Console.WriteLine();
                Console.WriteLine("DICA: PROFISSÃO");

                foreach (char letra in palavraa)
                {
                    if (letrac.Contains(letra))
                        Console.Write(letra + " ");
                    else
                        Console.Write("_ ");
                }

                Console.WriteLine();
                Console.Write("LETRA ERRADA: ");
                foreach (char c in letrae)
                    Console.Write(c + " ");
                Console.WriteLine();

                Console.WriteLine($"VIDAS RESTANTES: {tentativas}");
                Console.Write("DIGITE UMA LETRA: ");

                string entrada = Console.ReadLine().ToUpper();
                char tentativaa = entrada[0];

                Console.WriteLine();

                if (letrac.Contains(tentativaa) || letrae.Contains(tentativaa))
                {
                    Console.WriteLine("ESSA LETRA JA FOI, ANIMAL");
                    Console.ReadKey();
                    continue;
                }

                if (palavraa.Contains(tentativaa))
                {
                    letrac.Add(tentativaa);
                }
                else
                {
                    letrae.Add(tentativaa);
                    tentativas--;
                }

                bool venceu = true;
                foreach (char letra in palavraa)
                {
                    if (!letrac.Contains(letra))
                    {
                        venceu = false;
                        break;
                    }
                }

                if (venceu)
                {
                    Console.Clear();
                    Console.WriteLine("VOCÊ ACERTOU A PALAVRA, NÃO FEZ MAIS QUE SUA OBRIGAÇÃO");
                    Console.WriteLine($"A PALAVRA ERA: {palavraa}");
                    break;
                }

                if (tentativas == 0)
                {
                    Console.Clear();
                    Console.WriteLine("PERDEU ZÉ MANÉ");
                    Console.WriteLine($"A PALAVRA ERA: {palavraa}");
                }
            }
        }
    }
}

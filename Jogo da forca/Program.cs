using System;
using System.Collections.Generic;

namespace JogoDaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            int tentativas = 6;
            string[] palavras = new string[6] { "MEDICO", "PROFESSOR", "BANCARIO", "MINERADOR", "BOMBEIRO", "POLICIA" };
            Random random = new Random();
            string palavraescolhida = palavras[random.Next(palavras.Length)].ToUpper();

            List<char> letracerta = new List<char>();
            List<char> letraerrada = new List<char>();

            while (tentativas > 0)
            {
                Console.Clear();
                Console.WriteLine("### JOGO DA FORCA ###");
                Console.WriteLine();
                Console.WriteLine("DICA: PROFISSÃO");

                foreach (char letra in palavraescolhida)
                {
                    if (letracerta.Contains(letra))
                        Console.Write(letra + " ");
                    else
                        Console.Write("_ ");
                }

                Console.WriteLine();
                Console.Write("LETRA(S) ERRADA(S): ");
                foreach (char c in letraerrada)
                    Console.Write(c + " ");
                Console.WriteLine();

                Console.WriteLine($"VIDA(S) RESTANTE(S): {tentativas}");
                Console.Write("DIGITE UMA LETRA: ");

                string entrada = Console.ReadLine().ToUpper();
                char tentativarestante = entrada[0];

                Console.WriteLine();

                if (letracerta.Contains(tentativarestante) || letraerrada.Contains(tentativarestante))
                {
                    Console.WriteLine("ESSA LETRA JA FUI UTILIZADA, TENTE OUTRA!");
                    Console.ReadKey();
                    continue;
                }

                if (palavraescolhida.Contains(tentativarestante))
                {
                    letracerta.Add(tentativarestante);
                }
                else
                {
                    letraerrada.Add(tentativarestante);
                    tentativas--;
                }

                bool Venceu = true;
                foreach (char Letra in palavraescolhida)
                {
                    if (!letracerta.Contains(Letra))
                    {
                        Venceu = false;
                        break;
                    }
                }

                if (Venceu)
                {
                    Console.Clear();
                    Console.WriteLine("VOCÊ ACERTOU A PALAVRA, PARABÉNS!!!");
                    Console.WriteLine($"A PALAVRA ERA: {palavraescolhida}");
                    break;
                }

                if (tentativas == 0)
                {
                    Console.Clear();
                    Console.WriteLine("VOCÊ PERDEU!!!");
                    Console.WriteLine($"A PALAVRA ERA: {palavraescolhida}");
                }   

            }
            Console.WriteLine("APERTE QUALQUER TECLA PARA ENCERRAR O PROGRAMA");
            Console.ReadKey();
        }
    }
}

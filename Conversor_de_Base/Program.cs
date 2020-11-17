//importação das bibliotecas
using System;
using System.Linq;
using System.Threading;

namespace ConversorDeBases  
{
    class Program //inicio do programa
    {
        static void Main(string[] args)
        {
            char d;
            while (true) //um repedidor para poder sempre repetir o programa
            {
                try 
                {
                    Console.Clear(); //limpa o console

                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("Conversor de bases");
                    Console.WriteLine();
                    Console.Write("Informe o número na base decimal: ");
                    uint num = uint.Parse(Console.ReadLine()); // recebe o numero em base decimal

                    Console.WriteLine();
                    Console.WriteLine("Convertendo...");
                    Thread.Sleep(500);
                    Console.WriteLine($"Binário: {Binario(num)}"); //Escreve o numero em binario
                    Console.WriteLine($"Octal: {Octal(num)}"); //Escreve o numero em octal
                    Console.WriteLine($"Hexadecimal: {Hexadecimal(num)}"); //Escreve o numero em hexadecimal

                    Console.WriteLine();
                    do
                    {
                        Console.Write("Deseja realizar mais uma conversão (s/n)? "); //pergunta se deseja reiniciar o programa
                        d = Console.ReadLine().ToLower()[0];
                    } while (d != 's' && d != 'n');

                    if (d == 'n')
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.Write("O valor informado está em um formato incorreto!");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Obrigado por usar o Conversor de Base.");
            Console.ReadKey();
        }

        static string Binario(uint valor) //função que converte para binario
        {
            string novoValor = "";

            do
            {
                novoValor += (valor % 2).ToString();
                valor /= 2;
            } while (valor >= 1);
            return Reverter(novoValor);
        }

        static string Reverter(string valor)
        {
            string novoValor = "";

            for (int i = valor.Length - 1; i >= 0; i--)
            {
                novoValor += valor[i];
            }
            return novoValor;
        }

        static string Octal(uint valor) //função que converte para octal
        {
            string novoValor = "";

            do
            {
                novoValor += (valor % 8).ToString();
                valor /= 8;
            } while (valor >= 1);
            return Reverter(novoValor);
        }

        static string Hexadecimal(uint valor) //função que converte para hexadecimal
        {
            string novoValor = "";

            do
            {
                novoValor += (valor % 16) switch //definição da tabela de hexa
                {
                    10 => "A",
                    11 => "B",
                    12 => "C",
                    13 => "D",
                    14 => "E",
                    15 => "F",
                    _ => (valor % 16).ToString(),
                };
                valor /= 16;
            } while (valor >= 1);
            return Reverter(novoValor);
        }
    }
}
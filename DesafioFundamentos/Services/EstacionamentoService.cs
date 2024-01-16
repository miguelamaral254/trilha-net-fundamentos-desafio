using System;

namespace DesafioFundamentos.Services
{
    public class EstacionamentoService
    {
        public decimal ObterPrecoInicial()
        {
            decimal precoInicial = 0;

            while (true)
            {
                Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
                Console.WriteLine("Digite o preço inicial:");

                if (decimal.TryParse(Console.ReadLine(), out precoInicial))
                {
                    return precoInicial;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Digite um número válido.");
                }
            }
        }

        public decimal ObterPrecoPorHora()
        {
            decimal precoPorHora = 0;

            while (true)
            {
                Console.WriteLine("Agora digite o preço por hora:");

                if (decimal.TryParse(Console.ReadLine(), out precoPorHora))
                {
                    return precoPorHora;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Digite um número válido.");
                }
            }
        }
    }
}

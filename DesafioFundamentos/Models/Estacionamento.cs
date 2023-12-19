using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private string FormatarPlaca(string placa)
        {
            
            string placaLimpa = placa.Replace(" ", "").ToUpper();

            return placaLimpa;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar [LLL - NLNN]:");
            string placa = Console.ReadLine();

            // Formata a placa
            placa = FormatarPlaca(placa);

            // Adiciona a placa à lista de veículos
            veiculos.Add(placa);

            Console.WriteLine($"Veículo com placa {placa} foi estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {veiculos[i]}");
                }

                Console.WriteLine("Digite o número do veículo que deseja remover:");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    if (opcao > 0 && opcao <= veiculos.Count)
                    {
                        string placa = veiculos[opcao - 1];

                        int horas;

                        Console.WriteLine($"Digite a quantidade de horas que o veículo {placa} permaneceu estacionado:");

                        if (int.TryParse(Console.ReadLine(), out horas))
                        {
                            decimal valorTotal = precoInicial + (precoPorHora * horas);

                            veiculos.Remove(placa);

                            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        }
                        else
                        {
                            Console.WriteLine("Por favor, digite um valor válido para as horas.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, digite o número correspondente ao veículo que deseja remover.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("---------[Veículos]---------");

            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - [{veiculos[i]}]");
            }

            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

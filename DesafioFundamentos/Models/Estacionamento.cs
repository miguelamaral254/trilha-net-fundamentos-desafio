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

            // Verifica se a placa tem a formatação correta (LLLNLNN)
            if (placaLimpa.Length == 7 &&
                char.IsLetter(placaLimpa[0]) && char.IsLetter(placaLimpa[1]) && char.IsLetter(placaLimpa[2]) &&
                char.IsDigit(placaLimpa[3]) && char.IsLetter(placaLimpa[4]) && char.IsDigit(placaLimpa[5]) && 
                char.IsDigit(placaLimpa[6]))
            {
                // Formata a placa com a máscara (LLL - NLNN)
                return $"{placaLimpa.Substring(0, 3)} - {placaLimpa.Substring(3)}";
            }
            else
            {
                Console.WriteLine("Placa inválida. A placa deve seguir o padrão LLLNLNN.");
                return null;
            }
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (LLLNLNN):");
            string placa = Console.ReadLine();

            // Formata a placa
            string placaFormatada = FormatarPlaca(placa);

            if (placaFormatada != null)
            {
                // Adiciona a placa à lista de veículos
                veiculos.Add(placaFormatada);

                Console.WriteLine($"Veículo com placa {placaFormatada} foi estacionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Por favor, tente novamente.");
            }
        }
        public void RemoverVeiculo()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos estacionados:");

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - [{veiculos[i]}]");
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

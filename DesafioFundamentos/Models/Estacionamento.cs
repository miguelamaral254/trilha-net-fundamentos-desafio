using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial)
        {
            this.precoInicial = precoInicial;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (LLLNLNN):");
            string placa = Console.ReadLine();

            Veiculo veiculo = CriarVeiculo(placa);

            if (veiculo != null)
            {
                veiculos.Add(veiculo);
                Console.WriteLine($"Veículo com placa {veiculo.Placa} foi estacionado com sucesso!");
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
                Console.WriteLine("----[ Veículos estacionados ]----");

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - [{veiculos[i].Placa}]");
                }
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Digite o número do veículo que deseja remover:");
                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    if (opcao > 0 && opcao <= veiculos.Count)
                    {
                        Veiculo veiculoRemover = veiculos[opcao - 1];
                        RemoverVeiculoEObterPreco(veiculoRemover);
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

        private void RemoverVeiculoEObterPreco(Veiculo veiculo)
        {
            int horas;

            Console.WriteLine($"Digite a quantidade de horas que o veículo {veiculo.Placa} permaneceu estacionado:");

            if (int.TryParse(Console.ReadLine(), out horas))
            {
                decimal valorTotal = precoInicial + veiculo.CalcularPrecoEstacionamento(horas);

                veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Por favor, digite um valor válido para as horas.");
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("---------[Veículos]---------");

            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - [{veiculos[i].Placa}]");
            }

            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private Veiculo CriarVeiculo(string placa)
        {
            placa = FormatarPlaca(placa);

            if (placa != null)
            {
                
                return new Carro(placa);
            }
            else
            {
                return null;
            }
        }

        private string FormatarPlaca(string placa)
        {
            string placaLimpa = placa.Replace(" ", "").ToUpper();

            
            if (placaLimpa.Length == 7 &&
                char.IsLetter(placaLimpa[0]) && char.IsLetter(placaLimpa[1]) && char.IsLetter(placaLimpa[2]) &&
                char.IsDigit(placaLimpa[3]) && char.IsLetter(placaLimpa[4]) && char.IsDigit(placaLimpa[5]) &&
                char.IsDigit(placaLimpa[6]))
            {
                // Formata a placa com a máscara padrão mercosul (LLL - NLNN)
                return $"{placaLimpa.Substring(0, 3)} - {placaLimpa.Substring(3)}";
            }
            else
            {
                Console.WriteLine("Placa inválida. A placa deve seguir o padrão LLLNLNN.");
                return null;
            }
        }
    }
}

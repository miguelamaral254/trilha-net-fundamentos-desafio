using DesafioFundamentos.Models;
using DesafioFundamentos.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

EstacionamentoService estacionamentoService = new EstacionamentoService();

decimal precoInicial = estacionamentoService.ObterPrecoInicial();
decimal precoPorHora = estacionamentoService.ObterPrecoPorHora();

Estacionamento estacionamento = new Estacionamento(precoInicial);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            estacionamento.AdicionarVeiculo();
            break;

        case "2":
            estacionamento.RemoverVeiculo();
            break;

        case "3":
            estacionamento.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");

namespace DesafioFundamentos.Models
{
    public abstract class Veiculo
    {
        public string Placa { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public abstract decimal CalcularPrecoEstacionamento(int horas);
    }
}

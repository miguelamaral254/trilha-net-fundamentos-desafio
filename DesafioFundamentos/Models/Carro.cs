namespace DesafioFundamentos.Models
{
    public class Carro : Veiculo
    {
        public Carro(string placa) : base(placa) { }

        public override decimal CalcularPrecoEstacionamento(int horas)
        {
          
            return horas * 5; 
    }
}
}

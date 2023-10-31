namespace Estacionamento.Testes;

public class PatioTestes : IDisposable
{

    private Veiculo veiculo;
    private Patio estacionamento;
    private Operador operador;
    public ITestOutputHelper SaidaConsoleTeste { get; }

    //construtor
    public PatioTestes(ITestOutputHelper saidaConsoleTeste) {

      SaidaConsoleTeste = saidaConsoleTeste;
      SaidaConsoleTeste.WriteLine("Isso é uma mensagem de teste :)");
      veiculo = new Veiculo();
      estacionamento = new Patio();
      operador = new Operador();
      operador.Nome = "Pedro Fagundes";
    }

    [Fact]
    public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
    {
      estacionamento.OperadorPatio = operador;
      veiculo.Proprietario = "Kathelyn Gaioni";
      veiculo.Tipo = TipoDeVeiculo.Automovel;
      veiculo.Cor = "Azul";
      veiculo.Modelo = "Fusca";
      veiculo.Placa = "KOH-1234";

      estacionamento.RegistrarEntradaVeiculo(veiculo);
      estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

      //Act
      double Faturamento = estacionamento.TotalFaturado();

      //Assert
      Assert.Equal(2, Faturamento);

    }

    [Theory]
    [InlineData("Kathelyn Gaioni","KOH-1234", "Azul", "Fusca")]
    [InlineData("Jose Silva","POT-9242", "Cinza", "Fusca")]
    [InlineData("Maria Silva","GDR-6524", "Azul", "Opala")]
    public void ValidaFaturamentoComVariosVeiculos (string proprietario,
                                                    string placa,
                                                    string cor,
                                                    string modelo) 
    {
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;

        estacionamento.OperadorPatio = operador;
        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        double Faturamento = estacionamento.TotalFaturado();

        estacionamento.MostrarFaturamento();
        Assert.Equal(2, Faturamento); //será o faturamento de cada veiculo
        
    }

    [Theory]
    [InlineData("Kathelyn Gaioni","KOH-1234", "Azul", "Fusca")]
    public void LocalizaVeiculoNoPatioComBaseNoTicket( string proprietario,
                                        string placa,
                                        string cor,
                                        string modelo) 
    {
        estacionamento.OperadorPatio = operador;
        veiculo.Proprietario = proprietario;
        veiculo.Placa = placa;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;

        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var consultado = estacionamento.PesquisaVeiculoNoPatio(veiculo.IdTicket);

        Assert.Contains("### TICKET ESTACIONAMENTO ###", consultado.Ticket);
    }

    [Fact]
    public void AlterarDadosDoVeiculoDoProprioVeiculo()
    {
      estacionamento.OperadorPatio = operador;
      veiculo.Proprietario = "Kathelyn Gaioni";
      veiculo.Tipo = TipoDeVeiculo.Automovel;
      veiculo.Cor = "Azul";
      veiculo.Modelo = "Fusca";
      veiculo.Placa = "KOH-1234";

      estacionamento.RegistrarEntradaVeiculo(veiculo);

      var veiculoAlterado = new Veiculo();
      veiculoAlterado.Proprietario = "Kathelyn Gaioni";
      veiculoAlterado.Cor = "Azul";
      veiculoAlterado.Modelo = "Opala";
      veiculoAlterado.Placa = "KOH-1234"; //Alterado

      Veiculo alterado = estacionamento.AlterarDadosDoVeiculo(veiculoAlterado);

      Assert.Equal(alterado.Placa, veiculoAlterado.Placa);

    }

    public void Dispose()
    {
      SaidaConsoleTeste.WriteLine("Dispose :)");
    }
}
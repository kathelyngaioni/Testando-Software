namespace Estacionamento.Testes;

/* Padrão AAA
Arrange -> organizar
Act -> agir
Assert -> afirmar
*/

/* 
    Uso do ITestOutputHelper seria para printar mensagens na tela dos testes
*/

public class VeiculoTestes : IDisposable
{

    private Veiculo veiculo;
    public ITestOutputHelper SaidaConsoleTeste { get; }


    //construtor com saida no console
    public VeiculoTestes(ITestOutputHelper saidaConsoleTeste )
    {
        SaidaConsoleTeste = saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Isso é uma mensagem de teste :)");
        veiculo = new Veiculo();
    }
    
    [Fact]
    public void TestaVeiculoAcelerarComParâmetro10()
    {
        //Arrange
        //var veiculo = new Veiculo();

        //Act
        veiculo.Acelerar(10);

        //Assert
        Assert.Equal(100,veiculo.VelocidadeAtual); //resultado esperado
    }

    //O DisplayName vai ser o nome que vai aparecer
    [Fact(DisplayName = "Teste número 2")]
    public void TestaVeiculoFrear()
    {
        //var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150,veiculo.VelocidadeAtual); //resultado esperado
    }

    //teste que pode ser ignorado
    [Fact(Skip = "Teste ainda não implementado. Ignorar este teste")]
    public void ValidaNomeDoProprietario() {
        //implementar
    }

    
    [Fact]
    public void DadosVeiculo() {

        Veiculo veiculo = new Veiculo();
        veiculo.Proprietario = "Kathelyn Gaioni";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Azul";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "KOH-1234";

        string dados = veiculo.ToString();

        Assert.Contains("Ficha do Veiculo:", dados);

    }

    public void Dispose()
    {
      SaidaConsoleTeste.WriteLine("Dispose :)");
    }

}
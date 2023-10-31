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
        veiculo.Tipo = TipoDeVeiculo.Automovel;
        veiculo.Cor = "Azul";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "KOH-1234";

        string dados = veiculo.ToString();

        Assert.Contains("Ficha do Veiculo:", dados);

    }

    [Fact]
    public void TestaNomeProprietarioComMenosDeTresCaracteres() 
    {
        //Arrange
        string nomeDoProprietario= "AB";

        //Assert
        Assert.Throws<FormatException>(
            //Act
            () => new Veiculo(nomeDoProprietario)
        );
    }

    [Fact]
    public void TestaMensagemDeExcecaoDosCaracteresDaPlaca()
    {
        string placa = "ASDK-1234";
        var mensagem = Assert.Throws<FormatException>(
            () => new Veiculo().Placa = placa
        );

        Assert.Equal("A placa deve possuir 8 caracteres",mensagem.Message);
    }

    public void Dispose()
    {
      SaidaConsoleTeste.WriteLine("Dispose :)");
    }

}
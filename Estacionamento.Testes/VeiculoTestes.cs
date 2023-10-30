namespace Estacionamento.Testes;

/* Padrão AAA
Arrange -> organizar
Act -> agir
Assert -> afirmar
*/

public class VeiculoTestes
{
    /* [Trait] funciona como chave e valor
        Serve para agrupar os testes.
    */

    [Fact]
    [Trait("Funcionalidade","Acelerar")]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Acelerar(10);

        //Assert
        Assert.Equal(100,veiculo.VelocidadeAtual); //resultado esperado
    }


    [Fact(DisplayName = "Teste número 2")]
    [Trait("Funcionalidade","Frear")]
    public void TestaVeiculoFrear()
    {
        var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150,veiculo.VelocidadeAtual); //resultado esperado
    }

    //teste que pode ser ignorado
    [Fact(Skip = "Teste ainda não implementado. Ignorar este teste")]
    public void ValidaNomeDoProprietario() {
        //implementar
    }
}
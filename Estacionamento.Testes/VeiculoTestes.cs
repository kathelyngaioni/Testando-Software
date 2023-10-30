namespace Estacionamento.Testes;

/* Padrão AAA
Arrange -> organizar
Act -> agir
Assert -> afirmar
*/

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Acelerar(10);

        //Assert
        Assert.Equal(100,veiculo.VelocidadeAtual); //resultado esperado
    }

    [Fact]
    public void TestaVeiculoFrear()
    {
        var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150,veiculo.VelocidadeAtual); //resultado esperado
    }
}
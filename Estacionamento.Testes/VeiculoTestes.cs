namespace Estacionamento.Testes;

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        var veiculo = new Veiculo();
        veiculo.Acelerar(10);
        Assert.Equal(100,veiculo.VelocidadeAtual); //resultado esperado
    }
}
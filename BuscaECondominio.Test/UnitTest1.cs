using Xunit;
using BuscaECondominio.Lib.Models;

namespace BuscaECondominio.Test;

public class UnitTest1
{
    [Fact]
    public void TestarSetIdDaClaseModelBase()//Método
    {
        //Arrange
        var valorEsperadoUsuario = 1;
        var usuario = UsuarioEsperado();
        //Act
        usuario.SetId(valorEsperadoUsuario);
        //Assert
        Assert.Equal(valorEsperadoUsuario, usuario.Id);
    }    
}
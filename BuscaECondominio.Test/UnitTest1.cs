using Xunit;
using BuscaECondominio.Lib.Models;


namespace BuscaECondominio.Test;

public class UnitTest1
{
    [Fact]
    public void TestarSetIdDaClaseModelBase()//Método
    {
        //Arrange
        // var valorEsperadoUsuario = 1;
        // var usuario = CriarUsuarioTest();
        // //Act
        // usuario.SetId(valorEsperadoUsuario);
        // //Assert
        // Assert.Equal(valorEsperadoUsuario, usuario.Id);
    }

     [Fact]
    public void TestarSetNomeDaClasseUsuario()
    {
        var valorEsperadoUsuario = "Sidney";
        var usuario = CriarUsuarioTest();

        usuario.SetNome(valorEsperadoUsuario);

        Assert.Equal(valorEsperadoUsuario, usuario.Nome);
    }
    [Fact]
    public void TestarSetCpfDaClasseUsuario()
    {
        var valorEsperadoUsuario = "1234567899";
        var usuario = CriarUsuarioTest();

        usuario.SetCpf(valorEsperadoUsuario);

        Assert.Equal(valorEsperadoUsuario, usuario.Cpf);
    }

    [Fact]
    public void TestarSetDataNascimentoDaClasseUsuarioDeveSerMenorQueOAnoDe2010()
    {
        var valorEsperadoUsuario = DateTime.Parse("19/02/1985");
        var usuario = CriarUsuarioTest();

        usuario.SetDataNascimento(valorEsperadoUsuario);

        Assert.Equal(valorEsperadoUsuario, usuario.DataNascimento);
    }
    [Fact]
    public void TestarSetEmailDaClasseUsuarioDeveConterArroba()
    {
        var valorEsperadoUsuario = "email@email.com";
        var usuario = CriarUsuarioTest();

        usuario.SetEmail(valorEsperadoUsuario);

        Assert.Equal(valorEsperadoUsuario, usuario.Email);
    }
    [Fact]
    public void TestarSenhaDaClasseUsuarioDeveConterMaisDe8Caracteres()
    {
        var valorEsperadoUsuario = "bibi123456788";
        var usuario = CriarUsuarioTest();

        usuario.SetSenha(valorEsperadoUsuario);

        Assert.Equal(valorEsperadoUsuario, usuario.Senha);
    }
    
    public Usuario CriarUsuarioTest()
    {
        return new Usuario("Sidney", "1234567899", DateTime.Parse("19/02/1985"), "email@email.com", "bibi123456788", "marromemos", DateTime.Parse("28/07/2020"));
    }
}


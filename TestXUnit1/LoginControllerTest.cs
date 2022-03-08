using ChapterTest;
using ChapterTest.Controllers;
using ChapterTest.Interfaces;
using ChapterTest.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using Xunit;

namespace TestXUnit1
{
    public class LoginControllerTest
    {
        [Fact]
        public void FazerLoginTest()
        {
            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email123@gmail.com";
            dadosUsuario.senha = "123456";

            var controller = new LoginController(repositorioFalso.Object);

            //Act
            var resultado = controller.FazerLogin(dadosUsuario);

            //Assert

            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }

        [Fact]
        public void TestarRetornoUsuario()
        {
            //Arrange
            string issuerValidacao = "ChapterTest";

            Usuario usuarioFalso = new Usuario();
            usuarioFalso.Email = "email123@gmail.com";
            usuarioFalso.Senha = "123456";

            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioFalso);

            var controller = new LoginController(repositorioFalso.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email123@gmail.com";
            dadosUsuario.senha = "123456";

            //Act
            OkObjectResult resultado = (OkObjectResult)controller.FazerLogin(dadosUsuario);

            var token = resultado.Value.ToString().Split(' ')[3];

            var jstHandLer = new JwtSecurityTokenHandler();
            var jwtToken = jstHandLer.ReadJwtToken(token);


            //Assert
            Assert.Equal(issuerValidacao, jwtToken.Issuer);
            Assert.Equal(usuarioFalso.Email, dadosUsuario.email);
            Assert.Equal(usuarioFalso.Senha, dadosUsuario.senha);
        }
    }
    
}
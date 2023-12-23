using System;
using AutoMapper;
using DDD.Application.Services;
using DDD.Application.ViewModels;
using DDD.Domain.Interfaces;
using Moq;
using Xunit;

namespace DDD.Application.UnitTests.Services
{
    public class UsuarioAppServiceTests
    {
        [Fact]
        public void GetById()
        {
            // Arrange
            var usuario = new Domain.Models.Usuario(1, "Alan", "X", "alab@test.com", new DateTime(), 1);

            var customerRepositoryMock = new Mock<IUsuarioRepository>();
            customerRepositoryMock.Setup(x => x.GetById(usuario.Id ?? 0, false))
                .Returns(usuario);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<UsuarioViewModel>(usuario)).Returns(new UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataNascimento = usuario.DataNascimento,
            });

            // Act
            var sut = new UsuarioAppService(mapperMock.Object, customerRepositoryMock.Object, null, null);
            var result = sut.GetById(usuario.Id ?? 0);

            // Assert
            Assert.Equal(result.Id, usuario.Id);
            Assert.Equal(result.Nome, usuario.Nome);
            Assert.Equal(result.Email, usuario.Email);
            Assert.Equal(result.DataNascimento, usuario.DataNascimento);
        }
    }
}

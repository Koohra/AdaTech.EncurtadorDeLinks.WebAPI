using AdaTech.EncurtadorDeLinks.WebAPI.Models;
using AdaTech.EncurtadorDeLinks.WebAPI.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.EncurtadorLinks.Test
{
    public class EncurtadorLinksServicesTest
    {
        private readonly Mock<IRandomizer> _randomizerMock;
        private readonly EncurtadorLinksServices _service;

        public EncurtadorLinksServicesTest()
        {
            _randomizerMock = new Mock<IRandomizer>();
            _service = new EncurtadorLinksServices(_randomizerMock.Object);
        }

        [Theory]
        [InlineData(0, "AAAAAAA")]
        [InlineData(1, "BBBBBBB")]
        [InlineData(2, "CCCCCCC")]
        public void EncurtarLinks_DeveRetornarLinkComUrlCurta(int indice, string esperado)
        {
            // Arrange
            var link = new Link { UrlOriginal = "https://www.example.com" };
            _randomizerMock.Setup(r => r.Sortear(It.IsAny<int>())).Returns(indice);

            // Act
            var result = _service.EncurtarLinks(link);

            // Assert
            result.Should().NotBeNull();
            result.UrlCurta.Should().Be(esperado);

        }

        [Fact]
        public void ObterLinkOriginal_DeveRetornarUrlOriginal_QuandoLinkCurtoExiste()
        {
            // Arrange
            var link = new Link { UrlOriginal = "https://www.example.com" };
            _randomizerMock.Setup(r => r.Sortear(It.IsAny<int>())).Returns(0);
            var linkEncurtado = _service.EncurtarLinks(link);

            // Act
            var urlOriginal = _service.ObterLinkOriginal(linkEncurtado.UrlCurta);

            // Assert
            urlOriginal.Should().Be(link.UrlOriginal);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("ABC")]
        [InlineData("ABCD")]
        [InlineData("ABCDE")]
        [InlineData("ABCDEF")]
        public void ObterLinkOriginal_DeveLancarExcecao_QuandoLinkCurtoNaoExiste(string linkCurto)
        {

            // Act & Assert
            _service.Invoking(s => s.ObterLinkOriginal(linkCurto)).Should().ThrowExactly<KeyNotFoundException>();
        }
    }

}

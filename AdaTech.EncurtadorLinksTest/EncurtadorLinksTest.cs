using AdaTech.EncurtadorDeLinks.WebAPI.Models;
using AdaTech.EncurtadorDeLinks.WebAPI.Services;
using FluentAssertions;
using NSubstitute;


namespace AdaTech.EncurtadorLinks.Test
{
    public class EncurtadorLinksServicesTest
    {
        private readonly IRandomizer _randomizer;
        private readonly EncurtadorLinksServices _service;

        public EncurtadorLinksServicesTest()
        {
            _randomizer = Substitute.For<IRandomizer>();
            _service = new EncurtadorLinksServices(_randomizer);
        }

        [Theory]
        [InlineData(0, "AAAAAAA")]
        [InlineData(1, "BBBBBBB")]
        [InlineData(2, "CCCCCCC")]
        public void EncurtarLinks_DeveRetornarLinkComUrlCurta(int indice, string esperado)
        {
            // Arrange
            var link = new Link { Id = 1, UrlOriginal = "https://www.example.com" };
            _randomizer.Sortear(Arg.Any<int>()).Returns(indice);

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
            var link = new Link { Id = 1, UrlOriginal = "https://www.example.com" };
            _randomizer.Sortear(Arg.Any<int>()).Returns(0);
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

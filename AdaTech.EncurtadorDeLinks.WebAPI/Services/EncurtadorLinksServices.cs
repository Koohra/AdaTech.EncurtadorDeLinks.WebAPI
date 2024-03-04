using AdaTech.EncurtadorDeLinks.WebAPI.Models;

namespace AdaTech.EncurtadorDeLinks.WebAPI.Services
{

    public class EncurtadorLinksServices : IEncurtadorLinksService
    {
        private readonly Dictionary<string, string> _links = new Dictionary<string, string>();
        private readonly IRandomizer _randomizer;
        private const int NumeroDeCaracteresDoLinkEncurtado = 7;

        public EncurtadorLinksServices(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public Link EncurtarLinks(Link link)
        {
            var urlCurta = GeradorLinkCurto();
            _links.Add(urlCurta, link.UrlOriginal);

            var validade = DateTime.Today.AddDays(1).AddTicks(-1);

            return new Link
            {
                Id = link.Id,
                UrlOriginal = link.UrlOriginal,
                UrlCurta = urlCurta,
                Validade = validade
            };
        }

        public string ObterLinkOriginal(string linkCurto)
        {
            if (_links.TryGetValue(linkCurto, out var urlOriginal))
            {
                return urlOriginal;
            }
            throw new KeyNotFoundException($"O link {linkCurto} não foi encontrado");
        }

        private string GeradorLinkCurto()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, NumeroDeCaracteresDoLinkEncurtado)
                .Select(x => x[_randomizer.Sortear(x.Length)])
                .ToArray());
        }
    }
}

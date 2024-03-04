using AdaTech.EncurtadorDeLinks.WebAPI.Models;

namespace AdaTech.EncurtadorDeLinks.WebAPI.Services
{
    public interface IEncurtadorLinksService
    {
        Link EncurtarLinks(Link link);
        string ObterLinkOriginal(string linkCurto);
    }
}

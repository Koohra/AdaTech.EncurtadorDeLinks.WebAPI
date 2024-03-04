using AdaTech.EncurtadorDeLinks.WebAPI.Models;

namespace AdaTech.EncurtadorDeLinks.WebAPI.Repository
{
    public interface ILinkRepository
    {
        Link GetLink(string urlCurta);
        void AddLink(Link link);
    }
}

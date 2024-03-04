using AdaTech.EncurtadorDeLinks.WebAPI.Models;
using System.Net;

namespace AdaTech.EncurtadorDeLinks.WebAPI.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private readonly EncurtadorLinksContext _context;

        public LinkRepository(EncurtadorLinksContext context)
        {
            _context = context;
        }
        public Link GetLink(string urlCurta)
        {
            var link = _context.Links.FirstOrDefault(link => link.UrlCurta == urlCurta);

            if (link == null || link.Validade == null || DateTime.UtcNow > link.Validade)
            {
                return null;
            }
            return link;

        }

        public void AddLink(Link link)
        {
            link.UrlOriginal = WebUtility.UrlDecode(link.UrlOriginal);
            _context.Links.Add(link);
            _context.SaveChanges();
        }
    }
}

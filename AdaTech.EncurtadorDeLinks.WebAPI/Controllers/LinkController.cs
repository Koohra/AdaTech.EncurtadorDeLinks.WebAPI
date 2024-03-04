using AdaTech.EncurtadorDeLinks.WebAPI.Models;
using AdaTech.EncurtadorDeLinks.WebAPI.Repository;
using AdaTech.EncurtadorDeLinks.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.EncurtadorDeLinks.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly IEncurtadorLinksService _encurtadorLinksService;
        private readonly ILinkRepository _linkRepository;

        public LinkController(IEncurtadorLinksService encurtadorLinksService, ILinkRepository linkRepository)
        {
            _encurtadorLinksService = encurtadorLinksService;
            _linkRepository = linkRepository;
        }

        [HttpPost("{urlOriginal}")]
        
        public ActionResult<Link> EncurtarLink([FromRoute] string urlOriginal)
        {
            var link = new Link { UrlOriginal = urlOriginal };
            var encurtandoLink = _encurtadorLinksService.EncurtarLinks(link);
            _linkRepository.AddLink(encurtandoLink);

            return Ok(encurtandoLink);
        }

        [HttpGet("{linkCurto}")]
        public IActionResult BuscarLinkOriginal(string linkCurto)
        {        
            var link = _linkRepository.GetLink(linkCurto);

            if (link == null)
            {
                return BadRequest("Link não encontrado");
            }
            return Redirect(link.UrlOriginal);
        }
    }
}

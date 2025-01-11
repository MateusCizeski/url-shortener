using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("api/v1/url")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
    }
}

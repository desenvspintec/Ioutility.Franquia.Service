using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Api.Controllers;
using Pulsati.Core.Domain.Interfaces;

namespace Ioutility.Franquias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayNameController : BaseDisplayNameController
    {
        public DisplayNameController(IDisplayNameService displayName) : base(displayName)
        {
        }
    }
}

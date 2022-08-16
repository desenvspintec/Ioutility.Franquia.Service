using Microsoft.AspNetCore.Mvc;
using Pulsati.Core.Domain.Interfaces;

namespace Pulsati.Core.Api.Controllers
{
    public abstract class BaseDisplayNameController : ControllerBase
    {
        private readonly IDisplayNameService _displayName;

        protected BaseDisplayNameController(IDisplayNameService displayName)
        {
            _displayName = displayName;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dispayNames = _displayName.ObterTodos();
            return Ok(dispayNames);
        }
    }
}

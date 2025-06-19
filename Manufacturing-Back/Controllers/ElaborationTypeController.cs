using MF.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manufacturing_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElaborationTypeController : ControllerBase
    {
        private readonly IElaborationTypeService _elaborationTypeService;
        public ElaborationTypeController(IElaborationTypeService elaborationTypeService)
        {
            _elaborationTypeService = elaborationTypeService;
        }

        // GET: api/ElaborationType
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // This method should return a list of Elaboration Types.
            // For now, we return an empty list as a placeholder.
            return Ok( await _elaborationTypeService.GetAllAsync().ConfigureAwait(false));
        }
    }
}

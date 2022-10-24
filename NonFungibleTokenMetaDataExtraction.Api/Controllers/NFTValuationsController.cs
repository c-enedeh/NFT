using Microsoft.AspNetCore.Mvc;
using NonFungibleTokenMetaDataExtraction.Api.Model;
using NonFungibleTokenMetaDataExtraction.Api.Services;

namespace NonFungibleTokenMetaDataExtraction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFTValuationsController : ControllerBase
    {
        private readonly INonFungibleTokenValuations _nonFungibleTokenValuations;

        public NFTValuationsController(ILogger<NFTValuationsController> logger, INonFungibleTokenValuations nonFungibleTokenValuations)
        {
            _nonFungibleTokenValuations = nonFungibleTokenValuations;
        }

        [HttpPost]
        public IActionResult GetMetaData([FromBody] Request model)
        {
            var response = _nonFungibleTokenValuations.GetMetaData(model);
            return Ok(response);
        }
    }
}

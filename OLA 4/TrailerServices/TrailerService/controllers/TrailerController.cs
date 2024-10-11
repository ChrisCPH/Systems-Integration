using Microsoft.AspNetCore.Mvc;
using TrailerService.Services;

namespace TrailerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrailerController : ControllerBase
    {
        private readonly TrailerService _trailerService;

        public TrailerController(TrailerService trailerService)
        {
            _trailerService = trailerService;
        }

        [HttpPost("rent/{trailerId}")]
        public IActionResult RentTrailer(int trailerId)
        {
            var result = _trailerService.MarkTrailerAsRented(trailerId);

            if (!result)
            {
                return NotFound($"Trailer with ID {trailerId} not found or already rented.");
            }

            return Ok($"Trailer with ID {trailerId} successfully rented.");
        }

        [HttpGet("available")]
        public ActionResult GetAvailableTrailers()
        {
            var trailers = _trailerService.GetAvailableTrailers();
            return Ok(trailers);
        }
    }
}

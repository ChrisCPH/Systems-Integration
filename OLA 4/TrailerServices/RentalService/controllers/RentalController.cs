using Microsoft.AspNetCore.Mvc;
using RentalService.Models;
using RentalService.Services;

namespace RentalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly RentalService _rentalService;

        public RentalController(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("rent")]
        public ActionResult<RentalModel> RentTrailer(int trailerId, bool insurance)
        {
            var rental = _rentalService.RentTrailer(trailerId, insurance);
            return Ok(rental);
        }

        [HttpPost("return/{rentalId}")]
        public ActionResult ReturnTrailer(int rentalId)
        {
            _rentalService.ReturnTrailer(rentalId);
            return Ok();
        }
    }
}

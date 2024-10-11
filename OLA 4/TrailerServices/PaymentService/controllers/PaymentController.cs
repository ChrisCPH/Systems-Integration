using Microsoft.AspNetCore.Mvc;
using PaymentService.Services;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process/{rentalId}")]
        public ActionResult ProcessPayment(int rentalId, bool isLate, bool insurancePurchased)
        {
            _paymentService.ProcessPayment(rentalId, isLate, insurancePurchased);
            return Ok();
        }
    }
}

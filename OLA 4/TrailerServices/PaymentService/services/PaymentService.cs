using PaymentService.Data;
using PaymentService.Models;

namespace PaymentService.Services
{
    public class PaymentService
    {
        private readonly PaymentContext _context;

        public PaymentService(PaymentContext context)
        {
            _context = context;
        }

        public void ProcessPayment(int rentalId, bool isLate, bool insurancePurchased)
        {
            var lateFee = isLate ? 25m : 0m;
            var insuranceFee = insurancePurchased ? 50m : 0m;

            var payment = new PaymentModel
            {
                RentalID = rentalId,
                LateFee = lateFee,
                InsuranceFee = insuranceFee
            };

            _context.Payments.Add(payment);
            _context.SaveChanges();
        }
    }
}

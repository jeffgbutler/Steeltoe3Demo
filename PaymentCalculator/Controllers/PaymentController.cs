using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaymentCalculator.Models;
using PaymentCalculator.Services;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace PaymentCalculator.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PaymentController
    {
        private PaymentService PaymentService;
        private IHitCounterService HitCounterService;
        private CloudFoundryApplicationOptions AppOptions;

        private readonly ILogger _logger;

        public PaymentController(PaymentService paymentService,
                IHitCounterService hitCounterService,
                ILogger<PaymentController> logger,
                IOptions<CloudFoundryApplicationOptions> appOptions)
        {
            PaymentService = paymentService;
            HitCounterService = hitCounterService;
            _logger = logger;
            AppOptions = appOptions.Value;
        }

        [HttpGet]
        public ActionResult<CalculatedPayment> calculatePayment(double Amount, double Rate, int Years)
        {
            var Payment = PaymentService.Calculate(Amount, Rate, Years);

            _logger.LogDebug("Calculated payment of {Payment} for input amount: {Amount}, rate: {Rate}, years: {Years}",
                Payment, Amount, Rate, Years);

            return new CalculatedPayment
            {
                Amount = Amount,
                Rate = Rate,
                Years = Years,
                Instance = AppOptions.InstanceIndex.ToString(),
                Count = HitCounterService.GetAndIncrement(),
                Payment = Payment
            };
        }
    }
}

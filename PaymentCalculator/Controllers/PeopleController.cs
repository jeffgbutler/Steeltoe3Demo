using Microsoft.AspNetCore.Mvc;
using PaymentCalculator.Data;
using PaymentCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace PaymentCalculator.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PeopleController
    {
        public PeopleController()
        {
        }

        [HttpGet]
        public ActionResult<List<Person>> GetInventory([FromServices] SteeltoeContext context)
        {
            return context.People.ToList();
        }
    }
}

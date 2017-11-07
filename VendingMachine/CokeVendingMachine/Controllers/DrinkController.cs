using CokeVendingMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CokeVendingMachine.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DrinkController : ApiController
    {
        [Route("items/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(DrinkRepository.GetAll());
        }

        [Route("money/{amount}/item/{itemNumber}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Purchase(decimal amount, int itemNumber)
        {
            if (DrinkRepository.RequestPurchase(amount, itemNumber) == true)
            {
                if (DrinkRepository._drinks.FirstOrDefault(d => d.Id == itemNumber).Quantity > 0)
                {
                    return Ok(DrinkRepository.MakePurchase(amount, itemNumber));
                }
            }
            if (DrinkRepository._drinks.FirstOrDefault(d => d.Id == itemNumber).Quantity == 0)
            {
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)422,
                    new HttpError("SOLD OUT!!!")
                    )
                );
            }

                decimal remaining = DrinkRepository._drinks.FirstOrDefault(d => d.Id == itemNumber).Price - amount;
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)422,
                    new HttpError("Please Deposit " + remaining)
                    )
                );
            
        }
    }
}

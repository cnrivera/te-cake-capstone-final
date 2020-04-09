using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;
using SampleApi.Models.Account;
using SampleApi.Providers.Security;

namespace SampleApi.Controllers
{
    /// <summary>
    /// Creates a new order controller to save order details
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderDAO orderDao;

        
        public OrderController(IOrderDAO orderDao)
        {
            this.orderDao = orderDao;
        }

       

        /// <summary>
        /// Creates a new order in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("cakeOrder")]
        public IActionResult Create([FromBody] Order order)
        {
            bool result=false;
            if (orderDao.AddOrder(order))
            {
               result = true;
            }
            return Ok(result);


        }
    }
}
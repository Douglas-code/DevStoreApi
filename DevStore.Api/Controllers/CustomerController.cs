using DevStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DevStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get() => null;

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id) => null;

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Customer> GetOrders(Guid id) => null;

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] Customer customer) => null;

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] Customer customer) => null;

        [HttpDelete]
        [Route("customers/{id}")]
        public Customer Delete() => null;
    }
}

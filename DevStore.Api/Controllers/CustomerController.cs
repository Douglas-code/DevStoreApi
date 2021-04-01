using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;
using DevStore.Domain.StoreContext.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DevStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
           this._repository = repository;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get() => this._repository.Get();

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id) => this._repository.GetById(id);

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id) => this._repository.GetOrders(id);

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

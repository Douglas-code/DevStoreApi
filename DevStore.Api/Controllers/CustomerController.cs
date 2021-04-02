using DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs;
using DevStore.Domain.StoreContext.Commands.CustomerCommads.Outputs;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Handlers;
using DevStore.Domain.StoreContext.Queries;
using DevStore.Domain.StoreContext.Repositories;
using DevStore.Shared.Commands;
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
        private readonly CreateCustomerCommandHandler _handler;

        public CustomerController(ICustomerRepository repository, CreateCustomerCommandHandler handler)
        {
            this._repository = repository;
            this._handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return this._repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return this._repository.GetById(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return this._repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public CreateCustomerCommandResult Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)this._handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody] Customer customer) => null;

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public Customer Delete() => null;
    }
}

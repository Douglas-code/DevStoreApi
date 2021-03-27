﻿using Dapper;
using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Repositories;
using DevStore.Infra.StoreContext.DataContext;
using System.Data;
using System.Linq;

namespace DevStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DevDataContext _context;

        public CustomerRepository(DevDataContext context)
        {
            this._context = context;
        }

        public bool CheckDocument(string document)
        {
            return this._context.Connection
                .Query<bool>("spCheckDocument", new { Document = document }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return this._context.Connection
                .Query<bool>("spCheckEmail", new { Email = email }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            this._context.Connection.Execute("spCreateCustomer", new
            {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach(Address address in customer.Addresses)
            {
                this._context.Connection.Execute("spCreateAddress", new 
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

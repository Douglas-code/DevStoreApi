using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;

namespace DevStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

        IEnumerable<ListCustomerQueryResult> Get();

        GetCustomerQueryResult GetById(Guid id);

        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
    }
}

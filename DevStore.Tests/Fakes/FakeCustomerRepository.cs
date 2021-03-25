using DevStore.Domain.StoreContext.Entities;
using DevStore.Domain.StoreContext.Repositories;

namespace DevStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
           
        }
    }
}

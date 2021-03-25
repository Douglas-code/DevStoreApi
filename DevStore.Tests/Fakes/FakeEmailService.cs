using DevStore.Domain.StoreContext.Services;

namespace DevStore.Tests.Fakes
{
    class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}

using DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs;
using DevStore.Domain.StoreContext.Handlers;
using DevStore.Tests.Fakes;
using Xunit;

namespace DevStore.Tests.Handlers
{
    public class CreateCustomerCommandHandlerTests
    {
        [Fact]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            CreateCustomerCommand command = new CreateCustomerCommand();
            command.FirstName = "Douglas";
            command.LastName = "Pereira";
            command.Document = "58303366343";
            command.Email = "dg@gmail.com";
            command.Phone = "123123123";
            Assert.True(command.Validate());

            CreateCustomerCommandHandler handler = new CreateCustomerCommandHandler(new FakeCustomerRepository(), new FakeEmailService());
            Assert.True(handler.Valid);
        }
    }
}

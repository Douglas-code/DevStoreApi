using DevStore.Domain.StoreContext.Commands.CustomerCommads.Inputs;
using Xunit;

namespace DevStore.Tests.Commands
{
    public class CreateCustomerCommandTests
    {
        [Fact]
        public void ShouldValidateWhenCommandIsVAlid()
        {
            CreateCustomerCommand command = new CreateCustomerCommand();
            command.FirstName = "Douglas";
            command.LastName = "Pereira";
            command.Document = "58303366343";
            command.Email = "dg@gmail.com";
            command.Phone = "123123123";
            Assert.True(command.Validate());
        }
    }
}

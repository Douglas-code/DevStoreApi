using DevStore.Shared.Commands;

namespace DevStore.Shared.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}

namespace ECommerce.Commands
{
    public interface ICommand
    {
        string _commandStr { get; set; }
        void Validate();
        void Run();
    }
}

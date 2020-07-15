namespace ECommerce.Commands
{
    public interface ICommand
    {
        string CommandStr { get; set; }
        void Validate();
        void Run();
    }
}

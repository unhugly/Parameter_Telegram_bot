using System.Threading.Tasks;

namespace TelegramBot_for_parameter
{
    internal interface ICommand
    {
        Task ExecuteAsync(long chatId);
    }
}

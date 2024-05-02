using System.Threading.Tasks;
using TelegramBot_for_parameter.Commands;

namespace TelegramBot_for_parameter
{
    internal interface ICommand
    {
        CommandState State { get; set; }
        Task ExecuteAsync(long chatId);
        Task<bool> ContinueExecuteAsync(string message, long chatId);
        void Reset();
    }

}

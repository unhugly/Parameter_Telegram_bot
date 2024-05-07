using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot_for_parameter.Commands
{
    public enum CommandState { Initial, AwaitingInput, Completed }

    internal abstract class Command : ICommand
    {
        protected ITelegramBotClient _client;
        public CommandState State { get; set; }

        protected Command(ITelegramBotClient botClient)
        {
            _client = botClient;
            State = CommandState.Initial;
        }

        public abstract Task ExecuteAsync(long chatId);
        public abstract Task<bool> ContinueExecuteAsync(string message, long chatId);
        public virtual void Reset()
        {
            State = CommandState.Initial;
        }
    }
}

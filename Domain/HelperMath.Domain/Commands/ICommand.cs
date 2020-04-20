using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HelperMath.Domain.Commands
{
    public interface ICommand
    {
        bool Contains(string messageName);
        Task Execute(Message message, ITelegramBotClient client);
    }
}

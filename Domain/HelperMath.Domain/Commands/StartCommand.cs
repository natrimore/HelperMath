using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HelperMath.Domain.Commands
{
    public class StartCommand : ICommand
    {
        private readonly string _meesageName = @"/start";
        public bool Contains(string messageName)
        {
            return messageName.Contains(_meesageName);
        }

        public async Task Execute(Message message, ITelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Xush kelibsiz. Hisoblashga qiynalyapsizmi ? marhamat... ))", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, null);
        }
    }
}
